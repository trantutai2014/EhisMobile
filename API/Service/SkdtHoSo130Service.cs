using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Helpers;
using Data.EF;
using Data.Models;
using MDP.Common.Enums;
using Data.Models;
using static Common.Model.LichSuKhamResModel;

namespace Service
{
    public class SkdtHoSo130Service
    {
        private readonly MDPDbContext _context;
        private readonly IRepository _repository;

        private readonly HoSoService _skdt_HoSoService;

        public SkdtHoSo130Service(MDPDbContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;
        }


        ////
        public async Task<LichSuKham_ThongTin_ResModel> GetLichSuKCB(string id, DateTime ngayRa)
        {
            var result = new LichSuKham_ThongTin_ResModel();
            var part = DateHelper.GetPartion(ngayRa);
            var data = _repository.GetAll<ThongTinKhamChuaBenh130>(s => s.Id == id && s.NGAY_RA >= part.StartDate && s.NGAY_RA <= part.EndDate)
                .Select(s => new
                {
                    s.MA_CSKCB,
                    s.LY_DO_VV,
                    s.MA_NOI_DI,
                    s.NGAY_VAO,
                    s.MA_LOAI_KCB,
                    s.NGAY_VAO_NOI_TRU,
                    s.NGAY_RA,
                    s.KET_QUA_DTRI,
                    s.MA_LOAI_RV,
                    s.MA_NOI_DEN,
                    s.CHAN_DOAN_RV,
                    s.MA_BENH_CHINH,
                    s.MA_BENH_KT,
                    s.NHOM_MAU,
                    s.CAN_NANG
                }).FirstOrDefault();
            if (data != null)
            {
                result.MaCSKCB = data.MA_CSKCB;
                result.TenCSKCB = GetTenBV(data.MA_CSKCB);
                result.LyDoDenKham = data.LY_DO_VV;
                result.MaCSKCBChuyenDi = data.MA_NOI_DI;
                result.TenCSKCBChuyenDi = GetTenBV(data.MA_NOI_DI);
                result.NgayKham = data.NGAY_VAO;
                result.HinhThucKham = Descriptions.MaLoaiKCB[data.MA_LOAI_KCB];
                result.NgayVaoVien = data.NGAY_VAO_NOI_TRU;
                result.NgayRa = data.NGAY_RA;
                result.KetQua = Descriptions.KetQuaDieuTri[data.KET_QUA_DTRI];
                result.TinhTrang = Descriptions.MaLoaiRaVien[data.MA_LOAI_RV];
                result.MaCSKCBChuyenDen = data.MA_NOI_DEN;
                result.TenCSKCBChuyenDen = GetTenBV(data.MA_NOI_DEN);
                result.ChanDoan = data.CHAN_DOAN_RV;
                result.MaICD10 = data.MA_BENH_CHINH;
                result.TenTheoICD10 = GetTenICD10(data.MA_BENH_CHINH);
                result.MaICD10KemTheo = data.MA_BENH_KT;
                result.NhomMau = data.NHOM_MAU;
                result.CanNang = data.CAN_NANG;


            }
            return await Task.FromResult(result);
        }


