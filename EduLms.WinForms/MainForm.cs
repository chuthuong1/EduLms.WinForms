using EduLms.Data;
using EduLms.Data.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EduLms.WinForms
{
    public partial class MainForm : Form
    {
        private readonly EduLmsContext _db;
        public User? LoggedInUser { get; set; }
        public MainForm(EduLmsContext db)
        {
            InitializeComponent();
            _db = db;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            var classes = await _db.Classes.AsNoTracking().ToListAsync();
            gridClasses.DataSource = classes;

            var subjects = await _db.Subjects.AsNoTracking().ToListAsync();
            gridSubjects.DataSource = subjects;

            var scores = await _db.ExamAttempts
                .AsNoTracking()
                .Include(a => a.Student)
                .Include(a => a.Exam)
                .Select(a => new
                {
                    a.AttemptId,
                    Student = a.Student.FullName,
                    Exam = a.Exam.Title,
                    a.Score
                })
                .ToListAsync();
            gridScores.DataSource = scores;
        }

        private void btnCreateExam_Click(object sender, EventArgs e)
        {
            if (LoggedInUser == null)
            {
                MessageBox.Show("Missing teacher information.");
                return;
            }
            using var frm = new TeacherExamForm(_db, LoggedInUser);
            frm.ShowDialog();
        }
    }
}
