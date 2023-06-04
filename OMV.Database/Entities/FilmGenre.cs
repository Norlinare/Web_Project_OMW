namespace OMV.Video.Database.Entities
{
    public class FilmGenre : IReferenceEntity
    {

        public int FilmId { get; set; }
        public int GenreId { get; set; }

        public Film? Film { get; set; } = null!;
        public Genre? Genre { get; set; } = null!;
    }
}
