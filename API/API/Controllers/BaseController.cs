﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  [Produces("application/json")]
  public class BaseController : ControllerBase
  {
  }
}