//using OMV.Common.DTOs;
//using OMV.Video.Database.Service;

//namespace OMV.Video.Database.Extensions
//{

//    public static class SeedExtension
//    {
//        public static async Task SeedData(this IDbService service)
//        {
//            try
//            {
//                //#region Add Director
//                await service.AddAsync<Director, DirectorCreateDTO>(new DirectorCreateDTO
//                {
//                    Name = "Steven Spielberg"
//                });

//                await service.AddAsync<Director, DirectorCreateDTO>(new DirectorCreateDTO
//                {
//                    Name = "Clint Eastwood"
//                });

//                await service.AddAsync<Director, DirectorCreateDTO>(new DirectorCreateDTO
//                {
//                    Name = "Tim Burton"
//                });

//                //await service.SaveChangesAsync();
//                //#endregion


//                //#region Add Films
//                var Director1 = await service.SingleAsync<Director, DirectorDTO>(c => c.Name.Equals("Steven Spielberg"));
//                var Director2 = await service.SingleAsync<Director, DirectorDTO>(c => c.Name.Equals("Clint Eastwood"));
//                var Director3 = await service.SingleAsync<Director, DirectorDTO>(c => c.Name.Equals("Tim Burton"));

//                //Steven Spielberg
//                await service.AddAsync<Film, FilmCreateDTO>(new FilmCreateDTO
//                {
//                    Title = "Indiana Jones and the Kingdom of the Crystal Skull",
//                    Released = new DateTime(2008, 05, 18),
//                    Free = false,
//                    Description = "An adventurer goes looking for the Crystal Skull in a temple.",
//                    FilmUrl = "https://www.youtube.com/watch?v=WAdJf4wTC5Y",
//                    DirectorId = Director1.Id
//                });

//                await service.AddAsync<Film, FilmCreateDTO>(new FilmCreateDTO
//                {
//                    Title = "Jurassic Park",
//                    Released = new DateTime(1993, 06, 11),
//                    Free = false,
//                    Description = "Dinosaurs get released by accident on an amusement park and wreck havoc.",
//                    FilmUrl = "https://www.youtube.com/watch?v=lc0UehYemQA",
//                    DirectorId = Director1.Id
//                });

//                await service.AddAsync<Film, FilmCreateDTO>(new FilmCreateDTO
//                {
//                    Title = "Jaws",
//                    Released = new DateTime(1975, 06, 20),
//                    Free = true,
//                    Description = "A shark attacks people at a beach.",
//                    FilmUrl = "https://www.youtube.com/watch?v=U1fu_sA7XhE",
//                    DirectorId = Director1.Id
//                });

//                //Clint Eastwood
//                await service.AddAsync<Film, FilmCreateDTO>(new FilmCreateDTO
//                {
//                    Title = "Space Cowboys",
//                    Released = new DateTime(2000, 08, 04),
//                    Free = true,
//                    Description = "A story in space.",
//                    FilmUrl = "https://www.youtube.com/watch?v=WjIMiGb_tmM",
//                    DirectorId = Director2.Id
//                });

//                await service.AddAsync<Film, FilmCreateDTO>(new FilmCreateDTO
//                {
//                    Title = "Pale Rider",
//                    Released = new DateTime(1985, 06, 26),
//                    Free = true,
//                    Description = "A western story about a man.",
//                    FilmUrl = "https://www.youtube.com/watch?v=SGzz3hh1jHc",
//                    DirectorId = Director2.Id
//                });

//                await service.AddAsync<Film, FilmCreateDTO>(new FilmCreateDTO
//                {
//                    Title = "Invictus",
//                    Released = new DateTime(2009, 12, 11),
//                    Free = false,
//                    Description = "A story about a sports player in South Africa.",
//                    FilmUrl = "https://www.youtube.com/watch?v=RZY8c_a_dlQ",
//                    DirectorId = Director2.Id
//                });

//                //Tim Burton
//                await service.AddAsync<Film, FilmCreateDTO>(new FilmCreateDTO
//                {
//                    Title = "Batman",
//                    Released = new DateTime(1989, 06, 19),
//                    Free = true,
//                    Description = "A boy's parents gets murdered and the son take an oath to avenge them and fight off evil.",
//                    FilmUrl = "https://www.youtube.com/watch?v=dgC9Q0uhX70",
//                    DirectorId = Director3.Id
//                });

//                await service.AddAsync<Film, FilmCreateDTO>(new FilmCreateDTO
//                {
//                    Title = "Alice in Wonderland",
//                    Released = new DateTime(2010, 02, 25),
//                    Free = false,
//                    Description = "Alice falls down a hole and has to save a kingdom.",
//                    FilmUrl = "https://www.youtube.com/watch?v=9POCgSRVvf0",
//                    DirectorId = Director3.Id
//                });

