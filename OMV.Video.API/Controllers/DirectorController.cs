namespace OMV.Video.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDbService _db;
        public DirectorController(IDbService db)
        {
            _db = db;
        }

        // GET: api/<DirectorController>
        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                _db.Include<Director>();
                var directors = await _db.GetAllAsync<Director, DirectorDTO>();
                return Results.Ok(directors);
            }
            catch
            {
                return Results.NotFound("Could not find any Directors");
            }
        }

        // GET api/<DirectorController>/3
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            try
            {
                _db.Include<Director>();
                var director = await _db.SingleAsync<Director, DirectorDTO>(f => f.Id == id);
                return Results.Ok(director);
            }
            catch (Exception)
            {

                return Results.NotFound("Could not find that Director");
            }
        }

        // POST api/<DirectorController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] DirectorCreateDTO dto)
        {
            try
            {
                var director = await _db.AddAsync<Director, DirectorCreateDTO>(dto);
                var result = await _db.SaveChangesAsync();
                if (!result) return Results.BadRequest();

                return Results.Created(_db.GetURL(director), director);
            }
            catch
            {
                return Results.BadRequest("Could not add the Director");
            }
        }

        // PUT api/<DirectorController>/3
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] DirectorEditDTO dto)
        {
            try
            {
                if (id != dto.Id)
                {
                    return Results.BadRequest($"Id not found. URL ID: {id} DTO Id: {dto.Id}");
                }
                var exists = await _db.AnyAsync<Director>(d => d.Id == id);
                if (!exists) return Results.NotFound("Director not found");

                _db.Update<Director, DirectorEditDTO>(id, dto);
                var result = await _db.SaveChangesAsync();
                if (!result) return Results.BadRequest();

                return Results.NoContent();
            }
            catch
            {
                return Results.BadRequest("Could not update the Director");
            }
        }

        // DELETE api/<DirectorController>/3
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                var exists = await _db.AnyAsync<Director>(d => d.Id == id);
                if (!exists) return Results.NotFound("Director not found");

                var success = await _db.DeleteAsync<Director>(id);
                if (!success) return Results.NotFound("Director could not be deleted");

                await _db.SaveChangesAsync();


                return Results.NoContent();
            }
            catch
            {
                return Results.BadRequest($"Failed to delete Director with Id:{id}");
            }
        }
    }
}
