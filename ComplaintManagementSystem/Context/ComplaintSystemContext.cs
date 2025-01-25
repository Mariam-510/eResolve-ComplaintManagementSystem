using ComplaintManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintManagementSystem.Context
{
    public class ComplaintSystemContext : DbContext
    {
        #region DbSets
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<City> Cities { get; set; }
        #endregion

        #region OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-SKHKQAE;Initial Catalog=ComplaintSystem;Integrated Security=True;Encrypt=False");
        }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Employee Constraint
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable(tb =>
                {
                    //Add check constraint for Salary > 0
                    tb.HasCheckConstraint("CK_Employee_Salary", "[Salary] > 0");

                    //Add check constraint for Age between 18 and 60
                    tb.HasCheckConstraint("CK_Employee_DateOfBirth", "DATEDIFF(YEAR, [DateOfBirth], GETDATE()) BETWEEN 18 AND 60");

                    // Add check constraint for PhoneNumber length (11 to 15 characters)
                    tb.HasCheckConstraint("CK_Employee_PhoneNumber_Length", "LEN([PhoneNumber]) BETWEEN 11 AND 15");
                });
                
                //Emp Salary 
                entity.Property(e => e.Salary)
                        .HasColumnType("decimal(18,2)");

                // Emp AccountId Unique
                entity.HasIndex(e => e.AccountId).IsUnique();
            });
            #endregion

            #region Citizen Constraint
            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.ToTable(tb =>
                {
                    // Add check constraint for PhoneNumber length (11 to 15 characters)
                    tb.HasCheckConstraint("CK_Citizen_PhoneNumber_Length", "LEN([PhoneNumber]) BETWEEN 11 AND 15");
                });
                
                // Citizen AccountId Unique
                entity.HasIndex(c => c.AccountId).IsUnique();
            });
            #endregion

            #region Complaint Constraint
            modelBuilder.Entity<Complaint>(entity =>
            {
                entity.ToTable(tb =>
                {
                    // Add check constraint for Status
                    tb.HasCheckConstraint("CK_Complaint_Status", "[Status] IN ('Pending', 'In Progress', 'Resolved')");

                    // Add check constraint for PhoneNumber length (11 to 15 characters)
                    tb.HasCheckConstraint("CK_Complaint_PhoneNumber_Length", "LEN([PhoneNumber]) BETWEEN 11 AND 15");
                });
            });
            #endregion

            #region Account Constraint
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable(tb =>
                {
                    tb.HasCheckConstraint("CK_Account_Role", "[Role] IN ('Citizen', 'Admin', 'Employee')");

                });
            }); 
            #endregion

            #region Seed Cities
            DbInitializer.SeedCities(modelBuilder);
            #endregion

            #region Seed Departments
            DbInitializer.SeedDepartments(modelBuilder);
            #endregion

            #region Seed Admin Employee
            DbInitializer.SeedAdminEmployee(modelBuilder);
            #endregion

            #region Seed Employee
            DbInitializer.SeedEmployee(modelBuilder);
            #endregion


        }
        #endregion


    }
}
