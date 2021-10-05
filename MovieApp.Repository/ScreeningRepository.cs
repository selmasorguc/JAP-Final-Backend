using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities;
using MovieApp.Core.Interfaces;
using MovieApp.Database;
using System;
using System.Threading.Tasks;

namespace MovieApp.Repository
{
    public class ScreeningRepository : IScreeningRepository
    {
        private readonly DataContext _context;
        public ScreeningRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Screening> GetScreening(int id)
        {
            return await _context.Screenings.SingleOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Updates a screening after a ticket has been bought
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Updated screening</returns>
        public async Task<Screening> UpdateScreening(Screening screening)
        {
            screening.MaxSeatsNumber -= 1;
            _context.Screenings.Update(screening);
            await _context.SaveChangesAsync();

            return screening;
        }

        public async Task<Screening> AddScreening(Screening screening)
        {
            if (await _context.Screenings.SingleOrDefaultAsync(x => x.Id == screening.Id) != null)
                throw new Exception("Screening already exists in the DB");
            _context.Screenings.Add(screening);
            await _context.SaveChangesAsync();

            return screening;
        }
    }
}
