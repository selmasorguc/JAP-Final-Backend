using AutoMapper;
using MovieApp.Core.DTOs.ScreeningDtos;
using MovieApp.Core.Entities;
using MovieApp.Core.Interfaces;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Get list of addresses where screenings happen from DB
        /// </summary>
        /// <returns>List of factories</returns>
        public async Task<ServiceResponse<List<Address>>> GetAddresses()
        {
            var response = new ServiceResponse<List<Address>>();
            response.Data = await _screeningRepository.GetAddresses();
            return response;
        }

        public async Task<ServiceResponse<List<GetScreeningDto>>> GetScreenings()
        {
            var response = new ServiceResponse<List<GetScreeningDto>>();
            response.Data = _mapper.Map<List<GetScreeningDto>>(await _screeningRepository.GetScreenings());
            return response;
        }
    }
}
