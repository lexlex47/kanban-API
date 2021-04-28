using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkPilot.Models.Dtos
{
    public class BoardDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public ICollection<Status> Statuses = new List<Status>();
    }
}
