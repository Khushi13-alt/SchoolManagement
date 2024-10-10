using System;
using System.Collections.Generic;

namespace School_Management_Project.Models;

public partial class TblSubjectLanguage
{
    public int SubjectLanguageId { get; set; }

    public int SubjectId { get; set; }

    public int LanguageId { get; set; }

    public virtual TblLanguage Language { get; set; } = null!;

    public virtual TblSubject Subject { get; set; } = null!;
}
