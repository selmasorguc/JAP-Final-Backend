namespace MovieApp.Core.Interfaces
{
    using MovieApp.Core.DTOs.TicketDtos;
    using MovieApp.Core.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITicketService
    {
        Task<ServiceResponse<TicketDto>> BuyTicket(TicketDto ticket, string username);

        Task<ServiceResponse<List<GetTicketDto>>> GetUserTickets(string username);

    }
}
