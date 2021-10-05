namespace MovieApp.Core.DTOs.ScreeningDtos
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AddScreeningDto
    {
        public DateTime StartTime { get; set; }

        [Range(0, 150)]
        public int MaxSeatsNumber { get; set; }

        [Required]
        public int MediaId { get; set; }

        public double Price { get; set; }

        public int AddressId { get; set; }
    }
}
