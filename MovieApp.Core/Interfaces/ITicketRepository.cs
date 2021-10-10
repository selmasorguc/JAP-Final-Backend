using MovieApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.Core.Interfaces
{
    public interface ITicketRepository
    {
        Task<Ticket> AddTicket(Ticket ticket);

        Task<List<Ticket>> GetUserTickets(int id);
    }
}
