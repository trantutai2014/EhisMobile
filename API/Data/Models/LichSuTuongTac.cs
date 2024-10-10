using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MDP.Common.Enums;

using Data.Abstract;
using Common.Constants;
using Data.Models;

namespace MDP.Data.Models
{
    [Table("LichSuTuongTac")]
    public class LichSuTuongTac : BaseEntity
    {
        public LichSuTuongTac()
        {
            ThongTinKhamChuaBenhs = new HashSet<ThongTinKhamChuaBenh>();
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


        public ICollection<ThongTinKhamChuaBenh> ThongTinKhamChuaBenhs { get; set; }

        public DMCoSo DMCoSo { get; set; }
    }
}
