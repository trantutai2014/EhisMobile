using API.Model;
using Microsoft.EntityFrameworkCore;

public class MDPDbContext : DbContext
{
        public MDPDbContext(DbContextOptions<MDPDbContext> options) : base(options)
        {
        }

        public DbSet<UserRoleModel> UserRoles { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RegisterModel> Register { get; set; }


}