using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkPilot.Models.Dtos;
using WorkPilot.Models;

namespace WorkPilot.Services.Interfaces
{
    public interface IUserService
    {
        User SelectUserInDb(int id);
        IEnumerable<User> GetUsers();
        void AddUser(User user);
        void RemoveUser(User user);
        void SaveChange();
    }
}
