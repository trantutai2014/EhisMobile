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
    [Table("DS_GiamDinhYKhoa130")]
    public class DS_GiamDinhYKhoa130 : BaseEntity
    {
        public DS_GiamDinhYKhoa130()
        {
            Id = Guid.NewGuid().ToString();
        }
        [MaxLength(255)]
        [Required]
        public string NGUOI_CHU_TRI { get; set; }
        [Required]
        public int CHUC_VU { get; set; }
        [Required]
        public DateTime NGAY_HOP { get; set; }
        [MaxLength(255)]
        [Required]
        public string HO_TEN { get; set; }
        [Required]
        public DateTime NGAY_SINH { get; set; }
        [MaxLength(15)]
        [Required]
        public string SO_CCCD { get; set; }
        [Required]
        public DateTime NGAY_CAP_CCCD { get; set; }
        [MaxLength(1024)]
        [Required]
        public string NOI_CAP_CCCD { get; set; }
        [MaxLength(1024)]
        [Required]
        public string DIA_CHI { get; set; }
        [MaxLength(3)]
        [Required]
        public string MATINH_CU_TRU { get; set; }
        [MaxLength(3)]
        [Required]
        public string MAHUYEN_CU_TRU { get; set; }
        [MaxLength(5)]
        [Required]
        public string MAXA_CU_TRU { get; set; }
        [MaxLength(10)]
        [Required]
        public string MA_BHXH { get; set; }
        [MaxLength(15)]
        public string MA_THE_BHYT { get; set; }
        [MaxLength(100)]
        public string NGHE_NGHIEP { get; set; }
        [MaxLength(15)]
        [Required]
        public string DIEN_THOAI { get; set; }
        [MaxLength(20)]
        [Required]
        public string MA_DOI_TUONG { get; set; }
        [Required]
        public int KHAM_GIAM_DINH { get; set; }
        [MaxLength(200)]
        [Required]
        public string SO_BIEN_BAN { get; set; }
        [MaxLength(3)]
        public string TYLE_TTCT_CU { get; set; }
        [MaxLength(10)]
        [Required]
        public string DANG_HUONG_CHE_DO { get; set; }
        [Required]
        public DateTime NGAY_CHUNG_TU { get; set; }
        [MaxLength(200)]
        [Required]
        public string SO_GIAY_GIOI_THIEU { get; set; }
        [Required]
        public DateTime NGAY_DE_NGHI { get; set; }
        [MaxLength(200)]
        [Required]
        public string MA_DONVI { get; set; }
        [MaxLength(1024)]
        [Required]
        public string GIOI_THIEU_CUA { get; set; }
        [Required]
        public string KET_QUA_KHAM { get; set; }
        [MaxLength(200)]
        [Required]
        public string SO_VAN_BAN_CAN_CU { get; set; }
        [Required]
        public int TYLE_TTCT_MOI { get; set; }
        [Required]
        public int TONG_TYLE_TTCT { get; set; }
        [MaxLength(1)]
        public string DANG_KHUYETTAT { get; set; }
        [MaxLength(1)]
        public string MUC_DO_KHUYETTAT { get; set; }
        [Required]
        public string DE_NGHI { get; set; }
        [Required]
        public string DUOC_XACDINH { get; set; }
        public string DU_PHONG { get; set; }
        public DateTime? NgayRa { set; get; }

        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string ThongTinKhamChuaBenhID { get; set; }
        public ThongTinKhamChuaBenh130 ThongTinKhamChuaBenh130 { get; set; }
    }
}
