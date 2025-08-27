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
            cmbType = new ComboBox();
            btnImage = new Button();
            picQuestion = new PictureBox();
            gridOptions = new DataGridView();
            btnSave = new Button();
            var colContent = new DataGridViewTextBoxColumn();
            var colIsCorrect = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)numDifficulty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picQuestion).BeginInit();
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
            // cmbType
            //
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.Location = new Point(390, 25);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(140, 23);
            cmbType.TabIndex = 3;
            cmbType.SelectedIndexChanged += cmbType_SelectedIndexChanged;
            //
            // btnImage
            //
            btnImage.Location = new Point(440, 65);
            btnImage.Name = "btnImage";
            btnImage.Size = new Size(90, 23);
            btnImage.TabIndex = 4;
            btnImage.Text = "Load Image";
            btnImage.UseVisualStyleBackColor = true;
            btnImage.Click += btnImage_Click;
            //
            // picQuestion
            //
            picQuestion.BorderStyle = BorderStyle.FixedSingle;
            picQuestion.Location = new Point(440, 94);
            picQuestion.Name = "picQuestion";
            picQuestion.Size = new Size(140, 120);
            picQuestion.SizeMode = PictureBoxSizeMode.Zoom;
            picQuestion.TabIndex = 5;
            picQuestion.TabStop = false;
            //
            // gridOptions
            //
            colContent.HeaderText = "Option";
            colContent.Name = "colContent";
            colIsCorrect.HeaderText = "IsCorrect";
            colIsCorrect.Name = "colIsCorrect";
            gridOptions.Columns.AddRange(new DataGridViewColumn[] { colContent, colIsCorrect });
            gridOptions.Location = new Point(30, 160);
            gridOptions.Name = "gridOptions";
            gridOptions.Size = new Size(400, 150);
            gridOptions.TabIndex = 6;
            //
            // btnSave
            //
            btnSave.Location = new Point(505, 315);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            //
            // TeacherQuestionForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(594, 361);
            Controls.Add(btnSave);
            Controls.Add(gridOptions);
            Controls.Add(picQuestion);
            Controls.Add(btnImage);
            Controls.Add(cmbType);
            Controls.Add(numDifficulty);
            Controls.Add(txtQuestion);
            Controls.Add(cmbSubjects);
            Name = "TeacherQuestionForm";
            Text = "Question";
            Load += TeacherQuestionForm_Load;
            ((System.ComponentModel.ISupportInitialize)numDifficulty).EndInit();
            ((System.ComponentModel.ISupportInitialize)picQuestion).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridOptions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbSubjects;
        private TextBox txtQuestion;
        private NumericUpDown numDifficulty;
        private ComboBox cmbType;
        private Button btnImage;
        private PictureBox picQuestion;
        private DataGridView gridOptions;
        private Button btnSave;
    }
}
