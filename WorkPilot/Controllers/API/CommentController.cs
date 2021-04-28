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
    public class CommentController : Controller
    {
        private ICommentService _commentService;
        private Mapper _mapper;

        public CommentController(ICommentService commentService, Mapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpGet("{userId}", Name = "GetUser")]
        public ActionResult GetComment(int userId, int taskId, int commentId)
        {
            var comment = _commentService.SelectCommentInDb(userId, taskId, commentId);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Comment, CommentDto>(comment));
        }

        [HttpPost]
        public ActionResult CreateComment(CommentDto commentDto)
        {
            var task = _commentService.GetTaskFromComment(commentDto);
            if (task == null)
            {
                return NotFound();
            }

            var comment = _mapper.Map<CommentDto, Comment>(commentDto);

            _commentService.AddComment(task, comment);

            commentDto.Id = comment.Id;
            return Created("GetComment", commentDto);
        }

        [HttpDelete]
        public ActionResult DeleteComment(int userId, int taskId, int commentId)
        {
            var comment = _commentService.SelectCommentInDb(userId, taskId, commentId);
            if (comment == null)
            {
                return NotFound();
            }
            _commentService.RemoveComment(comment);
            return Ok();
        }
    }
}
