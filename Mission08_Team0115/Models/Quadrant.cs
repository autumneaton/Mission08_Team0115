using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0115.Models;

public partial class Quadrant
{
    public int Key { get; set; }

    [Required]
    public string Task { get; set; }

    public string? DueDate { get; set; }

    public int Quadrant1 { get; set; }

    public string? Category { get; set; }

    public int Completed { get; set; }
}
