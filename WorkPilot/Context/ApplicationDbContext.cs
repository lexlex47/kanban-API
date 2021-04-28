using System;
using System.Collections.Generic;
using System.Linq;
using WorkPilot.Models;
using Microsoft.EntityFrameworkCore;

namespace WorkPilot.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public ApplicationDbContext() : base()
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
