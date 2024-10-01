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
    [Table("DS_GiayHenKhamLai130")]
    public class DS_GiayHenKhamLai130 : BaseEntity
    {
        public DS_GiayHenKhamLai130()
        {
            Id = Guid.NewGuid().ToString();
        }
        [MaxLength(100)]
        [Required]
        public string MA_LK { get; set; }
        [MaxLength(50)]
        [Required]
        public string SO_GIAYHEN_KL { get; set; }
        [MaxLength(5)]
        [Required]
        public string MA_CSKCB { get; set; }
        [MaxLength(255)]
        [Required]
        public string HO_TEN { get; set; }
        public DateTime NGAY_SINH { get; set; }
        [MaxLength(1)]
        public string GIOI_TINH { get; set; }
        [MaxLength(1024)]
        public string DIA_CHI { get; set; }
        public string MA_THE_BHYT { get; set; }
        public string GT_THE_DEN { get; set; }
        public DateTime NGAY_VAO { get; set; }
        public DateTime? NGAY_VAO_NOI_TRU { get; set; }
        public DateTime NGAY_RA { get; set; }
        [Required]
        public DateTime NGAY_HEN_KL { get; set; }
        public string CHAN_DOAN_RV { get; set; }
        [MaxLength(7)]
        public string MA_BENH_CHINH { get; set; }
        [MaxLength(100)]
        public string MA_BENH_KT { get; set; }
        [MaxLength(255)]
        public string MA_BENH_YHCT { get; set; }
        [MaxLength(4)]
        public string MA_DOITUONG_KCB { get; set; }
        [MaxLength(255)]
        [Required]
        public string MA_BAC_SI {  get; set; }
        [MaxLength(10)]
        [Required]
        public string MA_TTDV { get; set; }
        [Required]
        public DateTime NGAY_CT {  get; set; }
        public string DU_PHONG { get; set; }
        public DateTime? NgayRa { set; get; }


        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string ThongTinKhamChuaBenhID { get; set; }
        public ThongTinKhamChuaBenh130 ThongTinKhamChuaBenh130 { get; set; }
    }
}
