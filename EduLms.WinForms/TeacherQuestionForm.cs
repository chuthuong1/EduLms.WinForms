using EduLms.Data.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EduLms.WinForms
{
    public partial class TeacherQuestionForm : Form
    {
        private readonly EduLmsContext _db;
        public TeacherQuestionForm(EduLmsContext db)
        {
            InitializeComponent();
            _db = db;
        }

        private async void TeacherQuestionForm_Load(object sender, EventArgs e)
        {
            var subjects = await _db.Subjects.AsNoTracking().ToListAsync();
            cmbSubjects.DataSource = subjects;
            cmbSubjects.DisplayMember = nameof(Subject.SubjectName);
            cmbSubjects.ValueMember = nameof(Subject.SubjectId);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbSubjects.SelectedItem is not Subject subject)
            {
                MessageBox.Show("Please select a subject.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                MessageBox.Show("Question text is required.");
                return;
            }

            var options = new List<Option>();
            foreach (DataGridViewRow row in gridOptions.Rows)
            {
                if (row.IsNewRow) continue;
                var content = row.Cells["colContent"].Value?.ToString();
                var isCorrectObj = row.Cells["colIsCorrect"].Value;
                var isCorrect = isCorrectObj != null && (bool)isCorrectObj;
                if (string.IsNullOrWhiteSpace(content))
                {
                    MessageBox.Show("All option texts are required.");
                    return;
                }
                options.Add(new Option { Content = content, IsCorrect = isCorrect });
            }

            if (!options.Any(o => o.IsCorrect))
            {
                MessageBox.Show("At least one option must be marked correct.");
                return;
            }

            var question = new Question
            {
                SubjectId = subject.SubjectId,
                Content = txtQuestion.Text.Trim(),
                Difficulty = (byte)numDifficulty.Value,
                CreatedAt = DateTime.UtcNow
            };
            foreach (var opt in options)
            {
                question.Options.Add(opt);
            }
            _db.Questions.Add(question);
            await _db.SaveChangesAsync();
            MessageBox.Show("Saved!");
        }
    }
}
