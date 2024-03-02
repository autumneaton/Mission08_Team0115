using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0115.Models;

public partial class Quadrant
{
    [Key]
    public int Key { get; set; }

    [Required]
    public string? Task { get; set; }

    public string? DueDate { get; set; }

    public int Quadrant1 { get; set; }

    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
    public TaskCategory? Category { get; set; }

    public bool Completed { get; set; }
}
