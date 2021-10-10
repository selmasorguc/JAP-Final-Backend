using System;

namespace MovieApp.Core.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        public Screening Screening { get; set; }

        public int ScreeningId { get; set; }

        public AppUser User { get; set; }

        public int UserId { get; set; }

        public int MediaId { get; set; }

        public Media Media { get; set; }
        public DateTime DateOfPurchase { get; set; } = DateTime.Now;
    }
}
