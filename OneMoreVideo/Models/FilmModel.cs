﻿namespace OMV.Common.Models
{
    public class FilmModel
    {
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string Title { get; set; } = null!;

        [MaxLength(50), Required]
        public string Released { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string MarqueeUrl { get; set; } = null!;


        public bool Free { get; set; }

        [MaxLength(200), Required]
        public string Description { get; set; } = null!;

        [MaxLength(1024), Required]
        public string FilmUrl { get; set; } = null!;

        public int DirectorId { get; set; }
        public virtual DirectorModel? Director { get; set; }
        public List<SimilarFilmDTO> SimilarFilms { get; set; } = new List<SimilarFilmDTO>();

        public List<GenreDTO> Genres { get; set; } = new List<GenreDTO>();
    }
}
