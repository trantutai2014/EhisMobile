using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class SKDT_ThongTinKhamChuaBenh
    {
        public string Id { get; set; }
        public string MA_LK { get; set; }
        public string MA_THE_BHYT { get; set; }
        public string GT_THE_TU { get; set; }
        public string GT_THE_DEN { get; set; }
        public string MA_DKBD { get; set; }
        public string MA_BENH_CHINH { get; set; }
        public string CHAN_DOAN_RV { get; set; }
        public DateTime NGAY_RA { get; set; }
        public DateTime NGAY_VAO { get; set; }
        public string TenBV { get; set; }
        public DateTime NgayGio { get; set; }
        public LoaiHSSKDTEnum LoaiHoSo { get; set; }

    }
}
