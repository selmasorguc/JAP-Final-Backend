using MovieApp.Core.Entities;
using System.Threading.Tasks;

namespace MovieApp.Core.Interfaces
{
    public interface IScreeningRepository
    {
        public Task<Screening> UpdateScreening(Screening screening);
        public Task<Screening> GetScreening(int id);
        Task<Screening> AddScreening(Screening screening);
    }
}
