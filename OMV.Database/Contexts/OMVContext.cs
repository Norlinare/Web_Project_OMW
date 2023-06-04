namespace OMV.Video.Database.Contexts
{
    public class OMVContext : DbContext
    {


        private readonly SeedData.SeedData _seedData = new SeedData.SeedData();

        public OMVContext(DbContextOptions<OMVContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SimilarFilm>()
                .HasKey(sf => new { sf.ParentFilmId, sf.SimilarFilmId });
            modelBuilder.Entity<SimilarFilm>().HasKey(f => new { f.ParentFilmId, f.SimilarFilmId });

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



            modelBuilder.Entity<Film>()
                .HasMany(f => f.SimilarFilms)
                .WithOne(fg => fg.ParentFilm)
                .HasForeignKey(fg => fg.ParentFilmId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            _seedData.SeedAll(modelBuilder);
        }

        public DbSet<Director> Directors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmGenre> FilmGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<SimilarFilm> SimilarFilms { get; set; }


    }
}
