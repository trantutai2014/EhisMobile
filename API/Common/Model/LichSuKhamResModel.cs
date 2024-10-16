using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Model
{
    public class LichSuKhamResModel
    {
        public class LichSuKham_ThongTin_ResModel
        {
            public string? MaCSKCB { set; get; }
            public string? TenCSKCB { set; get; }
            public string? LyDoDenKham { set; get; }

            public string? MaCSKCBChuyenDi { set; get; }
            public string? TenCSKCBChuyenDi { set; get; }
            public DateTime? NgayKham { set; get; }
            public string? HinhThucKham { set; get; }

            public DateTime? NgayVaoVien { set; get; }
            public DateTime NgayRa { set; get; }
            public string? KetQua { set; get; }
            public string? TinhTrang { set; get; }
            public string? MaCSKCBChuyenDen { set; get; }
            public string? TenCSKCBChuyenDen { set; get; }
            public string? ChanDoan { set; get; }
            public string? MaICD10 { set; get; }
            public string? TenTheoICD10 { set; get; }
            public string? MaICD10KemTheo { set; get; }
            public string? NhomMau { set; get; }
            public string? CanNang { set; get; }
        }

        public class LichSuKham_XN_ResModel
        {
            public string Ma { set; get; }
            public DateTime? NgayKetQua { set; get; }
            public string Ten { set; get; }
            public LichSuKham_XNCT_ResModel[] KetQua { set; get; }
        }

        public class LichSuKham_XNCT_ResModel
        {
            public string Ma { set; get; }
            public string Ten { set; get; }
            public string KetQua { set; get; }
            public string DonVi { set; get; }
        }

        public class LichSuKham_CDHA_TDCN_ResModel
        {
            public string Ma { set; get; }
            public DateTime? NgayKetQua { set; get; }
            public string Ten { set; get; }
            public string MoTa { set; get; }
            public string KetLuan { set; get; }
        }

        public class LichSuKham_Thuoc_ResModel
        {
            public string Ma { set; get; }
            public string Ten { set; get; }
            public string HamLuong { set; get; }
            public decimal SoLuong { set; get; }
            public string LieuDung { set; get; }
            public string CachDung { set; get; }
            public string DonViTinh { set; get; }
        }

        public class LichSuKham_PTTT_ResModel
        {
            public string Ma { set; get; }
            public string Ten { set; get; }
            public DateTime? NgayKetQua { set; get; }
            public string MoTa { set; get; }
        }

        public class LichSuKham_TomTat_ResModel
        {
            public string TomTatTienSu { set; get; }
            public string TomTatCLS { set; get; }
            public string PhuongPhapDieuTri { set; get; }
            public string HuongDieuTri { set; get; }
            public string BacSi { set; get; }
            public string SDTBacSi { set; get; }
        }
    }
}
