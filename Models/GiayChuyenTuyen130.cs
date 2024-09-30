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
    [Table("DS_GiayChuyenTuyen130")]
    public class DS_GiayChuyenTuyen130 : BaseEntity
    {
        public DS_GiayChuyenTuyen130()
        {
            Id = Guid.NewGuid().ToString();
        }
        [MaxLength(100)]
        [Required]
        public string MA_LK { get; set; }
        [MaxLength(50)]
        [Required]
        public string SO_HOSO { get; set; }
        [MaxLength(50)]
        [Required]
        public string SO_CHUYENTUYEN { get; set; }
        [MaxLength(50)]
        [Required]
        public string GIAY_CHUYEN_TUYEN { get; set; }
        [MaxLength(5)]
        public string MA_CSKCB { get; set; }
        [MaxLength(5)]
        public string MA_NOI_DI { get; set; }
        [MaxLength(5)]
        public string MA_NOI_DEN { get; set; }
        [MaxLength(255)]
        public string HO_TEN { get; set; }
        public DateTime NGAY_SINH { get; set; }
        public int GIOI_TINH { get; set; }
        [MaxLength(3)]
        public string MA_QUOCTICH { get; set; }
        [MaxLength(2)]
        public string MA_DANTOC { get; set; }
        [MaxLength(5)]
        public string MA_NGHE_NGHIEP { get; set; }
        [MaxLength(1024)]
        public string DIA_CHI { get; set; }
        public string MA_THE_BHYT { get; set; }
        public string GT_THE_DEN { get; set; }
        [Required]
        public DateTime NGAY_VAO { get; set; }
        public DateTime? NGAY_VAO_NOI_TRU { get; set; }
        public DateTime NGAY_RA {  get; set; }
        [Required]
        public string DAU_HIEU_LS { get; set; }
        [Required]
        public string CHAN_DOAN_RV { get; set; }
        [Required]
        public string QT_BENHLY { get; set; }
        [Required]
        public string TOMTAT_KQ { get; set; }
        public string PP_DIEUTRI { get; set; }
        [MaxLength(7)]
        public string MA_BENH_CHINH { get; set; }
        [MaxLength(100)]
        public string MA_BENH_KT { get; set; }
        [MaxLength(255)]
        public string MA_BENH_YHCT { get; set; }
        [MaxLength(1024)]
        [Required]
        public string TEN_DICH_VU { get; set; }
        [MaxLength(1024)]
        public string TEN_THUOC { get; set; }
        public string PP_DIEU_TRI { get; set; }
        [MaxLength(1)]
        public int MA_LOAI_RV { get; set; }
        [MaxLength(1)]
        public string MA_LYDO_CT { get; set; }
        public string HUONG_DIEU_TRI { get; set; }
        [MaxLength(255)]
        public string PHUONGTIEN_VC { get; set; }
        [MaxLength(255)]
        public string HOTEN_NGUOI_HT { get; set; }
        [MaxLength(255)]
        public string CHUC_DANH_NGUOI_HT { get; set; }
        [MaxLength(255)]
        public string MA_BAC_SI {  get; set; }
        [MaxLength(10)]
        public string MA_TTDV {  get; set; }
        public string DU_PHONG { get; set; }
        public DateTime? NgayRa { set; get; }


        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string ThongTinKhamChuaBenhID { get; set; }
        public ThongTinKhamChuaBenh130 ThongTinKhamChuaBenh130 { get; set; }
    }
}
