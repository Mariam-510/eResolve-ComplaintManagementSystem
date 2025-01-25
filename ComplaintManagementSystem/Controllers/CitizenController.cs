using ComplaintManagementSystem.Context;
using ComplaintManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComplaintManagementSystem.Controllers
{
    public class CitizenController
    {
        private readonly ComplaintSystemContext _context;

        public CitizenController(ComplaintSystemContext context)
        {
            _context = context;
        }

        // Get all citizens
        public List<Citizen> GetAllCitizens()
        {
            return _context.Citizens.Where(c => !c.IsDeleted)
                .Include(c => c.Account)
                .ToList();
        }

        // Get a citizen by ID
        public Citizen GetCitizenById(int citizenId)
        {
            var citizen = _context.Citizens
                .Where(c => !c.IsDeleted)
                .Include(c => c.Account)
                .FirstOrDefault(c => c.Id == citizenId);

            if (citizen == null)
            {
                throw new KeyNotFoundException("Citizen not found.");
            }

            return citizen;
        }

        // Get a citizen by AccountId
        public Citizen GetCitizenByAccountId(int accountId)
        {
            var citizen = _context.Citizens
                 .Where(c => !c.IsDeleted)
                .Include(c => c.Account)
                .FirstOrDefault(c => c.AccountId == accountId);

            if (citizen == null)
            {
                throw new KeyNotFoundException("Citizen with the specified AccountId not found.");
            }

            return citizen;
        }

        // Get complaints for a specific citizen with filtering and sorting
        public List<Complaint> GetComplaintsForCitizenFiltered(int citizenId, string status = null, string orderBySubmissionDate = "A")
        {
            var citizen = _context.Citizens.Where(c => !c.IsDeleted).FirstOrDefault(c => c.Id == citizenId);

            if (citizen == null)
            {
                throw new KeyNotFoundException("Citizen not found.");
            }

            var complaints = _context.Complaints
                .Where(c => !c.IsDeleted && c.CitizenId == citizenId).AsQueryable();


            // Filter by status if provided
            if (!string.IsNullOrEmpty(status))
            {
                var normalizedStatus = status.ToLower(); // Normalize the input
                complaints = complaints.Where(c => c.Status.ToLower() == normalizedStatus);
            }

            // Order by SubmissionDate
            if (orderBySubmissionDate.Equals("D", StringComparison.OrdinalIgnoreCase))
            {
                complaints = complaints.OrderByDescending(c => c.SubmissionDate);
            }
            else
            {
                complaints = complaints.OrderBy(c => c.SubmissionDate);
            }

            return complaints.ToList();
        }

        // Add a new citizen
        public void AddCitizen(Citizen citizen)
        {
            // Optional: Check if the citizen's AccountId already exists
            if (_context.Citizens.Where(c => !c.IsDeleted).Any(c => c.AccountId == citizen.AccountId))
            {
                throw new InvalidOperationException("Citizen with the same AccountId already exists.");
            }

            _context.Citizens.Add(citizen);
            _context.SaveChanges();
        }

        // Update an existing citizen
        public void UpdateCitizen(int citizenId, Citizen updatedCitizen)
        {
            var citizen = _context.Citizens.Where(c => !c.IsDeleted).FirstOrDefault(c => c.Id == citizenId);

            if (citizen == null)
            {
                throw new KeyNotFoundException("Citizen not found.");
            }

            citizen.Name = updatedCitizen.Name;
            citizen.PhoneNumber = updatedCitizen.PhoneNumber;

            _context.SaveChanges();
        }

        // Delete a citizen
        public void DeleteCitizen(int citizenId)
        {
            var citizen = _context.Citizens.Where(c => !c.IsDeleted).FirstOrDefault(c => c.Id == citizenId);

            if (citizen == null)
            {
                throw new KeyNotFoundException("Citizen not found.");
            }

            citizen.IsDeleted = true;

            _context.SaveChanges();
        }

    }
}
