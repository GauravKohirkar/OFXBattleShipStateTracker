using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BattleShipStateTracker.Data.Entities;
using BattleShipStateTracker.Data.Exceptions;
using BattleShipStateTracker.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BattleShipStateTracker.API.Controllers
{
    [Route("match")]
    public class MatchController : Controller
    {
        private readonly IBattleShipService _battleShipService;
        public MatchController(IBattleShipService battleShipService)
        {
            _battleShipService = battleShipService;
        }

        /// <summary>
        /// Get the Match Id
        /// </summary>
        /// <returns>The current running match Id.</returns>
        /// <param name="id"></param>
        /// <response code="200">Returns the id for the new match.</response>
        /// <response code="500">An error has occurred</response>
        [Route("{id}")]
        [HttpGet]
        [Produces(typeof(int))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<ActionResult<int>> GetMatch(int id)
        {
            try
            {
                var match = await _battleShipService.GetMatchById(id);
                if (match == null)
                    throw new NotFoundException(nameof(Match), id);
                return Ok(match);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // USE A LOGGER SERVICE TO LOG VARIOUS ERRORS IN KIBANA etc.
                return BadRequest();
            }
        }

        [HttpPost]
        [Produces(typeof(int))]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<ActionResult<int>> CreateMatch()
        {
            try
            {
                var match = await _battleShipService.CreateMatch();
                return Ok(match);
            }
            catch (Exception ex)
            {
                // USE A LOGGER SERVICE TO LOG VARIOUS ERRORS IN KIBANA etc.
                return BadRequest(); 
            }
        }
    }
}
