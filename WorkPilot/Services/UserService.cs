using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WorkPilot.Models;
using WorkPilot.Models.Dtos;
using WorkPilot.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Web.Http;
using WorkPilot.Services.Interfaces;
using System.Data.Entity;

namespace WorkPilot.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _context;
  
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User SelectUserInDb(int id)
        {
            var users = _context.Users.ToList();

            return users.SingleOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            SaveChange();
        }

        public void RemoveUser(User user)
        {
            _context.Users.Remove(user);
            SaveChange();
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
