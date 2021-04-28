using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkPilot.Models.Dtos;
using WorkPilot.Models;

namespace WorkPilot.Services.Interfaces
{
    public interface IBoardService
    {
        Board SelectBoardInDb(int userId, int boardId);
        IEnumerable<Board> GetBoards(int userId);
        User GetUserFromBoard(BoardDto boardDto);
        void AddBoard(Board board);
        void RemoveBoard(Board board);
        void SaveChange();
    }
}
