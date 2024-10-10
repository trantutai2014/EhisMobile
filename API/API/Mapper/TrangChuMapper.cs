using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Model;
using Data.Models.SKDT;

namespace API.Mapper
{
    public class TrangChuMapper
    {
        public static SKDT_HoSoModel TrangChuMap(SKDT_HoSo hoSo)
        {
            return new SKDT_HoSoModel
            {
                CCCD = hoSo.CCCD,
                HoTen = hoSo.HoTen,

            };
        }
    }
}