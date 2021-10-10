using MovieApp.Core.DTOs.ScreeningDtos;
using MovieApp.Core.DTOs.UserDtos;
using System;

namespace MovieApp.Core.DTOs.TicketDtos
{
    public class GetTicketDto
    {
        public int ScreeningId { get; set; }

        public int UserId { get; set; }

        public ProfileDto User { get; set; }

        public int MediaId { get; set; }

        public AddMediaDto Media { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public AddScreeningDto Screening { get; set; }
    }
}
