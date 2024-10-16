using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Enums;
using Common.Helpers;
using MDP.Common.Enums;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChiTietTienSuBenhController : ControllerBase
    {

        private readonly SkdtHoSoService4210 _skdtHoSo4210service;
        private readonly SkdtHoSo130Service _skdtHoSoservice;

        public ChiTietTienSuBenhController(SkdtHoSoService4210 skdtHoSo4210service, SkdtHoSo130Service skdtHoSoservice)
        {
            _skdtHoSo4210service = skdtHoSo4210service;
            _skdtHoSoservice = skdtHoSoservice;
        }

        [HttpGet("lich-su-kcb")]
        public async Task<IActionResult> GetLichSuKCB([FromQuery] string id, [FromQuery] LoaiHSSKDTEnum loai, [FromQuery] DateTime p)
        {
            id = KeyHelper.Decrypt(id);
            if (loai == LoaiHSSKDTEnum.HS4210)
            {
                var data = await _skdtHoSo4210service.GetLichSuKCB(id, p);
                return Ok(data);
            }
            else
            {
                var data = await _skdtHoSoservice.GetLichSuKCB(id, p);
                return Ok(data);
            }

        }


        [HttpGet("xet-nghiem")]
        public async Task<IActionResult> GetXetNghiemKCB([FromQuery] string id, [FromQuery] LoaiHSSKDTEnum loai, [FromQuery] DateTime p)
        {
            id = KeyHelper.Decrypt(id);
            if (loai == LoaiHSSKDTEnum.HS4210)
            {
                var data = await _skdtHoSo4210service.GetXetNghiemKCB(id, p);
                return Ok(data);
            }
            else
            {
                var data = await _skdtHoSoservice.GetXetNghiemKCB(id, p);
                return Ok(data);
            }
        }
        [HttpGet("cdha-tdcn")]
        public async Task<IActionResult> GetCDHA_TDCNKCB([FromQuery] string id, [FromQuery] LoaiHSSKDTEnum loai, [FromQuery] DateTime p)
        {
            id = KeyHelper.Decrypt(id);
            if (loai == LoaiHSSKDTEnum.HS4210)
            {
                var data = await _skdtHoSo4210service.GetCDHAKCB(id, p);
                return Ok(data);
            }
            else
            {
                var data = await _skdtHoSoservice.GetCDHAKCB(id, p);
                return Ok(data);
            }
        }
        [HttpGet("pttt")]
        public async Task<IActionResult> GetPTTTKCB([FromQuery] string id, [FromQuery] LoaiHSSKDTEnum loai, [FromQuery] DateTime p)
        {
            id = KeyHelper.Decrypt(id);
            if (loai == LoaiHSSKDTEnum.HS4210)
            {
                var data = await _skdtHoSo4210service.GetPTTTKCB(id, p);
                return Ok(data);
            }
            else
            {
                var data = await _skdtHoSoservice.GetPTTTKCB(id, p);
                return Ok(data);
            }
        }
        [HttpGet("thuoc")]
        public async Task<IActionResult> GetThuocKCB([FromQuery] string id, [FromQuery] LoaiHSSKDTEnum loai, [FromQuery] DateTime p)
        {
            id = KeyHelper.Decrypt(id);
            if (loai == LoaiHSSKDTEnum.HS4210)
            {
                var data = await _skdtHoSo4210service.GetThuocKCB(id, p);
                return Ok(data);
            }
            else
            {
                var data = await _skdtHoSoservice.GetThuocKCB(id, p);
                return Ok(data);
            }
        }
        [HttpGet("tom-tat")]
        public async Task<IActionResult> GetTomTatKCB([FromQuery] string id, [FromQuery] LoaiHSSKDTEnum loai, [FromQuery] DateTime p)
        {
            id = KeyHelper.Decrypt(id);
            if (loai == LoaiHSSKDTEnum.HS4210)
            {
                var data = await _skdtHoSo4210service.GetTomTatKCB(id, p);
                return Ok(data);
            }
            else
            {
                var data = await _skdtHoSoservice.GetTomTatKCB(id, p);
                return Ok(data);
            }
        }
    }
}