using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkPilot.Models.Dtos;
using WorkPilot.Models;

namespace WorkPilot.Services.Interfaces
{
    public interface IStatusService
    {
        Status SelectStatusInDb(int boardId, int statusId);

        IEnumerable<Status> GetStatusesInBoard(int boardId);

        Board GetBoardFromStatus(StatusDto statusDto);
        void AddStatus(Board board, Status status);
        void RemoveStatus(Status status);
        void SaveChange();
    }
}
