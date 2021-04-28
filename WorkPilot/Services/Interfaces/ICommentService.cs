using System;
using System.Collections.Generic;
using System.Linq;
using WorkPilot.Models.Dtos;
using WorkPilot.Models;

namespace WorkPilot.Services.Interfaces
{
    public interface ICommentService
    {
        Comment SelectCommentInDb(int userId, int taskId, int commentId);
        Task GetTaskFromComment(CommentDto commentDto);
        void AddComment(Task task, Comment comment);
        void RemoveComment(Comment comment);
    }
}
