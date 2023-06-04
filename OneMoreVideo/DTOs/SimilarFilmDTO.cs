namespace OMV.Common.DTOs
{
    public class SimilarFilmDTO
    {
        public int ParentFilmId { get; set; }
        public int SimilarFilmId { get; set; }

        public SimilarFilmDTO(int parentFilmId, int similarFilmId)
        {
            ParentFilmId = parentFilmId;
            SimilarFilmId = similarFilmId;
        }
    }

    public class SimilarFilmCreateDTO
    {
        public int ParentFilmId { get; set; }
        public int SimilarFilmId { get; set; }
    }

    public class SimilarFilmEditDTO : SimilarFilmCreateDTO
    {

    }
}
