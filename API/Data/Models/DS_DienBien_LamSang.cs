using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Data.Abstract;
using Common.Constants;

namespace MDP.Data.Models
{
    [Table("DS_DienBien_LamSang")]
    public class DS_DienBien_LamSang : BaseEntity
    {
        public DS_DienBien_LamSang()
        {
            Id = Guid.NewGuid().ToString();
        }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int DS_DienBien_LamSangID { get; set; }
        [MaxLength(100)]
        public string MA_LK { set; get; }
        public int STT { set; get; }
        [Required]
        public string DIEN_BIEN { set; get; }
        public string HOI_CHAN { set; get; }
        //[MaxLength(1024)]
        [MaxLength(4000)]
        public string PHAU_THUAT { set; get; }
        public DateTime NGAY_YL { set; get; }

        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string ThongTinKhamChuaBenhID { get; set; }
        public DateTime? NgayRa { set; get; }
        public ThongTinKhamChuaBenh ThongTinKhamChuaBenh { get; set; }
    }
}
