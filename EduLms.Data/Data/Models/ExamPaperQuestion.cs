using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EduLms.Data.Data.Models;

[PrimaryKey("PaperId", "QuestionId")]
[Index("PaperId", Name = "IX_EPQ_Paper")]
[Index("QuestionId", Name = "IX_EPQ_Question")]
public partial class ExamPaperQuestion
{
    [Key]
    public int PaperId { get; set; }

    [Key]
    public int QuestionId { get; set; }

    public int Ordinal { get; set; }

    [ForeignKey("PaperId")]
    [InverseProperty("ExamPaperQuestions")]
    public virtual ExamPaper Paper { get; set; } = null!;

    [ForeignKey("QuestionId")]
    [InverseProperty("ExamPaperQuestions")]
    public virtual Question Question { get; set; } = null!;
}
