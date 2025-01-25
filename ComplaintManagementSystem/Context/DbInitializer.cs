using ComplaintManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ComplaintManagementSystem.Context
{
    public static class DbInitializer
    {
        //Seed Cities
        public static void SeedCities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Alexandria" },
                new City { Id = 2, Name = "Aswan" },
                new City { Id = 3, Name = "Asyut" },
                new City { Id = 4, Name = "Beheira" },
                new City { Id = 5, Name = "Beni Suef" },
                new City { Id = 6, Name = "Cairo" },
                new City { Id = 7, Name = "Dakahlia" },
                new City { Id = 8, Name = "Damietta" },
                new City { Id = 9, Name = "Faiyum" },
                new City { Id = 10, Name = "Gharbia" },
                new City { Id = 11, Name = "Giza" },
                new City { Id = 12, Name = "Ismailia" },
                new City { Id = 13, Name = "Kafr El-Sheikh" },
                new City { Id = 14, Name = "Luxor" },
                new City { Id = 15, Name = "Marsa Matruh" },
                new City { Id = 16, Name = "Minya" },
                new City { Id = 17, Name = "Monufia" },
                new City { Id = 18, Name = "New Valley" },
                new City { Id = 19, Name = "North Sinai" },
                new City { Id = 20, Name = "Port Said" },
                new City { Id = 21, Name = "Qalyubia" },
                new City { Id = 22, Name = "Qena" },
                new City { Id = 23, Name = "Red Sea" },
                new City { Id = 24, Name = "Sharqia" },
                new City { Id = 25, Name = "Sohag" },
                new City { Id = 26, Name = "South Sinai" },
                new City { Id = 27, Name = "Suez" }
            );
        }

        //Seed Departments
        public static void SeedDepartments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Water" },
                new Department { Id = 2, Name = "Electricity" },
                new Department { Id = 3, Name = "Road" },
                new Department { Id = 4, Name = "Sanitation" },
                new Department { Id = 5, Name = "Telecommunication" },
                new Department { Id = 6, Name = "Transport" }

            );
        }

        //Seed Admin Employee
        public static void SeedAdminEmployee(ModelBuilder modelBuilder)
        {
            // Seed Admin Account
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = 1,
                    Username = "Mariam",
                    PasswordHash = HashPassword("Mariam@123"),
                    Role = "Admin",
                    CreatedAt = new DateTime(2025, 1, 20, 9, 50, 0),
                });

            // Seed Admin Employee
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Mariam Ashraf",
                    Salary = 10000.00m,
                    PhoneNumber = "01144456820",
                    DateOfBirth = new DateTime(2002, 10, 5),
                    CityId = 6,
                    AccountId = 1,
                    DepartmentId = null
                });


        }

        //Seed Admin Employee
        public static void SeedEmployee(ModelBuilder modelBuilder)
        {
            // Seed Admin Account
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = 2,
                    Username = "Hoda",
                    PasswordHash = HashPassword("Hoda@123"),
                    Role = "Employee",
                    CreatedAt = new DateTime(2025, 1, 20, 9, 50, 0),
                });

            // Seed Admin Employee
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 2,
                    Name = "Hoda",
                    Salary = 5000.00m,
                    PhoneNumber = "01144890255",
                    DateOfBirth = new DateTime(2001, 7, 7),
                    CityId = 3,
                    AccountId = 2,
                    DepartmentId = 2
                });
        }

        //HashPassword
        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }


    }
}