namespace MovieApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MovieApp.Core.DTOs;
    using MovieApp.Core.DTOs.MediaDtos;
    using MovieApp.Core.Entities;
    using MovieApp.Core.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/media")]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        /// <summary>
        /// Gets media (movies or tv shows) from the database
        /// When no params have been sent it returns 20 top rated media (tv shows and movies together)
        /// Check the MediaParams class in Core DTOs
        /// </summary>
        /// <param name="movieParams"></param>
        /// <returns>List of media</returns>
        [HttpGet]
        public async Task<ActionResult<List<MediaDto>>> GetMedia(
            [FromQuery] MediaParams movieParams)
        {
            var movies = await _mediaService.GetMediaAsync(movieParams);
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<MediaDto>>> GetSingleMedia(int id)
        {
            var response = new ServiceResponse<MediaDto>();
            response.Data = await _mediaService.GetSingleMedia(id);
            return Ok(response);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<AddMediaDto>>> AddMedia(AddMediaDto media)
        {
            var response = new ServiceResponse<AddMediaDto>();
            response.Data = await _mediaService.AddMedia(media);
            if (response.Data == null)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<UpdateMediaDto>>> UpdateMedia(UpdateMediaDto media)
        {
            var response = new ServiceResponse<UpdateMediaDto>();
            response.Data = await _mediaService.UpdateMedia(media);
            if (response.Data == null)
                return BadRequest(response);
            return Ok(response);
        }
    }
}
