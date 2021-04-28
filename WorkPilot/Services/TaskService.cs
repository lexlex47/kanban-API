using System;
using System.Collections.Generic;
using System.Linq;
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
    public class TaskService
    {
        private ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task SelectTaskInDb(int statusId, int taskId)
        {
            return _context.Tasks
                           .Where(t => t.StatusId == statusId && t.Id == taskId)
                           .FirstOrDefault();
        }

        public int MaxTaksNumber(int statusId)
        {
            return _context.Tasks.Count(t => t.StatusId == statusId);
        }

        public Task GetTask(int taskId)
        {
            return _context.Tasks.Where(t => t.Id == taskId).SingleOrDefault();
        }

        public IEnumerable<Task> GetTasks(int statusId)
        {
            return _context.Tasks.Where(t => t.StatusId == statusId);
        }

        public Status GetStausFromTask(TaskDto taskDto)
        {
            return _context.Statuses.Single(s => s.Id == taskDto.StatusId);
        }

        public void AddTask(Status status, Task task)
        {
            status.Tasks.Add(task);
            SaveChange();
        }

        public void AddUserToTask(User user, Task task)
        {
            task.Users.Add(user);
            SaveChange();
        }

        public void AddTagToTask(string tag, Task task)
        {
            task.Tags.Add(tag);
            SaveChange();
        }

        public void RemoveTask(Task task)
        {
            _context.Tasks.Remove(task);
            SaveChange();
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
