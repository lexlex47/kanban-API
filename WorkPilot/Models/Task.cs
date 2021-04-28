using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkPilot.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Display(Name = "Status")]
        [Required]
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
        public int StatusId { get; set; }

        public ICollection<string> Tags { get; set; } = new List<string>();

        [Display(Name = "Order")]
        [Required]
        public int Order { get; set; }

        public DateTime DateAdded { get; set; }
        
        [Display(Name = "Start Time")]
        [Required]
        public DateTime DateStart { get; set; }

        [Display(Name = "End Time")]
        [Required]
        public DateTime DateEnd { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
