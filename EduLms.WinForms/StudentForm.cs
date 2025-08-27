using EduLms.Data.Data.Models;
using System.Windows.Forms;

namespace EduLms.WinForms
{
    public partial class StudentForm : Form
    {
        private readonly EduLmsContext _db;
        public StudentForm(EduLmsContext db)
        {
            InitializeComponent();
            _db = db;
        }
    }
}

