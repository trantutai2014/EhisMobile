using API.Common.Models;
using API.Helper;
using MDP.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class DangKyService
    {
        private readonly MDPDbContext _context;

        public DangKyService(MDPDbContext context)
        {
            _context = context;
        }

        public async Task RegisterAsync(RegisterModel model)
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

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
