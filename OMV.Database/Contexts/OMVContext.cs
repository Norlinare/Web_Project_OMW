using Microsoft.EntityFrameworkCore;
using OMV.Video.Database.Entities;

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

            modelBuilder.Entity<SimilarFilms>()
                .HasOne(sf => sf.ParentFilm)
                .WithMany(f => f.ParentFilms)
                .HasForeignKey(sf => sf.ParentFilmId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<SimilarFilms>()
                .HasOne(sf => sf.SimilarFilm)
                .WithMany(f => f.SimilarFilms)
                .HasForeignKey(sf => sf.SimilarFilmId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<SimilarFilms>()
                .HasKey(nameof(SimilarFilms.ParentFilmId), nameof(SimilarFilms.SimilarFilmId));

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Director> Directors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmGenre> FilmGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }

    }
}
