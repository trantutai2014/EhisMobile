using API.Model;
using Common.Constants;
using Common.Extensions;
using Data.Interfaces;
using Data.Models;
using MDP.Data.Models;
using MDP.Data.Models.SKDT;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using Z.EntityFramework.Extensions;

public class MDPDbContext : DbContext
{
  private readonly IHttpContextAccessor _httpContextAccessor;
  public MDPDbContext(DbContextOptions<MDPDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
  {
    _httpContextAccessor = httpContextAccessor;
    EntityFrameworkManager.ContextFactory = context => new MDPDbContext(options);
  }

  public MDPDbContext(DbContextOptions<MDPDbContext> options) : base(options)
  {
  }

  //public DbSet<UserRoleModel> UserRoles { get; set; }
  //public DbSet<UserModel> Users { get; set; }
  //public DbSet<RegisterModel> Register { get; set; }
  public DbSet<User> Users { get; set; }
  public DbSet<Role> Roles { get; set; }
  public DbSet<UserLogin> UserLogins { get; set; }
  public DbSet<UserRole> UserRoles { get; set; }
  public DbSet<NavigationMenu> NavigationMenus { get; set; }
  public DbSet<RoleNavigationMenu> RoleNavigationMenus { get; set; }

  public DbSet<DMCoSo> DMCoSos { get; set; }
  public DbSet<ThongTinKhamChuaBenh130> ThongTinKhamChuaBenh130s { get; set; }
  public virtual DbSet<SKDT_HoSo> SKDT_HoSos { get; set; }
  public virtual DbSet<SKDT_DMNgheNghiep> SKDT_DMNgheNghieps { get; set; }
  public virtual DbSet<SKDT_DMPhuongXa> SKDT_DMPhuongXas { get; set; }
  public virtual DbSet<SKDT_DMQuanHuyen> SKDT_DMQuanHuyens { get; set; }
  public virtual DbSet<SKDT_DMQuocTich> SKDT_DMQuocTichs { get; set; }
  public virtual DbSet<SKDT_DMTinhThanh> SKDT_DMTinhThanhs { get; set; }
  public virtual DbSet<SoTheBHYT> SoTheBHYTs { get; set; }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    ConfigureModel(modelBuilder);
  }

