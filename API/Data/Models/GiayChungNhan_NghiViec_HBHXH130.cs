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


namespace MDP.Data.Models
{
    [Table("DS_GiayChungNhan_NghiViec_HBHXH130")]
    public class DS_GiayChungNhan_NghiViec_HBHXH130 : BaseEntity
    {
        public DS_GiayChungNhan_NghiViec_HBHXH130()
        {
            Id = Guid.NewGuid().ToString();
        }
        [MaxLength(100)]
        [Required]
        public string MA_LK { get; set; }
        [MaxLength(200)]
        [Required]
        public string SO_CT { get; set; }
        [MaxLength(200)]
        [Required]
        public string SO_SERI { get; set; }
        [MaxLength(200)]
        [Required]
        public string SO_KCB { get; set; }
        [MaxLength(1024)]
        [Required]
        public string DON_VI { get; set; }
        [MaxLength(10)]
        [Required]
        public string MA_BHXH { get; set; }
        public string MA_THE_BHYT { get; set; }
        [Required]
        public string CHAN_DOAN_RV { get; set; }
        [Required]
        public string PP_DIEUTRI { get; set; }
        [MaxLength(1)]
        public string MA_DINH_CHI_THAI { get; set; }
        // [RequiredIfIn("MA_DINH_CHI_THAI", true, new string[] { "1" })]
        public string NGUYENNHAN_DINHCHI { get; set; }
        // [RequiredIfIn("MA_DINH_CHI_THAI", true, new string[] { "1" })]
        [MaxLength(2)]
        public string TUOI_THAI { get; set; }
        public int SO_NGAY_NGHI { get; set; }
        [Required]
        public DateTime TU_NGAY { get; set; }
        [Required]
        public DateTime DEN_NGAY { get; set; }
        [MaxLength(255)]
        public string HO_TEN_CHA { get; set; }
        [MaxLength(255)]
        public string HO_TEN_ME { get; set; }
        [MaxLength(10)]
        [Required]
        public string MA_TTDV { get; set; }
        [MaxLength(200)]
        public string MA_BS { get; set; }
        public DateTime NGAY_CT { get; set; }
        [MaxLength(15)]
        public string MA_THE_TAM { get; set; }
        [MaxLength(5)]
        public string MAU_SO { get; set; }
        public string DU_PHONG { get; set; }
        public DateTime? NgayRa { set; get; }

        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string ThongTinKhamChuaBenhID { get; set; }
        public ThongTinKhamChuaBenh130 ThongTinKhamChuaBenh130 { get; set; }
    }
}
