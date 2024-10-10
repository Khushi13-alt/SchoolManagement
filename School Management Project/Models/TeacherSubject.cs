using System;
using System.Collections.Generic;

namespace School_Management_Project.Models;

public partial class TeacherSubject
{
    public int TeacherSubjectId { get; set; }

    public int? TeacherId { get; set; }

    public int? SubjectId { get; set; }

    public virtual TblSubject? Subject { get; set; }

    public virtual TblTeacher? Teacher { get; set; }
}
