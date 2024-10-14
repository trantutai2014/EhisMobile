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
    [Table("DS_GiayChungSinh130")]
    public class DS_GiayChungSinh130 : BaseEntity
    {
        public DS_GiayChungSinh130()
        {
            Id = Guid.NewGuid().ToString();
        }
        [MaxLength(100)]
        [Required]
        public string MA_LK { get; set; }
        [MaxLength(10)]
        public string MA_BHXH_NND { get; set; }
        [MaxLength(15)]
        public string MA_THE_NND { get; set; }
        [MaxLength(255)]
        [Required]
        public string HO_TEN_NND { get; set; }
        [Required]
        public DateTime NGAYSINH_NND { get; set; }
        [MaxLength(2)]
        [Required]
        public string MA_DANTOC_NND { get; set; }
        [MaxLength(15)]
        [Required]
        public string SO_CCCD_NND { get; set; }
        [Required]
        public DateTime NGAYCAP_CCCD_NND { get; set; }
        [MaxLength(1024)]
        [Required]
        public string NOICAP_CCCD_NND { get; set; }
        [MaxLength(1024)]
        [Required]
        public string NOI_CU_TRU_NND { get; set; }
        [MaxLength(3)]
        [Required]
        public string MA_QUOCTICH { get; set; }
        [MaxLength(3)]
        [Required]
        public string MATINH_CU_TRU { get; set; }
        [MaxLength(3)]
        [Required]
        public string MAHUYEN_CU_TRU { get; set; }
        [MaxLength(5)]
        [Required]
        public string MAXA_CU_TRU { get; set; }
        [MaxLength(255)]
        public string HO_TEN_CHA { get; set; }
        [MaxLength(15)]
        [Required]
        public string MA_THE_TAM { get; set; }
        [MaxLength(255)]
        public string HO_TEN_CON { get; set; }
        [Required]
        public int GIOI_TINH_CON { get; set; }
        [Required]
        public int SO_CON { get; set; }
        [Required]
        public int LAN_SINH { get; set; }
        [Required]
        public int SO_CON_SONG { get; set; }
        [Required]
        public decimal CAN_NANG_CON { get; set; }
        [Required]
        public DateTime NGAY_SINH_CON { get; set; }
        [MaxLength(1024)]
        [Required]
        public string NOI_SINH_CON { get; set; }
        [Required]
        public string TINH_TRANG_CON { get; set; }
        public int SINHCON_PHAUTHUAT { get; set; }
        public int SINHCON_DUOI32TUAN { get; set; }
        [Required]
        public string GHI_CHU { get; set; }
        [MaxLength(255)]
        [Required]
        public string NGUOI_DO_DE { get; set; }
        [MaxLength(255)]
        [Required]
        public string NGUOI_GHI_PHIEU { get; set; }
        [Required]
        public DateTime NGAY_CT { get; set; }
        [MaxLength(200)]
        [Required]
        public string SO { get; set; }
        [MaxLength(200)]
        [Required]
        public string QUYEN_SO { get; set; }
        [Required]
        public int MA_TTDV { get; set; }
        public string DU_PHONG { get; set; }
        public DateTime? NgayRa { set; get; }

        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string ThongTinKhamChuaBenhID { get; set; }
        public ThongTinKhamChuaBenh130 ThongTinKhamChuaBenh130 { get; set; }
    }
}
