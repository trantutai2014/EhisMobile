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
    [Table("SKDT_DMQuanHuyen")]
    public class SKDT_DMQuanHuyen
    {
        public SKDT_DMQuanHuyen()
        {
            SKDT_DMPhuongXas = new HashSet<SKDT_DMPhuongXa>();
        }
        [Key, Required, MaxLength(3)]
        public string Ma { get; set; }
        [Required, MaxLength(255)]
        public string Ten { get; set; }
        [Required, MaxLength(2)]
        [ForeignKey("MaTinh")]
        public string MaTinh { get; set; }
        public virtual SKDT_DMTinhThanh SKDT_DMTinhThanh { get; set; }
        public ICollection<SKDT_DMPhuongXa> SKDT_DMPhuongXas { get; set; }
    }
}
