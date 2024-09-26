using Common.Helpers;
using Common.Model;
using Data.EF;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Service
{
  public interface IDangKyService
  {
    Task<User> RegisterAsync(RegisterModel model);
  }
  public class DangKyService
  {
    //rivate readonly MDPDbContext _context;
    private readonly IRepository _repository;

    public DangKyService(MDPDbContext context, IRepository repository)
    {
      //_context = context;
      _repository = repository;
    }

    public async Task<User> RegisterAsync(RegisterModel model)
    {
      try
      {
        var hashedPassword = PasswordHelper.HashPassword(model.Password);
        var user = new User
        {
          Id = Guid.NewGuid().ToString(),
          Username = model.Username,
          Password = hashedPassword,
          MaBV = model.MaBV,
          DateCreated = DateTime.UtcNow,
          DateModified = DateTime.UtcNow,
          IsDeleted = false,
          IsLocked = false
        };
        return await _repository.InsertAsync(user);
      }
      catch (Exception ex)
      {
        throw;
      }
    }
  }
}
