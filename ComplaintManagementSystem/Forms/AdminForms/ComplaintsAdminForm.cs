using ComplaintManagementSystem.Context;
using ComplaintManagementSystem.Controllers;
using ComplaintManagementSystem.DTO;
using ComplaintManagementSystem.Forms.LoginAndSignUpForms;
using ComplaintManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComplaintManagementSystem.Forms.AdminForms
{
    public partial class ComplaintsAdminForm : Form
    {
        private readonly ComplaintSystemContext _context;
        EmployeeController employeeController;
        private int _empId;
        ComplaintController complaintController;
        CityController cityController;
        DepartmentController departmentController;

        bool sFlag = true, oFlag = true, cFlag = true, dFlag = true;

        #region Ctor
        public ComplaintsAdminForm(ComplaintSystemContext context, int empId)
        {
            InitializeComponent();
            _context = context;
            _empId = empId;
            employeeController = new EmployeeController(_context);
            complaintController = new ComplaintController(_context);
            cityController = new CityController(_context);
            departmentController = new DepartmentController(_context);
            this.FormClosing += ExitFormClosing;
        }
        #endregion

        #region Closing Event
        private void ExitFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion


        #region HomePage Button
        private void butHomePage_Click(object sender, EventArgs e)
        {

            HomePageAdminForm homePage = new HomePageAdminForm(_context, _empId);
            this.Hide();
            homePage.Show();
        }
        #endregion

        #region Profile Button
        private void butEditProfile_Click(object sender, EventArgs e)
        {
            ProfileAdminForm profileForm = new ProfileAdminForm(_context, _empId);
            this.Hide();
            profileForm.Show();
        }
        #endregion

        #region Employees Button
        private void butEmployees_Click(object sender, EventArgs e)
        {
            EmployeesForm employeesForm = new EmployeesForm(_context, _empId);
            this.Hide();
            employeesForm.Show();
        }
        #endregion

        #region Complaints Buuton
        private void butComplaints_Click(object sender, EventArgs e)
        {
            ComplaintsAdminForm complaintsAdminForm = new ComplaintsAdminForm(_context, _empId);
            this.Hide();
            complaintsAdminForm.Show();
        }
        #endregion

        #region Add Emp Button
        private void butAddEmp_Click(object sender, EventArgs e)
        {

            AddEmployeeForm addEmployeeForm = new AddEmployeeForm(_context, _empId);
            this.Hide();
            addEmployeeForm.Show();
        }
        #endregion

        #region Form Load
        private void ComplaintsAdminForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _emp = employeeController.GetEmployeeById(_empId);
                labelUserName.Text = "Welcome " + _emp.Account.Username;

                // Populate Cities in comboBoxCity
                var cities = cityController.GetAllCities();
                cities.Insert(0, new City { Id = 0, Name = "All" }); // Add "All" option
                comboBoxCityFilter.DataSource = cities;
                comboBoxCityFilter.DisplayMember = "Name";
                comboBoxCityFilter.ValueMember = "Id";

                // Populate Departments in comboBoxDepFilter
                var departments = departmentController.GetAllDepartments();
                departments.Insert(0, new Department { Id = 0, Name = "All" }); // Add "All" option
                comboBoxDepFilter.DataSource = departments;
                comboBoxDepFilter.DisplayMember = "Name";
                comboBoxDepFilter.ValueMember = "Id";

                var statusListFiltered = new List<string>() { "All", "Pending", "In Progress", "Resolved" };
                comboBoxStatusFilter.DataSource = statusListFiltered;

                var submissionDateListFiltered = new List<string>() { "Newer to Older", "Older to Newer" };
                comboBoxSubmissionDate.DataSource = submissionDateListFiltered;

                sFlag = false; oFlag = false; cFlag = false; dFlag = false;
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

        private void comboBoxCityFilter_SelectedIndexChanged(object sender, EventArgs e)
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

        private void comboBoxDepFilter_SelectedIndexChanged(object sender, EventArgs e)
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

                var status = row.Cells["Status"].Value.ToString();
                if (status == "Resolved")
                {
                    MessageBox.Show("This complaint cannot be edited because its status is 'Resolved'.", "Edit Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int newEmpId = (int)row.Cells["AssignedEmployee"].Value;

                Debug.WriteLine(newEmpId);

                // Update the complaint in the database
                complaintController.UpdateAssignedEmployee(complaintId, newEmpId);
                complaintController.UpdateComplaintStatus(complaintId, "In Progress");

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
            if (sFlag || oFlag || cFlag || dFlag)
                return;

            var statusFiltered = comboBoxStatusFilter.SelectedValue.ToString() == "All" ? "" : comboBoxStatusFilter.SelectedValue.ToString();
            var submissionDateEFiltered = comboBoxSubmissionDate.SelectedIndex == 0 ? "D" : "A";

            int? selectedCityId = (int)comboBoxCityFilter.SelectedValue == 0 ? null : (int)comboBoxCityFilter.SelectedValue;
            int? selectedDepId = (int)comboBoxDepFilter.SelectedValue == 0 ? null : (int)comboBoxDepFilter.SelectedValue;

            var complaints = complaintController.GetAllComplaints(statusFiltered, submissionDateEFiltered, selectedCityId, selectedDepId);

            // Map complaints to ComplaintViewModel
            var complaintViewModels = complaints.Select(c => new complaintViewModelsV2
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                Status = c.Status,
                CitizenName = c.Citizen.Name,
                PhoneNumber = c.PhoneNumber,
                CityName = c.City.Name,
                DepartmentName = c.Department.Name,
                Address = c.Address,
                SubmissionDate = c.SubmissionDate,
                ResolutionDate = c.ResolutionDate,
                AssignedEmployeeId = c.AssignedEmployeeId
            }).ToList();

            dataGridViewComplaint.DataSource = complaintViewModels;

            if (!dataGridViewComplaint.Columns.Contains("AssignedEmployee"))
            {
                // Create and add combo boxes for City and Department columns
                DataGridViewComboBoxColumn assignedEmployeeComboBoxColumn = new DataGridViewComboBoxColumn
                {
                    HeaderText = "AssignedEmployee",
                    Name = "AssignedEmployee",
                    DataSource = employeeController.GetFilteredEmployees(role: "Employee"),
                    DisplayMember = "Name",
                    ValueMember = "Id",
                    DataPropertyName = "AssignedEmployeeId"
                };
                dataGridViewComplaint.Columns.Add(assignedEmployeeComboBoxColumn);
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
            dataGridViewComplaint.Columns["Status"].ReadOnly = true;

            // Hide unnecessary columns
            dataGridViewComplaint.Columns["Id"].Visible = false;
            dataGridViewComplaint.Columns["AssignedEmployeeId"].Visible = false;

            // Initialize the DataGridView's other settings
            InitializeDataGridView();
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
