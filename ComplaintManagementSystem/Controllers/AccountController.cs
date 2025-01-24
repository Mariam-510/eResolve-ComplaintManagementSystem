using ComplaintManagementSystem.Context;
using ComplaintManagementSystem.Models;
using Microsoft.Identity.Client;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ComplaintManagementSystem.Controllers
{
    public class AccountController
    {
        private readonly ComplaintSystemContext _context;

        public AccountController(ComplaintSystemContext context)
        {
            _context = context;
        }

        // Register a new account
        public void Register(string username, string password, string role)
        {
            if (!IsPasswordValid(password))
            {
                throw new ArgumentException("Password must be 6-10 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.");
            }

            if (_context.Accounts.Where(a => !a.IsDeleted).Any(a => a.Username == username))
            {
                throw new InvalidOperationException("Username already exists.");
            }

            var account = new Account
            {
                Username = username,
                PasswordHash = HashPassword(password),
                Role = role
            };

            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        // Login method
        public Account Login(string username, string password)
        {
            var account = _context.Accounts.Where(a => !a.IsDeleted).FirstOrDefault(a => a.Username == username);

            if (account == null || !VerifyPassword(password, account.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            return account;
        }

        // Update password
        public void UpdatePassword(int accountId, string currentPassword, string newPassword)
        {
            var account = _context.Accounts.Where(a => !a.IsDeleted).FirstOrDefault(a => a.Id == accountId);

            if (account == null)
            {
                throw new KeyNotFoundException("Account not found.");
            }

            if (!VerifyPassword(currentPassword, account.PasswordHash))
            {
                throw new UnauthorizedAccessException("Current password is incorrect.");
            }

            if (!IsPasswordValid(newPassword))
            {
                throw new ArgumentException("Password must be 6-10 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.");
            }

            account.PasswordHash = HashPassword(newPassword);
            _context.SaveChanges();
        }

        // Delete account
        public void DeleteAccount(int accountId)
        {
            var account = _context.Accounts.Where(a => !a.IsDeleted).FirstOrDefault(a => a.Id == accountId);

            if (account == null)
            {
                throw new KeyNotFoundException("Account not found.");
            }
            
            account.IsDeleted = true;

            _context.SaveChanges();
        }

        // Get account by Id
        public Account GetAccountById(int accountId)
        {
            var account = _context.Accounts.Where(a => !a.IsDeleted).FirstOrDefault(a => a.Id == accountId);
            if (account == null)
            {
                throw new KeyNotFoundException("Account not found.");
            }
            return account;
        }

        // Get account by Username
        public Account GetAccountByUsername(string username)
        {
            var account = _context.Accounts.Where(a => !a.IsDeleted).FirstOrDefault(a => a.Username == username);
            if (account == null)
            {
                throw new KeyNotFoundException("Account not found.");
            }
            return account;
        }

        // Validate password
        private bool IsPasswordValid(string password)
        {
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{6,10}$");

            return regex.IsMatch(password);
        }

        // Hash password
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        // Verify password
        private bool VerifyPassword(string password, string passwordHash)
        {
            var hashedInput = HashPassword(password);
            return hashedInput == passwordHash;
        }
    
    }
}
