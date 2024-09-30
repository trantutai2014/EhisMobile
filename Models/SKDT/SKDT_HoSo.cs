using MDP.Common.Constants;
using MDP.Data.Abstract;
using MDP.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.Data.Models.SKDT
{
    [Table("SKDT_HoSo")]
    public class SKDT_HoSo 
    {
        public SKDT_HoSo()
        {
          
        }

        [Key, Required, MaxLength(20)]
        public string CCCD { set; get; }
        public DateTime? NgayCap { set; get; }
        public string NoiCap { set; get; }
        [MaxLength(15)]
        public string SDT { set; get; }
        [MaxLength(255)]
        [Required]
        public string HoTen { set; get; }
        [Required]
        public DateTime NgaySinh { set; get; }
        [Required]
        public int GioiTinh { set; get; }
        [MaxLength(2)]
        //[Required]
        public string MaDanToc { set; get; }
        [MaxLength(5)]
        //[Required]
        public string MaNgheNghiep { set; get; }
        [MaxLength(1024)]
        [Required]
        public string DiaChi { set; get; }
        [MaxLength(3)]
        //[Required]
        public string MaQuocTich { set; get; }
        [MaxLength(5)]
        //[Required]
        public string MaPhuongXa { set; get; }

        [MaxLength(255)]
        public string NguoiDaiDien { set; get; }
        [MaxLength(20)]
        public string CCCDNguoiDaiDien { set; get; }

        [MaxLength(250)]
        public string MoiQuanHe { set; get; }
        [ MaxLength(20)]
        public string SDTNguoiDaiDien { set; get; }
        public byte[]? Image { get; set; }
        [Required]
        public DateTime NgayTao { set; get; }
        //Mã bệnh viện tạo hồ sơ
        [MaxLength(5)]
        public string NoiTao { set; get; }

        [MaxLength(500)]
        public string SoThe { set; get; }

        [ForeignKey("MaDanToc")]
        public virtual SKDT_DMDanToc SKDT_DMDanToc { get; set; }
        [ForeignKey("MaNgheNghiep")]
        public virtual SKDT_DMNgheNghiep SKDT_DMNgheNghiep { get; set; }
        [ForeignKey("MaQuocTich")]
        public virtual SKDT_DMQuocTich SKDT_DMQuocTich { get; set; }
        [ForeignKey("MaPhuongXa")]
        public virtual SKDT_DMPhuongXa SKDT_DMPhuongXa { get; set; }

    }
}
