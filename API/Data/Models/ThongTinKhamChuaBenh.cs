using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Common.Enums;

using Data.Abstract;
using Common.Constants;

namespace Data.Models
{
    [Table("ThongTinKhamChuaBenh")]
    public class ThongTinKhamChuaBenh : BaseEntity
    {
        public ThongTinKhamChuaBenh()
        {
            Id = Guid.NewGuid().ToString();
            DS_ChiTiet_DVKTs = new HashSet<DS_ChiTiet_DVKT>();
            DS_ChiTiet_Thuocs = new HashSet<DS_ChiTiet_Thuoc>();
            DS_DienBien_LamSangs = new HashSet<DS_DienBien_LamSang>();
            DS_KetQua_CLSs = new HashSet<DS_KetQua_CLS>();
        }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int ThongTinKhamChuaBenhID { get; set; }
        [Required]
        [MaxLength(100)]
        public string MA_LK { set; get; }
        [Required]
        public int STT { set; get; }
        [MaxLength(100)]
        [Required]
        public string MA_BN { set; get; }
        [MaxLength(255)]
        [Required]
        public string HO_TEN { set; get; }
        public DateTime NGAY_SINH { set; get; }
        public int GIOI_TINH { set; get; }
        [MaxLength(1024)]
        [Required]
        public string DIA_CHI { set; get; }
        //[MaxLength(128)]
        public string MA_THE { set; get; }
        [MaxLength(128)]
        public string MA_DKBD { set; get; }
        [MaxLength(50)]
        public string GT_THE_TU { set; get; }
        [MaxLength(50)]
        public string GT_THE_DEN { set; get; }
        [MaxLength(8)]
        public string MIEN_CUNG_CT { set; get; }
        [Required]
        [MaxLength(1024)]
        public string TEN_BENH { set; get; }
        [MaxLength(128)]
        [Required]
        public string MA_BENH { set; get; }
        [MaxLength(255)]
        public string MA_BENHKHAC { set; get; }
        public int MA_LYDO_VVIEN { set; get; }
        [MaxLength(15)]
        public string MA_NOI_CHUYEN { set; get; }
        [MaxLength(5)]
        public string MA_NOI_DEN { set; get; }
        [MaxLength(5)]
        public string MA_NOI_DI { set; get; }
        public int? MA_TAI_NAN { set; get; }
        public DateTime NGAY_VAO { set; get; }
        public DateTime NGAY_RA { set; get; }
        public int SO_NGAY_DTRI { set; get; }
        public int KET_QUA_DTRI { set; get; }
        public int TINH_TRANG_RV { set; get; }
        public DateTime NGAY_TTOAN { set; get; }
        public decimal T_THUOC { set; get; }
        public decimal T_VTYT { set; get; }
        public decimal T_TONGCHI { set; get; }
        public decimal T_BNTT { set; get; }
        public decimal T_BNCCT { set; get; }
        public decimal T_BHTT { set; get; }
        public decimal T_NGUONKHAC { set; get; }
        public decimal T_NGOAIDS { set; get; }
        public int NAM_QT { set; get; }
        public int THANG_QT { set; get; }
        public int MA_LOAI_KCB { set; get; }
        [MaxLength(15)]
        public string MA_KHOA { set; get; }
        [MaxLength(5)]
        [Required]
        public string MA_CSKCB { set; get; }
        [MaxLength(2)]
        public string MA_KHUVUC { set; get; }
        [MaxLength(255)]
        public string MA_PTTT_QT { set; get; }
        public decimal? CAN_NANG { set; get; }
        public TrangThaiHSEnum TRANG_THAI { set; get; }
        public string Loi { set; get; }
        [MaxLength(15)]
        public string SO_CCCD { set; get; }
        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string LichSuTuongTacID { get; set; }
        [MaxLength(10)]
        public string BHXHID { set; get; }
        public LichSuTuongTac LichSuTuongTac { get; set; }
        public ICollection<DS_ChiTiet_DVKT> DS_ChiTiet_DVKTs { get; set; }
        public ICollection<DS_ChiTiet_Thuoc> DS_ChiTiet_Thuocs { get; set; }
        public ICollection<DS_DienBien_LamSang> DS_DienBien_LamSangs { get; set; }
        public ICollection<DS_KetQua_CLS> DS_KetQua_CLSs { get; set; }


    }
}
