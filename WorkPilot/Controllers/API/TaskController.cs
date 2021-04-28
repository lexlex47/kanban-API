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

namespace WorkPilot.Controllers.API
{
    public class TaskController : Controller
    {

        private ITaskService _taskService;
        private IUserService _userService;
        private Mapper _mapper;

        public TaskController(ITaskService taskService, IUserService userService, Mapper mapper)
        {
            _taskService = taskService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("{taskId}", Name = "GetTask")]
        public ActionResult GetTask(int statusId, int taskId)
        {
            var task = _taskService.SelectTaskInDb(statusId, taskId);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Task, TaskDto>(task));
        }

        [HttpGet]
        public ActionResult GetTasksInStatus(int statusId)
        {
            var tasks = _taskService.GetTasks(statusId);
            return Ok(_mapper.Map<IEnumerable<Task>>(tasks));
        }

        [HttpPost]
        public ActionResult CreateTask(TaskDto taskDto)
        {
            var status = _taskService.GetStausFromTask(taskDto);
            if (status == null)
            {
                return NotFound();
            }

            //set start order
            taskDto.Order = _taskService.MaxTaksNumber(status.Id);

            var task = _mapper.Map<TaskDto, Task>(taskDto);

            _taskService.AddTask(status, task);

            taskDto.Id = task.Id;
            return Created("GetTask", taskDto);
        }

        [HttpPut]
        public ActionResult UpdateTask(int statusId, int taskId, TaskDto taskDto)
        {
            var task = _taskService.SelectTaskInDb(statusId, taskId);
            if (task == null)
            {
                return NotFound();
            }
            _mapper.Map(taskDto, task);
            _taskService.SaveChange();
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteTask(int statusId, int taskId)
        {
            var task = _taskService.SelectTaskInDb(statusId, taskId);
            if (task == null)
            {
                return NotFound();
            }
            _taskService.RemoveTask(task);
            return Ok();
        }

        [HttpPost]
        public ActionResult AddUserToTask(int taskId, int userId)
        {
            var task = _taskService.GetTask(taskId);
            var user = _userService.SelectUserInDb(userId);
            if (task == null || user == null)
            {
                return NotFound();
            }
            _taskService.AddUserToTask(user, task);
            return Ok();
        }

        [HttpPost]
        public ActionResult AddTagToTask(int taskId, string tag)
        {
            var task = _taskService.GetTask(taskId);
            if (task == null)
            {
                return NotFound();
            }
            if (tag == null)
            {
                return NoContent();
            }
            _taskService.AddTagToTask(tag, task);
            return Ok();
        }

        //For drag task and swap order purpose
        [HttpPut]
        public ActionResult UpdateTaskOrder(int current_taskId, int target_taskId)
        {
            var current_task = _taskService.GetTask(current_taskId);
            var target_task = _taskService.GetTask(target_taskId);
            if (current_task == null || target_task == null)
            {
                return NotFound();
            }
            (current_task.Order, target_task.Order) = (target_task.Order, current_task.Order);
            _taskService.SaveChange();
            return Ok();
        }

    }
}
