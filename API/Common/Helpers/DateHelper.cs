
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Helpers
{
    public static class DateHelper
    {
        /// <summary>
        /// Lấy ngày giữa 2 ngày
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static List<DateTime> GetAllDatesBetweenDates(DateTime startDate, DateTime endDate, bool hasWeekend = false)
        {
            var result = Enumerable.Range(0, 1 + endDate.Subtract(startDate).Days)
                          .Select(offset => startDate.AddDays(offset))
                          .Where(s => hasWeekend ? true : s.DayOfWeek != DayOfWeek.Saturday && s.DayOfWeek != DayOfWeek.Sunday)
                          .ToList();
            return result;
        }


        public static DateTime ChuyenChuoiThanhNgay(string chuoi)
        {
            if (chuoi.Length == 4)
                return new DateTime(int.Parse(chuoi), 1, 1).Date;
            else if (chuoi.Length == 6)
                return new DateTime(int.Parse(chuoi.Substring(0, 4)), int.Parse(chuoi.Substring(4, 2)), 1).Date;
            else if (chuoi.Length == 8)
                return new DateTime(int.Parse(chuoi.Substring(0, 4)), int.Parse(chuoi.Substring(4, 2)), int.Parse(chuoi.Substring(6, 2))).Date;
            else if (chuoi.Length == 12)
                return new DateTime(int.Parse(chuoi.Substring(0, 4)), int.Parse(chuoi.Substring(4, 2)), int.Parse(chuoi.Substring(6, 2)),
                    int.Parse(chuoi.Substring(8, 2)), int.Parse(chuoi.Substring(10, 2)), 0);
            else
                throw new Exception("Chưa có định dạng ngày giờ chuyển đổi");

        }
        public static DateTime? ChuyenChuoiThanhNgay_null(string chuoi)
        {
            try
            {
                if (String.IsNullOrEmpty(chuoi))
                    return null;
                if (chuoi.Length == 4)
                    return new DateTime(int.Parse(chuoi), 1, 1).Date;
                else if (chuoi.Length == 6)
                    return new DateTime(int.Parse(chuoi.Substring(0, 4)), int.Parse(chuoi.Substring(4, 2)), 1).Date;
                else if (chuoi.Length == 8)
                    return new DateTime(int.Parse(chuoi.Substring(0, 4)), int.Parse(chuoi.Substring(4, 2)), int.Parse(chuoi.Substring(6, 2))).Date;
                else if (chuoi.Length == 12)
                    return new DateTime(int.Parse(chuoi.Substring(0, 4)), int.Parse(chuoi.Substring(4, 2)), int.Parse(chuoi.Substring(6, 2)),
                        int.Parse(chuoi.Substring(8, 2)), int.Parse(chuoi.Substring(10, 2)), 0);
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public static DateTime lastTimeDate(DateTime date)
        {
            return date.Date.AddDays(1).AddTicks(-1);
        }

        public static CheckPartion GetPartion(DateTime ngayRa)
        {
            CheckPartion result=new CheckPartion();
            result.StartDate = new DateTime(ngayRa.Year, 1, 1);
            result.EndDate = new DateTime(ngayRa.Year, 12, 31);
            if (ngayRa < new DateTime(2024, 6, 21))
                result.BeforePartion = true;
            else
                result.StartDate = new DateTime(2024, 6, 21);
            return result;
        }
    }
}
