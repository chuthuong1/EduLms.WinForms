using EduLms.Data.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;

namespace EduLms.WinForms
{
    public partial class TeacherExamForm : Form
    {
        private readonly EduLmsContext _db;
        private readonly User _teacher;
        public TeacherExamForm(EduLmsContext db, User teacher)
        {
            InitializeComponent();
            _db = db;
            _teacher = teacher;
        }

        private async void TeacherExamForm_Load(object sender, EventArgs e)
        {
            var subjects = await _db.Subjects.AsNoTracking().ToListAsync();
            cmbSubject.DataSource = subjects;
            cmbSubject.DisplayMember = nameof(Subject.SubjectName);
            cmbSubject.ValueMember = nameof(Subject.SubjectId);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbSubject.SelectedItem is not Subject subject)
            {
                MessageBox.Show("Please select a subject.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title is required.");
                return;
            }
            var exam = new Exam
            {
                Title = txtTitle.Text.Trim(),
                SubjectId = subject.SubjectId,
                DurationMinutes = (int)numDuration.Value,
                StartAt = dtStart.Checked ? dtStart.Value : null,
                EndAt = dtEnd.Checked ? dtEnd.Value : null,
                CreatedByTeacherId = _teacher.UserId,
                MaxAttempts = (int)numMaxAttempts.Value,
                ShuffleOptions = chkShuffle.Checked,
                CreatedAt = DateTime.UtcNow
            };
            _db.Exams.Add(exam);
            await _db.SaveChangesAsync();
            MessageBox.Show("Exam saved!");
        }
    }
}