  public static void ConfigureModel(ModelBuilder modelBuilder)
  {
    var user = modelBuilder.Entity<User>();
    var role = modelBuilder.Entity<Role>();
    var userLogin = modelBuilder.Entity<UserLogin>();
    var userRole = modelBuilder.Entity<UserRole>();
    var navigationMenu = modelBuilder.Entity<NavigationMenu>();
    var roleNavigationMenu = modelBuilder.Entity<RoleNavigationMenu>();
    var thongtinkcb130 = modelBuilder.Entity<ThongTinKhamChuaBenh130>();
    var dmcoso = modelBuilder.Entity<DMCoSo>();
    var skdt_hoso = modelBuilder.Entity<SKDT_HoSo>();
    var skdt_dmnghe = modelBuilder.Entity<SKDT_DMNgheNghiep>();
    var skdt_dmphuongxa = modelBuilder.Entity<SKDT_DMPhuongXa>();
    var skdt_dmquanhuyen = modelBuilder.Entity<SKDT_DMQuanHuyen>();
    var skdt_dmquoctich = modelBuilder.Entity<SKDT_DMQuocTich>();
    var skdt_dmtinhthanh = modelBuilder.Entity<SKDT_DMTinhThanh>();


    skdt_hoso.HasOne(_ => _.SKDT_DMNgheNghiep).WithMany(_ => _.SKDT_HoSos).HasForeignKey(_ => _.MaNgheNghiep);
    skdt_hoso.HasOne(_ => _.SKDT_DMQuocTich).WithMany(_ => _.SKDT_HoSos).HasForeignKey(_ => _.MaQuocTich);
    skdt_hoso.HasOne(_ => _.SKDT_DMPhuongXa).WithMany(_ => _.SKDT_HoSos).HasForeignKey(_ => _.MaPhuongXa);
    skdt_hoso.HasOne(_ => _.SKDT_DMDanToc).WithMany(_ => _.SKDT_HoSos).HasForeignKey(_ => _.MaDanToc);

    user.HasIndex(_ => _.Id);
    user.HasIndex(_ => _.Username)
        .IsUnique();
    user.HasOne(_ => _.UserLogin).WithOne(_ => _.User).HasForeignKey<UserLogin>(_ => _.Id);
    user.HasOne(_ => _.DMCoSo).WithMany(_ => _.Users).HasForeignKey(_ => _.MaBV);

    role.HasIndex(_ => _.Id);

    userLogin.HasIndex(_ => _.Id);

    userRole.HasIndex(_ => _.Id);
    userRole.HasOne(_ => _.User).WithMany(_ => _.UserRoles).HasForeignKey(_ => _.UserId);
    userRole.HasOne(_ => _.Role).WithMany(_ => _.UserRoles).HasForeignKey(_ => _.RoleId);

    navigationMenu.HasIndex(_ => _.Id);
    navigationMenu.HasOne(_ => _.ParentNavMenu).WithMany(_ => _.ChildNavMenus).HasForeignKey(_ => _.ParentId);

    roleNavigationMenu.HasIndex(_ => _.Id);
    roleNavigationMenu.HasOne(_ => _.Role).WithMany(_ => _.RoleNavigationMenus).HasForeignKey(_ => _.RoleId);
    roleNavigationMenu.HasOne(_ => _.NavigationMenu).WithMany(_ => _.RoleNavigationMenus).HasForeignKey(_ => _.NavigationMenuId);

    dmcoso.HasIndex(_ => _.Id).IsUnique();
    dmcoso.HasOne(_ => _.Parent).WithMany(_ => _.Childrens).HasForeignKey(_ => _.ParentId);

    modelBuilder.Entity<UserExternalApi>(entity =>
    {
      entity.HasOne(d => d.User)
            .WithMany(p => p.UserExternalApis)
            .HasForeignKey(d => d.UserId);
    });
    foreach (var property in modelBuilder.Model.GetEntityTypes()
    .SelectMany(t => t.GetProperties())
    .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
    {
      property.SetColumnType("decimal(18,2)");
    }
  }
  public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
  {
    var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Added ||
                                                      e.State == EntityState.Modified ||
                                                      e.State == EntityState.Deleted);
    foreach (var item in modified)
    {
      // DateTracking
      if (item.Entity is IDateTracking dateTracking)
      {
        if (item.State == EntityState.Added)
          dateTracking.DateCreated = DateTime.Now;
        else if (item.State == EntityState.Deleted)
          dateTracking.DateDeleted = DateTime.Now;

        dateTracking.DateModified = DateTime.Now;
      }

      // PersonTracking
      if (item.Entity is IPersonTracking personTracking)
      {
        if (_httpContextAccessor.HttpContext != null &&
            _httpContextAccessor.HttpContext.User != null &&
            _httpContextAccessor.HttpContext.User.Identity != null &&
            _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
        {
          var userId = IdentityExtensions.GetUserId(_httpContextAccessor);

          if (item.State == EntityState.Added)
            personTracking.CreatorUserId = userId;
          else if (item.State == EntityState.Deleted)
            personTracking.DeleterUserId = userId;

          personTracking.LastModifierUserId = userId;
        }
      }

      // HospitalCode
      if (item.Entity is IHospitalCode hospitalCode)
      {
        if (item.State == EntityState.Added)
        {
          hospitalCode.MaBV = _httpContextAccessor.HttpContext!.User!.GetSpecificClaim(ClaimConsts.MaBV);
        }
      }
    }

    //var auditEntries = OnBeforeSaveChanges();

    var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

    //OnAfterSaveChanges(auditEntries);

    return result;
  }
}
