using MovieApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Core.DTOs
{
    public class AddMediaDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public string CoverUrl { get; set; }

        [Required]
        public MediaType MediaType { get; set; }

        public List<AddActorDto> Cast { get; set; }

    }
}
