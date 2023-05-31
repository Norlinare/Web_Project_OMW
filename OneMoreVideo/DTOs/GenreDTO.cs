namespace OMV.Common.DTOs
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<FilmDTO> Film { get; set; } = new();
    }
    public class GenreCreateDTO
    {
        public string? Name { get; set; }
    }
    public class GenreEditDTO : GenreCreateDTO
    {
        public int Id { get; set; }
    }
}
