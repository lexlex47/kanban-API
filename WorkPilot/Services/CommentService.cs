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
    public class CommentService : ICommentService
    {
        private ApplicationDbContext _context;

        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Comment SelectCommentInDb(int userId, int taskId, int commentId)
        {
            return _context.Comments
                           .Where(c => c.TaskId == taskId
                                       && c.User.Id == userId
                                       && c.Id == commentId)
                           .FirstOrDefault();
        }

        public Task GetTaskFromComment(CommentDto commentDto)
        {
            return _context.Tasks.Single(t => t.Id == commentDto.TaskId);
        }

        public void AddComment(Task task, Comment comment)
        {
            task.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void RemoveComment(Comment comment)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }
    }
}
