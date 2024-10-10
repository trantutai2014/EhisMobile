using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Common.Constants;
using Data.Abstract;
using MDP.Data.Models;
using MDP.Common.Enums;

namespace Data.Models
{
  [Table("ThongTinKhamChuaBenh130")]
  public class ThongTinKhamChuaBenh130 : BaseEntity
  {
    public ThongTinKhamChuaBenh130()
    {
      Id = Guid.NewGuid().ToString();
      //DS_ChiTiet_Thuoc130s = new HashSet<DS_ChiTiet_Thuoc130>();
      //DS_ChiTiet_DVKT130s = new HashSet<DS_ChiTiet_DVKT130>();
      //DS_DVCLS130s = new HashSet<DS_DVCLS130>();
      //DS_DienBien_LamSang130s = new HashSet<DS_DienBien_LamSang130>();
      //DS_CSDT_ARV130s = new HashSet<DS_CSDT_ARV130>();
      //DS_GiayRaVien130s = new HashSet<DS_GiayRaVien130>();
      // DS_TomTat_HoSoBA130s = new HashSet<DS_TomTat_HoSoBA130>();
      //DS_GiayChungSinh130s = new HashSet<DS_GiayChungSinh130>();
      //DS_ChungNhan_NghiDuongThai130s = new HashSet<DS_ChungNhan_NghiDuongThai130>();
      //DS_GiayChungNhan_NghiViec_HBHXH130s = new HashSet<DS_GiayChungNhan_NghiViec_HBHXH130>();
      //DS_GiamDinhYKhoa130s = new HashSet<DS_GiamDinhYKhoa130>();
      // DS_GiayChuyenTuyen130s = new HashSet<DS_GiayChuyenTuyen130>();
      // DS_GiayHenKhamLai130s = new HashSet<DS_GiayHenKhamLai130>();
      // DS_DieuTriBenhLao130s = new HashSet<DS_DieuTriBenhLao130>();
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ThongTinKhamChuaBenhID { get; set; }
    [Required]
    [MaxLength(100)]
    public string MA_LK { set; get; }
    [MaxLength(10)]
    public string? STT { set; get; }
    [MaxLength(100)]
    [Required]
    public string MA_BN { set; get; }
    [MaxLength(255)]
    [Required]
    public string HO_TEN { set; get; }
    [MaxLength(15)]
    public string? SO_CCCD { set; get; }
    [Required]
    public DateTime NGAY_SINH { set; get; }
    [Required]
    public int GIOI_TINH { set; get; }
    [MaxLength(5)]
    public string? NHOM_MAU { set; get; }
    [MaxLength(3)]
    [Required]
    public string MA_QUOCTICH { set; get; }
    [MaxLength(2)]
    [Required]
    public string MA_DANTOC { set; get; }
    [MaxLength(5)]
    [Required]
    public string MA_NGHE_NGHIEP { set; get; }
    [MaxLength(1024)]
    [Required]
    public string DIA_CHI { set; get; }
    [MaxLength(3)]
    [Required]
    public string MATINH_CU_TRU { set; get; }
    [MaxLength(3)]
    [Required]
    public string MAHUYEN_CU_TRU { set; get; }
    [MaxLength(5)]
    [Required]
    public string MAXA_CU_TRU { set; get; }
    [MaxLength(15)]
    public string? DIEN_THOAI { set; get; }
    public string? MA_THE_BHYT { set; get; }
    public string? MA_DKBD { set; get; }
    public string? GT_THE_TU { set; get; }
    public string? GT_THE_DEN { set; get; }
    public DateTime? NGAY_MIEN_CCT { set; get; }
    [Required]
    public string LY_DO_VV { set; get; }
    public string? LY_DO_VNT { set; get; }
    [MaxLength(5)]
    public string? MA_LY_DO_VNT { set; get; }
    [Required]
    public string CHAN_DOAN_VAO { set; get; }
    [Required]
    public string CHAN_DOAN_RV { set; get; }
    [MaxLength(7)]
    [Required]
    public string MA_BENH_CHINH { set; get; }
    [MaxLength(100)]
    public string? MA_BENH_KT { set; get; }
    [MaxLength(255)]
    public string? MA_BENH_YHCT { set; get; }
    [MaxLength(125)]
    public string? MA_PTTT_QT { set; get; }
    [MaxLength(4)]
    [Required]
    public string MA_DOITUONG_KCB { set; get; }
    [MaxLength(5)]
    public string? MA_NOI_DI { set; get; }
    [MaxLength(5)]
    public string? MA_NOI_DEN { set; get; }
    public int MA_TAI_NAN { set; get; }
    [Required]
    public DateTime NGAY_VAO { set; get; }
    public DateTime? NGAY_VAO_NOI_TRU { set; get; }
    [Required]
    public DateTime NGAY_RA { set; get; }
    [MaxLength(50)]
    public string? GIAY_CHUYEN_TUYEN { set; get; }
    public int SO_NGAY_DTRI { set; get; }
    public string? PP_DIEU_TRI { set; get; }
    public int KET_QUA_DTRI { set; get; }
    [Required]
    public int MA_LOAI_RV { set; get; }
    public string? GHI_CHU { set; get; }
    public DateTime? NGAY_TTOAN { set; get; }
    [Required]
    public decimal T_THUOC { set; get; }
    [Required]
    public decimal T_VTYT { set; get; }
    [Required]
    public decimal T_TONGCHI_BV { set; get; }
    [Required]
    public decimal T_TONGCHI_BH { set; get; }
    [Required]
    public decimal T_BNTT { set; get; }
    [Required]
    public decimal T_BNCCT { set; get; }
    [Required]
    public decimal T_BHTT { set; get; }
    [Required]
    public decimal T_NGUONKHAC { set; get; }
    [Required]
    public decimal T_BHTT_GDV { set; get; }
    [Required]
    public int NAM_QT { set; get; }
    [Required]
    public int THANG_QT { set; get; }
    [MaxLength(2)]
    [Required]
    public string MA_LOAI_KCB { set; get; }
    [MaxLength(50)]
    [Required]
    public string MA_KHOA { set; get; }
    [MaxLength(5)]
    [Required]
    public string MA_CSKCB { set; get; }
    [MaxLength(2)]
    public string? MA_KHUVUC { set; get; }
    [MaxLength(6)]
    [Required]
    public string CAN_NANG { set; get; }
    [MaxLength(100)]
    public string? CAN_NANG_CON { set; get; }
    [MaxLength(8)]
    public DateTime? NAM_NAM_LIEN_TUC { set; get; }
    [MaxLength(50)]
    public string? NGAY_TAI_KHAM { set; get; }
    [MaxLength(100)]
    [Required]
    public string MA_HSBA { set; get; }
    [MaxLength(10)]
    public string? MA_TTDV { set; get; }
    public string? DU_PHONG { set; get; }
    public TrangThaiHSEnum TRANG_THAI { set; get; }
    [NotMapped]
    public TrangThaiHSEnum TRANG_THAI2 { set; get; }
    public string? Loi { set; get; }

    [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
    public string LichSuTuongTacID { get; set; }

    [MaxLength(10)]
    public string? BHXHID { set; get; }




  }
}
