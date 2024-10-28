using Common.Constants;
using Data.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.Models
{
    [Table("DS_ChiTiet_Thuoc130")]
    public class DS_ChiTiet_Thuoc130 : BaseEntity
    {
        public DS_ChiTiet_Thuoc130()
        {
            Id = Guid.NewGuid().ToString();
        }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int DS_ChiTiet_ThuocID { get; set; }
        [Required]
        [MaxLength(100)]
        public string MA_LK { set; get; }
        [Required]
        public int STT { set; get; }
        [MaxLength(255)]
        [Required]
        public string MA_THUOC { set; get; }
        [MaxLength(255)]
        public string MA_PP_CHEBIEN { set; get; }
        [MaxLength(10)]
        public string MA_CSKCB_THUOC { set; get; }
        [Required]
        public int MA_NHOM { set; get; }
        [MaxLength(1024)]
        [Required]
        public string TEN_THUOC { set; get; }
        [MaxLength(50)]
        [Required]
        public string DON_VI_TINH { set; get; }
        [MaxLength(1024)]
        //[Required]
        public string HAM_LUONG { set; get; }
        [MaxLength(4)]
        //[Required]
        public string DUONG_DUNG { set; get; }
        [MaxLength(1024)]
        public string DANG_BAO_CHE { set; get; }
        [MaxLength(1024)]
        [Required]
        public string LIEU_DUNG { set; get; }
        [MaxLength(1024)]
        public string CACH_DUNG { set; get; }

        [MaxLength(255)]
        public string SO_DANG_KY { set; get; }
        [MaxLength(250)]
        public string TT_THAU { set; get; }
        [Required]
        public int PHAM_VI { set; get; }
        [Required]
        public int TYLE_TT_BH { set; get; }
        [Required]
        public decimal SO_LUONG { set; get; }
        [Required]
        public decimal DON_GIA { set; get; }
        [Required]
        public decimal THANH_TIEN_BV { set; get; }
        [Required]
        public decimal THANH_TIEN_BH { set; get; }
        [Required]
        public decimal T_NGUONKHAC_NSNN { set; get; }
        [Required]
        public decimal T_NGUONKHAC_VTNN { set; get; }
        [Required]
        public decimal T_NGUONKHAC_VTTN { set; get; }
        [Required]
        public decimal T_NGUONKHAC_CL { set; get; }
        [Required]
        public decimal T_NGUONKHAC { set; get; }
        [Required]
        public decimal MUC_HUONG { set; get; }
        [Required]
        public decimal T_BNTT { set; get; }
        [Required]
        public decimal T_BNCCT { set; get; }
        [Required]
        public decimal T_BHTT { set; get; }
        [MaxLength(50)]
        [Required]
        public string MA_KHOA { set; get; }
        [MaxLength(255)]
        [Required]
        public string MA_BAC_SI { set; get; }
        [MaxLength(255)]
        public string MA_DICH_VU { set; get; }
        public DateTime NGAY_YL { set; get; }
        public DateTime? NGAY_TH_YL { set; get; }
        [Required]
        public int MA_PTTT { set; get; }
        [Required]
        public int NGUON_CTRA { set; get; }
        [MaxLength(1)]
        public string VET_THUONG_TP { set; get; }
        public string DU_PHONG { set; get; }
        public DateTime? NgayRa { set; get; }

        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string ThongTinKhamChuaBenhID { get; set; }

        public ThongTinKhamChuaBenh130 ThongTinKhamChuaBenh130 { get; set; }
    }
}
