namespace OMV.Video.Database.Entities
{
    public class SimilarFilms
    {

        public int? ParentFilmId { get; set; }

        public int? SimilarFilmId { get; set; }


        public Film? ParentFilm { get; set; }
        public Film? SimilarFilm { get; set; }
    }
}
