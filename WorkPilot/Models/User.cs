using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WorkPilot.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? Birthday { get; set; }

        public ICollection<Board> Boards { get; set; } = new List<Board>();
    }
}
