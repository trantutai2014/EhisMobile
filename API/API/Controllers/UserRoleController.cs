using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UserRolesController : ControllerBase
{
    private readonly UserRoleService _userRoleService;

    public UserRolesController(UserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var userRoles = await _userRoleService.GetAll();
            if (userRoles == null)
            {
                return NotFound();
            }
            return Ok(userRoles);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}