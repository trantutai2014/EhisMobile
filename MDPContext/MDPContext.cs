using MDP.Common.BackgroundTasks;
using MDP.Common.Constants;
using MDP.Common.Extensions;
using MDP.Common.Helpers;
using MDP.Common.ResponseModels.SKDT;
using MDP.Data.Interfaces;
using MDP.Data.Models;
using MDP.Data.Models.MauSoY;
using MDP.Data.Models.QuyetDinh3373BHYT;
using MDP.Data.Models.SKDT;
using MDP.Data.Models.SoGhiChep;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Z.EntityFramework.Extensions;

namespace MDP.Data.EF
{
    public class MDPContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public IBackgroundTaskQueue Queue { get; }

        public MDPContext(DbContextOptions<MDPContext> options,
                             IHttpContextAccessor httpContextAccessor,
                             IBackgroundTaskQueue queue,
                             IServiceScopeFactory serviceScopeFactory) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceScopeFactory = serviceScopeFactory;
            Queue = queue;
            EntityFrameworkManager.ContextFactory = context => new MDPContext(options);
        }

        public MDPContext(DbContextOptions<MDPContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<NavigationMenu> NavigationMenus { get; set; }
        public DbSet<RoleNavigationMenu> RoleNavigationMenus { get; set; }

        public DbSet<DMCoSo> DMCoSos { get; set; }
        public DbSet<DMKhoaPhong> DMKhoaPhongs { get; set; }
        public DbSet<DMBenhYHCT> DMBenhYHCTs { get; set; }
        public DbSet<DMChePhamThuocYHCT> DMChePhamThuocYHCTs { get; set; }
        public DbSet<DMDuongDung> DMDuongDungs { get; set; }
        public DbSet<DMDVKT> DMDVKTs { get; set; }
        public DbSet<DMMaBenhTheoICD10> DMMaBenhTheoICD10s { get; set; }
        public DbSet<DMICD10> DMICD10s { get; set; }
        public DbSet<DMThuocTanDuoc> DMThuocTanDuocs { get; set; }
        public DbSet<DMViThuocYHCT> DMViThuocYHCTs { get; set; }
        public DbSet<DMVTYT> DMVTYTs { get; set; }
        public DbSet<DMMau> DMMaus { get; set; }

        public DbSet<DS_ChiTiet_DVKT> DS_ChiTiet_DVKTs { get; set; }
        public DbSet<DS_ChiTiet_Thuoc> DS_ChiTiet_Thuocs { get; set; }
        public DbSet<DS_DienBien_LamSang> DS_DienBien_LamSangs { get; set; }
        public DbSet<DS_KetQua_CLS> DS_KetQua_CLSs { get; set; }
        public DbSet<LichSuTuongTac> LichSuTuongTacs { get; set; }
        public virtual DbSet<DVC_BTDPXa> DVCBTDPXas { get; set; }
        public virtual DbSet<DVC_BTDQuan> DVCBTDQuans { get; set; }
        public virtual DbSet<DVC_BTDTT> DVCBTDTTs { get; set; }
        public virtual DbSet<UserExternalApi> UserExternalApis { get; set; }

        public virtual DbSet<TT37> TT37 { get; set; }

        #region Báo cáo tuyến huyên

        public virtual DbSet<Bieu1BCH> Bieu1BCH { get; set; }
        public virtual DbSet<Bieu2BCH> Bieu2BCH { get; set; }
        public virtual DbSet<Bieu3_1BCH> Bieu3_1BCH { get; set; }
        public virtual DbSet<Bieu3_2BCH> Bieu3_2BCH { get; set; }
        public virtual DbSet<Bieu3_3BCH> Bieu3_3BCH { get; set; }
        public virtual DbSet<Bieu4BCH> Bieu4BCH { get; set; }
        public virtual DbSet<Bieu5BCH> Bieu5BCH { get; set; }
        public virtual DbSet<Bieu6BCH> Bieu6BCH { get; set; }
        public virtual DbSet<Bieu7BCH> Bieu7BCH { get; set; }
        public virtual DbSet<Bieu8BCH> Bieu8BCH { get; set; }
        public virtual DbSet<Bieu9BCH> Bieu9BCH { get; set; }
        public virtual DbSet<Bieu10BCH> Bieu10BCH { get; set; }
        public virtual DbSet<Bieu11_1BCH> Bieu11_1BCH { get; set; }
        public virtual DbSet<Bieu11_2BCH> Bieu11_2BCH { get; set; }
        public virtual DbSet<Bieu11_3BCH> Bieu11_3BCH { get; set; }
        public virtual DbSet<Bieu12BCH> Bieu12BCH { get; set; }
        public virtual DbSet<Bieu13BCH> Bieu13BCH { get; set; }
        public virtual DbSet<Bieu14BCH> Bieu14BCH { get; set; }

        #endregion Báo cáo tuyến huyên

        #region Báo cáo tuyến xã, phường, thị trấn

        public virtual DbSet<Bieu1BCX> Bieu1BCX { get; set; }
        public virtual DbSet<Bieu2BCX> Bieu2BCX { get; set; }
        public virtual DbSet<Bieu3BCX> Bieu3BCX { get; set; }
        public virtual DbSet<Bieu4BCX> Bieu4BCX { get; set; }
        public virtual DbSet<Bieu5BCX> Bieu5BCX { get; set; }
        public virtual DbSet<Bieu6BCX> Bieu6BCX { get; set; }
        public virtual DbSet<Bieu7BCX> Bieu7BCX { get; set; }
        public virtual DbSet<Bieu8BCX> Bieu8BCX { get; set; }

        #endregion Báo cáo tuyến xã, phường, thị trấn

        #region Sổ ghi chép

        public virtual DbSet<A1CSYT> A1CSYT { get; set; }
        public virtual DbSet<A2_1CSYT> A2_1CSYT { get; set; }
        public virtual DbSet<A2_2CSYT> A2_2CSYT { get; set; }
        public virtual DbSet<A3CSYT> A3CSYT { get; set; }
        public virtual DbSet<A4CSYT> A4CSYT { get; set; }
        public virtual DbSet<A5_1CSYT> A5_1CSYT { get; set; }
        public virtual DbSet<A5_2CSYT> A5_2CSYT { get; set; }
        public virtual DbSet<A6TYT> A6TYT { get; set; }
        public virtual DbSet<A7TYT> A7TYT { get; set; }
        public virtual DbSet<A8TYT> A8TYT { get; set; }
        public virtual DbSet<A9TYT> A9TYT { get; set; }
        public virtual DbSet<A10TYT> A10TYT { get; set; }
        public virtual DbSet<A11TYT> A11TYT { get; set; }
        public virtual DbSet<A12_1TYT> A12_1TYT { get; set; }
        public virtual DbSet<A12_2TYT> A12_2TYT { get; set; }
        public virtual DbSet<A12_3TYT> A12_3TYT { get; set; }

        #endregion Sổ ghi chép

        #region Mẫu sổ y

        public virtual DbSet<MauSoY> MauSoY { get; set; }
        public virtual DbSet<SoKhamBenh> SoKhamBenh { get; set; }
        public virtual DbSet<SoVaoRaChuyenVien> SoVaoRaChuyenVien { get; set; }
        public virtual DbSet<SoBGHSBenhAn> SoBGHSBenhAn { get; set; }
        public virtual DbSet<SoLTHSBenhAn> SoLTHSBenhAn { get; set; }
        public virtual DbSet<SoLTHSBenhAnTuVong> SoLTHSBenhAnTuVong { get; set; }
        public virtual DbSet<SoBGNBVaoKhoa> SoBGNBVaoKhoa { get; set; }
        public virtual DbSet<SoBCCongTacThang> SoBCCongTacThang { get; set; }
        public virtual DbSet<SoCongTacChiDaoTuyen> SoCongTacChiDaoTuyen { get; set; }
        public virtual DbSet<SoKiemTra> SoKiemTra { get; set; }
        public virtual DbSet<SoBGNBChuyenVien> SoBGNBChuyenVien { get; set; }
        public virtual DbSet<SoMoiHoiChuan> SoMoiHoiChuan { get; set; }
        public virtual DbSet<SoBBHoiChuan> SoBBHoiChuan { get; set; }
        public virtual DbSet<SoPhauThuat> SoPhauThuat { get; set; }
        public virtual DbSet<SoSaiSotChuyenMon> SoSaiSotChuyenMon { get; set; }
        public virtual DbSet<SoBBKiemDiemTuVong> SoBBKiemDiemTuVong { get; set; }
        public virtual DbSet<SoThuThuat> SoThuThuat { get; set; }
        public virtual DbSet<SoXetNghiem> SoXetNghiem { get; set; }
        public virtual DbSet<SoChanDoanHinhAnh> SoChanDoanHinhAnh { get; set; }
        public virtual DbSet<SoDTBDChuyenMon> SoDTBDChuyenMon { get; set; }
        public virtual DbSet<SoXNTBMauNgoaiVi> SoXNTBMauNgoaiVi { get; set; }
        public virtual DbSet<SoNoiSoi> SoNoiSoi { get; set; }
        public virtual DbSet<SoGiaoVaNhanBenhPham> SoGiaoVaNhanBenhPham { get; set; }
        public virtual DbSet<SoTraKetQuaCLS> SoTraKetQuaCLS { get; set; }
        public virtual DbSet<SoHopGiaoBan> SoHopGiaoBan { get; set; }
        public virtual DbSet<SoHopHDThuocVaDT> SoHopHDThuocVaDT { get; set; }
        public virtual DbSet<SoHopHDKHKT> SoHopHDKHKT { get; set; }
        public virtual DbSet<SoDangKiDeTaiNCKH> SoDangKiDeTaiNCKH { get; set; }
        public virtual DbSet<SoTheoDoiKhenThuong> SoTheoDoiKhenThuong { get; set; }
        public virtual DbSet<SoTheoDoiKyLuat> SoTheoDoiKyLuat { get; set; }
        public virtual DbSet<SoBaoAnUongNguoiBenh> SoBaoAnUongNguoiBenh { get; set; }
        public virtual DbSet<SoGopYNguoiBenh> SoGopYNguoiBenh { get; set; }
        public virtual DbSet<SoThuongTruc> SoThuongTruc { get; set; }
        public virtual DbSet<SoDuyetKeHoachPhauThuat> SoDuyetKeHoachPhauThuat { get; set; }
        public virtual DbSet<SoBanGiaoThuocThuongTruc> SoBanGiaoThuocThuongTruc { get; set; }
        public virtual DbSet<ChiTietSoBanGiaoThuocThuongTruc> ChiTietSoBanGiaoThuocThuongTruc { get; set; }
        public virtual DbSet<SoBanGiaoDungCuThuongTruc> SoBanGiaoDungCuThuongTruc { get; set; }
        public virtual DbSet<ChiTietSoBanGiaoDungCuThuongTruc> ChiTietSoBanGiaoDungCuThuongTruc { get; set; }
        public virtual DbSet<SoSinhHoatHoiDongNguoiBenh> SoSinhHoatHoiDongNguoiBenh { get; set; }

        public virtual DbSet<SoTongHopThuocHangNgay> SoTongHopThuocHangNgay { get; set; }
        public virtual DbSet<ChiTietSoTongHopThuocHangNgay> ChiTietSoTongHopThuocHangNgay { get; set; }
        public virtual DbSet<SoBanGiaoTuTrangNguoiBenhTuVong> SoBanGiaoTuTrangNguoiBenhTuVong { get; set; }
        public virtual DbSet<SoQuanLiSuaChuaThietBiYTe> SoQuanLiSuaChuaThietBiYTe { get; set; }
        public virtual DbSet<SoTaiSanYDungCu> SoTaiSanYDungCu { get; set; }
        public virtual DbSet<SoXinXeOToCuuThuong> SoXinXeOToCuuThuong { get; set; }
        public virtual DbSet<SoXetNghiemViSinh> SoXetNghiemViSinh { get; set; }

        #endregion Mẫu sổ y
        #region QD3373
        public virtual DbSet<CT_CapCCHanhNghe> CT_CapCCHanhNghe { get; set; }
        public virtual DbSet<CT_CapCCHanhNghe_KCB> CT_CapCCHanhNghe_KCB { get; set; }
        public DbSet<CT_CSKCB> CT_CSKCB { get; set; }
        public virtual DbSet<CT_CSKinhDoanh> CT_CSKinhDoanh { get; set; }
        public DbSet<CT_DMThuoc> CT_DMThuoc { get; set; }
        public DbSet<CT_DMTrangThietBi> CT_DMTrangThietBi { get; set; }
        public DbSet<CT_DMVatTuYTe> CT_DMVatTuYTe { get; set; }
        public DbSet<CT_DVKyThuat> CT_DVKyThuat { get; set; }
        public DbSet<CT_NguoiHanhNgheY> CT_NguoiHanhNgheY { get; set; }
        #endregion
        #region 130
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

        #endregion


        #region SKDT
        public virtual DbSet<SKDT_HoSo> SKDT_HoSos { get; set; }
        public virtual DbSet<SKDT_DMNgheNghiep> SKDT_DMNgheNghieps { get; set; }
        public virtual DbSet<SKDT_DMPhuongXa> SKDT_DMPhuongXas { get; set; }
        public virtual DbSet<SKDT_DMQuanHuyen> SKDT_DMQuanHuyens { get; set; }
        public virtual DbSet<SKDT_DMQuocTich> SKDT_DMQuocTichs { get; set; }
        public virtual DbSet<SKDT_DMTinhThanh> SKDT_DMTinhThanhs { get; set; }
        public virtual DbSet<SoTheBHYT> SoTheBHYTs { get; set; }

        #endregion

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
            var dmkhoaphong = modelBuilder.Entity<DMKhoaPhong>();
            var dmbenhyhct = modelBuilder.Entity<DMBenhYHCT>();
            var dmchephamyhct = modelBuilder.Entity<DMChePhamThuocYHCT>();
            var dmduongdung = modelBuilder.Entity<DMDuongDung>();
            var dmdvkt = modelBuilder.Entity<DMDVKT>();
            var dmicd10 = modelBuilder.Entity<DMMaBenhTheoICD10>();
            var _dmicd10 = modelBuilder.Entity<DMICD10>();
            var dmtanduoc = modelBuilder.Entity<DMThuocTanDuoc>();
            var dmvithuocyhct = modelBuilder.Entity<DMViThuocYHCT>();
            var dmvtyt = modelBuilder.Entity<DMVTYT>();
            var dmmau = modelBuilder.Entity<DMMau>();

            var lichsutuongtac = modelBuilder.Entity<LichSuTuongTac>();
            var thongtinkcb = modelBuilder.Entity<ThongTinKhamChuaBenh>();
            var dschitietdvkt = modelBuilder.Entity<DS_ChiTiet_DVKT>();
            var dschitietthuoc = modelBuilder.Entity<DS_ChiTiet_Thuoc>();
            var dschitietdienbien = modelBuilder.Entity<DS_DienBien_LamSang>();
            var dschitietketqua = modelBuilder.Entity<DS_KetQua_CLS>();

            var lichsutuongtac130 = modelBuilder.Entity<LichSuTuongTac130> ();
            var thongtinkcb130 = modelBuilder.Entity<ThongTinKhamChuaBenh130> ();
            var dschitietthuoc130 = modelBuilder.Entity<DS_ChiTiet_Thuoc130> ();
            var dschitietdvkt130 = modelBuilder.Entity<DS_ChiTiet_DVKT130> ();
            var dsdvcls130 = modelBuilder.Entity<DS_DVCLS130> ();
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


            dmkhoaphong.HasIndex(_ => _.Id);
            dmbenhyhct.HasIndex(_ => _.Id);
            dmchephamyhct.HasIndex(_ => _.Id);
            dmduongdung.HasIndex(_ => _.Id);
            dmdvkt.HasIndex(_ => _.Id);
            dmicd10.HasIndex(_ => _.Id);
            _dmicd10.HasIndex(_ => _.Id);
            dmtanduoc.HasIndex(_ => _.Id);
            dmvithuocyhct.HasIndex(_ => _.Id);
            dmvtyt.HasIndex(_ => _.Id);
            dmmau.HasIndex(_ => _.Id);


            #region SKDT
            var skdt_hoso = modelBuilder.Entity<SKDT_HoSo>();
            var skdt_dmnghe = modelBuilder.Entity<SKDT_DMNgheNghiep>();
            var skdt_dmphuongxa = modelBuilder.Entity<SKDT_DMPhuongXa>();
            var skdt_dmquanhuyen = modelBuilder.Entity<SKDT_DMQuanHuyen>();
            var skdt_dmquoctich = modelBuilder.Entity<SKDT_DMQuocTich>();
            var skdt_dmtinhthanh = modelBuilder.Entity<SKDT_DMTinhThanh>();

            skdt_dmquanhuyen.HasOne(_ => _.SKDT_DMTinhThanh).WithMany(_ => _.SKDT_DMQuanHuyens).HasForeignKey(_ => _.MaTinh);
            skdt_dmphuongxa.HasOne(_ => _.SKDT_DMQuanHuyen).WithMany(_ => _.SKDT_DMPhuongXas).HasForeignKey(_ => _.MaHuyen);

            skdt_hoso.HasOne(_ => _.SKDT_DMNgheNghiep).WithMany(_ => _.SKDT_HoSos).HasForeignKey(_ => _.MaNgheNghiep);
            skdt_hoso.HasOne(_ => _.SKDT_DMQuocTich).WithMany(_ => _.SKDT_HoSos).HasForeignKey(_ => _.MaQuocTich);
            skdt_hoso.HasOne(_ => _.SKDT_DMPhuongXa).WithMany(_ => _.SKDT_HoSos).HasForeignKey(_ => _.MaPhuongXa);
            skdt_hoso.HasOne(_ => _.SKDT_DMDanToc).WithMany(_ => _.SKDT_HoSos).HasForeignKey(_ => _.MaDanToc);

            #endregion

            modelBuilder.Entity<ChiTietSoBanGiaoThuocThuongTruc>(entity =>
            {
                entity.HasOne(d => d.SoBanGiaoThuocThuongTruc)
                    .WithMany(p => p.ChiTietSoBanGiaoThuocThuongTrucs)
                    .HasForeignKey(d => d.SoBGId);
            });

            modelBuilder.Entity<ChiTietSoBanGiaoDungCuThuongTruc>(entity =>
            {
                entity.HasOne(d => d.SoBanGiaoDungCuThuongTruc)
                    .WithMany(p => p.ChiTietSoBanGiaoDungCuThuongTrucs)
                    .HasForeignKey(d => d.SoBGId);
            });

            modelBuilder.Entity<ChiTietSoTongHopThuocHangNgay>(entity =>
            {
                entity.HasOne(d => d.SoTongHopThuocHangNgay)
                    .WithMany(p => p.ChiTietSoTongHopThuocHangNgays)
                    .HasForeignKey(d => d.SoTHId);
            });

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
                        hospitalCode.MaBV = _httpContextAccessor.HttpContext.User.GetSpecificClaim(ClaimConsts.MaBV);
                    }
                }
            }

            //var auditEntries = OnBeforeSaveChanges();

            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

            //OnAfterSaveChanges(auditEntries);

            return result;
        }

        #region Private methods

        private List<AuditLogEntry> OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditLogEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is AuditLog || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var auditEntry = new AuditLogEntry(entry)
                {
                    TableName = entry.Metadata.GetTableName()
                };

                auditEntries.Add(auditEntry);

                foreach (var property in entry.Properties)
                {
                    if (property.IsTemporary)
                    {
                        // value will be generated by the database, get the value after saving
                        auditEntry.TemporaryProperties.Add(property);
                        continue;
                    }

                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.NewValues[propertyName] = property.CurrentValue;

                            break;

                        case EntityState.Modified:
                            if (property.IsModified && !property.OriginalValue.JSONEquals(property.CurrentValue))
                            {
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }

                            break;

                        case EntityState.Deleted:
                            auditEntry.OldValues[propertyName] = property.OriginalValue;

                            break;
                    }
                }
            }

            return auditEntries;
        }

        private void OnAfterSaveChanges(List<AuditLogEntry> auditEntries)
        {
            if (auditEntries == null || !auditEntries.Any())
                return;

            Queue.QueueBackgroundWorkItem(async token =>
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var auditLogDbContext = scopedServices.GetRequiredService<AuditLogDbContext>();

                // 1. Save audit entities that have all the modifications
                foreach (var auditEntry in auditEntries.Where(_ => !_.HasTemporaryProperties))
                {
                    // Save the Audit entry
                    if (auditEntry.OldValues.Any() || auditEntry.NewValues.Any())
                        await auditLogDbContext.AuditLogs.AddAsync(auditEntry.ToAuditLog(), token);
                }

                // 2 Get the final value of the temporary properties
                var auditEnitiesTemporary = auditEntries.Where(_ => _.HasTemporaryProperties).ToList();
                if (auditEnitiesTemporary.Any())
                {
                    foreach (var auditEntry in auditEnitiesTemporary)
                    {
                        // Get the final value of the temporary properties
                        foreach (var prop in auditEntry.TemporaryProperties)
                        {
                            if (prop.Metadata.IsPrimaryKey())
                                auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                            else
                                auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                        }

                        // Save the Audit entry
                        if (auditEntry.OldValues.Any() || auditEntry.NewValues.Any())
                            await auditLogDbContext.AuditLogs.AddAsync(auditEntry.ToAuditLog(), token);
                    }
                }

                await auditLogDbContext.SaveChangesAsync(token);
            });
        }

        #endregion Private methods
    }
}