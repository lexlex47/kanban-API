using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkPilot.Models.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }

        public int StatusId { get; set; }

        public ICollection<string> Tags { get; set; } = new List<string>();

        public int Order { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
