using ComplaintManagementSystem.Context;
using ComplaintManagementSystem.Controllers;
using ComplaintManagementSystem.DTO;
using ComplaintManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComplaintManagementSystem.DTO;
using System.Diagnostics;
using ComplaintManagementSystem.Forms.LoginAndSignUpForms;

namespace ComplaintManagementSystem.Forms.EmployeeForms
{
    public partial class ComplaintsEmpForm : Form
    {
        private readonly ComplaintSystemContext _context;

        private int _empId;

        EmployeeController employeeController;
        ComplaintController complaintController;

        bool sFlag = true, oFlag = true;

        #region Ctor
        public ComplaintsEmpForm(ComplaintSystemContext context, int empId)
        {
            InitializeComponent();
            _context = context;
            _empId = empId;
            employeeController = new EmployeeController(_context);
            complaintController = new ComplaintController(_context);
            this.FormClosing += ExitFormClosing;
        }
        #endregion

        #region Closing Event
        private void ExitFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Form Load
        private void ComplaintsEmpForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _emp = employeeController.GetEmployeeById(_empId);
                labelUserName.Text = "Welcome " + _emp.Account.Username;

                var statusListFiltered = new List<string>() { "All", "Pending", "In Progress", "Resolved" };
                comboBoxStatusFilter.DataSource = statusListFiltered;

                var submissionDateListFiltered = new List<string>() { "Newer to Older", "Older to Newer" };
                comboBoxSubmissionDate.DataSource = submissionDateListFiltered;

                sFlag = false; oFlag = false;
                RefreshComplaintList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading complaints: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Selected Index Changed
        private void comboBoxStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshComplaintList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading complaints: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxSubmissionDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshComplaintList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading complaints: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region InitializeDataGridView
        private void InitializeDataGridView()
        {
            dataGridViewComplaint.AutoGenerateColumns = true; // Automatically generate columns

            // Ensure the DataGridView is editable
            dataGridViewComplaint.ReadOnly = false;
            dataGridViewComplaint.AllowUserToAddRows = false;

            if (!dataGridViewComplaint.Columns.Contains("EditButton"))
            {
                // Add Edit Button
                var editButtonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Edit",
                    Name = "EditButton",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewComplaint.Columns.Add(editButtonColumn);
            }
        }
        #endregion

        #region Cell Click
        private void dataGridViewComplaint_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header row

            var complaintId = Convert.ToInt32(dataGridViewComplaint.Rows[e.RowIndex].Cells["Id"].Value);

            if (dataGridViewComplaint.Columns[e.ColumnIndex].Name == "EditButton")
            {
                // Handle Edit Button Click
                EditComplaint(complaintId);
            }
        }
        #endregion

        #region Edit Complaint
        private void EditComplaint(int complaintId)
        {
            try
            {
                // Get the row being edited
                var row = dataGridViewComplaint.Rows
                    .Cast<DataGridViewRow>()
                    .FirstOrDefault(r => Convert.ToInt32(r.Cells["Id"].Value) == complaintId);

                if (row == null) return;

                //var oldstatus = complaintController.GetComplaintById(complaintId).Status;
                //if (oldstatus == "Resolved")
                //{
                //    MessageBox.Show("This complaint cannot be edited because its status is 'Resolved'.", "Edit Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                var newStatus = row.Cells["Status"].Value.ToString();

                // Update the complaint in the database
                complaintController.UpdateComplaintStatus(complaintId, newStatus);

                MessageBox.Show("Complaint updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh the DataGridView
                RefreshComplaintList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating complaint: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region RefreshComplaintList
        private void RefreshComplaintList()
        {
            if (sFlag || oFlag)
                return;

            var statusFiltered = comboBoxStatusFilter.SelectedValue.ToString() == "All" ? "" : comboBoxStatusFilter.SelectedValue.ToString();
            var submissionDatEFiltered = comboBoxSubmissionDate.SelectedIndex == 0 ? "D" : "A";

            var complaints = employeeController.GetAllComplaintsForEmployee(_empId, statusFiltered, submissionDatEFiltered);

            // Map complaints to ComplaintViewModel
            var complaintViewModels = complaints.Select(c => new complaintViewModels
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                StatusTxt = c.Status,
                CitizenName = c.Citizen.Name,
                PhoneNumber = c.PhoneNumber,
                CityName = c.City.Name,
                DepartmentName = c.Department.Name,
                Address = c.Address,
                SubmissionDate = c.SubmissionDate,
                ResolutionDate = c.ResolutionDate
            }).ToList();

            dataGridViewComplaint.DataSource = complaintViewModels;

            // Remove the existing "Status" column if it exists
            if (!dataGridViewComplaint.Columns.Contains("Status"))
            {
                // Add a combo box column for "Status"
                var statusList = new List<string>() { "Pending", "In Progress", "Resolved" };
                DataGridViewComboBoxColumn statusComboBoxColumn = new DataGridViewComboBoxColumn
                {
                    HeaderText = "Status",
                    Name = "Status",
                    DataSource = statusList,
                    DataPropertyName = "StatusTxt",
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                };
                dataGridViewComplaint.Columns.Add(statusComboBoxColumn);
            }

            // Make other columns read-only
            dataGridViewComplaint.Columns["Title"].ReadOnly = true;
            dataGridViewComplaint.Columns["Description"].ReadOnly = true;
            dataGridViewComplaint.Columns["PhoneNumber"].ReadOnly = true;
            dataGridViewComplaint.Columns["CityName"].ReadOnly = true;
            dataGridViewComplaint.Columns["DepartmentName"].ReadOnly = true;
            dataGridViewComplaint.Columns["Address"].ReadOnly = true;
            dataGridViewComplaint.Columns["SubmissionDate"].ReadOnly = true;
            dataGridViewComplaint.Columns["ResolutionDate"].ReadOnly = true;

            // Hide unnecessary columns
            dataGridViewComplaint.Columns["Id"].Visible = false;
            dataGridViewComplaint.Columns["StatusTxt"].Visible = false;

            // Initialize the DataGridView's other settings
            InitializeDataGridView();
        }
        #endregion

        #region HomePage Button
        private void butHomePage_Click(object sender, EventArgs e)
        {

            HomePageEmployeeForm homePage = new HomePageEmployeeForm(_context, _empId);
            this.Hide();
            homePage.Show();
        }
        #endregion

        #region Profile Button
        private void butEditProfile_Click(object sender, EventArgs e)
        {
            ProfileEmpForm profileForm = new ProfileEmpForm(_context, _empId);
            this.Hide();
            profileForm.Show();
        }
        #endregion

        #region Complaints Buuton
        private void butComplaints_Click(object sender, EventArgs e)
        {

            ComplaintsEmpForm complaintsEmpForm = new ComplaintsEmpForm(_context, _empId);
            this.Hide();
            complaintsEmpForm.Show();
        }
        #endregion

        #region Logout Button
        private void butLogout_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            this.Hide();
            welcomeForm.Show();
        }
        private void pictureBox15_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            this.Hide();
            welcomeForm.Show();
        }
        #endregion

    }
}
