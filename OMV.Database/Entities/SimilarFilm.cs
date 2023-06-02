namespace OMV.Video.Database.Entities
{
    public class SimilarFilm : IEntity
    {

        public int? ParentFilmId { get; set; }

        public int? SimilarFilmId { get; set; }


        public Film? ParentFilm { get; set; }
        public Film? SimilarFilmToParent { get; set; }
    }
}
