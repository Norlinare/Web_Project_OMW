namespace OMV.Video.Database.Contexts
{
    public class OMVContext : DbContext
    {

        public OMVContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Film>()
                .HasMany(f => f.Genres)
                .WithMany(g => g.Films)
                .UsingEntity<FilmGenre>(
                fg => fg.HasOne(prop => prop.Genre).WithMany().HasForeignKey(prop => prop.GenreId),
                fg => fg.HasOne(prop => prop.Film).WithMany().HasForeignKey(prop => prop.FilmId),
                fg =>
                {
                    fg.HasKey(prop => new { prop.GenreId, prop.FilmId });
                }
                );

            modelBuilder.Entity<SimilarFilm>()
                .HasOne(sf => sf.ParentFilm)
                .WithMany(f => f.ParentFilms)
                .HasForeignKey(sf => sf.ParentFilmId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<SimilarFilm>()
                .HasOne(sf => sf.SimilarFilmToParent)
                .WithMany(f => f.SimilarFilms)
                .HasForeignKey(sf => sf.SimilarFilmId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<SimilarFilm>()
                .HasKey(nameof(SimilarFilm.ParentFilmId), nameof(SimilarFilm.SimilarFilmId));

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Director> Directors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmGenre> FilmGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<SimilarFilm> SimilarFilms { get; set; }

    }
}
