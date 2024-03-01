using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0115.Models
{
    public class TaskCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}
