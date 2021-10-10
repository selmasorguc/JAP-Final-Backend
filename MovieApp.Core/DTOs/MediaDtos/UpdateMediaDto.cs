using MovieApp.Core.Entities;
using System;

namespace MovieApp.Core.DTOs.MediaDtos
{
    public class UpdateMediaDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string CoverUrl { get; set; }

        public MediaType MediaType { get; set; }
    }
}
