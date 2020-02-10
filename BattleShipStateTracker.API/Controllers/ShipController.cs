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
    [Route("ship")]
    public class ShipController : Controller
    {
        private readonly IBattleShipService _battleShipService;
        public ShipController(IBattleShipService battleShipService)
        {
            _battleShipService = battleShipService;
        }

        [HttpPost]
        [Produces(typeof(int))]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<int>> CreateShip([FromBody] CreateShipDto createShipDto)
        {
            try
            {
                var shipId = await _battleShipService.CreateShip(createShipDto);
                return Ok(shipId);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Produces(typeof(int))]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<int>> AttackShip([FromBody] AttackDto attackDto)
        {
            try
            {
                var result = await _battleShipService.AttackShip(attackDto);
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
