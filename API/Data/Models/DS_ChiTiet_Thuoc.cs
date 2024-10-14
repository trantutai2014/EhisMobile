using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Data.Abstract;
using Common.Constants;

namespace Data.Models
{
    [Table("DS_ChiTiet_Thuoc")]
    public class DS_ChiTiet_Thuoc : BaseEntity
    {
        public DS_ChiTiet_Thuoc()
        {
            Id = Guid.NewGuid().ToString();
        }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int DS_ChiTiet_ThuocID { get; set; }
        [Required]
        [MaxLength(100)]
        public string MA_LK { set; get; }
        public int STT { set; get; }
        [MaxLength(255)]
        [Required]
        public string MA_THUOC { set; get; }
        public int MA_NHOM { set; get; }
        [MaxLength(1024)]
        [Required]
        public string TEN_THUOC { set; get; }
        [MaxLength(50)]
        [Required]
        public string DON_VI_TINH { set; get; }
        [MaxLength(1024)]
        public string HAM_LUONG { set; get; }
        [MaxLength(4)]
        public string DUONG_DUNG { set; get; }
        [MaxLength(255)]
        public string LIEU_DUNG { set; get; }
        [MaxLength(255)]
        public string SO_DANG_KY { set; get; }
        [MaxLength(250)]
        public string TT_THAU { set; get; }
        public int PHAM_VI { set; get; }
        public decimal SO_LUONG { set; get; }
        public decimal DON_GIA { set; get; }
        public int TYLE_TT { set; get; }
        public decimal THANH_TIEN { set; get; }
        public decimal MUC_HUONG { set; get; }
        public decimal T_NGUONKHAC { set; get; }
        public decimal T_BNTT { set; get; }
        public decimal T_BHTT { set; get; }
        public decimal T_BNCCT { set; get; }
        public decimal T_NGOAIDS { set; get; }
        [MaxLength(15)]
        public string MA_KHOA { set; get; }
        [MaxLength(255)]
        public string MA_BAC_SI { set; get; }
        [MaxLength(255)]
        public string MA_BENH { set; get; }
        public DateTime NGAY_YL { set; get; }
        public int MA_PTTT { set; get; }

        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string ThongTinKhamChuaBenhID { get; set; }
        public DateTime? NgayRa { set; get; }
        public ThongTinKhamChuaBenh ThongTinKhamChuaBenh { get; set; }
    }
}
