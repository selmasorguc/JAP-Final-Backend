using AutoMapper;
using MovieApp.Core.DTOs;
using MovieApp.Core.DTOs.MediaDtos;
using MovieApp.Core.Entities;
using MovieApp.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MovieApp.Core.Services
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly IMapper _mapper;
        public MediaService(IMediaRepository mediaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _mediaRepository = mediaRepository;
        }

        public async Task<List<MediaDto>> GetMediaAsync(MediaParams movieParams)
        {
            return _mapper.Map<List<MediaDto>>(await _mediaRepository.GetMediaAsync(movieParams));
        }

        public async Task<AddMediaDto> AddMedia(AddMediaDto media)
        {
            await _mediaRepository.AddMedia(_mapper.Map<Media>(media));
            return media;
        }

        public async Task<MediaDto> GetSingleMedia(int id)
        {
            return _mapper.Map<MediaDto>(await _mediaRepository.GetSingleMediaAync(id));
        }

        public async Task<UpdateMediaDto> UpdateMedia(UpdateMediaDto media)
        {
            var preUpdate = await _mediaRepository.GetSingleMediaAync(media.Id);
            _mapper.Map(media, preUpdate);
            await _mediaRepository.UpdateMedia(preUpdate);
            return media;
        }
    }
}