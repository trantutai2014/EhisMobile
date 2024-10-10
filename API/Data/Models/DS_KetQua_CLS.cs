using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Data.Abstract;
using Common.Constants;

namespace MDP.Data.Models
{
    [Table("DS_KetQua_CLS")]
    public class DS_KetQua_CLS : BaseEntity
    {
        public DS_KetQua_CLS()
        {
            Id = Guid.NewGuid().ToString();
        }
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int DS_KetQua_CLSID { get; set; }

        [MaxLength(100)]
        public string MA_LK { set; get; }
        public int STT { set; get; }
        [MaxLength(15)]
        [Required]
        public string MA_DICH_VU { set; get; }
        [MaxLength(20)]
        public string MA_CHI_SO { set; get; }
        [MaxLength(255)]
        public string TEN_CHI_SO { set; get; }
        [MaxLength(50)]
        public string GIA_TRI { set; get; }
        [MaxLength(50)]
        public string MA_MAY { set; get; }
        //[MaxLength(1024)]
        [MaxLength(4000)]
        public string MO_TA { set; get; }
        //[MaxLength(1024)]
        [MaxLength(4000)]
        public string KET_LUAN { set; get; }
        public DateTime NGAY_KQ { set; get; }

        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string ThongTinKhamChuaBenhID { get; set; }
        public DateTime? NgayRa { set; get; }
        public ThongTinKhamChuaBenh ThongTinKhamChuaBenh { get; set; }
    }
}
