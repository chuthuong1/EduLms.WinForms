using EduLms.Data.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EduLms.WinForms
{
    public partial class TeacherExamForm : Form
    {
        private readonly EduLmsContext _db;
        private readonly User _teacher;
        private readonly List<Question> _questions = new();
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
            gridQuestions.AutoGenerateColumns = true;
            gridQuestions.DataSource = _questions;
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
            if (!_questions.Any())
            {
                MessageBox.Show("Please add at least one question.");
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

            var paper = new ExamPaper
            {
                ExamId = exam.ExamId,
                PaperCode = "1",
                IsActive = true
            };
            _db.ExamPapers.Add(paper);
            await _db.SaveChangesAsync();

            int ordinal = 1;
            foreach (var q in _questions)
            {
                _db.ExamPaperQuestions.Add(new ExamPaperQuestion
                {
                    PaperId = paper.PaperId,
                    QuestionId = q.QuestionId,
                    Ordinal = ordinal++
                });
            }
            await _db.SaveChangesAsync();

            MessageBox.Show("Exam saved!");
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            using var frm = new TeacherQuestionForm(_db);
            if (frm.ShowDialog() == DialogResult.OK && frm.CreatedQuestion != null)
            {
                _questions.Add(frm.CreatedQuestion);
                gridQuestions.DataSource = null;
                gridQuestions.DataSource = _questions.Select(q => new { q.QuestionId, q.Content }).ToList();
            }
        }
    }
}
