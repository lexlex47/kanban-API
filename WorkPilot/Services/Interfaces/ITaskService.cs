using System;
using System.Collections.Generic;
using System.Linq;
using WorkPilot.Models.Dtos;
using WorkPilot.Models;

namespace WorkPilot.Services.Interfaces
{
    public interface ITaskService
    {
        Task SelectTaskInDb(int statusId, int taskId);
        int MaxTaksNumber(int statusId);
        IEnumerable<Task> GetTasks(int statusId);
        Status GetStausFromTask(TaskDto taskDto);
        void AddTask(Status status, Task task);
        Task GetTask(int taskId);
        void AddUserToTask(User user, Task task);
        void AddTagToTask(string tag, Task task);
        void RemoveTask(Task task);
        void SaveChange();
    }
}
