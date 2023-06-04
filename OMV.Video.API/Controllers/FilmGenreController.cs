namespace OMV.Video.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmGenreController : ControllerBase
    {
        private readonly IDbService _db;
        public FilmGenreController(IDbService db)
        {
            _db = db;
        }



        // POST api/<FilmGenresController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] FilmGenreCreateDTO dto)
        {
            try
            {
                var filmgenre = await _db.AddAsyncRefEntity<FilmGenre, FilmGenreCreateDTO>(dto);
                var result = await _db.SaveChangesAsync();
                if (!result) return Results.BadRequest();

                var node = typeof(FilmGenre).Name.ToLower();

                return Results.Created($"/{node}s/{dto}", filmgenre);
            }
            catch
            {
                return Results.BadRequest("Could not add the filmgenre");
            }
        }

        // DELETE api/<FilmGenresController>/3
        [HttpDelete]
        public async Task<IResult> Delete([FromBody] FilmGenreEditDTO dto)
        {
            try
            {
                var filmgenre = _db.DeleteAsyncRefEntity<FilmGenre, FilmGenreEditDTO>(dto);
                if (!filmgenre) return Results.NotFound();

                var success = await _db.SaveChangesAsync();
                if (success) return Results.NoContent();

            }
            catch
            {
                return Results.BadRequest($"Failed to delete FilmGenre with FilmId:{dto.FilmId} and GenreId:{dto.GenreId}");
            }
            return Results.BadRequest("Could not delete the filmgenre");
        }
    }
}
