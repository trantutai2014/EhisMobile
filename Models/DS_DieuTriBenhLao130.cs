using MDP.Common.Constants;
using MDP.Data.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.Data.Models
{
    [Table("DS_DieuTriBenhLao130")]
    public class DS_DieuTriBenhLao130 : BaseEntity
    {
        public DS_DieuTriBenhLao130()
        {
            Id = Guid.NewGuid().ToString();
        }
        [MaxLength(100)]
        [Required]
        public string MA_LK { get; set; }
        [MaxLength(10)]
        public string STT { get; set; }
        [MaxLength(100)]
        [Required]
        public string MA_BN { get; set; }
        [MaxLength(255)]
        public string HO_TEN { get; set; }
        [MaxLength(15)]
        public string SO_CCCD { get; set; }
        [Required]
        public int PHANLOAI_LAO_VITRI {  get; set; }
        [Required]
        public int PHANLOAI_LAO_TS { get; set; }
        [Required]
        public int PHANLOAI_LAO_HIV { get; set; }
        [Required]
        public int PHANLOAI_LAO_VK { get; set; }
        [Required]
        public int PHANLOAI_LAO_KT { get; set; }
        [Required]
        public int LOAI_DTRI_LAO {  get; set; }
        public DateTime? NGAYBD_DTRI_LAO { get; set; }
        [Required]
        public int PHACDO_DTRI_LAO { get; set; }
        public DateTime? NGAYKT_DTRI_LAO { get; set;}
        [Required]
        public int KET_QUA_DTRI_LAO { get; set; }
        [MaxLength(5)]
        public string MA_CSKCB { get; set; }
        public DateTime? NGAYKD_HIV { get; set; }
        public DateTime? BDDT_ARV { get; set; }
        public DateTime? NGAY_BAT_DAU_DT_CTX { get; set; }
        public string DU_PHONG { get; set; }
        public DateTime? NgayRa { set; get; }

        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string ThongTinKhamChuaBenhID { get; set; }
        public ThongTinKhamChuaBenh130 ThongTinKhamChuaBenh130 { get; set; }
    }
}
