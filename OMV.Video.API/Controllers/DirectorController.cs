

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OMV.Video.API.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly OMVContext _context;

        public DirectorController(OMVContext context)
        {
            _context = context;
        }

        // GET: api/<DirectorController>
        [HttpGet]
        public async Task<ActionResult<DbService<List<Director>>>> GetDirectors()
        {
            var directors = await _context.Directors.ToListAsync();
            var response = new DbService<List<Director>>()
            {
                Data = directors
            };
            return Ok(response);
        }



    }
}
