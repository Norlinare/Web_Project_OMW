namespace OMV.Common.Models
{
    public class SimilarFilmModel
    {
        public SimilarFilmModel()
        {

        }

        public SimilarFilmModel(int ParentId, int SimilarId)
        {
            ParentFilmId = ParentId;
            SimilarFilmId = SimilarId;
        }

        public int ParentFilmId { get; set; }
        public int SimilarFilmId { get; set; }
        [MaxLength(50), Required]
        public string Title { get; set; } = null!;
    }
}
