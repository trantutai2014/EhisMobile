

using Data.EF;
using Data.Models;
using Microsoft.EntityFrameworkCore;

public interface IUserRoleService
{
     Task<IEnumerable<UserRoleModel>> GetAll();
}
public class UserRoleService: IUserRoleService
{
    private readonly MDPDbContext _context;
    private readonly IRepository _repository;

    public UserRoleService(MDPDbContext context, IRepository repository)
    {
        _context = context;
      _repository = repository;
    }

  public async Task<IEnumerable<UserRoleModel>> GetAll()
  {
    var data = _repository.GetAll<UserRole>().Select(s =>
    new UserRoleModel
    {
      ID = s.Id,
      RoleId = s.RoleId,
      UserId = s.UserId,
    }).AsEnumerable();
    return data;
  }
}
