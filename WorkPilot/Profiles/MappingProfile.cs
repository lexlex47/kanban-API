using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WorkPilot.Models;
using WorkPilot.Models.Dtos;

namespace WorkPilot.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Board, BoardDto>();
            CreateMap<Task, TaskDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<Status, StatusDto>();

            CreateMap<UserDto, User>()
                .ForMember(u => u.Id, opt => opt.Ignore());

            CreateMap<BoardDto, Board>()
                .ForMember(b => b.Id, opt => opt.Ignore());

            CreateMap<TaskDto, Task>()
                .ForMember(t => t.Id, opt => opt.Ignore());

            CreateMap<CommentDto, Comment>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<StatusDto, Status>()
                .ForMember(s => s.Id, opt => opt.Ignore());
        }
    }
}
