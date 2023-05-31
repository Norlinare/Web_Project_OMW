namespace OMV.Video.Database.Entities
{
    public class Film : IEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        public DateTime Released { get; set; }
        public bool Free { get; set; }
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;
        [MaxLength(1024)]
        public string FilmUrl { get; set; } = string.Empty;

        public int DirectorId { get; set; }

        public virtual ICollection<Genre>? Genres { get; set; }
        public Director? Director { get; set; }
        public virtual ICollection<SimilarFilms> ParentFilms { get; set; } = new List<SimilarFilms>();
        public virtual ICollection<SimilarFilms> SimilarFilms { get; set; } = new List<SimilarFilms>();
    }
}
