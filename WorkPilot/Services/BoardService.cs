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
    public class BoardService : IBoardService
    {
        private ApplicationDbContext _context;

        public BoardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Board SelectBoardInDb(int userId, int boardId)
        {
            return _context.Boards
                           .Where(b => b.UserId == userId && b.Id == boardId)
                           .FirstOrDefault();
        }

        public IEnumerable<Board> GetBoards(int userId)
        {
            return _context.Boards.Where(u => u.Id == userId);
        }

        public User GetUserFromBoard(BoardDto boardDto)
        {
            return _context.Users.Single(u => u.Id == boardDto.UserId);
        }

        public void AddBoard(Board board)
        {
            _context.Boards.Add(board);
            SaveChange();
        }

        public void RemoveBoard(Board board)
        {
            _context.Boards.Remove(board);
            SaveChange();
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
