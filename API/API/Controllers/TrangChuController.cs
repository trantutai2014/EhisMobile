using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Protect all actions in this controller
    public class TrangChuController : ControllerBase
    {
        // Your protected actions here

        [HttpGet]
        public IActionResult GetHomeData()
        {
            // Return home page data
            return Ok(new { data = "Protected Home Data" });
        }
    }
}
