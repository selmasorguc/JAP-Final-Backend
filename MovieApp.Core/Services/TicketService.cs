namespace MovieApp.Core.Services
{
    using AutoMapper;
    using MovieApp.Core.DTOs.TicketDtos;
    using MovieApp.Core.Entities;
    using MovieApp.Core.Interfaces;
    using System;
    using System.Threading.Tasks;

    public class TicketService : ITicketService
    {
        private readonly IMapper _mapper;

        private readonly ITicketRepository _ticketRepository;

        private readonly IAuthRepository _authRepository;

        private readonly IMediaRepository _mediaRepository;

        private readonly IScreeningRepository _screeningRepository;

        public TicketService(ITicketRepository ticketRepository, IScreeningRepository screeningRepository,
            IMapper mapper, IAuthRepository authRepository, IMediaRepository mediaRepository)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
            _authRepository = authRepository;
            _screeningRepository = screeningRepository;
            _mediaRepository = mediaRepository;
        }

        /// <summary>
        /// Buying a ticket functionality - add a new ticket and update the screening and media
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="username"></param>
        /// <returns>Bought ticket thats been added to the DB</returns>
        public async Task<ServiceResponse<TicketDto>> BuyTicket(TicketDto ticket, string username)
        {
            var serviceResponse = new ServiceResponse<TicketDto>();

            //Check if movie and user exist in the DB
            if (!(await _mediaRepository.MediaExists(ticket.MediaId)))
                throw new ArgumentException("Movie id is not valid.");

            var screening = await _screeningRepository.GetScreening(ticket.ScreeningId);
            if (screening == null) 
                throw new ArgumentException("Screening id is not valid.");

            if (screening.StartTime < DateTime.Today)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "You cannot buy a ticket for screening in past";
            }
            else
            {
                var user = await _authRepository.GetUserByUsernameAsync(username);
                var addTicket = new Ticket
                {
                    User = user,
                    Screening = screening,
                    MediaId = ticket.MediaId,
                    ScreeningId = screening.Id,
                    UserId = user.Id
                };
                screening.SoldTickets.Add(addTicket);
                //Addting the new ticket to DB
                await _ticketRepository.AddTicket(addTicket);
                await _screeningRepository.UpdateScreening(screening);
                serviceResponse.Data = ticket;
            }

            return serviceResponse;
        }
    }
}
