using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class LoaiKCBHelper
    {
        public static readonly string[] LoaiKCBArray = new string[] { "Khám bệnh", "Điều trị ngoại trú", "Điều trị nội trú", "Điều trị nội trú ban ngày",
     "Điều trị lưu tại TYT xã, PKĐKKV","Nhận thuốc theo hẹn (không khám bệnh)"};
        public static string getLoaiKCBByNumber(int num)
        {
            if (num > 0 && num < LoaiKCBArray.Count())
                return LoaiKCBArray[num - 1];
            return "";
        }
    }
}