using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EduLms.Data.Data.Models;

[Index("SubjectId", Name = "IX_Questions_SubjectId")]
public partial class Question
{
    [Key]
    public int QuestionId { get; set; }

    public int SubjectId { get; set; }

    public string Content { get; set; } = null!;

    public byte? Difficulty { get; set; }

    [Precision(3)]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("Question")]
    public virtual ICollection<ExamPaperQuestion> ExamPaperQuestions { get; set; } = new List<ExamPaperQuestion>();

    [InverseProperty("Question")]
    public virtual ICollection<Option> Options { get; set; } = new List<Option>();

    [InverseProperty("Question")]
    public virtual ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();

    [ForeignKey("SubjectId")]
    [InverseProperty("Questions")]
    public virtual Subject Subject { get; set; } = null!;
}
