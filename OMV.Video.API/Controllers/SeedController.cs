//using Microsoft.AspNetCore.Authorization;
//using OMV.Video.Database.Extensions;


//namespace OMV.Video.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SeedController : ControllerBase
//    {
//        private readonly IDbService _db;
//        public SeedController(IDbService db)
//        {
//            _db = db;
//        }

//        [AllowAnonymous]
//        [HttpPost]
//        public async Task<IResult> Seed()
//        {
//            try
//            {
//                await _db.SeedData();
//                return Results.NoContent();
//            }
//            catch
//            {

//            }
//            return Results.BadRequest();
//        }


//    }
//}
