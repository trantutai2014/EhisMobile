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
    [Table("DS_TomTat_HoSoBA130")]
    public class DS_TomTat_HoSoBA130 : BaseEntity
    {
        public DS_TomTat_HoSoBA130()
        {
            Id = Guid.NewGuid().ToString();
        }
        [MaxLength(100)]
        [Required]
        public string MA_LK { get; set; }
        [MaxLength(2)]
        [Required]
        public string MA_LOAI_KCB { get; set; }
        [MaxLength(255)]
        public string HO_TEN_CHA { get; set; }
        [MaxLength(255)]
        public string HO_TEN_ME { get; set; }
        [MaxLength(255)]
        public string NGUOI_GIAM_HO { get; set; }
        [MaxLength(1024)]
        public string DON_VI { get; set; }
        public DateTime NGAY_VAO { get; set; }
        public DateTime NGAY_RA { get; set; }
        [Required]
        public string CHAN_DOAN_VAO { get; set; }
        [Required]
        public string CHAN_DOAN_RV { get; set; }
        [Required]
        public string QT_BENHLY { get; set; }
        [Required]
        public string TOMTAT_KQ { get; set; }
        [Required]
        public string PP_DIEUTRI { get; set; }
        public DateTime? NGAY_SINHCON { get; set; }
        public DateTime? NGAY_CONCHET { get; set; }
        [MaxLength(2)]
        public string SO_CONCHET { get; set; }
        [Required]
        public int KET_QUA_DTRI { get; set; }
        public string GHI_CHU { get; set; }
        [MaxLength(10)]
        [Required]
        public string MA_TTDV { get; set; }
        [Required]
        public DateTime NGAY_CT { get; set; }
        [MaxLength(15)]
        public string MA_THE_TAM { get; set; }
        public string DU_PHONG { get; set; }
        public DateTime? NgayRa { set; get; }

        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string ThongTinKhamChuaBenhID { get; set; }
        public ThongTinKhamChuaBenh130 ThongTinKhamChuaBenh130 { get; set; }
    }
}
