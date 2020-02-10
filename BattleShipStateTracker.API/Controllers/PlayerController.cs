using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShipStateTracker.Data.CommandsDto;
using BattleShipStateTracker.Data.Exceptions;
using BattleShipStateTracker.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BattleShipStateTracker.API.Controllers
{
    [Route("player")]
    public class PlayerController : Controller
    {
        private readonly IBattleShipService _battleShipService;
        public PlayerController(IBattleShipService battleShipService)
        {
            _battleShipService = battleShipService;
        }

        [HttpPost]
        [Produces(typeof(int))]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<int>> CreatePlayer([FromBody] SetPlayerDto player)
        {
            try
            {
                var playerId = await _battleShipService.CreatePlayer(player.Name);
                return Ok(playerId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
