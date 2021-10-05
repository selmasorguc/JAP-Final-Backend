using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.DTOs.ScreeningDtos;
using MovieApp.Core.Entities;
using MovieApp.Core.Interfaces;
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
        [Authorize(Roles ="Admin")]
        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<ScreeningDto>>> BuyTicket(AddScreeningDto screeningDto)
        {

            var serviceResponse = await _screeningService.AddScreening(screeningDto);

            if (serviceResponse.Data == null) return BadRequest(serviceResponse);

            return Ok(serviceResponse);
        }
    }
}


