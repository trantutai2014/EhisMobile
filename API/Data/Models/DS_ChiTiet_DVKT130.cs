
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Abstract;
using Common.Constants;
using Data.Models;

namespace Data.Models
{
    [Table("DS_ChiTiet_DVKT130")]
    public class DS_ChiTiet_DVKT130 : BaseEntity
    {
        public DS_ChiTiet_DVKT130()
        {
            Id = Guid.NewGuid().ToString();
        }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int DS_ChiTiet_DVKTID { get; set; }

        [MaxLength(100)]
        [Required]
        public string MA_LK { set; get; }
        [Required]
        public int STT { set; get; }
        [MaxLength(50)]
        public string MA_DICH_VU { set; get; }
        [MaxLength(255)]
        public string MA_PTTT_QT { set; get; }
        [MaxLength(255)]
        public string MA_VAT_TU { set; get; }
        [Required]
        public int MA_NHOM { set; get; }
        [MaxLength(3)]
        public string GOI_VTYT { set; get; }
        [MaxLength(1024)]
        public string TEN_VAT_TU { set; get; }
        [MaxLength(1024)]
        public string TEN_DICH_VU { set; get; }
        [MaxLength(20)]
        //[RequiredIfIn("MA_NHOM", true, new string[] { "12" })]
        public string MA_XANG_DAU { get; set; }
        [MaxLength(50)]
        [Required]
        public string DON_VI_TINH { set; get; }
        [Required]
        public int PHAM_VI { set; get; }
        [Required]
        public decimal SO_LUONG { set; get; }
        [Required]
        public decimal DON_GIA_BV { set; get; }
        [Required]
        public decimal DON_GIA_BH { set; get; }
        [MaxLength(25)]
        //[RequiredIfIn("MA_NHOM", true, new string[] { "10" })]
        public string TT_THAU { set; get; }
        public decimal TYLE_TT_DV { set; get; }
        public decimal TYLE_TT_BH { set; get; }
        public decimal THANH_TIEN_BV { set; get; }
        public decimal THANH_TIEN_BH { set; get; }
        [MaxLength(15)]
        public string T_TRANTT { set; get; }
        public decimal MUC_HUONG { set; get; }
        public decimal T_NGUONKHAC_NSNN { set; get; }
        public decimal T_NGUONKHAC_VTNN { set; get; }
        public decimal T_NGUONKHAC_VTTN { set; get; }
        public decimal T_NGUONKHAC_CL { set; get; }
        public decimal T_NGUONKHAC { set; get; }
        public decimal T_BNTT { set; get; }
        public decimal T_BNCCT { set; get; }
        public decimal T_BHTT { set; get; }
        [MaxLength(50)]
        [Required]
        public string MA_KHOA { set; get; }

        [MaxLength(50)]
        public string MA_GIUONG { set; get; }
        [MaxLength(255)]
        [Required]
        public string MA_BAC_SI { set; get; }
        [MaxLength(255)]
        //[RequiredIfIn("MA_NHOM", true,new string[] { "1", "2", "3", "8", "18" })]
        public string NGUOI_THUC_HIEN { set; get; }
        [MaxLength(100)]
        [Required]
        public string MA_BENH { set; get; }
        [MaxLength(255)]
        public string MA_BENH_YHCT { set; get; }
        public DateTime NGAY_YL { set; get; }
        //[RequiredIfIn("MA_NHOM", true, new string[] { "1", "2", "3", "8", "18" })]
        public DateTime? NGAY_TH_YL { set; get; }
        public DateTime? NGAY_KQ { set; get; }
        public int MA_PTTT { set; get; }
        [MaxLength(1)]
        public string VET_THUONG_TP { set; get; }
        [MaxLength(1)]
        public string PP_VO_CAM { set; get; }
        [MaxLength(3)]
        public string VI_TRI_TH_DVKT { set; get; }
        [MaxLength(1024)]
        public string MA_MAY { set; get; }
        [MaxLength(255)]
        public string MA_HIEU_SP { set; get; }
        [MaxLength(1)]
        public string TAI_SU_DUNG { set; get; }
        public string DU_PHONG { set; get; }
        public DateTime? NgayRa { set; get; }

        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string ThongTinKhamChuaBenhID { get; set; }


        public ThongTinKhamChuaBenh130 ThongTinKhamChuaBenh130 { get; set; }
    }
}
