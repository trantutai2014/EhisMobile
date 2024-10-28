using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Model;
using Data.EF;
using Data.Models;
using Data.Models.SKDT;

namespace Service
{
    public class HoSoService
    {
        private readonly IRepository _repository;

        public HoSoService(IRepository repository)
        {

            _repository = repository;
        }

        public string GetTenBV(string thongTinKhamChuaBenhID)
        {
            if (string.IsNullOrEmpty(thongTinKhamChuaBenhID))
                return null;
            var data = _repository.Get<DMCoSo>(thongTinKhamChuaBenhID);
            return data?.TenBV;
        }
        public string GetTenDanToc (string maDanToc)
        {
            if (string.IsNullOrEmpty(maDanToc))
                return null;
            var data = _repository.GetFirt<SKDT_DMDanToc>(m => m.Ma == maDanToc);
            return data?.Ten;
        }
    public string GetNgheNghiep(string maNgheNghiep)
    {
      if (string.IsNullOrEmpty(maNgheNghiep))
        return null;
      var data = _repository.GetFirt<SKDT_DMNgheNghiep>(m => m.Ma == maNgheNghiep);
      return data?.Ten;
    }
    public string GetQuocTich(string maQuocTich)
    {
      if (string.IsNullOrEmpty(maQuocTich))
        return null;
      var data = _repository.GetFirt<SKDT_DMQuocTich>(m => m.Ma == maQuocTich);
      return data?.Ten;
    }

    public string GetTenICD10(string maICD10)
        {
            if (string.IsNullOrEmpty(maICD10))
                return null;
            var data = _repository.Get<DMICD10>(s => s.Ma == maICD10);
            return data?.Ten;
        }
    public string GetThongTinKhamChuaBenhIDByCCCD(string soCCCD)
    {
      if (string.IsNullOrEmpty(soCCCD))
        return null;
      var data = _repository.Get<ThongTinKhamChuaBenh130>(i => i.SO_CCCD == soCCCD);
      return data?.Id;
  }
    public SKDT_HoSoModel GetHoSoByCCCD(string soCCCD)
    {
      if (string.IsNullOrEmpty(soCCCD))
        return null;

      var hoSoData = _repository.GetFirt<SKDT_HoSoModel>(i => i.CCCD == soCCCD);
      return hoSoData;
    }
  }

}
