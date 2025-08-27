using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EduLms.Data.Data.Models;

public partial class EduLmsContext : DbContext
{
    public EduLmsContext()
    {
    }

    public EduLmsContext(DbContextOptions<EduLmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<ExamAttempt> ExamAttempts { get; set; }

    public virtual DbSet<ExamPaper> ExamPapers { get; set; }

    public virtual DbSet<ExamPaperQuestion> ExamPaperQuestions { get; set; }

    public virtual DbSet<ExamStudentAssignment> ExamStudentAssignments { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<StudentAnswer> StudentAnswers { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<TeachingAssignment> TeachingAssignments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-KDOE91F\\TINO;Database=EduLMSTest;User Id=sa;Password=123456;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Classes__CB1927C0F7DC6C01");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__Enrollme__7F68771BB4F80C0C");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.IsCurrent).HasDefaultValue(true);

            entity.HasOne(d => d.Class).WithMany(p => p.Enrollments).HasConstraintName("FK_Enroll_Class");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments).HasConstraintName("FK_Enroll_Student");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.ExamId).HasName("PK__Exams__297521C7BDF73878");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.MaxAttempts).HasDefaultValue(1);
            entity.Property(e => e.ShuffleOptions).HasDefaultValue(true);
            entity.Property(e => e.ExamCode).HasMaxLength(20);
            entity.HasIndex(e => e.ExamCode).IsUnique().HasDatabaseName("IX_Exams_ExamCode");

            entity.HasOne(d => d.CreatedByTeacher).WithMany(p => p.Exams)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exams_Creator");

            entity.HasOne(d => d.Subject).WithMany(p => p.Exams)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exams_Subject");

            entity.HasMany(d => d.Classes).WithMany(p => p.Exams)
                .UsingEntity<Dictionary<string, object>>(
                    "ExamScope",
                    r => r.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassId")
                        .HasConstraintName("FK_ExamScopes_Class"),
                    l => l.HasOne<Exam>().WithMany()
                        .HasForeignKey("ExamId")
                        .HasConstraintName("FK_ExamScopes_Exam"),
                    j =>
                    {
                        j.HasKey("ExamId", "ClassId");
                        j.ToTable("ExamScopes");
                    });
        });

        modelBuilder.Entity<ExamAttempt>(entity =>
        {
            entity.HasKey(e => e.AttemptId).HasName("PK__ExamAtte__891A68E67D213BEE");

            entity.Property(e => e.StartedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Status).HasDefaultValue("Started");

            entity.HasOne(d => d.Exam).WithMany(p => p.ExamAttempts).HasConstraintName("FK_Attempts_Exam");

            entity.HasOne(d => d.Paper).WithMany(p => p.ExamAttempts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attempts_Paper");

            entity.HasOne(d => d.Student).WithMany(p => p.ExamAttempts).HasConstraintName("FK_Attempts_Student");
        });

        modelBuilder.Entity<ExamPaper>(entity =>
        {
            entity.HasKey(e => e.PaperId).HasName("PK__ExamPape__AB86120B55DB8712");

            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Exam).WithMany(p => p.ExamPapers).HasConstraintName("FK_Papers_Exam");
        });

        modelBuilder.Entity<ExamPaperQuestion>(entity =>
        {
            entity.HasOne(d => d.Paper).WithMany(p => p.ExamPaperQuestions).HasConstraintName("FK_EPQ_Paper");

            entity.HasOne(d => d.Question).WithMany(p => p.ExamPaperQuestions).HasConstraintName("FK_EPQ_Question");
        });

        modelBuilder.Entity<ExamStudentAssignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__ExamStud__32499E77B6B25648");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Exam).WithMany(p => p.ExamStudentAssignments).HasConstraintName("FK_ESA_Exam");

            entity.HasOne(d => d.Student).WithMany(p => p.ExamStudentAssignments).HasConstraintName("FK_ESA_Student");
        });

        modelBuilder.Entity<Option>(entity =>
        {
            entity.HasKey(e => e.OptionId).HasName("PK__Options__92C7A1FFB6B230AD");

            entity.HasOne(d => d.Question).WithMany(p => p.Options).HasConstraintName("FK_Options_Question");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Question__0DC06FAC948530A1");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Subject).WithMany(p => p.Questions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Questions_Subject");
        });

        modelBuilder.Entity<StudentAnswer>(entity =>
        {
            entity.HasOne(d => d.Attempt).WithMany(p => p.StudentAnswers).HasConstraintName("FK_SA_Attempt");

            entity.HasOne(d => d.Option).WithMany(p => p.StudentAnswers).HasConstraintName("FK_SA_Option");

            entity.HasOne(d => d.Question).WithMany(p => p.StudentAnswers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SA_Question");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subjects__AC1BA3A86D214639");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
        });

        modelBuilder.Entity<TeachingAssignment>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Class).WithMany(p => p.TeachingAssignments).HasConstraintName("FK_TA_Class");

            entity.HasOne(d => d.Subject).WithMany(p => p.TeachingAssignments).HasConstraintName("FK_TA_Subject");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeachingAssignments).HasConstraintName("FK_TA_Teacher");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C88C94AC4");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
