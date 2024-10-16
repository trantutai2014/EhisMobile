using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Helpers;
using Data.EF;
using MDP.Common.Enums;
using Data.Models;
using static Common.Model.LichSuKhamResModel;

namespace Service
{
    public class SkdtHoSoService4210
    {
        private readonly MDPDbContext _context;
        private readonly IRepository _repository;

        private readonly HoSoService _skdt_HoSoService;

        public SkdtHoSoService4210(MDPDbContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<LichSuKham_ThongTin_ResModel> GetLichSuKCB(string id, DateTime ngayRa)
        {
      //4210 luôn partion theo ngayRa
            var result = new LichSuKham_ThongTin_ResModel();

            var part = DateHelper.GetPartion(ngayRa);
            var data = _repository.GetAll<ThongTinKhamChuaBenh>(s => s.Id == id)
                .Where(s => s.NGAY_RA >= part.StartDate && s.NGAY_RA <= part.EndDate)
                .Select(s => new
                {
                    s.MA_CSKCB,
                    LY_DO_VV = string.Empty,//s.LY_DO_VV,
                    s.MA_NOI_DI,
                    s.NGAY_VAO,
                    MA_LOAI_KCB = s.MA_LOAI_KCB,//todo
                    NGAY_VAO_NOI_TRU = s.NGAY_VAO,//s.NGAY_VAO_NOI_TRU,
                    s.NGAY_RA,
                    s.KET_QUA_DTRI,
                    MA_LOAI_RV = s.TINH_TRANG_RV,//s.MA_LOAI_RV,
                    s.MA_NOI_DEN,
                    CHAN_DOAN_RV = s.TEN_BENH,//s.CHAN_DOAN_RV,
                    MA_BENH_CHINH = s.MA_BENH,//s.MA_BENH_CHINH,
                    MA_BENH_KT = s.MA_BENHKHAC, //s.MA_BENH_KT,
                    NHOM_MAU = string.Empty,//s.NHOM_MAU,
                    CAN_NANG = s.CAN_NANG != null ? s.CAN_NANG.Value.ToString() : string.Empty
                }).FirstOrDefault();
            if (data != null)
            {
                  result.MaCSKCB = data.MA_CSKCB;
                  result.TenCSKCB = _skdt_HoSoService.GetTenBV(data.MA_CSKCB);
                  result.LyDoDenKham = data.LY_DO_VV;
                  result.MaCSKCBChuyenDi = data.MA_NOI_DI;
                  result.TenCSKCBChuyenDi = _skdt_HoSoService.GetTenBV(data.MA_NOI_DI);
                  result.NgayKham = data.NGAY_VAO;
                  result.HinhThucKham = LoaiKCBHelper.LoaiKCBArray[data.MA_LOAI_KCB];
                  result.NgayVaoVien = data.NGAY_VAO_NOI_TRU;
                  result.NgayRa = data.NGAY_RA;
                  result.KetQua = Descriptions.KetQuaDieuTri[data.KET_QUA_DTRI];
                  result.TinhTrang = Descriptions.MaLoaiRaVien[data.MA_LOAI_RV];
                  result.MaCSKCBChuyenDen = data.MA_NOI_DEN;
                  result.TenCSKCBChuyenDen = _skdt_HoSoService.GetTenBV(data.MA_NOI_DEN);
                  result.ChanDoan = data.CHAN_DOAN_RV;
                  result.MaICD10 = data.MA_BENH_CHINH;
                  result.TenTheoICD10 = _skdt_HoSoService.GetTenICD10(data.MA_BENH_CHINH);
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
            var query = from s in _repository.GetAll<DS_ChiTiet_DVKT>()
                        join kq in _repository.GetAll<DS_KetQua_CLS>()
                        on s.MA_DICH_VU equals kq.MA_DICH_VU
                         into s_kq
                        from kq in s_kq.DefaultIfEmpty()
                        where s.ThongTinKhamChuaBenhID == id && kq.ThongTinKhamChuaBenhID == id
                         && (part.BeforePartion
                                ? (s.NgayRa == null && kq.NgayRa == null)
                                : (s.NgayRa >= part.StartDate && s.NgayRa <= part.EndDate && kq.NgayRa >= part.StartDate && kq.NgayRa <= part.EndDate))
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
                            DonViDo = string.Empty
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



        //////
        public async Task<IEnumerable<LichSuKham_CDHA_TDCN_ResModel>> GetCDHAKCB(string id, DateTime ngayRa)
        {
            var part = DateHelper.GetPartion(ngayRa);
            var result = from s in _repository.GetAll<DS_ChiTiet_DVKT>()
                         join kq in _repository.GetAll<DS_KetQua_CLS>()
                         on s.MA_DICH_VU equals kq.MA_DICH_VU
                         into s_kq
                         from kq in s_kq.DefaultIfEmpty()
                         where s.ThongTinKhamChuaBenhID == id && kq.ThongTinKhamChuaBenhID == id
                             && (part.BeforePartion
                                ? (s.NgayRa == null && kq.NgayRa == null)
                                : (s.NgayRa >= part.StartDate && s.NgayRa <= part.EndDate && kq.NgayRa >= part.StartDate && kq.NgayRa <= part.EndDate))
                              && (s.MA_NHOM == (int)NhomDVKTEnum.CDHA || s.MA_NHOM == (int)NhomDVKTEnum.TDCN)
                         orderby s.STT, kq.STT
                         select new LichSuKham_CDHA_TDCN_ResModel
                         {

                             Ma = s.MA_DICH_VU,
                             Ten = s.TEN_DICH_VU,
                             NgayKetQua = s.NGAY_KQ,
                             MoTa = kq.MO_TA ?? string.Empty,
                             KetLuan = kq.KET_LUAN ?? string.Empty
                         };
            return await Task.FromResult(result);
        }



        ////
        public async Task<IEnumerable<LichSuKham_PTTT_ResModel>> GetPTTTKCB(string id, DateTime ngayRa)
        {
            var part = DateHelper.GetPartion(ngayRa);

            var result = from s in _repository.GetAll<DS_ChiTiet_DVKT>()
                         join kq in _repository.GetAll<DS_KetQua_CLS>()
                          on s.MA_DICH_VU equals kq.MA_DICH_VU
                         where s.ThongTinKhamChuaBenhID == id && kq.ThongTinKhamChuaBenhID == id
                            && (part.BeforePartion
                                ? (s.NgayRa == null && kq.NgayRa == null)
                                : (s.NgayRa >= part.StartDate && s.NgayRa <= part.EndDate && kq.NgayRa >= part.StartDate && kq.NgayRa <= part.EndDate))
                            && (s.MA_NHOM == (int)NhomDVKTEnum.PT || s.MA_NHOM == (int)NhomDVKTEnum.TT)
                         orderby s.STT, kq.STT
                         select new LichSuKham_PTTT_ResModel()
                         {
                             Ma = s.MA_DICH_VU,
                             Ten = s.TEN_DICH_VU,
                             NgayKetQua = s.NGAY_KQ,
                             MoTa = kq.MO_TA ?? string.Empty,
                         };

            return await Task.FromResult(result);
        }



        ////
        public async Task<IEnumerable<LichSuKham_Thuoc_ResModel>> GetThuocKCB(string id, DateTime ngayRa)
        {
            var part = DateHelper.GetPartion(ngayRa);
            var query = _repository.GetAll<DS_ChiTiet_Thuoc>(s => s.ThongTinKhamChuaBenhID == id);
            if (part.BeforePartion)
                query = query.Where(s => s.NgayRa == null);
            else
                query = query.Where(s => s.NgayRa >= part.StartDate && s.NgayRa <= part.EndDate);

            var result = query
                  .OrderBy(s => s.STT).Select(s => new LichSuKham_Thuoc_ResModel
                  {
                      Ma = s.MA_THUOC,
                      Ten = s.TEN_THUOC,
                      HamLuong = s.HAM_LUONG,
                      DonViTinh = s.DON_VI_TINH,
                      SoLuong = s.SO_LUONG,
                      LieuDung = s.LIEU_DUNG,
                      CachDung = s.LIEU_DUNG,

                  });
            return await Task.FromResult(result);
        }



        /// không sài
        public async Task<LichSuKham_TomTat_ResModel> GetTomTatKCB(string id, DateTime ngayRa)
        {
            //todo 4210 chưa có thông tin tóm tắt
            return null;
            //var result= _repository.GetAll<DS_TomTat_HoSoBA>(s => s.ThongTinKhamChuaBenhID == id)
            //    .Select(s => new LichSuKham_TomTat_ResModel()
            //    {
            //        TomTatTienSu = s.QT_BENHLY,
            //        TomTatCLS = s.TOMTAT_KQ,
            //        PhuongPhapDieuTri = s.PP_DIEUTRI,
            //        HuongDieuTri = s.GHI_CHU,
            //        BacSi = s.MA_TTDV,
            //        SDTBacSi = string.Empty,
            //    }).FirstOrDefault();
            //return await Task.FromResult(result);
        }

    }



}
