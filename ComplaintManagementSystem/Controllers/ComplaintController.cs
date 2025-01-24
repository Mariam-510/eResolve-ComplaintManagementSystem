using ComplaintManagementSystem.Context;
using ComplaintManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComplaintManagementSystem.Controllers
{
    public class ComplaintController
    {
        private readonly ComplaintSystemContext _context;

        public ComplaintController(ComplaintSystemContext context)
        {
            _context = context;
        }

        // Get all complaints with related entities
        public List<Complaint> GetAllComplaints(string status = null, string orderBySubmissionDate = "A", int? cityId = null, int? departmentId = null)
        {
            var complaints = _context.Complaints
                .Where(c => !c.IsDeleted)
                .Include(c => c.City)
                .Include(c => c.Department)
                .Include(c => c.Citizen)
                .Include(c => c.AssignedEmployee)
                .AsQueryable();

            // Filter by status if provided
            if (!string.IsNullOrEmpty(status))
            {
                var normalizedStatus = status.ToLower(); // Normalize the input
                complaints = complaints.Where(c => c.Status.ToLower() == normalizedStatus);
            }

            // Filter by City if cityId is provided
            if (cityId.HasValue)
            {
                complaints = complaints.Where(c => c.CityId == cityId);
            }

            // Filter by Department if departmentId is provided
            if (departmentId.HasValue)
            {
                complaints = complaints.Where(c => c.DepartmentId == departmentId);
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

        // Get complaint by ID with related entities
        public Complaint GetComplaintById(int id)
        {
            var complaint = _context.Complaints
                .Where(c => !c.IsDeleted)
                .Include(c => c.City)
                .Include(c => c.Department)
                .Include(c => c.Citizen)
                .Include(c => c.AssignedEmployee)
                .FirstOrDefault(c => c.Id == id);

            if (complaint == null)
            {
                throw new KeyNotFoundException("Complaint not found.");
            }

            return complaint;
        }

        // Add a new complaint
        public void AddComplaint(Complaint complaint)
        {
            complaint.SubmissionDate = DateTime.Now; // Ensure submission date is set
            _context.Complaints.Add(complaint);
            _context.SaveChanges();
        }

        // Update complaint details
        public void UpdateComplaint(int complaintId, Complaint updatedComplaint)
        {
            var complaint = _context.Complaints.Where(c => !c.IsDeleted).FirstOrDefault(c => c.Id == complaintId);

            if (complaint == null)
            {
                throw new KeyNotFoundException("Complaint not found.");
            }

            complaint.Title = updatedComplaint.Title;
            complaint.Description = updatedComplaint.Description;
            complaint.PhoneNumber = updatedComplaint.PhoneNumber;
            complaint.Address = updatedComplaint.Address;
            complaint.CityId = updatedComplaint.CityId;
            complaint.DepartmentId = updatedComplaint.DepartmentId;

            _context.SaveChanges();
        }

        // Update complaint status
        public void UpdateComplaintStatus(int complaintId, string newStatus)
        {
            var complaint = _context.Complaints.Where(c => !c.IsDeleted).FirstOrDefault(c => c.Id == complaintId);

            if (complaint == null)
            {
                throw new KeyNotFoundException("Complaint not found.");
            }

            complaint.Status = newStatus;

            // If the status is "Resolved", set the ResolutionDate
            if (newStatus.Equals("Resolved", StringComparison.OrdinalIgnoreCase))
            {
                complaint.ResolutionDate = DateTime.Now;
            }

            _context.SaveChanges();
        }

        // Update complaint employee
        public void UpdateAssignedEmployee(int complaintId, int employeeId)
        {
            var complaint = _context.Complaints.Where(c => !c.IsDeleted).FirstOrDefault(c => c.Id == complaintId);

            if (complaint == null)
            {
                throw new KeyNotFoundException("Complaint not found.");
            }

            var employee = _context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found.");
            }

            complaint.AssignedEmployeeId = employeeId;

            _context.SaveChanges();
        }

        // Delete a complaint
        public void DeleteComplaint(int complaintId)
        {
            var complaint = _context.Complaints.Where(c => !c.IsDeleted).FirstOrDefault(c => c.Id == complaintId);

            if (complaint == null)
            {
                throw new KeyNotFoundException("Complaint not found.");
            }

            complaint.IsDeleted = true;

            _context.SaveChanges();
        }
    }
}
