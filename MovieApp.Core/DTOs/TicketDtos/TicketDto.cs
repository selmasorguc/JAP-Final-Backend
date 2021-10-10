using System.ComponentModel.DataAnnotations;

namespace MovieApp.Core.DTOs.TicketDtos
{
    public class TicketDto
    {
        public int ScreeningId { get; set; }

        public int MediaId { get; set; }

        [Range(1, 10)]
        public int NumberOfTickets { get; set; }
    }
}
