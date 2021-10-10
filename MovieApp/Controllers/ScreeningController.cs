using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.DTOs.ScreeningDtos;
using MovieApp.Core.Entities;
using MovieApp.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/screening")]
    public class ScreeningController : ControllerBase
    {
        private readonly IScreeningService _screeningService;

        public ScreeningController(IScreeningService screeningService)
        {
            _screeningService = screeningService;
        }

        /// <summary>
        /// Admin adding a new screening
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns>Return added screening</returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ScreeningDto>>> BuyTicket(AddScreeningDto screeningDto)
        {

            var serviceResponse = await _screeningService.AddScreening(screeningDto);

            if (serviceResponse.Data == null) return BadRequest(serviceResponse);

            return Ok(serviceResponse);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetScreeningDto>>>> GetScreenings()
        {
            var serviceResponse = await _screeningService.GetScreenings();

            if (serviceResponse.Data == null) return BadRequest(serviceResponse);

            return Ok(serviceResponse);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("addresses")]

        public async Task<ActionResult<ServiceResponse<List<Address>>>> GetAddresses()
        {
            var serviceResponse = await _screeningService.GetAddresses();

            if (serviceResponse.Data == null) return BadRequest(serviceResponse);

            return Ok(serviceResponse);
        }

    }
}


