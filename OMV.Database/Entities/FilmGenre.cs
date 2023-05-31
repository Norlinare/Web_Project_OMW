namespace OMV.Video.Database.Entities
{
    public class FilmGenre
    {
        [Key]
        public int FilmId { get; set; }
        [Key]
        public int GenreId { get; set; }

        public Film? Film { get; set; }
        public Genre? Genre { get; set; }
    }
}
