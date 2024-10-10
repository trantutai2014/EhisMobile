using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Common.Model;

namespace API.Mapper
{
    public class ThongTinBhytMapper
    {
        public static ThongTinBhytModel ThongTinBhytMap(ThongTinKhamChuaBenh130 thongTinKhamChuaBenh130)
        {
            return new ThongTinBhytModel
            {
                MA_THE_BHYT = thongTinKhamChuaBenh130.MA_THE_BHYT,
                MA_DKBD = thongTinKhamChuaBenh130.MA_DKBD,
                NGAY_VAO = thongTinKhamChuaBenh130.NGAY_VAO.ToString("dd/MM/yyyy HH:mm"),
                NGAY_RA = thongTinKhamChuaBenh130.NGAY_RA.ToString("dd/MM/yyyy HH:mm")
            };
        }

    }
}