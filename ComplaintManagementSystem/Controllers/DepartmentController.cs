using ComplaintManagementSystem.Context;
using ComplaintManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComplaintManagementSystem.Controllers
{
    public class DepartmentController
    {
        private readonly ComplaintSystemContext _context;

        public DepartmentController(ComplaintSystemContext context)
        {
            _context = context;
        }

        // Get all departments
        public List<Department> GetAllDepartments()
        {
            return _context.Departments.Where(d => !d.IsDeleted).OrderBy(d => d.Name).ToList();
        }

        // Get department by Id
        public Department GetDepartmentById(int departmentId)
        {
            var department = _context.Departments.Where(d => !d.IsDeleted).FirstOrDefault(d => d.Id == departmentId);

            if (department == null)
            {
                throw new KeyNotFoundException("Department not found.");
            }

            return department;
        }

        // Get department by Name
        public Department GetDepartmentByName(string departmentName)
        {
            var department = _context.Departments.Where(d => !d.IsDeleted).FirstOrDefault(d => d.Name.Equals(departmentName, StringComparison.OrdinalIgnoreCase));

            if (department == null)
            {
                throw new KeyNotFoundException("Department not found.");
            }

            return department;
        }

        // Add a new department
        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        // Update existing department
        public void UpdateDepartment(int oldDepartmentId, Department newDepartment)
        {
            if (_context.Departments.Where(d => !d.IsDeleted).Any(d => d.Name == newDepartment.Name && d.Id != oldDepartmentId))
            {
                throw new InvalidOperationException("Department name must be unique.");
            }

            var department = _context.Departments.Where(d => !d.IsDeleted).FirstOrDefault(d => d.Id == oldDepartmentId);

            if (department != null)
            {
                department.Name = newDepartment.Name;
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Department not found.");
            }
        }

        // Remove a department
        public void RemoveDepartment(int departmentId)
        {
            var department = _context.Departments.Where(d => !d.IsDeleted).FirstOrDefault(d => d.Id == departmentId);
            if (department != null)
            {
                department.IsDeleted = true;

                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Department not found.");
            }
        }

    }
}
