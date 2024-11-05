using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class ValuesController 
  {
    // GET: api/<ValuesController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

   
  }
}
