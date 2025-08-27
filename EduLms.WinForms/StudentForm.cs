using EduLms.Data.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EduLms.WinForms
{
    public partial class StudentForm : Form
    {
        private readonly EduLmsContext _db;
        public User? LoggedInUser { get; set; }
        public StudentForm(EduLmsContext db)
        {
            InitializeComponent();
            _db = db;
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            if (LoggedInUser == null) return;

            var now = DateTime.UtcNow;

            var exams = _db.ExamStudentAssignments
                .Include(a => a.Exam)
                .ThenInclude(e => e.Subject)
                .Where(a => a.StudentId == LoggedInUser.UserId
                    && (a.Exam.StartAt == null || a.Exam.StartAt <= now)
                    && (a.Exam.EndAt == null || a.Exam.EndAt >= now))
                .Select(a => new
                {
                    a.Exam.ExamId,
                    a.Exam.Title,
                    Subject = a.Exam.Subject.Name,
                    a.Exam.StartAt,
                    a.Exam.EndAt
                })
                .ToList();

            dgvExams.DataSource = exams;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (dgvExams.CurrentRow == null || LoggedInUser == null) return;

            var examId = (int)dgvExams.CurrentRow.Cells["ExamId"].Value;

            var code = Interaction.InputBox("Enter exam code", "Start Exam", "");
            if (string.IsNullOrWhiteSpace(code)) return;

            var exam = _db.Exams.Include(e => e.ExamPapers)
                .FirstOrDefault(e => e.ExamId == examId && e.ExamCode == code);
            if (exam == null)
            {
                MessageBox.Show("Invalid exam code");
                return;
            }

            var paper = exam.ExamPapers.FirstOrDefault(p => p.IsActive);
            if (paper == null)
            {
                MessageBox.Show("No active paper for this exam");
                return;
            }

            var attempt = _db.ExamAttempts
                .Include(a => a.Exam)
                .FirstOrDefault(a => a.ExamId == examId && a.StudentId == LoggedInUser.UserId);
            if (attempt == null)
            {
                attempt = new ExamAttempt
                {
                    ExamId = examId,
                    StudentId = LoggedInUser.UserId,
                    PaperId = paper.PaperId,
                    StartedAt = DateTime.UtcNow,
                    Status = "InProgress"
                };
                _db.ExamAttempts.Add(attempt);
                _db.SaveChanges();
                _db.Entry(attempt).Reference(a => a.Exam).Load();
            }

            using var examForm = new StudentExamTakeForm(_db, attempt);
            Hide();
            examForm.ShowDialog();
            Show();
        }
    }
}

