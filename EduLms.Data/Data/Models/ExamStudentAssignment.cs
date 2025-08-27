using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EduLms.Data.Data.Models;

[Index("ExamId", "StudentId", Name = "UQ_ExamStudent", IsUnique = true)]
public partial class ExamStudentAssignment
{
    [Key]
    public int AssignmentId { get; set; }

    public int ExamId { get; set; }

    public int StudentId { get; set; }

    public int? PreassignedPaperId { get; set; }

    [Precision(3)]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("ExamId")]
    [InverseProperty("ExamStudentAssignments")]
    public virtual Exam Exam { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("ExamStudentAssignments")]
    public virtual User Student { get; set; } = null!;
}
