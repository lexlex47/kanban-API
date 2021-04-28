using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkPilot.Models.Dtos
{
    public class StatusDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Board Board { get; set; }
        public int BoardId { get; set; }

        public ICollection<Task> Tasks = new List<Task>();
    }
}
