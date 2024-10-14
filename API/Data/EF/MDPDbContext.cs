using Common.Constants;
using Common.Extensions;
using Data.Interfaces;
using Data.Models;
using Data.Models.SKDT;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

  public virtual DbSet<SKDT_HoSo> SKDT_HoSos { get; set; }
  public virtual DbSet<SKDT_DMNgheNghiep> SKDT_DMNgheNghieps { get; set; }
  public virtual DbSet<SKDT_DMPhuongXa> SKDT_DMPhuongXas { get; set; }
  public virtual DbSet<SKDT_DMQuanHuyen> SKDT_DMQuanHuyens { get; set; }
  public virtual DbSet<SKDT_DMQuocTich> SKDT_DMQuocTichs { get; set; }
  public virtual DbSet<SKDT_DMTinhThanh> SKDT_DMTinhThanhs { get; set; }
  public virtual DbSet<SoTheBHYT> SoTheBHYTs { get; set; }

  public DbSet<DS_ChiTiet_DVKT> DS_ChiTiet_DVKTs { get; set; }
  public DbSet<DS_ChiTiet_Thuoc> DS_ChiTiet_Thuocs { get; set; }
  public DbSet<DS_DienBien_LamSang> DS_DienBien_LamSangs { get; set; }
  public DbSet<DS_KetQua_CLS> DS_KetQua_CLSs { get; set; }
  public DbSet<LichSuTuongTac> LichSuTuongTacs { get; set; }

  public DbSet<ThongTinKhamChuaBenh130> ThongTinKhamChuaBenh130s { get; set; }
  public DbSet<LichSuTuongTac130> LichSuTuongTac130s { get; set; }
  public DbSet<DS_ChiTiet_DVKT130> DS_ChiTiet_DVKT130s { get; set; }
  public DbSet<DS_ChiTiet_Thuoc130> DS_ChiTiet_Thuoc130s { get; set; }
  public DbSet<DS_DVCLS130> DS_DVCLS130s { get; set; }
  public DbSet<DS_CSDT_ARV130> DS_CSDT_ARV130s { get; set; }
  public DbSet<DS_GiayRaVien130> DS_GiayRaVien130s { get; set; }
  public DbSet<DS_TomTat_HoSoBA130> DS_TomTat_HoSoBA130s { get; set; }
  public DbSet<DS_GiayChungSinh130> DS_GiayChungSinh130s { get; set; }
  public DbSet<DS_ChungNhan_NghiDuongThai130> DS_ChungNhan_NghiDuongThai130s { get; set; }
  public DbSet<DS_GiayChungNhan_NghiViec_HBHXH130> DS_GiayChungNhan_NghiViec_HBHXH130s { get; set; }
  public DbSet<DS_GiamDinhYKhoa130> DS_GiamDinhYKhoa130s { get; set; }
  public DbSet<DS_GiayChuyenTuyen130> DS_GiayChuyenTuyen130s { get; set; }
  public DbSet<DS_GiayHenKhamLai130> DS_GiayHenKhamLai130s { get; set; }
  public DbSet<DS_DieuTriBenhLao130> DS_DieuTriBenhLao130s { get; set; }
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

    var dmcoso = modelBuilder.Entity<DMCoSo>();
    var skdt_hoso = modelBuilder.Entity<SKDT_HoSo>();
    var skdt_dmnghe = modelBuilder.Entity<SKDT_DMNgheNghiep>();
    var skdt_dmphuongxa = modelBuilder.Entity<SKDT_DMPhuongXa>();
    var skdt_dmquanhuyen = modelBuilder.Entity<SKDT_DMQuanHuyen>();
    var skdt_dmquoctich = modelBuilder.Entity<SKDT_DMQuocTich>();
    var skdt_dmtinhthanh = modelBuilder.Entity<SKDT_DMTinhThanh>();

    var lichsutuongtac = modelBuilder.Entity<LichSuTuongTac>();
    var thongtinkcb = modelBuilder.Entity<ThongTinKhamChuaBenh>();
    var dschitietdvkt = modelBuilder.Entity<DS_ChiTiet_DVKT>();
    var dschitietthuoc = modelBuilder.Entity<DS_ChiTiet_Thuoc>();
    var dschitietdienbien = modelBuilder.Entity<DS_DienBien_LamSang>();
    var dschitietketqua = modelBuilder.Entity<DS_KetQua_CLS>();

    var lichsutuongtac130 = modelBuilder.Entity<LichSuTuongTac130>();
    var thongtinkcb130 = modelBuilder.Entity<ThongTinKhamChuaBenh130>();
    var dschitietthuoc130 = modelBuilder.Entity<DS_ChiTiet_Thuoc130>();
    var dschitietdvkt130 = modelBuilder.Entity<DS_ChiTiet_DVKT130>();
    var dsdvcls130 = modelBuilder.Entity<DS_DVCLS130>();
    var dsdbcls130 = modelBuilder.Entity<DS_DienBien_LamSang130>();
    var dsarv130 = modelBuilder.Entity<DS_CSDT_ARV130>();
    var dsDS_GiayRaVien130 = modelBuilder.Entity<DS_GiayRaVien130>();
    var dstthosoba130 = modelBuilder.Entity<DS_TomTat_HoSoBA130>();
    var dsgiaychungsinh130 = modelBuilder.Entity<DS_GiayChungSinh130>();
    var dsnghiduongthai130 = modelBuilder.Entity<DS_ChungNhan_NghiDuongThai130>();
    var dshuongbhxh130 = modelBuilder.Entity<DS_GiayChungNhan_NghiViec_HBHXH130>();
    var dsgiamdinhykhoa130 = modelBuilder.Entity<DS_GiamDinhYKhoa130>();
    var dschuyentuyen130 = modelBuilder.Entity<DS_GiayChuyenTuyen130>();
    var dshenkhamlai130 = modelBuilder.Entity<DS_GiayHenKhamLai130>();
    var dsdieutrilao130 = modelBuilder.Entity<DS_DieuTriBenhLao130>();

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

    lichsutuongtac.HasIndex(_ => _.Id);
    lichsutuongtac.HasIndex(_ => _.MaBV);
    lichsutuongtac.HasIndex(_ => _.NgayGio);
    lichsutuongtac.HasOne(_ => _.DMCoSo).WithMany(_ => _.LichSuTuongTacs).HasForeignKey(_ => _.MaBV);

    thongtinkcb.HasIndex(_ => _.Id);
    thongtinkcb.HasIndex(_ => _.MA_CSKCB);
    thongtinkcb.HasIndex(_ => _.NGAY_VAO);
    thongtinkcb.HasOne(_ => _.LichSuTuongTac).WithMany(_ => _.ThongTinKhamChuaBenhs).HasForeignKey(_ => _.LichSuTuongTacID);

    dschitietdvkt.HasIndex(_ => _.Id);
    dschitietdvkt.HasOne(_ => _.ThongTinKhamChuaBenh).WithMany(_ => _.DS_ChiTiet_DVKTs).HasForeignKey(_ => _.ThongTinKhamChuaBenhID);

    dschitietthuoc.HasIndex(_ => _.Id);
    dschitietthuoc.HasOne(_ => _.ThongTinKhamChuaBenh).WithMany(_ => _.DS_ChiTiet_Thuocs).HasForeignKey(_ => _.ThongTinKhamChuaBenhID);

    dschitietdienbien.HasIndex(_ => _.Id);
    dschitietdienbien.HasOne(_ => _.ThongTinKhamChuaBenh).WithMany(_ => _.DS_DienBien_LamSangs).HasForeignKey(_ => _.ThongTinKhamChuaBenhID);

    dschitietketqua.HasIndex(_ => _.Id);
    dschitietketqua.HasOne(_ => _.ThongTinKhamChuaBenh).WithMany(_ => _.DS_KetQua_CLSs).HasForeignKey(_ => _.ThongTinKhamChuaBenhID);

    lichsutuongtac130.HasIndex(_ => _.Id);
    lichsutuongtac130.HasIndex(_ => _.MaBV);
    lichsutuongtac130.HasIndex(_ => _.NgayGio);
    lichsutuongtac130.HasOne(_ => _.DMCoSo).WithMany(_ => _.LichSuTuongTac130s).HasForeignKey(_ => _.MaBV);

    thongtinkcb130.HasIndex(_ => _.Id);
    thongtinkcb130.HasIndex(_ => _.MA_CSKCB);
    thongtinkcb130.HasIndex(_ => _.NGAY_VAO);
    thongtinkcb130.HasOne(_ => _.LichSuTuongTac130s).WithMany(_ => _.ThongTinKhamChuaBenh130s).HasForeignKey(_ => _.LichSuTuongTacID);

    dschitietdvkt130.HasIndex(_ => _.Id);
    dschitietdvkt130.HasOne(_ => _.ThongTinKhamChuaBenh130).WithMany(_ => _.DS_ChiTiet_DVKT130s).HasForeignKey(_ => _.ThongTinKhamChuaBenhID);

    dschitietthuoc130.HasIndex(_ => _.Id);
    dschitietthuoc130.HasOne(_ => _.ThongTinKhamChuaBenh130).WithMany(_ => _.DS_ChiTiet_Thuoc130s).HasForeignKey(_ => _.ThongTinKhamChuaBenhID);

    dsdvcls130.HasIndex(_ => _.Id);
    dsdvcls130.HasOne(_ => _.ThongTinKhamChuaBenh130).WithMany(_ => _.DS_DVCLS130s).HasForeignKey(_ => _.ThongTinKhamChuaBenhID);

    dsdbcls130.HasIndex(_ => _.Id);
    dsdbcls130.HasOne(_ => _.ThongTinKhamChuaBenh130).WithMany(_ => _.DS_DienBien_LamSang130s).HasForeignKey(_ => _.ThongTinKhamChuaBenhID);

    dsarv130.HasIndex(_ => _.Id);
    dsarv130.HasOne(_ => _.ThongTinKhamChuaBenh130).WithMany(_ => _.DS_CSDT_ARV130s).HasForeignKey(_ => _.ThongTinKhamChuaBenhID);

    dsDS_GiayRaVien130.HasIndex(_ => _.Id);
    dsDS_GiayRaVien130.HasOne(_ => _.ThongTinKhamChuaBenh130).WithOne(_ => _.DS_GiayRaVien130s).HasForeignKey<DS_GiayRaVien130>(_ => _.ThongTinKhamChuaBenhID);

    dstthosoba130.HasIndex(_ => _.Id);
    dstthosoba130.HasOne(_ => _.ThongTinKhamChuaBenh130).WithOne(_ => _.DS_TomTat_HoSoBA130s).HasForeignKey<DS_TomTat_HoSoBA130>(_ => _.ThongTinKhamChuaBenhID);

    dsgiaychungsinh130.HasIndex(_ => _.Id);
    dsgiaychungsinh130.HasOne(_ => _.ThongTinKhamChuaBenh130).WithMany(_ => _.DS_GiayChungSinh130s).HasForeignKey(_ => _.ThongTinKhamChuaBenhID);

    dsnghiduongthai130.HasIndex(_ => _.Id);
    dsnghiduongthai130.HasOne(_ => _.ThongTinKhamChuaBenh130).WithOne(_ => _.DS_ChungNhan_NghiDuongThai130s).HasForeignKey<DS_ChungNhan_NghiDuongThai130>(_ => _.ThongTinKhamChuaBenhID);

    dshuongbhxh130.HasIndex(_ => _.Id);
    dshuongbhxh130.HasOne(_ => _.ThongTinKhamChuaBenh130).WithOne(_ => _.DS_GiayChungNhan_NghiViec_HBHXH130s).HasForeignKey<DS_GiayChungNhan_NghiViec_HBHXH130>(_ => _.ThongTinKhamChuaBenhID);

    dsgiamdinhykhoa130.HasIndex(_ => _.Id);
    dsgiamdinhykhoa130.HasOne(_ => _.ThongTinKhamChuaBenh130).WithMany(_ => _.DS_GiamDinhYKhoa130s).HasForeignKey(_ => _.ThongTinKhamChuaBenhID);

    dschuyentuyen130.HasIndex(_ => _.Id);
    dschuyentuyen130.HasOne(_ => _.ThongTinKhamChuaBenh130).WithOne(_ => _.DS_GiayChuyenTuyen130s).HasForeignKey<DS_GiayChuyenTuyen130>(_ => _.ThongTinKhamChuaBenhID);

    dshenkhamlai130.HasIndex(_ => _.Id);
    dshenkhamlai130.HasOne(_ => _.ThongTinKhamChuaBenh130).WithOne(_ => _.DS_GiayHenKhamLai130s).HasForeignKey<DS_GiayHenKhamLai130>(_ => _.ThongTinKhamChuaBenhID);

    dsdieutrilao130.HasIndex(_ => _.Id);
    dsdieutrilao130.HasOne(_ => _.ThongTinKhamChuaBenh130).WithOne(_ => _.DS_DieuTriBenhLao130s).HasForeignKey<DS_DieuTriBenhLao130>(_ => _.ThongTinKhamChuaBenhID);

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
