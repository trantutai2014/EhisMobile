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
    [Table("DS_ChungNhan_NghiDuongThai130")]
    public class DS_ChungNhan_NghiDuongThai130 : BaseEntity
    {
        public DS_ChungNhan_NghiDuongThai130()
        {
            Id = Guid.NewGuid().ToString();
        }
        [MaxLength(100)]
        [Required]
        public string MA_LK { get; set; }
        [MaxLength(200)]
        [Required]
        public string SO_SERI { get; set; }
        [MaxLength(200)]
        [Required]
        public string SO_CT { get; set; }
        public int SO_NGAY { get; set; }
        [MaxLength(1024)]
        [Required]
        public string DON_VI { get; set; }
        [Required]
        public string CHAN_DOAN_RV { get; set; }
        public DateTime TU_NGAY { get; set; }
        public DateTime DEN_NGAY { get; set; }
        [MaxLength(10)]
        [Required]
        public string MA_TTDV { get; set; }
        [MaxLength(255)]
        public string TEN_BS { get; set; }
        [MaxLength(200)]
        public string MA_BS { get; set; }
        public DateTime NGAY_CT { get; set; }
        public string DU_PHONG { get; set; }
        public DateTime? NgayRa { set; get; }

        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string ThongTinKhamChuaBenhID { get; set; }
        public ThongTinKhamChuaBenh130 ThongTinKhamChuaBenh130 { get; set; }
    }
}
