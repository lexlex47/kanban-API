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
    public class StatusService : IStatusService
    {
        private ApplicationDbContext _context;

        public StatusService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Status SelectStatusInDb(int boardId, int statusId)
        {
            return _context.Statuses
                           .Where(s => s.BoardId == boardId && s.Id == statusId)
                           .FirstOrDefault();
        }

        public IEnumerable<Status> GetStatusesInBoard(int boardId)
        {
            return _context.Statuses.Where(u => u.Id == boardId);
        }

        public Board GetBoardFromStatus(StatusDto statusDto)
        {
            return _context.Boards.Single(b => b.Id == statusDto.BoardId);
        }

        public void AddStatus(Board board, Status status)
        {
            board.Statuses.Add(status);
            SaveChange();
        }

        public void RemoveStatus(Status status)
        {
            _context.Statuses.Remove(status);
            SaveChange();
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
