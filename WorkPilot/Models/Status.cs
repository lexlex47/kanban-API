using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkPilot.Models
{
    public class Status
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [ForeignKey("BoardId")]
        public Board Board { get; set; }
        public int BoardId { get; set; }

        public ICollection<Task> Tasks = new List<Task>();
    }
}
