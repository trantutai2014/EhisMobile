using API.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Protect all actions in this controller
    public class TrangChuController : ControllerBase
    {



        [HttpGet]
        public IActionResult GetHomeData()
        {
            // Return home page data
            return Ok(new { data = "Protected Home Data" }); 
        }



    }
}
