using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkPilot.Models.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<BoardDto> Boards { get; set; } = new List<BoardDto>();
    }
}
