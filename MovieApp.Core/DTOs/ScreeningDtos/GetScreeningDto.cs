using MovieApp.Core.DTOs.TicketDtos;
using System;
using System.Collections.Generic;

namespace MovieApp.Core.DTOs.ScreeningDtos
{
    public class GetScreeningDto
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public int MaxSeatsNumber { get; set; }

        public int MediaId { get; set; }

        public int AddressId { get; set; }

        public double Price { get; set; }
        public AddMediaDto Media { get; set; }

        public List<TicketDto> SoldTickets { get; set; }
    }
}
