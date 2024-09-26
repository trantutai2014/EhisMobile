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
    [Table("SKDT_DMPhuongXa")]
    public class SKDT_DMPhuongXa
    {
        public SKDT_DMPhuongXa()
        {
            SKDT_HoSos = new HashSet<SKDT_HoSo>();
        }
        [Key, Required, MaxLength(5)]
        public string Ma { get; set; }
        [Required, MaxLength(255)]
        public string Ten { get; set; }
        [Required, MaxLength(3)]
        [ForeignKey("MaHuyen")]
        public string MaHuyen { get; set; }
        public virtual SKDT_DMQuanHuyen SKDT_DMQuanHuyen { get; set; }
        public ICollection<SKDT_HoSo> SKDT_HoSos { get; set; }

    }
}
