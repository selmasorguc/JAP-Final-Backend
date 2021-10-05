using MovieApp.Core.DTOs;
using MovieApp.Core.DTOs.MediaDtos;
using MovieApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.Core.Interfaces
{
    public interface IMediaService
    {
        Task<List<MediaDto>> GetMediaAsync(MediaParams movieParams);
        Task<MediaDto> GetSingleMedia(int id);
        Task<AddMediaDto> AddMedia(AddMediaDto media);
        Task<UpdateMediaDto> UpdateMedia(UpdateMediaDto media);
    }
}