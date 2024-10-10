using Common.Model;
using Data.Models.SKDT;

namespace API.Mapper
{
  public class MapQR
  {
    public static SKDT_HoSoModel MapLoginQR(SKDT_HoSo hoSo)
    {
      return new SKDT_HoSoModel {
        CCCD = hoSo.CCCD,
        HoTen = hoSo.HoTen,
        GioiTinh = hoSo.GioiTinh,
        NgaySinh = hoSo.NgaySinh.ToString("dd/MM/yyyy"),
        DiaChi = hoSo.DiaChi,
        SDT = hoSo.SDT ?? null,
        NgayCap = hoSo.NgayCap?.ToString("dd/MM/yyyy"),
        TenDanToc = hoSo.SKDT_DMDanToc?.Ten ?? "N/A",
        TenNgheNghiep = hoSo.SKDT_DMNgheNghiep?.Ten ?? "N/A",
        TenQuocTich = hoSo.SKDT_DMQuocTich?.Ten ?? "N/A"
      };
    }

  }
}
