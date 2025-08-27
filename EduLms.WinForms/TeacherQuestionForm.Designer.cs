namespace EduLms.WinForms
{
    partial class TeacherQuestionForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            cmbSubjects = new ComboBox();
            txtQuestion = new TextBox();
            numDifficulty = new NumericUpDown();
            gridOptions = new DataGridView();
            btnSave = new Button();
            var colContent = new DataGridViewTextBoxColumn();
            var colIsCorrect = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)numDifficulty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridOptions).BeginInit();
            SuspendLayout();
            //
            // cmbSubjects
            //
            cmbSubjects.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubjects.Location = new Point(30, 25);
            cmbSubjects.Name = "cmbSubjects";
            cmbSubjects.Size = new Size(200, 23);
            cmbSubjects.TabIndex = 0;
            //
            // txtQuestion
            //
            txtQuestion.Location = new Point(30, 65);
            txtQuestion.Multiline = true;
            txtQuestion.Name = "txtQuestion";
            txtQuestion.Size = new Size(400, 60);
            txtQuestion.TabIndex = 1;
            //
            // numDifficulty
            //
            numDifficulty.Location = new Point(250, 25);
            numDifficulty.Name = "numDifficulty";
            numDifficulty.Size = new Size(120, 23);
            numDifficulty.TabIndex = 2;
            //
            // gridOptions
            //
            colContent.HeaderText = "Option";
            colContent.Name = "colContent";
            colIsCorrect.HeaderText = "IsCorrect";
            colIsCorrect.Name = "colIsCorrect";
            gridOptions.Columns.AddRange(new DataGridViewColumn[] { colContent, colIsCorrect });
            gridOptions.Location = new Point(30, 140);
            gridOptions.Name = "gridOptions";
            gridOptions.Size = new Size(400, 150);
            gridOptions.TabIndex = 3;
            //
            // btnSave
            //
            btnSave.Location = new Point(355, 310);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            //
            // TeacherQuestionForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 351);
            Controls.Add(btnSave);
            Controls.Add(gridOptions);
            Controls.Add(numDifficulty);
            Controls.Add(txtQuestion);
            Controls.Add(cmbSubjects);
            Name = "TeacherQuestionForm";
            Text = "TeacherQuestionForm";
            Load += TeacherQuestionForm_Load;
            ((System.ComponentModel.ISupportInitialize)numDifficulty).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridOptions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbSubjects;
        private TextBox txtQuestion;
        private NumericUpDown numDifficulty;
        private DataGridView gridOptions;
        private Button btnSave;
    }
}
