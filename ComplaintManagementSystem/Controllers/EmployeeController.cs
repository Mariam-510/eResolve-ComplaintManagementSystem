using ComplaintManagementSystem.Context;
using ComplaintManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ComplaintManagementSystem.Controllers
{
    public class EmployeeController
    {
        private readonly ComplaintSystemContext _context;

        public EmployeeController(ComplaintSystemContext context)
        {
            _context = context;
        }


        // Get all employees - admins with related entities
        public List<Employee> GetFilteredEmployees(int? cityId = null, int? departmentId = null, string? role = null)
        {
            var employees = _context.Employees
                .Where(e => !e.IsDeleted)
                .Include(e => e.City)
                .Include(e => e.Department)
                .Include(e => e.Account)
                .AsQueryable();

            // Filter by City if cityId is provided
            if (cityId.HasValue)
            {
                employees = employees.Where(e => e.CityId == cityId);
            }

            // Filter by Department if departmentId is provided
            if (departmentId.HasValue)
            {
                employees = employees.Where(e => e.DepartmentId == departmentId);
            }

            // Filter by Role if provided
            if (!string.IsNullOrEmpty(role))
            {
                var normalizedRole = role.ToLower(); // Normalize the input
                employees = employees.Where(e => e.Account.Role.ToLower() == normalizedRole);
            }

            return employees.ToList();
        }

        // Get employee by ID with related entities
        public Employee GetEmployeeById(int id)
        {
            var employee = _context.Employees
                .Where(e => !e.IsDeleted)
                .Include(e => e.City)
                .Include(e => e.Department)
                .Include(e => e.Account)
                .FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found.");
            }

            return employee;
        }

        // Get employee by AccountId
        public Employee GetEmployeeByAccountId(int accountId)
        {
            var employee = _context.Employees
                .Where(e => !e.IsDeleted)
                .Include(e => e.City)
                .Include(e => e.Department)
                .Include(e => e.Account)
                .FirstOrDefault(e => e.AccountId == accountId);

            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found.");
            }

            return employee;
        }

        // Get employees by name with related entities
        public List<Employee> GetEmployeesByName(string name)
        {
            return _context.Employees
                .Where(e => !e.IsDeleted)
                .Include(e => e.City)
                .Include(e => e.Department)
                .Include(e => e.Account)
                .Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Get all complaints assigned to a specific employee
        public List<Complaint> GetAllComplaintsForEmployee(int employeeId, string? status = null, string orderBySubmissionDate = "A")
        {
            var employee = _context.Employees.Where(e => !e.IsDeleted).FirstOrDefault(e => e.Id == employeeId);

            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found.");
            }

            // Start with all complaints
            var complaints = _context.Complaints
                .Where(c => !c.IsDeleted && c.AssignedEmployeeId == employeeId)
                .Include(c => c.City)
                .Include(c => c.Department)
                .Include(c => c.Citizen)
                .AsQueryable();

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

        // Add a new employee
        public void AddEmployee(Employee employee)
        {
            if (_context.Employees.Any(e => e.PhoneNumber == employee.PhoneNumber))
            {
                throw new InvalidOperationException("An employee with the same phone number already exists.");
            }

            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        // Update employee details
        public void UpdateEmployee(int employeeId, Employee updatedEmployee)
        {
            var employee = _context.Employees.Where(e => !e.IsDeleted).FirstOrDefault(e => e.Id == employeeId);

            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found.");
            }

            employee.Name = updatedEmployee.Name;
            employee.Salary = updatedEmployee.Salary;
            employee.PhoneNumber = updatedEmployee.PhoneNumber;
            employee.DateOfBirth = updatedEmployee.DateOfBirth;
            employee.CityId = updatedEmployee.CityId;
            employee.DepartmentId = updatedEmployee.DepartmentId;

            _context.SaveChanges();
        }

        // Delete employee
        public void DeleteEmployee(int employeeId)
        {
            var employee = _context.Employees.Where(e => !e.IsDeleted).FirstOrDefault(e => e.Id == employeeId);

            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found.");
            }

            employee.IsDeleted = true;

            _context.SaveChanges();
        }


    }
}
