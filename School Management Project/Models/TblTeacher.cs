using System;
using System.Collections.Generic;

namespace School_Management_Project.Models;

public partial class TblTeacher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Image { get; set; }

    public int Age { get; set; }

    public string Sex { get; set; } = null!;

    public virtual ICollection<TblSubject> TblSubjects { get; set; } = new List<TblSubject>();

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
}
