namespace OMV.Video.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimilarFilmController : ControllerBase
    {
        private readonly IDbService _db;
        public SimilarFilmController(IDbService db)
        {
            _db = db;
        }

        // POST api/<SimilarFilmController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] SimilarFilmDTO dto)
        {
            try
            {
                var similarfilm = await _db.AddAsyncRefEntity<SimilarFilm, SimilarFilmDTO>(dto);
                var result = await _db.SaveChangesAsync();
                if (!result) return Results.BadRequest();
                var node = typeof(SimilarFilm).Name.ToLower();

                return Results.Created($"/{node}s/{dto}", similarfilm);

            }
            catch
            {
                return Results.BadRequest("Could not add the SimilarFilm");
            }
        }



        // DELETE api/<SimilarFilmController>/5
        [HttpDelete]
        public async Task<IResult> Delete([FromBody] SimilarFilmDTO dto)
        {
            try
            {
                var similarfilm = _db.DeleteAsyncRefEntity<SimilarFilm, SimilarFilmDTO>(dto);
                if (!similarfilm) return Results.NotFound();

                var success = await _db.SaveChangesAsync();
                if (success) return Results.NoContent();

            }
            catch
            {

            }
            return Results.BadRequest("Could not delete the SimilarFilm");
        }
    }
}
