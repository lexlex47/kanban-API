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

namespace WorkPilot.Controllers.API
{
    public class UserController : Controller
    {   

        private Mapper _mapper;
        private IUserService _userService;

        public UserController(IUserService userService, Mapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("{userId}",Name = "GetUser")]
        public ActionResult GetUser(int userId)
        {
            var user = _userService.SelectUserInDb(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<User, UserDto>(user));
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
        }

        [HttpPost]
        public ActionResult CreateUser(UserDto userDto)
        {
            var user = _mapper.Map<UserDto, User>(userDto);
            _userService.AddUser(user);

            userDto.Id = user.Id;
            return Created("GetUser", userDto);
        }

        [HttpPut]
        public ActionResult UpdateUser(int userId, UserDto userDto)
        {
            var user = _userService.SelectUserInDb(userId);
            if (user == null)
            {
                return NotFound();
            }
            _mapper.Map(userDto, user);
            _userService.SaveChange();
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteUser(int userId)
        {
            var user = _userService.SelectUserInDb(userId);
            if (user == null)
            {
                return NotFound();
            }
            _userService.RemoveUser(user);
            return Ok();
        }

    }
}
