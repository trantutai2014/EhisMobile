using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.SKDT
{
  [Table("SKDT_DMNgheNghiep")]
  public class SKDT_DMNgheNghiep
  {
    public SKDT_DMNgheNghiep()
    {
      SKDT_HoSos = new HashSet<SKDT_HoSo>();
    }
    [Key, Required, MaxLength(5)]
    public string Ma { set; get; }
    [Required, MaxLength(500)]
    public string Ten { set; get; }
    public ICollection<SKDT_HoSo> SKDT_HoSos { get; set; }
  }
}
