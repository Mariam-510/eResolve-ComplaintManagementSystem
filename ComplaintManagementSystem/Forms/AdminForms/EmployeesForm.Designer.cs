namespace ComplaintManagementSystem.Forms.AdminForms
{
    partial class EmployeesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeesForm));
            panelSide = new Panel();
            pictureBox5 = new PictureBox();
            butEmployees = new Button();
            panel1 = new Panel();
            labelUserName = new Label();
            pictureBox4 = new PictureBox();
            butComplaints = new Button();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            butHomePage = new Button();
            butEditProfile = new Button();
            butAddEmp = new Button();
            pictureBox10 = new PictureBox();
            dataGridViewEmployee = new DataGridView();
            label3 = new Label();
            comboBoxDepFilter = new ComboBox();
            label4 = new Label();
            comboBoxCityFilter = new ComboBox();
            panel2 = new Panel();
            pictureBox15 = new PictureBox();
            butLogout = new Button();
            pictureBox16 = new PictureBox();
            label13 = new Label();
            panelSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmployee).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox15).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox16).BeginInit();
            SuspendLayout();
            // 
            // panelSide
            // 
            panelSide.BackColor = Color.SteelBlue;
            panelSide.Controls.Add(pictureBox5);
            panelSide.Controls.Add(butEmployees);
            panelSide.Controls.Add(panel1);
            panelSide.Controls.Add(pictureBox4);
            panelSide.Controls.Add(butComplaints);
            panelSide.Controls.Add(pictureBox3);
            panelSide.Controls.Add(pictureBox2);
            panelSide.Controls.Add(pictureBox1);
            panelSide.Controls.Add(butHomePage);
            panelSide.Controls.Add(butEditProfile);
            panelSide.Controls.Add(butAddEmp);
            panelSide.Controls.Add(pictureBox10);
            panelSide.Location = new Point(1, 0);
            panelSide.Name = "panelSide";
            panelSide.Size = new Size(336, 450);
            panelSide.TabIndex = 60;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.White;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(7, 287);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(47, 43);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 21;
            pictureBox5.TabStop = false;
            // 
            // butEmployees
            // 
            butEmployees.BackColor = Color.SteelBlue;
            butEmployees.Cursor = Cursors.Hand;
            butEmployees.FlatAppearance.BorderSize = 0;
            butEmployees.FlatStyle = FlatStyle.Flat;
            butEmployees.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            butEmployees.ForeColor = Color.White;
            butEmployees.Location = new Point(55, 285);
            butEmployees.Name = "butEmployees";
            butEmployees.Size = new Size(222, 50);
            butEmployees.TabIndex = 22;
            butEmployees.Text = "Employees";
            butEmployees.UseVisualStyleBackColor = false;
            butEmployees.Click += butEmployees_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(labelUserName);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(334, 65);
            panel1.TabIndex = 5;
            // 
            // labelUserName
            // 
            labelUserName.AutoSize = true;
            labelUserName.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUserName.Location = new Point(24, 18);
            labelUserName.Name = "labelUserName";
            labelUserName.Size = new Size(118, 35);
            labelUserName.TabIndex = 0;
            labelUserName.Text = "Welcome";
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.White;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(7, 355);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(47, 43);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 9;
            pictureBox4.TabStop = false;
            // 
            // butComplaints
            // 
            butComplaints.BackColor = Color.SteelBlue;
            butComplaints.Cursor = Cursors.Hand;
            butComplaints.FlatAppearance.BorderSize = 0;
            butComplaints.FlatStyle = FlatStyle.Flat;
            butComplaints.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            butComplaints.ForeColor = Color.White;
            butComplaints.Location = new Point(60, 350);
            butComplaints.Name = "butComplaints";
            butComplaints.Size = new Size(217, 50);
            butComplaints.TabIndex = 8;
            butComplaints.Text = "Complaints";
            butComplaints.UseVisualStyleBackColor = false;
            butComplaints.Click += butComplaints_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.White;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(7, 221);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(47, 43);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(7, 158);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(47, 43);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = Properties.Resources.home;
            pictureBox1.Location = new Point(7, 92);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 43);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // butHomePage
            // 
            butHomePage.BackColor = Color.SteelBlue;
            butHomePage.Cursor = Cursors.Hand;
            butHomePage.FlatAppearance.BorderSize = 0;
            butHomePage.FlatStyle = FlatStyle.Flat;
            butHomePage.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            butHomePage.ForeColor = Color.White;
            butHomePage.Location = new Point(55, 89);
            butHomePage.Name = "butHomePage";
            butHomePage.Size = new Size(222, 50);
            butHomePage.TabIndex = 3;
            butHomePage.Text = "HomePage";
            butHomePage.UseVisualStyleBackColor = false;
            butHomePage.Click += butHomePage_Click;
            // 
            // butEditProfile
            // 
            butEditProfile.BackColor = Color.SteelBlue;
            butEditProfile.Cursor = Cursors.Hand;
            butEditProfile.FlatAppearance.BorderSize = 0;
            butEditProfile.FlatStyle = FlatStyle.Flat;
            butEditProfile.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            butEditProfile.ForeColor = Color.White;
            butEditProfile.Location = new Point(55, 155);
            butEditProfile.Name = "butEditProfile";
            butEditProfile.Size = new Size(222, 49);
            butEditProfile.TabIndex = 5;
            butEditProfile.Text = "Edit Profile";
            butEditProfile.UseVisualStyleBackColor = false;
            butEditProfile.Click += butEditProfile_Click;
            // 
            // butAddEmp
            // 
            butAddEmp.BackColor = Color.SteelBlue;
            butAddEmp.Cursor = Cursors.Hand;
            butAddEmp.FlatAppearance.BorderSize = 0;
            butAddEmp.FlatStyle = FlatStyle.Flat;
            butAddEmp.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            butAddEmp.ForeColor = Color.White;
            butAddEmp.Location = new Point(55, 219);
            butAddEmp.Name = "butAddEmp";
            butAddEmp.Size = new Size(222, 50);
            butAddEmp.TabIndex = 10;
            butAddEmp.Text = "Add Employee";
            butAddEmp.UseVisualStyleBackColor = false;
            butAddEmp.Click += butAddEmp_Click;
            // 
            // pictureBox10
            // 
            pictureBox10.BackColor = Color.SteelBlue;
            pictureBox10.Image = Properties.Resources.Half_Circle_PNG_Photo1;
            pictureBox10.Location = new Point(0, 2);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(334, 483);
            pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox10.TabIndex = 20;
            pictureBox10.TabStop = false;
            // 
            // dataGridViewEmployee
            // 
            dataGridViewEmployee.BackgroundColor = Color.SteelBlue;
            dataGridViewEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEmployee.Location = new Point(335, 97);
            dataGridViewEmployee.Name = "dataGridViewEmployee";
            dataGridViewEmployee.RowHeadersWidth = 51;
            dataGridViewEmployee.Size = new Size(634, 353);
            dataGridViewEmployee.TabIndex = 61;
            dataGridViewEmployee.CellClick += dataGridViewEmployee_CellClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.SteelBlue;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(638, 60);
            label3.Name = "label3";
            label3.Size = new Size(117, 28);
            label3.TabIndex = 85;
            label3.Text = "Department";
            // 
            // comboBoxDepFilter
            // 
            comboBoxDepFilter.FormattingEnabled = true;
            comboBoxDepFilter.Location = new Point(777, 60);
            comboBoxDepFilter.Name = "comboBoxDepFilter";
            comboBoxDepFilter.Size = new Size(174, 31);
            comboBoxDepFilter.TabIndex = 84;
            comboBoxDepFilter.SelectedIndexChanged += comboBoxDepFilter_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.SteelBlue;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(362, 60);
            label4.Name = "label4";
            label4.Size = new Size(46, 28);
            label4.TabIndex = 83;
            label4.Text = "City";
            // 
            // comboBoxCityFilter
            // 
            comboBoxCityFilter.FormattingEnabled = true;
            comboBoxCityFilter.Location = new Point(422, 60);
            comboBoxCityFilter.Name = "comboBoxCityFilter";
            comboBoxCityFilter.Size = new Size(174, 31);
            comboBoxCityFilter.TabIndex = 82;
            comboBoxCityFilter.SelectedIndexChanged += comboBoxCityFilter_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SteelBlue;
            panel2.Controls.Add(pictureBox16);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(pictureBox15);
            panel2.Controls.Add(butLogout);
            panel2.ForeColor = Color.White;
            panel2.Location = new Point(335, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(637, 56);
            panel2.TabIndex = 86;
            // 
            // pictureBox15
            // 
            pictureBox15.BackColor = Color.SteelBlue;
            pictureBox15.Image = (Image)resources.GetObject("pictureBox15.Image");
            pictureBox15.Location = new Point(475, 7);
            pictureBox15.Name = "pictureBox15";
            pictureBox15.Size = new Size(47, 43);
            pictureBox15.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox15.TabIndex = 95;
            pictureBox15.TabStop = false;
            pictureBox15.Click += pictureBox15_Click;
            // 
            // butLogout
            // 
            butLogout.BackColor = Color.SteelBlue;
            butLogout.FlatAppearance.BorderSize = 0;
            butLogout.FlatStyle = FlatStyle.Flat;
            butLogout.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            butLogout.ForeColor = Color.White;
            butLogout.Location = new Point(528, 5);
            butLogout.Name = "butLogout";
            butLogout.Size = new Size(101, 45);
            butLogout.TabIndex = 79;
            butLogout.Text = "LogOut";
            butLogout.UseVisualStyleBackColor = false;
            butLogout.Click += butLogout_Click;
            // 
            // pictureBox16
            // 
            pictureBox16.Image = (Image)resources.GetObject("pictureBox16.Image");
            pictureBox16.Location = new Point(14, 8);
            pictureBox16.Name = "pictureBox16";
            pictureBox16.Size = new Size(57, 43);
            pictureBox16.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox16.TabIndex = 99;
            pictureBox16.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.White;
            label13.Location = new Point(74, 8);
            label13.Name = "label13";
            label13.Size = new Size(126, 38);
            label13.TabIndex = 98;
            label13.Text = "eResolve";
            // 
            // EmployeesForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(972, 450);
            Controls.Add(panel2);
            Controls.Add(label3);
            Controls.Add(comboBoxDepFilter);
            Controls.Add(label4);
            Controls.Add(comboBoxCityFilter);
            Controls.Add(dataGridViewEmployee);
            Controls.Add(panelSide);
            Name = "EmployeesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Employees Page";
            Load += EmployeesForm_Load;
            panelSide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmployee).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox15).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox16).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelSide;
        private PictureBox pictureBox5;
        private Button butEmployees;
        private Panel panel1;
        private Label labelUserName;
        private PictureBox pictureBox4;
        private Button butComplaints;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button butHomePage;
        private Button butEditProfile;
        private Button butAddEmp;
        private PictureBox pictureBox10;
        private DataGridView dataGridViewEmployee;
        private Label label3;
        private ComboBox comboBoxDepFilter;
        private Label label4;
        private ComboBox comboBoxCityFilter;
        private Panel panel2;
        private Button butLogout;
        private PictureBox pictureBox15;
        private PictureBox pictureBox16;
        private Label label13;
    }
}