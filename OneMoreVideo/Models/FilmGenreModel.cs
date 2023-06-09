namespace OMV.Common.Models
{
    public class FilmGenreModel
    {
        public FilmGenreModel()
        {

        }

        public FilmGenreModel(int filmId, int genreId)
        {
            FilmId = filmId;
            GenreId = genreId;
        }
        public int FilmId { get; set; }
        public int GenreId { get; set; }

    }
}
