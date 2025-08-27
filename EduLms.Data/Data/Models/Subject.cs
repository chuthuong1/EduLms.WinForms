using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EduLms.Data.Data.Models;

[Index("SubjectName", Name = "UQ__Subjects__4C5A7D552352CD2A", IsUnique = true)]
public partial class Subject
{
    [Key]
    public int SubjectId { get; set; }

    [StringLength(50)]
    public string SubjectName { get; set; } = null!;

    [Precision(3)]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("Subject")]
    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    [InverseProperty("Subject")]
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    [InverseProperty("Subject")]
    public virtual ICollection<TeachingAssignment> TeachingAssignments { get; set; } = new List<TeachingAssignment>();
}