        ////
        public async Task<IEnumerable<LichSuKham_XN_ResModel>> GetXetNghiemKCB(string id, DateTime ngayRa)
        {
            var part = DateHelper.GetPartion(ngayRa);
            var query = from s in _repository.GetAll<DS_ChiTiet_DVKT130>()
                        join kq in _repository.GetAll<DS_DVCLS130>()
                        on s.MA_DICH_VU equals kq.MA_DICH_VU
                        into s_kq
                        from kq in s_kq.DefaultIfEmpty()
                        where s.ThongTinKhamChuaBenhID == id && kq.ThongTinKhamChuaBenhID == id
                            && s.NgayRa >= part.StartDate && s.NgayRa <= part.EndDate && kq.NgayRa >= part.StartDate && kq.NgayRa <= part.EndDate
                        && s.MA_NHOM == (int)NhomDVKTEnum.XetNghiem
                        orderby s.STT, kq.STT
                        select new
                        {
                            Id = s.Id,
                            MaDichVu = s.MA_DICH_VU,
                            TenDichVu = s.TEN_DICH_VU,
                            NgayKetQua = s.NGAY_KQ,
                            MaChiSo = kq.MA_CHI_SO ?? string.Empty,
                            TenChiSo = kq.TEN_CHI_SO ?? string.Empty,
                            GiaTri = kq.GIA_TRI ?? string.Empty,
                            DonViDo = kq.DON_VI_DO ?? string.Empty
                        };
            var data = query.ToList();
            var result = data.GroupBy(x => new { x.Id, x.MaDichVu, x.TenDichVu, x.NgayKetQua })
                .Select(g => new LichSuKham_XN_ResModel
                {
                    Ma = g.Key.MaDichVu,
                    Ten = g.Key.TenDichVu,
                    NgayKetQua = g.Key.NgayKetQua,
                    KetQua = g.Select(x => new LichSuKham_XNCT_ResModel
                    {
                        Ma = x.MaChiSo,
                        Ten = x.TenChiSo,
                        KetQua = x.GiaTri,
                        DonVi = x.DonViDo
                    }).ToArray()
                }).ToList();
            return await Task.FromResult(result);
        }


        ///
        public async Task<IEnumerable<LichSuKham_CDHA_TDCN_ResModel>> GetCDHAKCB(string id, DateTime ngayRa)
        {
            var part = DateHelper.GetPartion(ngayRa);
            var query = from s in _repository.GetAll<DS_ChiTiet_DVKT130>()
                        join kq in _repository.GetAll<DS_DVCLS130>()
                        on s.MA_DICH_VU equals kq.MA_DICH_VU
                         into s_kq
                        from kq in s_kq.DefaultIfEmpty()
                        where s.ThongTinKhamChuaBenhID == id && kq.ThongTinKhamChuaBenhID == id
                            && s.NgayRa >= part.StartDate && s.NgayRa <= part.EndDate && kq.NgayRa >= part.StartDate && kq.NgayRa <= part.EndDate
                            && (s.MA_NHOM == (int)NhomDVKTEnum.CDHA || s.MA_NHOM == (int)NhomDVKTEnum.TDCN)
                        orderby s.STT, kq.STT
                        select new
                        {
                            s.Id,
                            MaDichVu = s.MA_DICH_VU,
                            TenDichVu = s.TEN_DICH_VU,
                            NgayKetQua = s.NGAY_KQ,
                            MoTa = kq.MO_TA ?? string.Empty,
                            KetLuan = kq.KET_LUAN ?? string.Empty
                        };
            var data = query.ToList();
            var result = data.GroupBy(x => new { x.Id, x.MaDichVu, x.TenDichVu, x.NgayKetQua })
                 .Select(g => new LichSuKham_CDHA_TDCN_ResModel
                 {
                     Ma = g.Key.MaDichVu,
                     Ten = g.Key.TenDichVu,
                     NgayKetQua = g.Key.NgayKetQua,
                     MoTa = g.FirstOrDefault()?.MoTa,
                     KetLuan = g.FirstOrDefault()?.KetLuan
                 }).ToList();
            return await Task.FromResult(result);
        }


