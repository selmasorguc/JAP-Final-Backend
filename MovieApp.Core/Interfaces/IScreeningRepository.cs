using MovieApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.Core.Interfaces
{
    public interface IScreeningRepository
    {
        public Task<Screening> UpdateScreening(Screening screening);
        public Task<Screening> GetScreening(int id);
        public Task<List<Screening>> GetScreenings();
        Task<List<Address>> GetAddresses();
        Task<Screening> AddScreening(Screening screening);
    }
}
