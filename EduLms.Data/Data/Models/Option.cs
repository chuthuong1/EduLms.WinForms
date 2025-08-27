using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EduLms.Data.Data.Models;

[Index("QuestionId", Name = "IX_Options_QuestionId")]
public partial class Option
{
    [Key]
    public int OptionId { get; set; }

    public int QuestionId { get; set; }

    public string Content { get; set; } = null!;

    public bool IsCorrect { get; set; }

    [ForeignKey("QuestionId")]
    [InverseProperty("Options")]
    public virtual Question Question { get; set; } = null!;

    [InverseProperty("Option")]
    public virtual ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();
}