        //
        public async Task<IEnumerable<LichSuKham_PTTT_ResModel>> GetPTTTKCB(string id, DateTime ngayRa)
        {
            var part = DateHelper.GetPartion(ngayRa);
            var query = from s in _repository.GetAll<DS_ChiTiet_DVKT130>()
                        join kq in _repository.GetAll<DS_DienBien_LamSang130>()
                        on s.NGAY_KQ equals kq.THOI_DIEM_DBLS
                        where s.ThongTinKhamChuaBenhID == id && kq.ThongTinKhamChuaBenhID == id
                            && s.NgayRa >= part.StartDate && s.NgayRa <= part.EndDate && kq.NgayRa >= part.StartDate && kq.NgayRa <= part.EndDate
                            && (s.MA_NHOM == (int)NhomDVKTEnum.PT || s.MA_NHOM == (int)NhomDVKTEnum.TT)
                        orderby s.STT, kq.STT
                        select new
                        {
                            s.Id,
                            MaDichVu = s.MA_DICH_VU,
                            TenDichVu = s.TEN_DICH_VU,
                            NgayKetQua = s.NGAY_KQ,
                            MoTa = kq.PHAU_THUAT,
                            NgayDienBien = kq.THOI_DIEM_DBLS
                        };
            var data = query.ToList();
            var result = data.GroupBy(x => new { x.Id, x.MaDichVu, x.TenDichVu, x.NgayKetQua })
                 .Select(g => new LichSuKham_PTTT_ResModel
                 {
                     Ma = g.Key.MaDichVu,
                     Ten = g.Key.TenDichVu,
                     NgayKetQua = g.Key.NgayKetQua,
                     MoTa = g.Where(x => x.NgayDienBien >= g.Key.NgayKetQua && x.NgayDienBien.Date == g.Key.NgayKetQua.Value.Date && !string.IsNullOrEmpty(x.MoTa))
                     .FirstOrDefault()?.MoTa,
                 }).ToList();

            return await Task.FromResult(result);
        }


        //
        public async Task<IEnumerable<LichSuKham_Thuoc_ResModel>> GetThuocKCB(string id, DateTime ngayRa)
        {
            var part = DateHelper.GetPartion(ngayRa);
            var result = _repository.GetAll<DS_ChiTiet_Thuoc130>(s => s.ThongTinKhamChuaBenhID == id
            && s.NgayRa >= part.StartDate && s.NgayRa <= part.EndDate)
                  .OrderBy(s => s.STT).Select(s => new LichSuKham_Thuoc_ResModel
                  {
                      Ma = s.MA_THUOC,
                      Ten = s.TEN_THUOC,
                      HamLuong = s.HAM_LUONG,
                      DonViTinh = s.DON_VI_TINH,
                      SoLuong = s.SO_LUONG,
                      LieuDung = s.LIEU_DUNG,
                      CachDung = s.CACH_DUNG,

                  });
            return await Task.FromResult(result);
        }

        //
        public async Task<LichSuKham_TomTat_ResModel> GetTomTatKCB(string id, DateTime ngayRa)
        {
            var part = DateHelper.GetPartion(ngayRa);
            var result = _repository.GetAll<DS_TomTat_HoSoBA130>(s => s.ThongTinKhamChuaBenhID == id && s.NgayRa >= part.StartDate && s.NgayRa <= part.EndDate)
                .Select(s => new LichSuKham_TomTat_ResModel()
                {
                    TomTatTienSu = s.QT_BENHLY,
                    TomTatCLS = s.TOMTAT_KQ,
                    PhuongPhapDieuTri = s.PP_DIEUTRI,
                    HuongDieuTri = s.GHI_CHU,
                    BacSi = s.MA_TTDV,
                    SDTBacSi = string.Empty,
                }).FirstOrDefault();
            return await Task.FromResult(result);
        }

        ///
        public string GetTenBV(string maCSKCB)
        {
            if (string.IsNullOrEmpty(maCSKCB))
                return null;
            var data = _repository.Get<DMCoSo>(maCSKCB);
            return data?.TenBV ?? "Không có tên bệnh viện";
        }
        public string GetTenICD10(string maICD10)
        {
            if (string.IsNullOrEmpty(maICD10))
                return null;
            var data = _repository.Get<DMICD10>(s => s.Ma == maICD10);
            return data?.Ten;
        }



    }
}
