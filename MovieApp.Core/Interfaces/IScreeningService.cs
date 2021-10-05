using MovieApp.Core.DTOs.ScreeningDtos;
using MovieApp.Core.Entities;
using System.Threading.Tasks;

namespace MovieApp.Core.Interfaces
{
    public interface IScreeningService
    {
        Task<ServiceResponse<AddScreeningDto>> AddScreening(AddScreeningDto screeningDto);
    }
}
