using ComplaintManagementSystem.Context;
using ComplaintManagementSystem.Controllers;
using ComplaintManagementSystem.Forms.LoginAndSignUpForms;
using ComplaintManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ComplaintManagementSystem.Forms.CitizenForms
{
    public partial class TrackComplaintsForm : Form
    {
        private readonly ComplaintSystemContext _context;

        private int _citizenId;
        CitizenController citizenController;
        ComplaintController complaintController;
        CityController cityController;
        DepartmentController departmentController;

        bool sFlag = true, oFlag = true;


        #region Ctor
        public TrackComplaintsForm(ComplaintSystemContext context, int citizenId)
        {
            InitializeComponent();
            _context = context;
            _citizenId = citizenId;
            citizenController = new CitizenController(_context);
            complaintController = new ComplaintController(_context);
            cityController = new CityController(_context);
            departmentController = new DepartmentController(_context);
            this.FormClosing += ExitFormClosing;
            dataGridViewComplaint.CellClick += trackComplaintsGridView_CellClick;
        }
        #endregion

        #region Closing Event
        private void ExitFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Form Load
        private void TrackComplaintsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _citizen = citizenController.GetCitizenById(_citizenId);
                labelUserName.Text = "Welcome " + _citizen.Account.Username;

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

            if (!dataGridViewComplaint.Columns.Contains("DeleteButton"))
            {
                // Add Delete Button
                var deleteButtonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Delete",
                    Name = "DeleteButton",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewComplaint.Columns.Add(deleteButtonColumn);
            }
        }
        #endregion

        #region Cell Click
        private void trackComplaintsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header row

            var complaintId = Convert.ToInt32(dataGridViewComplaint.Rows[e.RowIndex].Cells["Id"].Value);

            if (dataGridViewComplaint.Columns[e.ColumnIndex].Name == "EditButton")
            {
                // Handle Edit Button Click
                EditComplaint(complaintId);
            }
            else if (dataGridViewComplaint.Columns[e.ColumnIndex].Name == "DeleteButton")
            {
                // Handle Delete Button Click
                DeleteComplaint(complaintId);
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

                string status = row.Cells["Status"].Value?.ToString();
                if (status != "Pending")
                {
                    MessageBox.Show("This complaint cannot be edited because its status is not 'Pending'.", "Edit Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate the row data
                if (!ValidateComplaintRow(row)) return;

                // Create an updated complaint object from the edited row
                var updatedComplaint = new Complaint
                {
                    Id = complaintId,
                    DepartmentId = (int)row.Cells["DepartmentId"].Value,
                    Title = row.Cells["Title"].Value.ToString(),
                    Description = row.Cells["Description"].Value != null ? row.Cells["Description"].Value.ToString() : null,
                    PhoneNumber = row.Cells["PhoneNumber"].Value.ToString(),
                    CityId = (int)row.Cells["CityId"].Value,
                    Address = row.Cells["Address"].Value.ToString(),
                };

                // Update the complaint in the database
                complaintController.UpdateComplaint(complaintId, updatedComplaint);

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

        #region ValidateComplaintRow
        private bool ValidateComplaintRow(DataGridViewRow row)
        {
            // Example validation: Ensure required fields are not null or empty
            if (string.IsNullOrEmpty(row.Cells["Title"].Value?.ToString()) ||
                string.IsNullOrEmpty(row.Cells["PhoneNumber"].Value?.ToString()))
            {
                MessageBox.Show("Title and PhoneNumber cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        #endregion

        #region Delete Complaint
        private void DeleteComplaint(int complaintId)
        {
            var result = MessageBox.Show("Are you sure you want to delete this complaint?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Get the row being edited
                    var row = dataGridViewComplaint.Rows
                        .Cast<DataGridViewRow>()
                        .FirstOrDefault(r => Convert.ToInt32(r.Cells["Id"].Value) == complaintId);

                    if (row == null) return;

                    string status = row.Cells["Status"].Value?.ToString();
                    if (status != "Pending")
                    {
                        MessageBox.Show("This complaint cannot be deleted because its status is not 'Pending'.", "Delete Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    complaintController.DeleteComplaint(complaintId);
                    MessageBox.Show("Complaint deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the DataGridView after deletion
                    RefreshComplaintList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting complaint: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

            var complaints = citizenController.GetComplaintsForCitizenFiltered(_citizenId, statusFiltered, submissionDatEFiltered);

            // Set the data source for the DataGridView
            dataGridViewComplaint.DataSource = complaints;

            // Make certain columns read-only
            dataGridViewComplaint.Columns["Status"].ReadOnly = true;
            dataGridViewComplaint.Columns["SubmissionDate"].ReadOnly = true;
            dataGridViewComplaint.Columns["ResolutionDate"].ReadOnly = true;

            // Hide some unnecessary columns
            dataGridViewComplaint.Columns["Id"].Visible = false;
            dataGridViewComplaint.Columns["CityId"].Visible = false;
            dataGridViewComplaint.Columns["DepartmentId"].Visible = false;
            dataGridViewComplaint.Columns["IsDeleted"].Visible = false;
            dataGridViewComplaint.Columns["CitizenId"].Visible = false;
            dataGridViewComplaint.Columns["AssignedEmployeeId"].Visible = false;
            dataGridViewComplaint.Columns["City"].Visible = false;
            dataGridViewComplaint.Columns["Department"].Visible = false;
            dataGridViewComplaint.Columns["Citizen"].Visible = false;
            dataGridViewComplaint.Columns["AssignedEmployee"].Visible = false;

            if (!dataGridViewComplaint.Columns.Contains("CityComboBox"))
            {
                // Create and add combo boxes for City and Department columns
                DataGridViewComboBoxColumn cityComboBoxColumn = new DataGridViewComboBoxColumn
                {
                    HeaderText = "City",
                    Name = "CityComboBox",
                    DataSource = cityController.GetAllCities(), // Get the cities from the controller
                    DisplayMember = "Name", // Assuming "CityName" is the name of the city in your data
                    ValueMember = "Id", // Assuming "CityId" is the ID of the city in your data
                    DataPropertyName = "CityId" // Bind this column to the "CityId" property of your complaint
                };
                dataGridViewComplaint.Columns.Add(cityComboBoxColumn);
            }

            if (!dataGridViewComplaint.Columns.Contains("DepartmentComboBox"))
            {
                DataGridViewComboBoxColumn departmentComboBoxColumn = new DataGridViewComboBoxColumn
                {
                    HeaderText = "Department",
                    Name = "DepartmentComboBox",
                    DataSource = departmentController.GetAllDepartments(), // Get the departments from the controller
                    DisplayMember = "Name", // Assuming "DepartmentName" is the name of the department
                    ValueMember = "Id", // Assuming "DepartmentId" is the ID of the department
                    DataPropertyName = "DepartmentId" // Bind this column to the "DepartmentId" property of your complaint
                };
                dataGridViewComplaint.Columns.Add(departmentComboBoxColumn);
            }

            // Initialize the DataGridView's other settings
            InitializeDataGridView();
        }
        #endregion


        #region HomePage Button
        private void butHomePage_Click(object sender, EventArgs e)
        {
            HomePageForm homePage = new HomePageForm(_context, _citizenId);
            this.Hide();
            homePage.Show();
        }
        #endregion

        #region Profile Button
        private void butEditProfile_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm(_context, _citizenId);
            this.Hide();
            profileForm.Show();
        }
        #endregion

        #region Submit Complaint Button
        private void butSubmit_Click(object sender, EventArgs e)
        {
            SubmitComplaintForm submitComplaintForm = new SubmitComplaintForm(_context, _citizenId);
            this.Hide();
            submitComplaintForm.Show();
        }
        #endregion

        #region Track Complaints Button
        private void butTrackComplaints_Click(object sender, EventArgs e)
        {
            TrackComplaintsForm trackComplaintsForm = new TrackComplaintsForm(_context, _citizenId);
            this.Hide();
            trackComplaintsForm.Show();
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
