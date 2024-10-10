using System;
using System.Collections.Generic;

namespace School_Management_Project.Models;

public partial class TblSubject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Class { get; set; } = null!;

    public int? TeacherId { get; set; }

    public virtual ICollection<TblSubjectLanguage> TblSubjectLanguages { get; set; } = new List<TblSubjectLanguage>();

    public virtual TblTeacher? Teacher { get; set; }

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
}
