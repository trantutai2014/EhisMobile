using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MDP.Data.Abstract;
using MDP.Common.Constants;

namespace MDP.Data.Models
{
    [Table("DS_ChiTiet_DVKT")]
    public class DS_ChiTiet_DVKT : BaseEntity
    {
        public DS_ChiTiet_DVKT()
        {
            Id = Guid.NewGuid().ToString();
        }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int DS_ChiTiet_DVKTID { get; set; }

        [MaxLength(100)]
        public string MA_LK { set; get; }
        public int STT { set; get; }
        [MaxLength(20)]
        public string MA_DICH_VU { set; get; }
        [MaxLength(255)]
        public string MA_VAT_TU { set; get; }
        public int MA_NHOM { set; get; }
        [MaxLength(2)]
        public string GOI_VTYT { set; get; }
        [MaxLength(1024)]
        public string TEN_VAT_TU { set; get; }
        [MaxLength(1024)]
        public string TEN_DICH_VU { set; get; }
        [MaxLength(50)]
        [Required]
        public string DON_VI_TINH { set; get; }
        public int PHAM_VI { set; get; }
        public decimal SO_LUONG { set; get; }
        public decimal DON_GIA { set; get; }
        [MaxLength(250)]
        public string TT_THAU { set; get; }
        public decimal TYLE_TT { set; get; }
        public decimal THANH_TIEN { set; get; }
        public decimal T_TRANTT { set; get; }
        public decimal MUC_HUONG { set; get; }
        public decimal T_NGUONKHAC { set; get; }
        public decimal T_BNTT { set; get; }
        public decimal T_BHTT { set; get; }
        public decimal T_BNCCT { set; get; }
        public decimal T_NGOAIDS { set; get; }
        [MaxLength(15)]
        public string MA_KHOA { set; get; }
        [MaxLength(14)]
        public string MA_GIUONG { set; get; }
        [MaxLength(255)]
        public string MA_BAC_SI { set; get; }
        [MaxLength(255)]
        public string MA_BENH { set; get; }
        public DateTime NGAY_YL { set; get; }
        public DateTime? NGAY_KQ { set; get; }
        public int MA_PTTT { set; get; }

        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string ThongTinKhamChuaBenhID { get; set; }
        public DateTime? NgayRa { set; get; }

        public ThongTinKhamChuaBenh ThongTinKhamChuaBenh { get; set; }
    }
}
