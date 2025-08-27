using EduLms.Data;
using EduLms.Data.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EduLms.WinForms
{
    public partial class MainForm : Form
    {
        private readonly EduLmsContext _db;
        public MainForm(EduLmsContext db)
        {
            InitializeComponent();
            _db = db;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            // ví dụ: nạp danh sách Users ra DataGridView
            var users = await _db.Users.AsNoTracking().Take(100).ToListAsync();
            dataGridView1.DataSource = users;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User
            {
                FullName = txtName.Text,
                Email = txtEmail.Text,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
            _db.Users.Add(u);
            await _db.SaveChangesAsync();
            MessageBox.Show("Saved!");
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            using var frm = new LoginForm(_db);
            frm.ShowDialog();
        }
    }
}
