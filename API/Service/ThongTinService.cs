using Common.Helpers;
using Data.EF;
using Data.Models.SKDT;
namespace Service
{
  public interface IThongTinService
  {

    Task<SKDT_HoSo> GetByCCCD(string cccd);

  }

  public class ThongTinService : IThongTinService
  {
    private readonly IRepository _repository;


    public ThongTinService(IRepository repository)
    {
      _repository = repository;
    }
    public async Task<SKDT_HoSo> GetByCode(string code)
    {
      var decryptedCCCD = KeyHelper.Decrypt(code);
      return await GetByCCCD(decryptedCCCD);
    }

    public async Task<SKDT_HoSo> GetByCCCD(string CCCD)
    {
      return await _repository.GetByCCCD(CCCD);
    }
  }
}
