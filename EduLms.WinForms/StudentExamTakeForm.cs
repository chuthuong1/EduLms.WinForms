using EduLms.Data.Data.Models;
using System;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace EduLms.WinForms
{
    public partial class StudentExamTakeForm : Form
    {
        private readonly EduLmsContext _db;
        private readonly ExamAttempt _attempt;
        private Timer _timer;
        private DateTime _endTime;

        public StudentExamTakeForm(EduLmsContext db, ExamAttempt attempt)
        {
            InitializeComponent();
            _db = db;
            _attempt = attempt;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _endTime = _attempt.StartedAt.AddMinutes(_attempt.Exam.DurationMinutes);
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;
            _timer.Start();
            UpdateTimer();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            UpdateTimer();
            if (DateTime.UtcNow >= _endTime)
            {
                SubmitAttempt();
            }
        }

        private void UpdateTimer()
        {
            var remaining = _endTime - DateTime.UtcNow;
            if (remaining < TimeSpan.Zero) remaining = TimeSpan.Zero;
            lblTimer.Text = remaining.ToString("mm':'ss");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SubmitAttempt();
        }

        private void SubmitAttempt()
        {
            _timer.Stop();
            _attempt.SubmittedAt = DateTime.UtcNow;
            _attempt.Status = "Submitted";
            _db.SaveChanges();
            Close();
        }
    }
}
