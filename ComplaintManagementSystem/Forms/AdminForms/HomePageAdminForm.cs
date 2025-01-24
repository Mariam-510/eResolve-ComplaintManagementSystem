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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ComplaintManagementSystem.Forms.AdminForms
{
    public partial class HomePageAdminForm : Form
    {
        private readonly ComplaintSystemContext _context;

        private int _empId;
        EmployeeController employeeController;


        #region Ctor
        public HomePageAdminForm(ComplaintSystemContext context, int empId)
        {
            InitializeComponent();
            _context = context;
            _empId = empId;
            employeeController = new EmployeeController(_context);
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
        private void HomePageAdminForm_Load(object sender, EventArgs e)
        {
            var _emp = employeeController.GetEmployeeById(_empId);
            labelUserName.Text = "Welcome " + _emp.Account.Username;

            var _emps = employeeController.GetFilteredEmployees(role: "Employee");
            labelNum.Text = _emps.Count() + " Employees";

            SetupCharts();
        }
        #endregion

        #region Charts
        private void SetupCharts()
        {
            // Create and set up the pie chart (Complaints by Status)
            var pieChart = new Chart
            {
                Size = new Size(250, 300),
                Location = new Point(715, 130)  // Adjust position as needed
            };

            // Add a chart area to the pie chart
            var pieChartArea = new ChartArea();
            pieChart.ChartAreas.Add(pieChartArea);

            // Set up the pie chart series
            SetupPieChartSeries(pieChart);

            // Add the pie chart to the form
            this.Controls.Add(pieChart);

            //-------------------------------------------------------------------------

            // Create and set up the complaints chart (Complaints per City)
            var complaintsChart = new Chart
            {
                Size = new Size(400, 300),  // Set the size of the chart
                Location = new Point(305, 130)  // Set the position of the chart
            };

            // Add a chart area to the complaints chart
            var chartArea = new ChartArea();
            complaintsChart.ChartAreas.Add(chartArea);

            // Set up the chart series
            SetupComplaintsChartSeries(complaintsChart);

            // Add the complaints chart to the form
            this.Controls.Add(complaintsChart);
        }

        private void SetupPieChartSeries(Chart chart)
        {
            var series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Complaints",
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true, // Show the value on the pie chart
                LabelFormat = "#PERCENT", // Show percentage on the segments (optional)
                BorderColor = Color.Black, // Optional: make the border color of the segments black
            };

            // Fetch complaints data by status
            var pendingCount = _context.Complaints.Where(c => !c.IsDeleted).Count(c => c.Status == "Pending");
            var resolvedCount = _context.Complaints.Where(c => !c.IsDeleted).Count(c => c.Status == "Resolved");
            var inProgressCount = _context.Complaints.Where(c => !c.IsDeleted).Count(c => c.Status == "In Progress");

            // Add the points to the pie chart
            series.Points.Add(new DataPoint(0, pendingCount) { LegendText = "Pending", Label = $"Pending: {pendingCount}" });
            series.Points.Add(new DataPoint(1, resolvedCount) { LegendText = "Resolved", Label = $"Resolved: {resolvedCount}" });
            series.Points.Add(new DataPoint(2, inProgressCount) { LegendText = "In Progress", Label = $"In Progress: {inProgressCount}" });

            // Add the series to the pie chart
            chart.Series.Add(series);

            // Add a title for the pie chart
            var chartTitle = new Title
            {
                Text = "Complaints by Status",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Alignment = ContentAlignment.TopCenter
            };
            chart.Titles.Add(chartTitle);

            // Optional: Format the pie chart
            var chartArea = chart.ChartAreas[0];
            chartArea.Area3DStyle.Enable3D = true;
            chartArea.AxisX.LabelStyle.Angle = -45;
        }

        private void SetupComplaintsChartSeries(Chart chart)
        {
            // Set up the series for Complaints per City (using a bar chart)
            var series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Complaints By City",
                ChartType = SeriesChartType.Bar,  // Using a bar chart here
                IsValueShownAsLabel = true,  // Display the value as a label
                BorderColor = Color.Black,  // Optional: Make the border color black
                LabelBackColor = Color.White // Optional: Set background color for labels
            };

            // Fetch the cities and complaints data from the CityController
            var cityController = new CityController(_context);
            var cities = cityController.GetAllCities();  // Fetch city names from the controller

            // Loop through each city and fetch the number of complaints
            foreach (var city in cities)
            {
                var cityComplaintsCount = _context.Complaints.Count(c => c.City.Id == city.Id && !c.IsDeleted);
                if (cityComplaintsCount > 0)
                {
                    series.Points.Add(new DataPoint
                    {
                        AxisLabel = city.Name,
                        YValues = new double[] { cityComplaintsCount }
                    });
                }
            }

            // Add the series to the complaints chart
            chart.Series.Add(series);

            // Add a title for the complaints chart
            var chartTitle = new Title
            {
                Text = "Complaints Per City",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Alignment = ContentAlignment.TopCenter
            };
            chart.Titles.Add(chartTitle);

            // Optional: Format the chart
            var chartArea = chart.ChartAreas[0];
            //chartArea.Area3DStyle.Enable3D = true;
            chartArea.AxisX.Title = "City";
            chartArea.AxisY.Title = "Number of Complaints";
            chartArea.AxisX.LabelStyle.Angle = -45;  // Optional: Rotate X-axis labels if necessary

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
