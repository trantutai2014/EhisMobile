using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.EF;
using Data.Models;

namespace Service
{
    public class HoSoService
    {
        private readonly IRepository _repository;

        public HoSoService(IRepository repository)
        {

            _repository = repository;
        }

        public string GetTenBV(string maCSKCB)
        {
            if (string.IsNullOrEmpty(maCSKCB))
                return null;
            var data = _repository.Get<DMCoSo>(maCSKCB);
            return data?.TenBV;
        }

        public string GetTenICD10(string maICD10)
        {
            if (string.IsNullOrEmpty(maICD10))
                return null;
            var data = _repository.Get<DMICD10>(s => s.Ma == maICD10);
            return data?.Ten;
        }
    }
}