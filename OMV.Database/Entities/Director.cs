namespace OMV.Video.Database.Entities
{
    public class Director : IEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Film>? Films { get; set; }
    }
}
