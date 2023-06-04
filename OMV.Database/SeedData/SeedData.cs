namespace OMV.Video.Database.SeedData
{
    public class SeedData
    {
        public void SeedAll(ModelBuilder modelBuilder)
        {
            SeedDirector(modelBuilder);
            SeedFilm(modelBuilder);
            SeedGenre(modelBuilder);
            SeedFilmGenre(modelBuilder);
            SeedSimilarFilm(modelBuilder);
        }

        public void SeedPrimaryKeys(ModelBuilder modelBuilder)
        {
            SeedDirector(modelBuilder);
            SeedFilm(modelBuilder);
            SeedGenre(modelBuilder);
        }

        public void SeedForegnKeys(ModelBuilder modelBuilder)
        {
            SeedFilmGenre(modelBuilder);
            SeedSimilarFilm(modelBuilder);
        }


        public void SeedDirector(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Director>().HasData(
                new Director
                {
                    Id = 1,
                    Name = "Steven Spielberg"
                },
                new Director
                {
                    Id = 2,
                    Name = "Clint Eastwood"
                },
                new Director
                {
                    Id = 3,
                    Name = "Tim Burton"
                }
                );
        }


        public static void SeedFilm(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().HasData(
                //Steven Spielberg
                new Film
                {
                    Id = 1,
                    Title = "Indiana Jones and the Kingdom of the Crystal Skull",
                    Released = new DateTime(2008, 05, 18),
                    Free = false,
                    Description = "An adventurer goes looking for the Crystal Skull in a temple.",
                    FilmUrl = "https://www.youtube.com/watch?v=WAdJf4wTC5Y",
                    DirectorId = 1
                },
                new Film
                {
                    Id = 2,
                    Title = "Jurassic Park",
                    Released = new DateTime(1993, 06, 11),
                    Free = false,
                    Description = "Dinosaurs get released by accident on an amusement park and wreck havoc.",
                    FilmUrl = "https://www.youtube.com/watch?v=lc0UehYemQA",
                    DirectorId = 1
                },
                new Film
                {
                    Id = 3,
                    Title = "Jaws",
                    Released = new DateTime(1975, 06, 20),
                    Free = true,
                    Description = "A shark attacks people at a beach.",
                    FilmUrl = "https://www.youtube.com/watch?v=U1fu_sA7XhE",
                    DirectorId = 1
                },


                //Clint Eastwood
                new Film
                {
                    Id = 4,
                    Title = "Space Cowboys",
                    Released = new DateTime(2000, 08, 04),
                    Free = true,
                    Description = "A story in space.",
                    FilmUrl = "https://www.youtube.com/watch?v=WjIMiGb_tmM",
                    DirectorId = 2
                },
                new Film
                {
                    Id = 5,
                    Title = "Pale Rider",
                    Released = new DateTime(1985, 06, 26),
                    Free = true,
                    Description = "A western story about a man.",
                    FilmUrl = "https://www.youtube.com/watch?v=SGzz3hh1jHc",
                    DirectorId = 2
                },
                new Film
                {
                    Id = 6,
                    Title = "Invictus",
                    Released = new DateTime(2009, 12, 11),
                    Free = false,
                    Description = "A story about a sports player in South Africa.",
                    FilmUrl = "https://www.youtube.com/watch?v=RZY8c_a_dlQ",
                    DirectorId = 2
                },


                //Tim Burton
                new Film
                {
                    Id = 7,
                    Title = "Batman",
                    Released = new DateTime(1989, 06, 19),
                    Free = true,
                    Description = "A boy's parents gets murdered and the son take an oath to avenge them and fight off evil.",
                    FilmUrl = "https://www.youtube.com/watch?v=dgC9Q0uhX70",
                    DirectorId = 3
                },
                new Film
                {
                    Id = 8,
                    Title = "Alice in Wonderland",
                    Released = new DateTime(2010, 02, 25),
                    Free = false,
                    Description = "Alice falls down a hole and has to save a kingdom.",
                    FilmUrl = "https://www.youtube.com/watch?v=9POCgSRVvf0",
                    DirectorId = 3
                },
                new Film
                {
                    Id = 9,
                    Title = "Miss Peregrine's Home for Peculiar Children",
                    Released = new DateTime(2016),
                    Free = false,
                    Description = "A boy finds a mysterious house with mysterious people.",
                    FilmUrl = "https://www.youtube.com/watch?v=tV_IhWE4LP0",
                    DirectorId = 3
                }
                );
        }



        public void SeedGenre(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    Name = "Adventure"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Sci-Fi"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Horror"
                },
                new Genre
                {
                    Id = 4,
                    Name = "Western"
                },
                new Genre
                {
                    Id = 5,
                    Name = "Sport"
                },
                new Genre
                {
                    Id = 6,
                    Name = "Action"
                },
                new Genre
                {
                    Id = 7,
                    Name = "Mystery"
                }
                );
        }


        public void SeedFilmGenre(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmGenre>().HasData(
                new FilmGenre
                {
                    FilmId = 1,
                    GenreId = 1,
                },
                new FilmGenre
                {
                    FilmId = 2,
                    GenreId = 2,
                },
                new FilmGenre
                {
                    FilmId = 3,
                    GenreId = 3,
                },
                new FilmGenre
                {
                    FilmId = 4,
                    GenreId = 2,
                },
                new FilmGenre
                {
                    FilmId = 5,
                    GenreId = 4,
                },
                new FilmGenre
                {
                    FilmId = 6,
                    GenreId = 5,
                },
                new FilmGenre
                {
                    FilmId = 7,
                    GenreId = 6,
                },
                new FilmGenre
                {
                    FilmId = 8,
                    GenreId = 1,
                },
                new FilmGenre
                {
                    FilmId = 9,
                    GenreId = 7,
                }
                );
        }

        public void SeedSimilarFilm(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SimilarFilm>().HasData(
                new SimilarFilm
                {
                    ParentFilmId = 1,
                    SimilarFilmId = 2,
                },
                new SimilarFilm
                {
                    ParentFilmId = 2,
                    SimilarFilmId = 1,
                },
                new SimilarFilm
                {
                    ParentFilmId = 4,
                    SimilarFilmId = 5,
                },
                new SimilarFilm
                {
                    ParentFilmId = 5,
                    SimilarFilmId = 7,
                },
                new SimilarFilm
                {
                    ParentFilmId = 7,
                    SimilarFilmId = 5,
                },
                new SimilarFilm
                {
                    ParentFilmId = 8,
                    SimilarFilmId = 9,
                },
                new SimilarFilm
                {
                    ParentFilmId = 9,
                    SimilarFilmId = 8,
                }
                );
        }
    }


}
