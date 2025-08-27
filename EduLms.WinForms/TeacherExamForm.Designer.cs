namespace EduLms.WinForms
{
    partial class TeacherExamForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblSubject = new Label();
            cmbSubject = new ComboBox();
            lblDuration = new Label();
            numDuration = new NumericUpDown();
            lblStart = new Label();
            dtStart = new DateTimePicker();
            lblEnd = new Label();
            dtEnd = new DateTimePicker();
            lblMaxAttempts = new Label();
            numMaxAttempts = new NumericUpDown();
            chkShuffle = new CheckBox();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)numDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxAttempts).BeginInit();
            SuspendLayout();
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(29, 15);
            lblTitle.Text = "Title";
            //
            // txtTitle
            //
            txtTitle.Location = new Point(150, 17);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(200, 23);
            //
            // lblSubject
            //
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(30, 60);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(45, 15);
            lblSubject.Text = "Subject";
            //
            // cmbSubject
            //
            cmbSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubject.Location = new Point(150, 57);
            cmbSubject.Name = "cmbSubject";
            cmbSubject.Size = new Size(200, 23);
            //
            // lblDuration
            //
            lblDuration.AutoSize = true;
            lblDuration.Location = new Point(30, 100);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(94, 15);
            lblDuration.Text = "Duration (mins)";
            //
            // numDuration
            //
            numDuration.Location = new Point(150, 98);
            numDuration.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(120, 23);
            //
            // lblStart
            //
            lblStart.AutoSize = true;
            lblStart.Location = new Point(30, 140);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(47, 15);
            lblStart.Text = "Start at";
            //
            // dtStart
            //
            dtStart.CustomFormat = "dd/MM/yyyy HH:mm";
            dtStart.Format = DateTimePickerFormat.Custom;
            dtStart.Location = new Point(150, 137);
            dtStart.Name = "dtStart";
            dtStart.ShowCheckBox = true;
            dtStart.Size = new Size(200, 23);
            //
            // lblEnd
            //
            lblEnd.AutoSize = true;
            lblEnd.Location = new Point(30, 180);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(43, 15);
            lblEnd.Text = "End at";
            //
            // dtEnd
            //
            dtEnd.CustomFormat = "dd/MM/yyyy HH:mm";
            dtEnd.Format = DateTimePickerFormat.Custom;
            dtEnd.Location = new Point(150, 177);
            dtEnd.Name = "dtEnd";
            dtEnd.ShowCheckBox = true;
            dtEnd.Size = new Size(200, 23);
            //
            // lblMaxAttempts
            //
            lblMaxAttempts.AutoSize = true;
            lblMaxAttempts.Location = new Point(30, 220);
            lblMaxAttempts.Name = "lblMaxAttempts";
            lblMaxAttempts.Size = new Size(80, 15);
            lblMaxAttempts.Text = "Max Attempts";
            //
            // numMaxAttempts
            //
            numMaxAttempts.Location = new Point(150, 218);
            numMaxAttempts.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numMaxAttempts.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMaxAttempts.Name = "numMaxAttempts";
            numMaxAttempts.Size = new Size(120, 23);
            numMaxAttempts.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // chkShuffle
            //
            chkShuffle.AutoSize = true;
            chkShuffle.Location = new Point(150, 255);
            chkShuffle.Name = "chkShuffle";
            chkShuffle.Size = new Size(106, 19);
            chkShuffle.Text = "Shuffle options";
            chkShuffle.UseVisualStyleBackColor = true;
            //
            // btnSave
            //
            btnSave.Location = new Point(150, 290);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            //
            // TeacherExamForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 330);
            Controls.Add(btnSave);
            Controls.Add(chkShuffle);
            Controls.Add(numMaxAttempts);
            Controls.Add(lblMaxAttempts);
            Controls.Add(dtEnd);
            Controls.Add(lblEnd);
            Controls.Add(dtStart);
            Controls.Add(lblStart);
            Controls.Add(numDuration);
            Controls.Add(lblDuration);
            Controls.Add(cmbSubject);
            Controls.Add(lblSubject);
            Controls.Add(txtTitle);
            Controls.Add(lblTitle);
            Name = "TeacherExamForm";
            Text = "Create Exam";
            Load += TeacherExamForm_Load;
            ((System.ComponentModel.ISupportInitialize)numDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxAttempts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblSubject;
        private ComboBox cmbSubject;
        private Label lblDuration;
        private NumericUpDown numDuration;
        private Label lblStart;
        private DateTimePicker dtStart;
        private Label lblEnd;
        private DateTimePicker dtEnd;
        private Label lblMaxAttempts;
        private NumericUpDown numMaxAttempts;
        private CheckBox chkShuffle;
        private Button btnSave;
    }
}
