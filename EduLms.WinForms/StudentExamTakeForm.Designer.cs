using System.Drawing;
using System.Windows.Forms;

namespace EduLms.WinForms
{
    partial class StudentExamTakeForm
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
            lblInfo = new Label();
            lblTimer = new Label();
            btnSubmit = new Button();
            SuspendLayout();
            //
            // lblInfo
            //
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(12, 9);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(88, 15);
            lblInfo.TabIndex = 0;
            lblInfo.Text = "Exam in progress";
            //
            // lblTimer
            //
            lblTimer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTimer.AutoSize = true;
            lblTimer.Location = new Point(776, 9);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(34, 15);
            lblTimer.TabIndex = 1;
            lblTimer.Text = "00:00";
            //
            // btnSubmit
            //
            btnSubmit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSubmit.Location = new Point(735, 415);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(75, 23);
            btnSubmit.TabIndex = 2;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            //
            // StudentExamTakeForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 450);
            Controls.Add(btnSubmit);
            Controls.Add(lblTimer);
            Controls.Add(lblInfo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "StudentExamTakeForm";
            Text = "Exam";
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInfo;
        private Label lblTimer;
        private Button btnSubmit;
    }
}
