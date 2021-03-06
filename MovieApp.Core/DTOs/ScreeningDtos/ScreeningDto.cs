namespace MovieApp.Core.DTOs.ScreeningDtos
{
    using MovieApp.Core.DTOs.TicketDtos;
    using System;
    using System.Collections.Generic;

    public class ScreeningDto
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public int MaxSeatsNumber { get; set; }

        public int MediaId { get; set; }

        public int AddressId { get; set; }

        public List<TicketDto> SoldTickets { get; set; }
    }
}
