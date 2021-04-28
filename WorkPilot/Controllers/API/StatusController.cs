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
    public class StatusController : Controller
    {
        private IStatusService _statusService;
        private Mapper _mapper;

        public StatusController(IStatusService statusService, Mapper mapper)
        {
            _statusService = statusService;
            _mapper = mapper;
        }

        [HttpGet("{statusId}", Name = "GetStatus")]
        public ActionResult GetStatus(int boardId, int statusId)
        {
            var status = _statusService.SelectStatusInDb(boardId, statusId);
            if (status == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Status, StatusDto>(status));
        }

        [HttpGet]
        public ActionResult GetStatusesInBoard(int boardId)
        {
            var statuses = _statusService.GetStatusesInBoard(boardId);
            return Ok(_mapper.Map<IEnumerable<Status>>(statuses));
        }

        [HttpPost]
        public ActionResult CreateStatus(StatusDto statusDto)
        {
            var board = _statusService.GetBoardFromStatus(statusDto);
            if (board == null)
            {
                return NotFound();
            }

            var status = _mapper.Map<StatusDto, Status>(statusDto);

            _statusService.AddStatus(board, status);

            statusDto.Id = status.Id;
            return Created("GetStatus", statusDto);
        }

        [HttpPut]
        public ActionResult UpdateStatus(int boardId, int statusId, StatusDto statusDto)
        {
            var status = _statusService.SelectStatusInDb(boardId, statusId);
            if (status == null)
            {
                return NotFound();
            }
            _mapper.Map(statusDto, status);
            _statusService.SaveChange();
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteStatus(int boardId, int statusId)
        {
            var status = _statusService.SelectStatusInDb(boardId, statusId);
            if (status == null)
            {
                return NotFound();
            }
            _statusService.RemoveStatus(status);
            return Ok();
        }
    }
}
