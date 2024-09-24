using Microsoft.EntityFrameworkCore;

public class UserRoleService
{
    private readonly MDPDbContext _context;

    public UserRoleService(MDPDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserRoleModel>> GetAll()
    {
        return await _context.UserRoles.ToListAsync();
    }
}