using MDP.Common.Enums;
namespace Common.Model
{
    public class TienSuBenhResModel
    {
        public TienSuBenhTheBHYTResModel[]? TheBHYT { set; get; }
        public TienSuBenhChiTietResModel[]? TienSu { set; get; }

    }
    public class TienSuBenhTheBHYTResModel
    {
        public string MaThe { set; get; }
        public string MaDKBD { set; get; }
        public DateTime TuNgay { set; get; }
        public DateTime DenNgay { set; get; }
    }

    public class TienSuBenhChiTietResModel
    {
        public string Id { set; get; }
        public DateTime NgayVao { set; get; }
        public DateTime NgayRa { set; get; }
        public string NoiKham { set; get; }
        public string ChanDoan { set; get; }
        public string MAICD10 { set; get; }
        public LoaiHSSKDTEnum LoaiHoSo { get; set; }
    }
}