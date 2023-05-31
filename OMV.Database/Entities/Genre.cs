namespace OMV.Video.Database.Entities
{
    public class Genre : IEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Film>? Films { get; set; }
    }
}
