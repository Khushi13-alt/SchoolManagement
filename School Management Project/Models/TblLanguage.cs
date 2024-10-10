using System;
using System.Collections.Generic;

namespace School_Management_Project.Models;

public partial class TblLanguage
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TblSubjectLanguage> TblSubjectLanguages { get; set; } = new List<TblSubjectLanguage>();
}
