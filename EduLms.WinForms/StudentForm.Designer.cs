namespace EduLms.WinForms
{
    partial class StudentForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvExams = new DataGridView();
            btnStart = new Button();
            SuspendLayout();
            //
            // dgvExams
            //
            dgvExams.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvExams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExams.Location = new Point(12, 12);
            dgvExams.MultiSelect = false;
            dgvExams.Name = "dgvExams";
            dgvExams.RowTemplate.Height = 25;
            dgvExams.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExams.Size = new Size(560, 300);
            dgvExams.TabIndex = 0;
            //
            // btnStart
            //
            btnStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnStart.Location = new Point(497, 318);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            //
            // StudentForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(btnStart);
            Controls.Add(dgvExams);
            Name = "StudentForm";
            Text = "My Exams";
            Load += StudentForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvExams;
        private Button btnStart;
    }
}

