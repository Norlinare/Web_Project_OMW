namespace OMV.Common.DTOs
{
    public class FilmGenreDTO
    {
        public FilmGenreDTO()
        {

        }
        public FilmGenreDTO(int filmId, int genreId)
        {
            filmId = FilmId;
            genreId = GenreId;
        }

        public int FilmId { get; set; }
        public int GenreId { get; set; }

        public FilmDTO Film { get; set; } = new();
        public GenreDTO Genre { get; set; } = new();
    }
    public class FilmGenreCreateDTO
    {
        public int FilmId { get; set; }
        public int GenreId { get; set; }
    }
    public class FilmGenreEditDTO : FilmGenreCreateDTO
    {
    }
}
