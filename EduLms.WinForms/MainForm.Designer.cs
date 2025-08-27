namespace EduLms.WinForms
{
    partial class MainForm
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
            dataGridView1 = new DataGridView();
            txtEmail = new TextBox();
            txtName = new TextBox();
            btnQuestions = new Button();
            btnCreateExam = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(44, 180);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(367, 215);
            dataGridView1.TabIndex = 0;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(239, 56);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 1;
            txtEmail.Text = "Email";
            // 
            // txtName
            // 
            txtName.Location = new Point(101, 56);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 2;
            txtName.Text = "FullName";
            //
            // btnQuestions
            //
            btnQuestions.Location = new Point(101, 100);
            btnQuestions.Name = "btnQuestions";
            btnQuestions.Size = new Size(100, 23);
            btnQuestions.TabIndex = 3;
            btnQuestions.Text = "Question Bank";
            btnQuestions.UseVisualStyleBackColor = true;
            btnQuestions.Click += btnQuestions_Click;
            //
            // btnCreateExam
            //
            btnCreateExam.Location = new Point(239, 100);
            btnCreateExam.Name = "btnCreateExam";
            btnCreateExam.Size = new Size(100, 23);
            btnCreateExam.TabIndex = 4;
            btnCreateExam.Text = "Create Exam";
            btnCreateExam.UseVisualStyleBackColor = true;
            btnCreateExam.Click += btnCreateExam_Click;
            //
            // MainForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCreateExam);
            Controls.Add(btnQuestions);
            Controls.Add(txtName);
            Controls.Add(txtEmail);
            Controls.Add(dataGridView1);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtEmail;
        private TextBox txtName;
        private Button btnQuestions;
        private Button btnCreateExam;
    }
}