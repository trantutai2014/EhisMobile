using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Helpers;
using Common.Model;
using Data.EF;
using Data.Models;
using MDP.Common.Enums;
using MDP.Common.Models;
using MDP.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LichSuKhamBenhController : BaseController
    {
        private readonly MDPDbContext _context;

        private readonly IRepository _repository;


        public LichSuKhamBenhController(MDPDbContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        //
        [HttpGet("{cccd}")]
        public async Task<TienSuBenhResModel> GetTienSuBenh(string cccd)
        {

            var data = _repository.GetAll<ThongTinKhamChuaBenh130>(s => cccd.Length == 12 ? s.SO_CCCD == cccd : s.BHXHID == cccd)
                        .AsNoTracking()
                        .Select(s => new SKDT_ThongTinKhamChuaBenh()
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
                            TenBV = s.LichSuTuongTac130s.DMCoSo.TenBV,
                            NgayGio = s.LichSuTuongTac130s.NgayGio,
                            LoaiHoSo = LoaiHSSKDTEnum.HS130
                        })
                        .ToArray()
                        .GroupBy(s => s.MA_LK)
                        .Select(g => g
                            .OrderByDescending(s => s.NgayGio)
                            .FirstOrDefault())
                        .ToArray();

            var data4210 = _repository.GetAll<ThongTinKhamChuaBenh>(s => cccd.Length == 12 ? s.SO_CCCD == cccd : s.BHXHID == cccd)
                        .AsNoTracking()
                        .Select(s => new SKDT_ThongTinKhamChuaBenh()
                        {
                            Id = s.Id,
                            MA_LK = s.MA_LK,
                            MA_THE_BHYT = s.MA_THE,
                            GT_THE_TU = s.GT_THE_TU,
                            GT_THE_DEN = s.GT_THE_DEN,
                            MA_DKBD = s.MA_DKBD,
                            MA_BENH_CHINH = s.MA_BENH,
                            CHAN_DOAN_RV = s.TEN_BENH,
                            NGAY_RA = s.NGAY_RA,
                            NGAY_VAO = s.NGAY_VAO,
                            TenBV = s.LichSuTuongTac.DMCoSo.TenBV,
                            NgayGio = s.LichSuTuongTac.NgayGio,
                            LoaiHoSo = LoaiHSSKDTEnum.HS4210
                        })
                        .ToArray()
                        .GroupBy(s => s.MA_LK)
                        .Select(g => g
                            .OrderByDescending(s => s.NgayGio)
                            .FirstOrDefault())
                        .ToArray();


            data = data.Concat(data4210).ToArray();
            var theBHYT = data.Where(s => s.MA_THE_BHYT != null)
                .Select(s => new TienSuBenhTheBHYTResModel()
                {
                    MaThe = s.MA_THE_BHYT,
                    TuNgay = DateHelper.ChuyenChuoiThanhNgay(s.GT_THE_TU),
                    DenNgay = DateHelper.ChuyenChuoiThanhNgay(s.GT_THE_DEN),
                    MaDKBD = s.MA_DKBD
                }).GroupBy(x => new { x.MaThe, x.TuNgay, x.DenNgay, x.MaDKBD })
                .Select(g => g.First())
                .OrderByDescending(x => x.DenNgay).ToArray();
            var tienSuBenh = data
                .GroupBy(s => s.MA_LK)
                        .Select(g => g
                            .OrderByDescending(s => s.NgayGio)
                            .FirstOrDefault())//loại bỏ các bản ghi trùng lặp giửa 130 và 4210
            .Select(s => new TienSuBenhChiTietResModel()
            {
                Id = KeyHelper.Encrypt(s.Id),
                LoaiHoSo = s.LoaiHoSo,
                MAICD10 = s.MA_BENH_CHINH,
                ChanDoan = s.CHAN_DOAN_RV,
                NgayVao = s.NGAY_VAO,
                NgayRa = s.NGAY_RA,
                NoiKham = s.TenBV
            }).OrderByDescending(s => s.NgayRa).ToArray();
            var result = new TienSuBenhResModel()
            {
                TheBHYT = theBHYT,
                TienSu = tienSuBenh
            };
            return await Task.FromResult(result);
        }
    }
}
