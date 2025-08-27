using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EduLms.Data.Data.Models;

[Index("SubjectId", Name = "IX_Exams_SubjectId")]
[Index("StartAt", "EndAt", Name = "IX_Exams_Time")]
public partial class Exam
{
    [Key]
    public int ExamId { get; set; }

    [StringLength(200)]
    public string Title { get; set; } = null!;

    public int SubjectId { get; set; }

    public int DurationMinutes { get; set; }

    [Precision(3)]
    public DateTime? StartAt { get; set; }

    [Precision(3)]
    public DateTime? EndAt { get; set; }

    public int CreatedByTeacherId { get; set; }

    public int MaxAttempts { get; set; }

    public bool ShuffleOptions { get; set; }

    [Precision(3)]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("CreatedByTeacherId")]
    [InverseProperty("Exams")]
    public virtual User CreatedByTeacher { get; set; } = null!;

    [InverseProperty("Exam")]
    public virtual ICollection<ExamAttempt> ExamAttempts { get; set; } = new List<ExamAttempt>();

    [InverseProperty("Exam")]
    public virtual ICollection<ExamPaper> ExamPapers { get; set; } = new List<ExamPaper>();

    [InverseProperty("Exam")]
    public virtual ICollection<ExamStudentAssignment> ExamStudentAssignments { get; set; } = new List<ExamStudentAssignment>();

    [ForeignKey("SubjectId")]
    [InverseProperty("Exams")]
    public virtual Subject Subject { get; set; } = null!;

    [ForeignKey("ExamId")]
    [InverseProperty("Exams")]
    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
