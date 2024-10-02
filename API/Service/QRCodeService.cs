using Common.Helpers;
using Common.Model;
using Data.EF;
using Data.Models;
using Data.Models.SKDT;
using Microsoft.EntityFrameworkCore;

namespace Service
{
  public interface IQRCodeService
  {
    //Task<SKDT_HoSoModel> GetByCCCD(string CCCD);
    Task<SKDT_HoSo> GetByCode(string code);

  }

  public class QRCodeService : IQRCodeService
  {
    private readonly IRepository _repository;
    

    public QRCodeService(IRepository repository)
    {
      _repository = repository;
    }

    //public async Task<SKDT_HoSoModel> GetByCCCD(string CCCD)
    //{
    //  var decryptCCCD = KeyHelper.Decrypt(CCCD);
    //  var entity = await _repository.GetByCCCD(decryptCCCD);
    //  var SKDT_HoSoModel = new SKDT_HoSoModel
    //  {
    //    CCCD = entity.CCCD,
    //    HoTen = entity.HoTen,
    //    GioiTinh = entity.GioiTinh,
    //    NgaySinh = entity.NgaySinh.ToString("dd/MM/yyyy"),
    //    DiaChi = entity.DiaChi,
    //    SDT = entity.SDT??null,
    //    NgayCap = entity.NgayCap?.ToString("dd/MM/yyyy"), 
    //    TenDanToc = entity.SKDT_DMDanToc?.Ten ?? "N/A",
    //    TenNgheNghiep = entity.SKDT_DMNgheNghiep?.Ten ?? "N/A",
    //    TenQuocTich = entity.SKDT_DMQuocTich?.Ten ?? "N/A"
    //  };

    //  return SKDT_HoSoModel;
    //}

    public async Task<SKDT_HoSo> GetByCode(string code)
    {
      var decryptCCCD = KeyHelper.Decrypt(code);
      return await GetByCCC(decryptCCCD);
    }

    public async Task<SKDT_HoSo> GetByCCC(string CCCD)
    {
      return await _repository.GetByCCCD(CCCD);
    }
  }
}
