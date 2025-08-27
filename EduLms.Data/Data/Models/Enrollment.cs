using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EduLms.Data.Data.Models;

[Index("ClassId", Name = "IX_Enrollments_ClassId")]
[Index("StudentId", Name = "IX_Enrollments_StudentId")]
[Index("StudentId", "ClassId", Name = "UQ_Enroll", IsUnique = true)]
public partial class Enrollment
{
    [Key]
    public int EnrollmentId { get; set; }

    public int StudentId { get; set; }

    public int ClassId { get; set; }

    public bool IsCurrent { get; set; }

    [Precision(3)]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("Enrollments")]
    public virtual Class Class { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("Enrollments")]
    public virtual User Student { get; set; } = null!;
}
