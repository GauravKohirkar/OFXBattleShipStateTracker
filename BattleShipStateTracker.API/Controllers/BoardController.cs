using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShipStateTracker.Data.CommandsDto;
using BattleShipStateTracker.Data.Entities;
using BattleShipStateTracker.Data.Exceptions;
using BattleShipStateTracker.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BattleShipStateTracker.API.Controllers
{
    [Route("board")]
    public class BoardController : Controller
    {
        private readonly IBattleShipService _battleShipService;
        public BoardController(IBattleShipService battleShipService)
        {
            _battleShipService = battleShipService;
        }

        [HttpPost]
        [Produces(typeof(int))]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Board>> SetBoard([FromBody] SetBoardDto boardDto)
        {
            try
            {
                var board = await _battleShipService.SetBoard(boardDto);
                return Ok(board.BoardId);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // USE A LOGGER SERVICE TO LOG VARIOUS ERRORS IN KIBANA etc.
                return BadRequest();
            }
        }
    }
}
