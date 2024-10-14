using Common.Constants;
using Data.Models;
using Data.Abstract;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Models;

namespace Data.Models
{
    [Table("DMCoSo")]
    public class DMCoSo : BaseEntity, ISwitchable
    {
        public DMCoSo()
        {
            Users = new HashSet<User>();
            Childrens = new HashSet<DMCoSo>();
            //LichSuTuongTacs = new HashSet<LichSuTuongTac>();
        }

        public int STT { set; get; }
        [Required,MaxLength(256)]
        public string TenBV { set; get; }
        public string MaHuyen { set; get; }
        public int TuyenBV { set; get; }
        public int HangBV { set; get; }
        [MaxLength(500)]
        public string DiaChi { set; get; }
        [MaxLength(500)]
        public string GhiChu { set; get; }
        [MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string ParentId { get; set; }
        public bool InProvince { set; get; }
        public bool IsLocked { get; set; }
        [MaxLength(5)]
        public string MaPhuongXa { get; set; }
        [MaxLength(3)]
        public string MaQuanHuyen { get; set; }
        public ICollection<DMCoSo> Childrens { get; set; }
        public DMCoSo Parent { get; set; }
        public ICollection<User> Users { get; set; }

        public ICollection<LichSuTuongTac> LichSuTuongTacs { get; set; }
        public ICollection<LichSuTuongTac130> LichSuTuongTac130s { get; set; }

  }
}
