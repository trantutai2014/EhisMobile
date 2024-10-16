
using Common.Constants;
using Data.Abstract;
using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("DS_CSDT_ARV130")]
    public class DS_CSDT_ARV130 : BaseEntity
    {
        public DS_CSDT_ARV130()
        {
            Id = Guid.NewGuid().ToString();
        }
        [MaxLength(100)]
        [Required]
        public string MA_LK { get; set; }
        public string MA_THE_BHYT { get; set; }
        [MaxLength(15)]
        public string SO_CCCD { get; set; }
        public DateTime NGAY_SINH { get; set; }
        public int GIOI_TINH { get; set; }
        [MaxLength(1024)]
        public string DIA_CHI { get; set; }
        [MaxLength(3)]
        [Required]
        public string MATINH_CU_TRU { get; set; }
        [MaxLength(3)]
        [Required]
        public string MAHUYEN_CU_TRU { get; set; }
        [MaxLength(5)]
        [Required]
        public string MAXA_CU_TRU { get; set; }
        public DateTime? NGAYKD_HIV { get; set; }
        [MaxLength(5)]
        public string NOI_LAY_MAU_XN { get; set; }
        [MaxLength(5)]
        public string NOI_XN_KD { get; set; }
        [MaxLength(5)]
        public string NOI_BDDT_ARV { get; set; }
        public DateTime? BDDT_ARV { get; set; }

        [MaxLength(200)]
        public string MA_PHAC_DO_DIEU_TRI_BD { get; set; }
        [MaxLength(1)]
        public string MA_BAC_PHAC_DO_BD { get; set; }
        [Required]
        public int MA_LYDO_DTRI { get; set; }
        [Required]
        public int LOAI_DTRI_LAO { get; set; }
        [MaxLength(1)]
        public string SANG_LOC_LAO { get; set; }
        // [RequiredIfIn("LOAI_DTRI_LAO", false, new string[] { "0" })]
        public string PHACDO_DTRI_LAO { get; set; }
        // [RequiredIfIn("LOAI_DTRI_LAO", false, new string[] { "0" })]
        [MaxLength(2)]
        public DateTime? NGAYBD_DTRI_LAO { get; set; }
        // [RequiredIfIn("LOAI_DTRI_LAO", false, new string[] { "0" })]
        public DateTime? NGAYKT_DTRI_LAO { get; set; }
        [MaxLength(1)]
        public string KQ_DTRI_LAO { get; set; }
        [MaxLength(1)]
        public string MA_LYDO_XNTL_VR { get; set; }
        public DateTime? NGAY_XN_TLVR { get; set; }
        [MaxLength(1)]
        public string KQ_XNTL_VR { get; set; }
        public DateTime? NGAY_KQ_XN_TLVR { get; set; }
        [Required]
        public int MA_LOAI_BN { get; set; }
        [MaxLength(1)]
        public string GIAI_DOAN_LAM_SANG { get; set; }
        [MaxLength(2)]
        public string NHOM_DOI_TUONG { get; set; }
        [MaxLength(18)]
        [Required]
        public string MA_TINH_TRANG_DK { get; set; }
        [MaxLength(1)]
        // [RequiredIfIn("MA_TINH_TRANG_DK", true, new string[] { "1" })]
        public string LAN_XN_PCR { get; set; }
        // [RequiredIfIn("MA_TINH_TRANG_DK", true, new string[] { "1" })]
        public DateTime? NGAY_XN_PCR { get; set; }
        // [RequiredIfIn("MA_TINH_TRANG_DK", true, new string[] { "1" })]
        public DateTime? NGAY_KQ_XN_PCR { get; set; }
        // [RequiredIfIn("MA_TINH_TRANG_DK", true, new string[] { "1" })]
        [MaxLength(1)]
        public string MA_KQ_XN_PCR { get; set; }
        public DateTime? NGAY_NHAN_TT_MANG_THAI { get; set; }
        public DateTime? NGAY_BAT_DAU_DT_CTX { get; set; }
        [Required]
        public int MA_XU_TRI { get; set; }
        // [RequiredIfIn("MA_XU_TRI", true, new string[] { "1" })]
        public DateTime? NGAY_BAT_DAU_XU_TRI { get; set; }
        // [RequiredIfIn("MA_XU_TRI", true, new string[] { "1" })]
        public DateTime? NGAY_kET_THUC_XU_TRI { get; set; }
        [MaxLength(200)]
        [Required]
        public string MA_PHAC_DO_DIEU_TRI { get; set; }
        // [RequiredIfIn("MA_PHAC_DO_DIEU_TRI", true, new string[] { "KHAC" })]
        public string MA_BAC_PHAC_DO { get; set; }
        // [RequiredIfIn("MA_XU_TRI", true, new string[] { "1" })]
        public string SO_NGAY_CAP_THUOC_ARV { get; set; }
        public DateTime? NGAY_CHUYEN_PHAC_DO { get; set; }
        [MaxLength(1)]
        public string LY_DO_CHUYEN_PHAC_DO { get; set; }
        [MaxLength(5)]
        public string MA_CSKCB { get; set; }
        public string DU_PHONG { get; set; }
        public DateTime? NgayRa { set; get; }
        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string ThongTinKhamChuaBenhID { get; set; }
        public ThongTinKhamChuaBenh130 ThongTinKhamChuaBenh130 { get; set; }
    }
}
