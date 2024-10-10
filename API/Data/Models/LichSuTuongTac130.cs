
using MDP.Common.Enums;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Abstract;
using Data.Models;
using Common.Constants;

namespace MDP.Data.Models
{
    [Table("LichSuTuongTac130")]
    public class LichSuTuongTac130 : BaseEntity
    {
        public LichSuTuongTac130()
        {
            ThongTinKhamChuaBenh130s = new HashSet<ThongTinKhamChuaBenh130>();
            Id = Guid.NewGuid().ToString();
        }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int LichSuTuongTacID { get; set; }

        public DateTime NgayGio { get; set; }
        public DateTime NgayLap { get; set; }
        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string MaBV { set; get; }
        public TrangThaiHSEnum TrangThai { set; get; }
        public int SoLuongHoSo { set; get; }
        public string Loi { set; get; }
        public string Username { set; get; }


        public ICollection<ThongTinKhamChuaBenh130> ThongTinKhamChuaBenh130s { get; set; }

        public DMCoSo DMCoSo { get; set; }
    }
}
