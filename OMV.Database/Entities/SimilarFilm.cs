using System.ComponentModel.DataAnnotations.Schema;

namespace OMV.Video.Database.Entities
{
    public class SimilarFilm : IReferenceEntity
    {

        public int ParentFilmId { get; set; }
        public int SimilarFilmId { get; set; }


        public Film ParentFilm { get; set; } = null!;
        [ForeignKey("SimilarFilmId")]
        public Film SimilarFilmToParent { get; set; } = null!;
    }
}
