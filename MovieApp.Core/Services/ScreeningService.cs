using AutoMapper;
using MovieApp.Core.DTOs.ScreeningDtos;
using MovieApp.Core.Entities;
using MovieApp.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace MovieApp.Core.Services
{
    public class ScreeningService : IScreeningService
    {
        private readonly IMapper _mapper;

        private readonly IScreeningRepository _screeningRepository;

        private readonly IMediaRepository _mediaRepository;

        public ScreeningService(IScreeningRepository screeningRepository, IMapper mapper,
            IMediaRepository mediaRepository)
        {
            _mapper = mapper;
            _screeningRepository = screeningRepository;
            _mediaRepository = mediaRepository;
        }

        public async Task<ServiceResponse<AddScreeningDto>> AddScreening(AddScreeningDto screeningDto)
        {
            if (!(await _mediaRepository.MediaExists(screeningDto.MediaId)))
                throw new ArgumentException("Movie id is not valid.");

            var serviceResponse = new ServiceResponse<AddScreeningDto>();
            await _screeningRepository.AddScreening(_mapper.Map<Screening>(screeningDto));
            serviceResponse.Data = screeningDto;
            return serviceResponse;
        }

    }
}
