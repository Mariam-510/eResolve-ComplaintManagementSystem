namespace ComplaintManagementSystem.Forms.EmployeeForms
{
    partial class ComplaintsEmpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComplaintsEmpForm));
            dataGridViewComplaint = new DataGridView();
            panel1 = new Panel();
            labelUserName = new Label();
            pictureBox4 = new PictureBox();
            butComplaints = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            butHomePage = new Button();
            butEditProfile = new Button();
            pictureBox10 = new PictureBox();
            comboBoxStatusFilter = new ComboBox();
            label1 = new Label();
            comboBoxSubmissionDate = new ComboBox();
            label2 = new Label();
            panel2 = new Panel();
            pictureBox15 = new PictureBox();
            butLogout = new Button();
            pictureBox16 = new PictureBox();
            label13 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewComplaint).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox15).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox16).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewComplaint
            // 
            dataGridViewComplaint.BackgroundColor = Color.SteelBlue;
            dataGridViewComplaint.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewComplaint.Location = new Point(321, 97);
            dataGridViewComplaint.Name = "dataGridViewComplaint";
            dataGridViewComplaint.RowHeadersWidth = 51;
            dataGridViewComplaint.Size = new Size(648, 365);
            dataGridViewComplaint.TabIndex = 58;
            dataGridViewComplaint.CellClick += dataGridViewComplaint_CellClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(labelUserName);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(-8, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(329, 65);
            panel1.TabIndex = 60;
            // 
            // labelUserName
            // 
            labelUserName.AutoSize = true;
            labelUserName.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUserName.Location = new Point(24, 16);
            labelUserName.Name = "labelUserName";
            labelUserName.Size = new Size(118, 35);
            labelUserName.TabIndex = 0;
            labelUserName.Text = "Welcome";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(16, 323);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(47, 43);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 68;
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
            butComplaints.Location = new Point(66, 318);
            butComplaints.Name = "butComplaints";
            butComplaints.Size = new Size(205, 50);
            butComplaints.TabIndex = 67;
            butComplaints.Text = "Track Complaints";
            butComplaints.UseVisualStyleBackColor = false;
            butComplaints.Click += butComplaints_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(18, 222);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(47, 43);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 65;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.home;
            pictureBox1.Location = new Point(18, 120);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 43);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 63;
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
            butHomePage.Location = new Point(71, 116);
            butHomePage.Name = "butHomePage";
            butHomePage.Size = new Size(200, 50);
            butHomePage.TabIndex = 64;
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
            butEditProfile.Location = new Point(71, 218);
            butEditProfile.Name = "butEditProfile";
            butEditProfile.Size = new Size(200, 49);
            butEditProfile.TabIndex = 66;
            butEditProfile.Text = "Edit Profile";
            butEditProfile.UseVisualStyleBackColor = false;
            butEditProfile.Click += butEditProfile_Click;
            // 
            // pictureBox10
            // 
            pictureBox10.BackColor = Color.SteelBlue;
            pictureBox10.Image = Properties.Resources.Half_Circle_PNG_Photo1;
            pictureBox10.Location = new Point(4, 19);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(317, 443);
            pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox10.TabIndex = 69;
            pictureBox10.TabStop = false;
            // 
            // comboBoxStatusFilter
            // 
            comboBoxStatusFilter.FormattingEnabled = true;
            comboBoxStatusFilter.Location = new Point(413, 59);
            comboBoxStatusFilter.Name = "comboBoxStatusFilter";
            comboBoxStatusFilter.Size = new Size(174, 31);
            comboBoxStatusFilter.TabIndex = 70;
            comboBoxStatusFilter.SelectedIndexChanged += comboBoxStatusFilter_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.SteelBlue;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(342, 61);
            label1.Name = "label1";
            label1.Size = new Size(65, 28);
            label1.TabIndex = 71;
            label1.Text = "Status";
            // 
            // comboBoxSubmissionDate
            // 
            comboBoxSubmissionDate.FormattingEnabled = true;
            comboBoxSubmissionDate.Location = new Point(768, 59);
            comboBoxSubmissionDate.Name = "comboBoxSubmissionDate";
            comboBoxSubmissionDate.Size = new Size(174, 31);
            comboBoxSubmissionDate.TabIndex = 72;
            comboBoxSubmissionDate.SelectedIndexChanged += comboBoxSubmissionDate_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.SteelBlue;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(609, 60);
            label2.Name = "label2";
            label2.Size = new Size(153, 28);
            label2.TabIndex = 73;
            label2.Text = "SubmissionDate";
            // 
            // panel2
            // 
            panel2.BackColor = Color.SteelBlue;
            panel2.Controls.Add(pictureBox16);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(pictureBox15);
            panel2.Controls.Add(butLogout);
            panel2.ForeColor = Color.White;
            panel2.Location = new Point(321, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(669, 56);
            panel2.TabIndex = 74;
            // 
            // pictureBox15
            // 
            pictureBox15.BackColor = Color.SteelBlue;
            pictureBox15.Image = (Image)resources.GetObject("pictureBox15.Image");
            pictureBox15.Location = new Point(498, 7);
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
            butLogout.Location = new Point(545, 5);
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
            pictureBox16.Location = new Point(4, 8);
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
            label13.Location = new Point(64, 8);
            label13.Name = "label13";
            label13.Size = new Size(126, 38);
            label13.TabIndex = 98;
            label13.Text = "eResolve";
            // 
            // ComplaintsEmpForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(972, 450);
            Controls.Add(panel2);
            Controls.Add(label2);
            Controls.Add(comboBoxSubmissionDate);
            Controls.Add(label1);
            Controls.Add(comboBoxStatusFilter);
            Controls.Add(panel1);
            Controls.Add(pictureBox4);
            Controls.Add(butComplaints);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(butHomePage);
            Controls.Add(butEditProfile);
            Controls.Add(pictureBox10);
            Controls.Add(dataGridViewComplaint);
            Name = "ComplaintsEmpForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Complaints Page";
            Load += ComplaintsEmpForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewComplaint).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox15).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox16).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridViewComplaint;
        private Panel panel1;
        private Label labelUserName;
        private PictureBox pictureBox4;
        private Button butComplaints;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button butHomePage;
        private Button butEditProfile;
        private PictureBox pictureBox10;
        private ComboBox comboBoxStatusFilter;
        private Label label1;
        private ComboBox comboBoxSubmissionDate;
        private Label label2;
        private Panel panel2;
        private Button butLogout;
        private PictureBox pictureBox15;
        private PictureBox pictureBox16;
        private Label label13;
    }
}