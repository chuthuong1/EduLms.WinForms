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
            tabManage = new TabControl();
            tabClasses = new TabPage();
            gridClasses = new DataGridView();
            tabSubjects = new TabPage();
            gridSubjects = new DataGridView();
            tabScores = new TabPage();
            gridScores = new DataGridView();
            btnCreateExam = new Button();
            tabManage.SuspendLayout();
            tabClasses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridClasses).BeginInit();
            tabSubjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridSubjects).BeginInit();
            tabScores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridScores).BeginInit();
            SuspendLayout();
            //
            // tabManage
            //
            tabManage.Controls.Add(tabClasses);
            tabManage.Controls.Add(tabSubjects);
            tabManage.Controls.Add(tabScores);
            tabManage.Location = new Point(12, 58);
            tabManage.Name = "tabManage";
            tabManage.SelectedIndex = 0;
            tabManage.Size = new Size(776, 380);
            tabManage.TabIndex = 0;
            //
            // tabClasses
            //
            tabClasses.Controls.Add(gridClasses);
            tabClasses.Location = new Point(4, 24);
            tabClasses.Name = "tabClasses";
            tabClasses.Padding = new Padding(3);
            tabClasses.Size = new Size(768, 352);
            tabClasses.TabIndex = 0;
            tabClasses.Text = "Classes";
            tabClasses.UseVisualStyleBackColor = true;
            //
            // gridClasses
            //
            gridClasses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridClasses.Dock = DockStyle.Fill;
            gridClasses.Location = new Point(3, 3);
            gridClasses.Name = "gridClasses";
            gridClasses.Size = new Size(762, 346);
            gridClasses.TabIndex = 0;
            //
            // tabSubjects
            //
            tabSubjects.Controls.Add(gridSubjects);
            tabSubjects.Location = new Point(4, 24);
            tabSubjects.Name = "tabSubjects";
            tabSubjects.Padding = new Padding(3);
            tabSubjects.Size = new Size(768, 352);
            tabSubjects.TabIndex = 1;
            tabSubjects.Text = "Subjects";
            tabSubjects.UseVisualStyleBackColor = true;
            //
            // gridSubjects
            //
            gridSubjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSubjects.Dock = DockStyle.Fill;
            gridSubjects.Location = new Point(3, 3);
            gridSubjects.Name = "gridSubjects";
            gridSubjects.Size = new Size(762, 346);
            gridSubjects.TabIndex = 0;
            //
            // tabScores
            //
            tabScores.Controls.Add(gridScores);
            tabScores.Location = new Point(4, 24);
            tabScores.Name = "tabScores";
            tabScores.Padding = new Padding(3);
            tabScores.Size = new Size(768, 352);
            tabScores.TabIndex = 2;
            tabScores.Text = "Scores";
            tabScores.UseVisualStyleBackColor = true;
            //
            // gridScores
            //
            gridScores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridScores.Dock = DockStyle.Fill;
            gridScores.Location = new Point(3, 3);
            gridScores.Name = "gridScores";
            gridScores.Size = new Size(762, 346);
            gridScores.TabIndex = 0;
            //
            // btnCreateExam
            //
            btnCreateExam.Location = new Point(12, 12);
            btnCreateExam.Name = "btnCreateExam";
            btnCreateExam.Size = new Size(120, 30);
            btnCreateExam.TabIndex = 1;
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
            Controls.Add(tabManage);
            Name = "MainForm";
            Text = "Teacher Dashboard";
            Load += MainForm_Load;
            tabManage.ResumeLayout(false);
            tabClasses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridClasses).EndInit();
            tabSubjects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridSubjects).EndInit();
            tabScores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridScores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabManage;
        private TabPage tabClasses;
        private DataGridView gridClasses;
        private TabPage tabSubjects;
        private DataGridView gridSubjects;
        private TabPage tabScores;
        private DataGridView gridScores;
        private Button btnCreateExam;
    }
}