namespace OMV.Common.DTOs
{
    public class FilmGenreDTO
    {


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

    public class FilmGenreDeleteDTO : FilmGenreCreateDTO
    {
        public FilmGenreDeleteDTO()
        {

        }
        public FilmGenreDeleteDTO(int filmId, int genreId)
        {
            FilmId = filmId;
            GenreId = genreId;
        }
    }
}
