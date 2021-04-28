using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkPilot.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Content { get; set; }

        [ForeignKey("TaskId")]
        public Task Task { get; set; }
        public int TaskId { get; set; }

        [Required]
        public User User { get; set; }
    }
}
