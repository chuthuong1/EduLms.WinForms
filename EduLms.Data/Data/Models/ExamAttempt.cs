using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EduLms.Data.Data.Models;

[Index("ExamId", Name = "IX_Attempts_Exam")]
[Index("ExamId", "StudentId", Name = "IX_Attempts_Exam_Student")]
[Index("StudentId", Name = "IX_Attempts_Student")]
[Index("ExamId", "StudentId", Name = "UQ_Attempt", IsUnique = true)]
public partial class ExamAttempt
{
    [Key]
    public int AttemptId { get; set; }

    public int ExamId { get; set; }

    public int StudentId { get; set; }

    public int PaperId { get; set; }

    [Precision(3)]
    public DateTime StartedAt { get; set; }

    [Precision(3)]
    public DateTime? SubmittedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? Score { get; set; }

    [ForeignKey("ExamId")]
    [InverseProperty("ExamAttempts")]
    public virtual Exam Exam { get; set; } = null!;

    [ForeignKey("PaperId")]
    [InverseProperty("ExamAttempts")]
    public virtual ExamPaper Paper { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("ExamAttempts")]
    public virtual User Student { get; set; } = null!;

    [InverseProperty("Attempt")]
    public virtual ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();
}
