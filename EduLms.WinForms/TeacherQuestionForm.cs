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
        private string? _imagePath;
        public Question? CreatedQuestion { get; private set; }
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
            cmbType.Items.AddRange(new[] { "Single Choice", "Multiple Choice", "Essay" });
            cmbType.SelectedIndex = 0;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbSubjects.SelectedItem is not Subject subject)
            {
                MessageBox.Show("Please select a subject.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtQuestion.Text) && string.IsNullOrEmpty(_imagePath))
            {
                MessageBox.Show("Question text or image is required.");
                return;
            }

            var type = cmbType.SelectedItem?.ToString();
            var options = new List<Option>();
            if (type != "Essay")
            {
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

                var correctCount = options.Count(o => o.IsCorrect);
                if (type == "Single Choice" && correctCount != 1)
                {
                    MessageBox.Show("Single choice requires exactly one correct option.");
                    return;
                }
                if (type == "Multiple Choice" && correctCount == 0)
                {
                    MessageBox.Show("Multiple choice requires at least one correct option.");
                    return;
                }
            }

            var content = string.IsNullOrWhiteSpace(txtQuestion.Text) ? "[Image]" : txtQuestion.Text.Trim();
            var question = new Question
            {
                SubjectId = subject.SubjectId,
                Content = content,
                Difficulty = (byte)numDifficulty.Value,
                CreatedAt = DateTime.UtcNow
            };
            foreach (var opt in options)
            {
                question.Options.Add(opt);
            }
            _db.Questions.Add(question);
            await _db.SaveChangesAsync();
            CreatedQuestion = question;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridOptions.Visible = cmbType.SelectedItem?.ToString() != "Essay";
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _imagePath = dlg.FileName;
                picQuestion.ImageLocation = _imagePath;
            }
        }
    }
}
