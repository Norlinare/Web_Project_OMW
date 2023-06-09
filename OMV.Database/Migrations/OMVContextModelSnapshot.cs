﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OMV.Video.Database.Contexts;

#nullable disable

namespace OMV.Video.Database.Migrations
{
    [DbContext(typeof(OMVContext))]
    partial class OMVContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OMV.Video.Database.Entities.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Directors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Steven Spielberg"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Clint Eastwood"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tim Burton"
                        });
                });

            modelBuilder.Entity("OMV.Video.Database.Entities.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<string>("FilmUrl")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<bool>("Free")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Released")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Films");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "An adventurer goes looking for the Crystal Skull in a temple.",
                            DirectorId = 1,
                            FilmUrl = "https://www.youtube.com/watch?v=WAdJf4wTC5Y",
                            Free = false,
                            Released = new DateTime(2008, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Indiana Jones and the Kingdom of the Crystal Skull"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Dinosaurs get released by accident on an amusement park and wreck havoc.",
                            DirectorId = 1,
                            FilmUrl = "https://www.youtube.com/watch?v=lc0UehYemQA",
                            Free = false,
                            Released = new DateTime(1993, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Jurassic Park"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A shark attacks people at a beach.",
                            DirectorId = 1,
                            FilmUrl = "https://www.youtube.com/watch?v=U1fu_sA7XhE",
                            Free = true,
                            Released = new DateTime(1975, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Jaws"
                        },
                        new
                        {
                            Id = 4,
                            Description = "A story in space.",
                            DirectorId = 2,
                            FilmUrl = "https://www.youtube.com/watch?v=WjIMiGb_tmM",
                            Free = true,
                            Released = new DateTime(2000, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Space Cowboys"
                        },
                        new
                        {
                            Id = 5,
                            Description = "A western story about a man.",
                            DirectorId = 2,
                            FilmUrl = "https://www.youtube.com/watch?v=SGzz3hh1jHc",
                            Free = true,
                            Released = new DateTime(1985, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Pale Rider"
                        },
                        new
                        {
                            Id = 6,
                            Description = "A story about a sports player in South Africa.",
                            DirectorId = 2,
                            FilmUrl = "https://www.youtube.com/watch?v=RZY8c_a_dlQ",
                            Free = false,
                            Released = new DateTime(2009, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Invictus"
                        },
                        new
                        {
                            Id = 7,
                            Description = "A boy's parents gets murdered and the son take an oath to avenge them and fight off evil.",
                            DirectorId = 3,
                            FilmUrl = "https://www.youtube.com/watch?v=dgC9Q0uhX70",
                            Free = true,
                            Released = new DateTime(1989, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Batman"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Alice falls down a hole and has to save a kingdom.",
                            DirectorId = 3,
                            FilmUrl = "https://www.youtube.com/watch?v=9POCgSRVvf0",
                            Free = false,
                            Released = new DateTime(2010, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Alice in Wonderland"
                        },
                        new
                        {
                            Id = 9,
                            Description = "A boy finds a mysterious house with mysterious people.",
                            DirectorId = 3,
                            FilmUrl = "https://www.youtube.com/watch?v=tV_IhWE4LP0",
                            Free = false,
                            Released = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2016),
                            Title = "Miss Peregrine's Home for Peculiar Children"
                        });
                });

            modelBuilder.Entity("OMV.Video.Database.Entities.FilmGenre", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.HasKey("GenreId", "FilmId");

                    b.HasIndex("FilmId");

                    b.ToTable("FilmGenres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            FilmId = 1
                        },
                        new
                        {
                            GenreId = 2,
                            FilmId = 2
                        },
                        new
                        {
                            GenreId = 3,
                            FilmId = 3
                        },
                        new
                        {
                            GenreId = 2,
                            FilmId = 4
                        },
                        new
                        {
                            GenreId = 4,
                            FilmId = 5
                        },
                        new
                        {
                            GenreId = 5,
                            FilmId = 6
                        },
                        new
                        {
                            GenreId = 6,
                            FilmId = 7
                        },
                        new
                        {
                            GenreId = 1,
                            FilmId = 8
                        },
                        new
                        {
                            GenreId = 7,
                            FilmId = 9
                        },
                        new
                        {
                            GenreId = 6,
                            FilmId = 1
                        },
                        new
                        {
                            GenreId = 6,
                            FilmId = 2
                        },
                        new
                        {
                            GenreId = 7,
                            FilmId = 8
                        });
                });

            modelBuilder.Entity("OMV.Video.Database.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Western"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Sport"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Mystery"
                        });
                });

            modelBuilder.Entity("OMV.Video.Database.Entities.SimilarFilm", b =>
                {
                    b.Property<int>("ParentFilmId")
                        .HasColumnType("int");

                    b.Property<int>("SimilarFilmId")
                        .HasColumnType("int");

                    b.HasKey("ParentFilmId", "SimilarFilmId");

                    b.HasIndex("SimilarFilmId");

                    b.ToTable("SimilarFilms");

                    b.HasData(
                        new
                        {
                            ParentFilmId = 1,
                            SimilarFilmId = 2
                        },
                        new
                        {
                            ParentFilmId = 2,
                            SimilarFilmId = 1
                        },
                        new
                        {
                            ParentFilmId = 5,
                            SimilarFilmId = 4
                        },
                        new
                        {
                            ParentFilmId = 4,
                            SimilarFilmId = 5
                        },
                        new
                        {
                            ParentFilmId = 5,
                            SimilarFilmId = 7
                        },
                        new
                        {
                            ParentFilmId = 7,
                            SimilarFilmId = 5
                        },
                        new
                        {
                            ParentFilmId = 8,
                            SimilarFilmId = 9
                        },
                        new
                        {
                            ParentFilmId = 9,
                            SimilarFilmId = 8
                        },
                        new
                        {
                            ParentFilmId = 8,
                            SimilarFilmId = 1
                        },
                        new
                        {
                            ParentFilmId = 1,
                            SimilarFilmId = 8
                        },
                        new
                        {
                            ParentFilmId = 5,
                            SimilarFilmId = 1
                        },
                        new
                        {
                            ParentFilmId = 1,
                            SimilarFilmId = 5
                        },
                        new
                        {
                            ParentFilmId = 7,
                            SimilarFilmId = 2
                        },
                        new
                        {
                            ParentFilmId = 2,
                            SimilarFilmId = 7
                        });
                });

            modelBuilder.Entity("OMV.Video.Database.Entities.Film", b =>
                {
                    b.HasOne("OMV.Video.Database.Entities.Director", "Director")
                        .WithMany("Films")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Director");
                });

            modelBuilder.Entity("OMV.Video.Database.Entities.FilmGenre", b =>
                {
                    b.HasOne("OMV.Video.Database.Entities.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OMV.Video.Database.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("OMV.Video.Database.Entities.SimilarFilm", b =>
                {
                    b.HasOne("OMV.Video.Database.Entities.Film", "ParentFilm")
                        .WithMany("SimilarFilms")
                        .HasForeignKey("ParentFilmId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OMV.Video.Database.Entities.Film", "SimilarFilmToParent")
                        .WithMany()
                        .HasForeignKey("SimilarFilmId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ParentFilm");

                    b.Navigation("SimilarFilmToParent");
                });

            modelBuilder.Entity("OMV.Video.Database.Entities.Director", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("OMV.Video.Database.Entities.Film", b =>
                {
                    b.Navigation("SimilarFilms");
                });
#pragma warning restore 612, 618
        }
    }
}
