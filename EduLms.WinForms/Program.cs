using EduLms.Data;
using EduLms.Data.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows.Forms;
namespace EduLms.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(cfg =>
                {
                    cfg.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((ctx, services) =>
                {
                    var cs = ctx.Configuration.GetConnectionString("EduLms");
                    services.AddDbContext<EduLmsContext>(opt =>
                        opt.UseSqlServer(cs));
                    // Đăng ký Form dùng DI
                    services.AddTransient<LoginForm>();
                    services.AddTransient<MainForm>();
                    services.AddTransient<StudentForm>();
                })
                .Build();

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            ApplicationConfiguration.Initialize();
            var login = services.GetRequiredService<LoginForm>();
            if (login.ShowDialog() == DialogResult.OK && login.LoggedInUser != null)
            {
                var role = login.LoggedInUser.Role;
                if (string.Equals(role, "Teacher", StringComparison.OrdinalIgnoreCase))
                {
                    var main = services.GetRequiredService<MainForm>();
                    Application.Run(main);
                }
                else if (string.Equals(role, "Student", StringComparison.OrdinalIgnoreCase))
                {
                    var student = services.GetRequiredService<StudentForm>();
                    Application.Run(student);
                }
                else
                {
                    MessageBox.Show($"Role '{role}' is not supported.");
                }
            }
        }
    }
}