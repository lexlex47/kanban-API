using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkPilot.Models.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public Task Task { get; set; }
        public int TaskId { get; set; }

        public User User { get; set; }
    }
}
