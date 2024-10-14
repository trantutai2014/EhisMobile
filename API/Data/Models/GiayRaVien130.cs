using Data.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Common.Constants;
using System.ComponentModel.DataAnnotations;
using Data.Models;


namespace Data.Models
{
    [Table("DS_GiayRaVien130")]
    public class DS_GiayRaVien130 : BaseEntity
    {
        public DS_GiayRaVien130()
        {
            Id = Guid.NewGuid().ToString();
        }
        [MaxLength(100)]
        [Required]
        public string MA_LK { get; set; }
        [MaxLength(200)]
        [Required]
        public string SO_LUU_TRU { get; set; }
        [MaxLength(200)]
        [Required]
        public string MA_YTE { get; set; }
        [MaxLength(200)]
        [Required]
        public string MA_KHOA_RV { get; set; }
        public DateTime NGAY_VAO { get; set; }
        public DateTime NGAY_RA { get; set; }
        [MaxLength(1)]
        public string MA_DINH_CHI_THAI { get; set; }
        // [RequiredIfIn("MA_DINH_CHI_THAI", true, new string[] { "1" })]
        public string NGUYENNHAN_DINHCHI { get; set; }
        // [RequiredIfIn("MA_DINH_CHI_THAI", true, new string[] { "1" })]
        public DateTime? THOIGIAN_DINHCHI { get; set; }
        // [RequiredIfIn("MA_DINH_CHI_THAI", true, new string[] { "1" })]
        [MaxLength(2)]
        public string TUOI_THAI { get; set; }
        [MaxLength(1500)]
        [Required]
        public string CHAN_DOAN_RV { get; set; }
        [MaxLength(1500)]
        [Required]
        public string PP_DIEUTRI { get; set; }
        [MaxLength(1500)]
        public string GHI_CHU { get; set; }
        [MaxLength(10)]
        [Required]
        public string MA_TTDV { get; set; }
        [MaxLength(200)]
        [Required]
        public string MA_BS { get; set; }
        [MaxLength(255)]
        [Required]
        public string TEN_BS { get; set; }
        public DateTime NGAY_CT { get; set; }
        [MaxLength(10)]
        public string MA_CHA { get; set; }
        [MaxLength(10)]
        public string MA_ME { get; set; }
        [MaxLength(15)]
        public string MA_THE_TAM { get; set; }
        [MaxLength(255)]
        public string HO_TEN_CHA { get; set; }
        [MaxLength(255)]
        public string HO_TEN_ME { get; set; }
        [MaxLength(2)]
        public string SO_NGAY_NGHI { get; set; }
        public DateTime? NGOAITRU_TUNGAY { get; set; }
        public DateTime? NGOAITRU_DENNGAY { get; set; }
        public string DU_PHONG { get; set; }
        public DateTime? NgayRa { set; get; }

        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string ThongTinKhamChuaBenhID { get; set; }
        public ThongTinKhamChuaBenh130 ThongTinKhamChuaBenh130 { get; set; }
    }
}
