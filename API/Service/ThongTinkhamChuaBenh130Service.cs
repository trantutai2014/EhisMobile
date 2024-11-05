using Common.Enums;
using Common.Model;
using Common.Models;
using Data.EF;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
  public interface IThongTinkhamChuaBenh130Service
  {
    Task<IEnumerable<ThongTinKhamChuaBenh130>> GetAllByCCCD(string cccd);
    Task<IEnumerable<SKDT_ThongTinKhamChuaBenh>> GetTienSuByCCCD(string cccd);
  }
  public class ThongTinkhamChuaBenh130Service : IThongTinkhamChuaBenh130Service
  {
    private readonly IRepository _repository;

    public ThongTinkhamChuaBenh130Service(IRepository repository)
    {
      _repository = repository;
    }

    public async Task<IEnumerable<ThongTinKhamChuaBenh130>> GetAllByCCCD(string cccd)
    {
      return await Task.FromResult(_repository.GetAll<ThongTinKhamChuaBenh130>(x => x.SO_CCCD == cccd));
    }

    public async Task<IEnumerable<SKDT_ThongTinKhamChuaBenh>> GetTienSuByCCCD(string cccd)
    {
      var data = await GetAllByCCCD(cccd);
      return data?.Select(s => new SKDT_ThongTinKhamChuaBenh()
      {
        Id = s.Id,
        MA_LK = s.MA_LK,
        MA_THE_BHYT = s.MA_THE_BHYT,
        GT_THE_TU = s.GT_THE_TU,
        GT_THE_DEN = s.GT_THE_DEN,
        MA_DKBD = s.MA_DKBD,
        MA_BENH_CHINH = s.MA_BENH_CHINH,
        CHAN_DOAN_RV = s.CHAN_DOAN_RV,
        NGAY_RA = s.NGAY_RA,
        NGAY_VAO = s.NGAY_VAO,
        TenBV = s.LichSuTuongTac130s != null ? s.LichSuTuongTac130s.DMCoSo.TenBV : string.Empty,
        NgayGio = s.LichSuTuongTac130s != null ? s.LichSuTuongTac130s.NgayGio : DateTime.MinValue,
        LoaiHoSo = LoaiHSSKDTEnum.HS130
      })
      .GroupBy(s => s.MA_LK)
      .Select(g => g.OrderByDescending(s => s.NgayGio).FirstOrDefault());
    }
  }

}
