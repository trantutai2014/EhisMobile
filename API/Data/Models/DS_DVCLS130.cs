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
    [Table("DS_DVCLS130")]
    public class DS_DVCLS130 : BaseEntity
    {
        public DS_DVCLS130()
        {
            Id = Guid.NewGuid().ToString();
        }
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int DS_KetQua_CLSID { get; set; }

        [MaxLength(100)]
        [Required]
        public string MA_LK { set; get; }
        [Required]
        public int STT { set; get; }
        [MaxLength(15)]
        [Required]
        public string MA_DICH_VU { set; get; }
        [MaxLength(50)]
        public string MA_CHI_SO { set; get; }
        [MaxLength(255)]
        public string TEN_CHI_SO { set; get; }
        [MaxLength(50)]
        public string GIA_TRI { set; get; }
        [MaxLength(50)]
        public string DON_VI_DO { set; get; }
        public string MO_TA { set; get; }
        public string KET_LUAN { set; get; }
        [Required]
        public DateTime NGAY_KQ { set; get; }
        [MaxLength(255)]
        public string MA_BS_DOC_KQ { set; get; }
        public string DU_PHONG { set; get; }
        public DateTime? NgayRa { set; get; }
        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string ThongTinKhamChuaBenhID { get; set; }

        public ThongTinKhamChuaBenh130 ThongTinKhamChuaBenh130 { get; set; }
    }
}
