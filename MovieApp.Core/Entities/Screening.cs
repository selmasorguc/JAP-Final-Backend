namespace MovieApp.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Screening
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        [Range(0, 1000)]
        public int MaxSeatsNumber { get; set; }

        public int MediaId { get; set; }

        public Media Media { get; set; }

        public List<Ticket> SoldTickets { get; set; } = new List<Ticket>();

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public double Price { get; set; }
    }
}
