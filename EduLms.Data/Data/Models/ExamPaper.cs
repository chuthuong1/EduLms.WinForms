using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EduLms.Data.Data.Models;

[Index("ExamId", Name = "IX_ExamPapers_ExamId")]
[Index("ExamId", "PaperCode", Name = "UX_Papers_Exam_Code", IsUnique = true)]
public partial class ExamPaper
{
    [Key]
    public int PaperId { get; set; }

    public int ExamId { get; set; }

    [StringLength(20)]
    public string PaperCode { get; set; } = null!;

    public bool IsActive { get; set; }

    [ForeignKey("ExamId")]
    [InverseProperty("ExamPapers")]
    public virtual Exam Exam { get; set; } = null!;

    [InverseProperty("Paper")]
    public virtual ICollection<ExamAttempt> ExamAttempts { get; set; } = new List<ExamAttempt>();

    [InverseProperty("Paper")]
    public virtual ICollection<ExamPaperQuestion> ExamPaperQuestions { get; set; } = new List<ExamPaperQuestion>();
}
