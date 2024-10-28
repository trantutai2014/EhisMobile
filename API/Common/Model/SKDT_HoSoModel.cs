using System.ComponentModel.DataAnnotations;

namespace Common.Model
{
  public class SKDT_HoSoModel
  {
    [Key]
    public string CCCD { get; set; }
    public string NgayCap { get; set; }

    public string NoiCap { get; set; }

    public string SDT { get; set; }

    public string HoTen { get; set; }

    public string NgaySinh { get; set; }

    public int GioiTinh { get; set; }
    public string? NoiTao { set; get; }
    public string TenDanToc { get; set; }
    public string TenNgheNghiep { get; set; }
    public string TenQuocTich { get; set; }

    public string DiaChi { get; set; }

    public string NgayTao { get; set; }
    public string ThongTinKhamChuaBenhID { get; set; }

  }
}
