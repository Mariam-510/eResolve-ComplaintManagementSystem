using ComplaintManagementSystem.Context;
using ComplaintManagementSystem.Controllers;
using ComplaintManagementSystem.Forms.CitizenForms;
using ComplaintManagementSystem.Forms.LoginAndSignUpForms;
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

namespace ComplaintManagementSystem.Forms.EmployeeForms
{
    public partial class HomePageEmployeeForm : Form
    {
        private readonly ComplaintSystemContext _context;
        EmployeeController employeeController;

        private int _empId;

        #region Ctor
        public HomePageEmployeeForm(ComplaintSystemContext context, int citizenId)
        {
            InitializeComponent();
            _context = context;
            _empId = citizenId;
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

        #region Form Load
        private void HomePageEmployeeForm_Load(object sender, EventArgs e)
        {
            var _emp = employeeController.GetEmployeeById(_empId);
            labelUserName.Text = "Welcome " + _emp.Account.Username;

            var _coms = employeeController.GetAllComplaintsForEmployee(_empId);
            labelNum.Text = _coms.Count() + " Complaints";

            SetupCharts();
        }
        #endregion

        #region Charts
        private void SetupCharts()
        {
            // Create and set up the bar chart (Complaints Submitted Per Month)
            var barChart = new Chart
            {
                Size = new Size(500, 300),
                Location = new Point(385, 130)  // Adjust position as needed
            };

            // Add a chart area to the bar chart
            var barChartArea = new ChartArea();
            barChart.ChartAreas.Add(barChartArea);

            // Set up the bar chart series
            SetupBarChartSeries(barChart);

            // Add the bar chart to the form
            this.Controls.Add(barChart);
        }

        private void SetupBarChartSeries(Chart chart)
        {
            var series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Monthly Complaints",
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true
            };

            // Fetch complaints data for the past year
            var complaintsPerMonth = _context.Complaints
                .Where(c => !c.IsDeleted && c.AssignedEmployeeId == _empId &&
                            c.SubmissionDate > DateTime.Now.AddYears(-1))
                .GroupBy(c => c.SubmissionDate.Month)
                .Select(g => new { Month = g.Key, Count = g.Count() })
                .OrderBy(g => g.Month)
                .ToList();

            if (complaintsPerMonth.Count == 0)
            {
                MessageBox.Show("No complaints data available.");
                return;
            }

            // Create a list of abbreviated month names
            var monthNamesAbbreviated = new List<string>
    {
        "Jan", "Feb", "Mar", "Apr", "May", "Jun",
        "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
    };

            // Add the points for each month to the bar chart
            foreach (var monthData in complaintsPerMonth)
            {
                // Get the abbreviated month name using the month number
                string monthAbbreviation = monthNamesAbbreviated[monthData.Month - 1];

                series.Points.Add(new DataPoint(monthData.Month, monthData.Count)
                {
                    LegendText = $"{monthAbbreviation}",
                    Label = $"{monthData.Count} Complaints"
                });
            }

            // Add the series to the bar chart
            chart.Series.Add(series);

            // Optional: Format the bar chart
            var chartArea = chart.ChartAreas[0];
            chartArea.AxisX.Title = "Month";
            chartArea.AxisY.Title = "Number of Complaints";
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.LabelStyle.Angle = -45;  // Angle of the month labels if needed
            //chartArea.AxisY.LabelStyle.Format = "0"; // Format the Y-Axis labels to show integers

            // Add a title for the bar chart
            var chartTitle = new Title
            {
                Text = "Complaints Submitted Per Month\n(This Year)",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Alignment = ContentAlignment.TopCenter
            };
            chart.Titles.Add(chartTitle);

            // Custom X-Axis labels to show abbreviated month names instead of numbers
            foreach (var point in series.Points)
            {
                point.AxisLabel = monthNamesAbbreviated[point.XValue.ToString() == "0" ? 0 : (int)point.XValue - 1]; // Adjust month name labels
            }
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
