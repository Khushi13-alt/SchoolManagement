using System;
using System.Collections.Generic;

namespace School_Management_Project.Models;

public partial class TblStudent
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string Class { get; set; } = null!;

    public string? Image { get; set; }

    public string Rollnumber { get; set; } = null!;
}
