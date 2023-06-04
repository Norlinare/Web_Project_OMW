namespace OMV.Common.Models
{
    public class SimilarFilmModel
    {
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string Title { get; set; } = null!;
    }
}
