using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Helpers;
using Data.EF;
using Data.Models;
using Data.Models.SKDT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThongTinHanhChinhController : BaseController
    {
        private readonly MDPDbContext _context;

        private readonly IRepository _repository;

        public ThongTinHanhChinhController(MDPDbContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;
        }

    //    //
    //    [HttpGet("{cccd}")]
    //    public async Task<HanhChinhResModel> GetThongTinHanhChinhByCccd(string cccd)
    //    {
    //        var hoSo = _repository.GetDbContext().Set<SKDT_HoSo>()
    //            .AsNoTracking()
    //            .Where(x => x.CCCD == cccd)
    //            .Select(s =>
    //            new HanhChinhResModel()
    //            {
    //                Key = KeyHelper.Encrypt(s.CCCD),
    //                CCCD = s.CCCD,
    //                NgayCap = s.NgayCap,
    //                NoiCap = s.NoiCap,
    //                HoTen = s.HoTen,
    //                NgaySinh = s.NgaySinh,
    //                GioiTinh = s.GioiTinh,
    //                DanToc = s.SKDT_DMDanToc == null ? "" : s.SKDT_DMDanToc.Ten,
    //                QuocTich = s.SKDT_DMQuocTich.Ten,
    //                NgheNghiep = s.SKDT_DMNgheNghiep.Ten == null ? "" : s.SKDT_DMNgheNghiep.Ten,
    //                DiaChi = s.DiaChi,
    //                SDT = s.SDT,
    //                Image = s.Image != null ? Convert.ToBase64String(s.Image) : null,
    //                NgayTao = s.NgayTao,
    //                NoiTao = s.NoiTao
    //            }).FirstOrDefault();
    //        if (hoSo != null)
    //            hoSo.NoiTao = GetTenBV(hoSo.NoiTao);
    //        return await Task.FromResult(hoSo);
    //    }

    //
    //public string GetTenBV(string maCSKCB)
    //{
    //  if (string.IsNullOrEmpty(maCSKCB))
    //    return null;
    //  var data = _repository.Get<DMCoSo>(maCSKCB);
    //  return data?.TenBV;
    //}

  }
}
