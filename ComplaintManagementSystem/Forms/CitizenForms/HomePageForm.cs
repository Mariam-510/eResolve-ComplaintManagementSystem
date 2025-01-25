using ComplaintManagementSystem.Context;
using ComplaintManagementSystem.Controllers;
using ComplaintManagementSystem.Models;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;
using ComplaintManagementSystem.Forms.LoginAndSignUpForms;

namespace ComplaintManagementSystem.Forms.CitizenForms
{
    public partial class HomePageForm : Form
    {
        private readonly ComplaintSystemContext _context;

        private int _citizenId;

        CitizenController citizenController;

        #region Ctor
        public HomePageForm(ComplaintSystemContext context, int citizenId)
        {
            InitializeComponent();
            _context = context;
            _citizenId = citizenId;
            citizenController = new CitizenController(_context);
            this.FormClosing += ExitFormClosing;
        }
        #endregion

        #region Closing Event
        private void ExitFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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

        #region HomePage Button
        private void butHomePage_Click(object sender, EventArgs e)
        {
            HomePageForm homePage = new HomePageForm(_context, _citizenId);
            this.Hide();
            homePage.Show();
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

        #region Form Load
        private void HomePageForm_Load(object sender, EventArgs e)
        {
            var _citizen = citizenController.GetCitizenById(_citizenId);
            labelUserName.Text = "Welcome " + _citizen.Account.Username;

            var _coms = citizenController.GetComplaintsForCitizenFiltered(_citizenId);
            labelNum.Text = _coms.Count() + " Complaints";

            // Call SetupChart to display the chart when the form loads
            SetupCharts();

        }
        #endregion

        #region charts
        private void SetupCharts()
        {
            // Create and set up the pie chart (Complaints by Status)
            var pieChart = new Chart
            {
                Size = new Size(450, 300),
                Location = new Point(425, 135)  // Adjust position as needed
            };

            // Add a chart area to the pie chart
            var pieChartArea = new ChartArea();
            pieChart.ChartAreas.Add(pieChartArea);

            // Set up the pie chart series
            SetupPieChartSeries(pieChart);

            // Add the pie chart to the form
            this.Controls.Add(pieChart);
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
            var complaints = citizenController.GetComplaintsForCitizenFiltered(_citizenId);
            var pendingCount = complaints.Count(c => c.Status == "Pending");
            var resolvedCount = complaints.Count(c => c.Status == "Resolved");
            var inProgressCount = complaints.Count(c => c.Status == "In Progress");

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
