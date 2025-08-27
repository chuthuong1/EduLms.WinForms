using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EduLms.Data.Data.Models;

[PrimaryKey("AttemptId", "QuestionId")]
[Index("AttemptId", Name = "IX_SA_Attempt")]
[Index("QuestionId", Name = "IX_SA_Question")]
public partial class StudentAnswer
{
    [Key]
    public int AttemptId { get; set; }

    [Key]
    public int QuestionId { get; set; }

    public int? OptionId { get; set; }

    [Precision(3)]
    public DateTime? AnsweredAt { get; set; }

    [ForeignKey("AttemptId")]
    [InverseProperty("StudentAnswers")]
    public virtual ExamAttempt Attempt { get; set; } = null!;

    [ForeignKey("OptionId")]
    [InverseProperty("StudentAnswers")]
    public virtual Option? Option { get; set; }

    [ForeignKey("QuestionId")]
    [InverseProperty("StudentAnswers")]
    public virtual Question Question { get; set; } = null!;
}
