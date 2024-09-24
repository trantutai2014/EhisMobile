using API.Helper;
using API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Services
{
    public class DangNhapService
    {
        private readonly MDPDbContext _context;

        public DangNhapService(MDPDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> LoginAsync(string username, string password)
        {
            try
            {
                var user = await _context.Users
                    .Where(u => u.Username == username)
                    .Select(u => new { u.Username, u.Password }) // Only retrieve username and password
                    .FirstOrDefaultAsync();
                if (user != null)
                {
                    if (PasswordHelper.VerifyHashedPassword(user.Password, password))
                    {
                        return new UserModel { Username = user.Username, Password = user.Password };
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}