using Common.Model;
using Data.EF;
using Data.Models;
using Data.Models.SKDT;
using Service;

namespace API.Mapper
{
  public class MapQR
  {
    private readonly HoSoService _hoSoService;

    public MapQR(HoSoService hoSoService)
    {

      _hoSoService = hoSoService;
    }
    public static SKDT_HoSoModel MapLoginQR(SKDT_HoSo hoSo, HoSoService hoSoService)
    {
      string maCSKCB = hoSo.NoiTao; // lấy giá trị của NoiTao
      string tenBV = maCSKCB != null ? hoSoService.GetTenBV(maCSKCB) : "Chưa cập nhật";

      return new SKDT_HoSoModel
      {
        CCCD = hoSo.CCCD,
        HoTen = hoSo.HoTen,
        GioiTinh = hoSo.GioiTinh,
        NgaySinh = hoSo.NgaySinh.ToString("dd/MM/yyyy"),
        DiaChi = hoSo.DiaChi ?? "Chưa cập nhật",
        SDT = hoSo.SDTHienThi,
        NgayCap = hoSo.NgayCap?.ToString("dd/MM/yyyy") ?? "Chưa cập nhật",
        TenDanToc = hoSo.SKDT_DMDanToc?.Ten ?? "Chưa cập nhật",
        TenNgheNghiep = hoSo.SKDT_DMNgheNghiep?.Ten ?? "Chưa cập nhật",
        TenQuocTich = hoSo.SKDT_DMQuocTich?.Ten ?? "Chưa cập nhật",
        NoiTao = tenBV,
        NgayTao = hoSo.NgayTao.ToString("dd/MM/yyyy") ?? "Chưa cập nhật",
        NoiCap = hoSo.NoiCap ?? "Chưa cập nhật"

      };
    }



  }
}