//                await service.AddAsync<Film, FilmCreateDTO>(new FilmCreateDTO
//                {
//                    Title = "Miss Peregrine's Home for Peculiar Children",
//                    Released = new DateTime(2016),
//                    Free = false,
//                    Description = "A boy finds a mysterious house with mysterious people.",
//                    FilmUrl = "https://www.youtube.com/watch?v=tV_IhWE4LP0",
//                });

//                //await service.SaveChangesAsync();
//                //#endregion

//                //#region Add Genres

//                await service.AddAsync<Genre, GenreCreateDTO>(new GenreCreateDTO
//                {
//                    Name = "Adventure"
//                });

//                await service.AddAsync<Genre, GenreCreateDTO>(new GenreCreateDTO
//                {
//                    Name = "Sci-Fi"
//                });


//                await service.AddAsync<Genre, GenreCreateDTO>(new GenreCreateDTO
//                {
//                    Name = "Horror"
//                });

//                await service.AddAsync<Genre, GenreCreateDTO>(new GenreCreateDTO
//                {
//                    Name = "Western"
//                });

//                await service.AddAsync<Genre, GenreCreateDTO>(new GenreCreateDTO
//                {
//                    Name = "Sport"
//                });

//                await service.AddAsync<Genre, GenreCreateDTO>(new GenreCreateDTO
//                {
//                    Name = "Action"
//                });

//                await service.AddAsync<Genre, GenreCreateDTO>(new GenreCreateDTO
//                {
//                    Name = "Mystery"
//                });
//                //await service.SaveChangesAsync();
//                //#endregion

//                //#region Add FilmGenre
//                var film1 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Indiana Jones and the Kingdom of the Crystal Skull");
//                var film2 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Jurassic Park");
//                var film3 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Jaws");
//                var film4 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Space Cowboys");
//                var film5 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Pale Rider");
//                var film6 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Invictus");
//                var film7 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Batman");
//                var film8 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Alice in Wonderland");
//                var film9 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Miss Peregrine's Home for Peculiar Children");
//                var genre1 = await service.SingleAsync<Genre, GenreDTO>(g => g.Name == "Adventure");
//                var genre2 = await service.SingleAsync<Genre, GenreDTO>(g => g.Name == "Sci-Fi");
//                var genre3 = await service.SingleAsync<Genre, GenreDTO>(g => g.Name == "Horror");
//                var genre4 = await service.SingleAsync<Genre, GenreDTO>(g => g.Name == "Western");
//                var genre5 = await service.SingleAsync<Genre, GenreDTO>(g => g.Name == "Sport");
//                var genre6 = await service.SingleAsync<Genre, GenreDTO>(g => g.Name == "Action");
//                var genre7 = await service.SingleAsync<Genre, GenreDTO>(g => g.Name == "Mystery");




//                await service.AddAsyncRefEntity<FilmGenre, FilmGenreCreateDTO>(new FilmGenreCreateDTO
//                {
//                    FilmId = film1.Id,
//                    GenreId = genre1.Id,
//                });

//                await service.AddAsyncRefEntity<FilmGenre, FilmGenreCreateDTO>(new FilmGenreCreateDTO
//                {
//                    FilmId = film2.Id,
//                    GenreId = genre2.Id,
//                });

//                await service.AddAsyncRefEntity<FilmGenre, FilmGenreCreateDTO>(new FilmGenreCreateDTO
//                {
//                    FilmId = film3.Id,
//                    GenreId = genre3.Id,
//                });

//                await service.AddAsyncRefEntity<FilmGenre, FilmGenreCreateDTO>(new FilmGenreCreateDTO
//                {
//                    FilmId = film4.Id,
//                    GenreId = genre2.Id,
//                });

//                await service.AddAsyncRefEntity<FilmGenre, FilmGenreCreateDTO>(new FilmGenreCreateDTO
//                {
//                    FilmId = film4.Id,
//                    GenreId = genre6.Id,
//                });

//                await service.AddAsyncRefEntity<FilmGenre, FilmGenreCreateDTO>(new FilmGenreCreateDTO
//                {
//                    FilmId = film5.Id,
//                    GenreId = genre4.Id,
//                });

//                await service.AddAsyncRefEntity<FilmGenre, FilmGenreCreateDTO>(new FilmGenreCreateDTO
//                {
//                    FilmId = film6.Id,
//                    GenreId = genre5.Id,
//                });

