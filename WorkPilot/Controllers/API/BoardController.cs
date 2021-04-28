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
    public class BoardController : Controller
    {
        private IBoardService _boardService;
        private Mapper _mapper;

        public BoardController(IBoardService boardService, Mapper mapper)
        {
            _boardService = boardService;
            _mapper = mapper;
        }

        [HttpGet("{boardId}",Name = "GetBoard")]
        public ActionResult GetBoard(int userId, int boardId)
        {
            var board = _boardService.SelectBoardInDb(userId, boardId);
            if (board == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Board, BoardDto>(board));
        }

        [HttpGet]
        public ActionResult GetBoardsInUser(int userId)
        {
            var boards = _boardService.GetBoards(userId);
            return Ok(_mapper.Map<IEnumerable<Board>>(boards));
        }

        [HttpPost]
        public ActionResult CreateBoard(BoardDto boardDto)
        {
            var user = _boardService.GetUserFromBoard(boardDto);
            if (user == null)
            {
                return NotFound();
            }

            var board = _mapper.Map<BoardDto, Board>(boardDto);
            _boardService.AddBoard(board);

            boardDto.Id = board.Id;
            return Created("GetUser", boardDto);
        }

        [HttpPatch("{boardId}")]
        public ActionResult UpdateBoardName(int userId, int boardId, BoardDto boardDto)
        {
            var board = _boardService.SelectBoardInDb(userId, boardId);
            if (board == null)
            {
                return NotFound();
            }
            _mapper.Map(boardDto, board);
            _boardService.SaveChange();
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteBoard(int userId, int boardId)
        {
            var board = _boardService.SelectBoardInDb(userId, boardId);
            if (board == null)
            {
                return NotFound();
            }
            _boardService.RemoveBoard(board);
            return Ok();
        }

    }
}
