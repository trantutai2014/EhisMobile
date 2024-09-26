using MDP.Data.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.Data.Models.SKDT
{
    [Table("SKDT_DMQuocTich")]
    public class SKDT_DMQuocTich
    {
        public SKDT_DMQuocTich()
        {
            SKDT_HoSos = new HashSet<SKDT_HoSo>();
        }
        [Key, Required, MaxLength(3)]
        public string Ma { set; get; }
        [Required, MaxLength(250)]
        public string Ten { set; get; }
        public ICollection<SKDT_HoSo> SKDT_HoSos { get; set; }
    }
}
