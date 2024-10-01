using MDP.Data.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDP.Common.Constants;

namespace MDP.Data.Models.SKDT
{
    [Table("SKDT_DMNgheNghiep")]
    public class SKDT_DMNgheNghiep
    {
        public SKDT_DMNgheNghiep()
        {
            SKDT_HoSos = new HashSet<SKDT_HoSo>();
        }
        [Key,Required, MaxLength(5)]
        public string Ma { set; get; }
        [Required, MaxLength(500)]
        public string Ten { set; get; }
        public ICollection<SKDT_HoSo> SKDT_HoSos { get; set; }
    }
}
