
using EduLms.Data.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;

namespace EduLms.WinForms
{
    public partial class LoginForm : Form
    {
        private readonly EduLmsContext _db;
        public User? LoggedInUser { get; private set; }
        public LoginForm(EduLmsContext db)
        {
            InitializeComponent();
            _db = db;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text;
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Email and password are required.");
                return;
            }
            var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
            if (user == null || user.PasswordHash != password)
            {
                MessageBox.Show("Invalid credentials.");
                return;
            }
            LoggedInUser = user;
            MessageBox.Show("Login successful!");
            DialogResult = DialogResult.OK;
        }
    }
}