//                await service.AddAsyncRefEntity<FilmGenre, FilmGenreCreateDTO>(new FilmGenreCreateDTO
//                {
//                    FilmId = film7.Id,
//                    GenreId = genre6.Id,
//                });

//                await service.AddAsyncRefEntity<FilmGenre, FilmGenreCreateDTO>(new FilmGenreCreateDTO
//                {
//                    FilmId = film7.Id,
//                    GenreId = genre3.Id,
//                });

//                await service.AddAsyncRefEntity<FilmGenre, FilmGenreCreateDTO>(new FilmGenreCreateDTO
//                {
//                    FilmId = film8.Id,
//                    GenreId = genre1.Id,
//                });

//                await service.AddAsyncRefEntity<FilmGenre, FilmGenreCreateDTO>(new FilmGenreCreateDTO
//                {
//                    FilmId = film9.Id,
//                    GenreId = genre7.Id,
//                });

//                //await service.SaveChangesAsync();
//                //#endregion

//                //#region Add SimilarFilm

//                var ParentFilm1 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Indiana Jones and the Kingdom of the Crystal Skull");
//                var ParentFilm2 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Jurassic Park");
//                var ParentFilm3 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Jaws");
//                var ParentFilm4 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Space Cowboys");
//                var ParentFilm5 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Pale Rider");
//                var ParentFilm6 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Invictus");
//                var ParentFilm7 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Batman");
//                var ParentFilm8 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Alice in Wonderland");
//                var ParentFilm9 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Miss Peregrine's Home for Peculiar Children");

//                var SimilarFilm1 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Indiana Jones and the Kingdom of the Crystal Skull");
//                var SimilarFilm2 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Jurassic Park");
//                var SimilarFilm3 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Jaws");
//                var SimilarFilm4 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Space Cowboys");
//                var SimilarFilm5 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Pale Rider");
//                var SimilarFilm6 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Invictus");
//                var SimilarFilm7 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Batman");
//                var SimilarFilm8 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Alice in Wonderland");
//                var SimilarFilm9 = await service.SingleAsync<Film, FilmDTO>(f => f.Title == "Miss Peregrine's Home for Peculiar Children");

//                await service.AddAsyncRefEntity<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
//            (
//                ParentFilm1.Id,
//                SimilarFilm2.Id
//            )
//            );
//                await service.AddAsyncRefEntity<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
//            (
//                ParentFilm2.Id,
//                SimilarFilm1.Id
//            )
//            );

//                await service.AddAsyncRefEntity<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
//            (
//                ParentFilm4.Id,
//                SimilarFilm5.Id
//            )
//            );
//                await service.AddAsyncRefEntity<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
//            (
//                ParentFilm5.Id,
//                SimilarFilm4.Id
//            )
//            );
//                await service.AddAsyncRefEntity<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
//            (
//                ParentFilm7.Id,
//                SimilarFilm4.Id
//            )
//            );
//                await service.AddAsyncRefEntity<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
//            (
//                ParentFilm4.Id,
//                SimilarFilm7.Id
//            )
//            );
//                await service.AddAsyncRefEntity<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
//         (
//             ParentFilm7.Id,
//             SimilarFilm5.Id
//         )
//         );
//                await service.AddAsyncRefEntity<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
//            (
//                ParentFilm5.Id,
//                SimilarFilm7.Id
//            )
//            );
//                await service.AddAsyncRefEntity<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
//         (
//             ParentFilm8.Id,
//             SimilarFilm9.Id
//         )
//         );
//                await service.AddAsyncRefEntity<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
//            (
//                ParentFilm9.Id,
//                SimilarFilm8.Id
//            )
//            );

//                await service.AddAsyncRefEntity<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
//         (
//             ParentFilm1.Id,
//             SimilarFilm9.Id
//         )
//         );
//                await service.AddAsyncRefEntity<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
//            (
//                ParentFilm9.Id,
//                SimilarFilm1.Id
//            )
//            );

//                await service.AddAsyncRefEntity<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
//            (
//                ParentFilm9.Id,
//                SimilarFilm8.Id
//            )
//            );

//                await service.AddAsyncRefEntity<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
//         (
//             ParentFilm1.Id,
//             SimilarFilm8.Id
//         )
//         );
//                await service.AddAsyncRefEntity<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
//            (
//                ParentFilm8.Id,
//                SimilarFilm1.Id
//            )
//            );

//                await service.SaveChangesAsync();
//                //#endregion
//            }
//            catch (Exception ex)
//            {

//            }
//        }
//    }
//}
