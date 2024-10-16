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
    [Table("DS_DienBien_LamSang130")]
    public class DS_DienBien_LamSang130 : BaseEntity
    {
        public DS_DienBien_LamSang130()
        {
            Id = Guid.NewGuid().ToString();
        }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int DS_DienBien_LamSangID { get; set; }
        [MaxLength(100)]
        [Required]
        public string MA_LK { set; get; }
        [Required]
        public int STT { set; get; }
        [Required]
        public string DIEN_BIEN_LS { set; get; }
        public string GIAI_DOAN_BENH { set; get; }
        public string HOI_CHAN { set; get; }
        //[MaxLength(1024)]
        //[MaxLength(4000)]
        public string PHAU_THUAT { set; get; }
        [Required]
        public DateTime THOI_DIEM_DBLS { set; get; }
        [MaxLength(255)]
        [Required]
        public string NGUOI_THUC_HIEN { set; get; }
        public string DU_PHONG { set; get; }
        public DateTime? NgayRa { set; get; }
        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string ThongTinKhamChuaBenhID { get; set; }

        public ThongTinKhamChuaBenh130 ThongTinKhamChuaBenh130 { get; set; }
    }
}
