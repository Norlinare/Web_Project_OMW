using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OMV.Video.Database.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OMV.Video.API.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        List<Director> directors = new List<Director>();

        private readonly IMapper _mapper;

        private readonly OMVContext _context;

        public DirectorController(OMVContext context)
        {
            _context = context;
        }

        // GET: api/<DirectorController>
        [HttpGet]
        public async Task<ActionResult<List<Director>>> GetDirectors()
        {
            directors = await _context.Directors.ToListAsync();

            return Ok(directors);
        }



    }
}
