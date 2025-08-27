using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EduLms.Data.Data.Models;

[PrimaryKey("TeacherId", "ClassId", "SubjectId")]
public partial class TeachingAssignment
{
    [Key]
    public int TeacherId { get; set; }

    [Key]
    public int ClassId { get; set; }

    [Key]
    public int SubjectId { get; set; }

    [Precision(3)]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("TeachingAssignments")]
    public virtual Class Class { get; set; } = null!;

    [ForeignKey("SubjectId")]
    [InverseProperty("TeachingAssignments")]
    public virtual Subject Subject { get; set; } = null!;

    [ForeignKey("TeacherId")]
    [InverseProperty("TeachingAssignments")]
    public virtual User Teacher { get; set; } = null!;
}
