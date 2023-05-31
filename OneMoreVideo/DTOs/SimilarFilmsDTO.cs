namespace OMV.Common.DTOs
{
    public class SimilarFilmsDTO
    {
        public int ParentFilmId { get; set; }
        public int SimilarFilmId { get; set; }

        public FilmDTO ParentFilm { get; set; } = new FilmDTO();
        public FilmDTO SimilarFilm { get; set; } = new FilmDTO();
    }

    public class SimilarFilmsCreateDTO
    {
        public int ParentFilmId { get; set; }
        public int SimilarFilmId { get; set; }
    }

    public class SimilarFilmsEditDTO : SimilarFilmsCreateDTO
    {

    }
}
