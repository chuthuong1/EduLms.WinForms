using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EduLms.Data.Data.Models;

[Index("ClassName", "SchoolYear", Name = "UX_Classes_NameYear", IsUnique = true)]
public partial class Class
{
    [Key]
    public int ClassId { get; set; }

    [StringLength(50)]
    public string ClassName { get; set; } = null!;

    public byte Grade { get; set; }

    [StringLength(9)]
    public string SchoolYear { get; set; } = null!;

    [Precision(3)]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("Class")]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    [InverseProperty("Class")]
    public virtual ICollection<TeachingAssignment> TeachingAssignments { get; set; } = new List<TeachingAssignment>();

    [ForeignKey("ClassId")]
    [InverseProperty("Classes")]
    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
}
