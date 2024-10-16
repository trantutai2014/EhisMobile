using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class LoaiKCB130Helper
    {
        public static readonly string[] LoaiKCB130Array = new string[] { "Khám bệnh", "Điều trị ngoại trú", "Điều trị nội trú", "Điều trị nội trú ban ngày","Điều trị ngoại trú các bệnh mạn tính có KB&LT",
     "Điều trị lưu tại TYT xã, PKĐKKV","Nhận thuốc theo hẹn (không khám bệnh)","Điều trị ngoại trú các bệnh mạn tính có THDV&SDT","Điều trị nội trú dưới 04 (bốn) giờ","Các trường hợp khác"};
        public static string getLoaiKCBByNumber(int num)
        {
            if (num > 0 && num < LoaiKCB130Array.Count())
                return LoaiKCB130Array[num - 1];
            return "";
        }
    }
}