using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkPilot.Models
{
    public class Board
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Board Name")]
        public string Name { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }

        public ICollection<Status> Statuses = new List<Status>();
    }
}
