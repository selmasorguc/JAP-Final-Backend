using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities;
using MovieApp.Core.Interfaces;
using MovieApp.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly DataContext _context;
        public TicketRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Ticket>> GetUserTickets(int id)
        {
            return await _context.Tickets.Include(s => s.User)
                                         .Include(s => s.Media)
                                         .Include(s => s.Screening)
                                         .Where(t => t.UserId == id).ToListAsync();
        }
        public async Task<Ticket> AddTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }
    }
}
