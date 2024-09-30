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
    Task<SKDT_HoSo> GetByCCCD(string CCCD);
  }
  public class QRCodeService : IQRCodeService
  {
    private readonly IRepository _repository;

    public QRCodeService(IRepository repository)
    {
      _repository = repository;
    }

    public async Task<SKDT_HoSo> GetByCCCD(string CCCD)
    {
      var decryptCCCD = KeyHelper.Decrypt(CCCD);
      var entity = await _repository.GetByCCCD(decryptCCCD);
      return entity;
    }
  }
}

