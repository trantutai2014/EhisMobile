using API.Services;
using MDP.API.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Ocsp;

public class UserRolesController : BaseController
{
    private readonly IUserRoleService _userRoleService;

    public UserRolesController(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }
    [AllowAnonymous]  
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
    //try
    //{
    //    var userRoles = await _userRoleService.GetAll();
    //    if (userRoles == null)
    //    {
    //        return NotFound();
    //    }
    //    return Ok(userRoles);
    //}
    //catch (Exception ex)
    //{
    //    return StatusCode(500, ex.Message);
    //}
    var data = await _userRoleService.GetAll();
    return Ok(data);
  }
}
