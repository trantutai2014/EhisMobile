using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Data.Abstract;
using Data.Interfaces;

namespace Data.Models.SKDT
{
  [Table("SKDT_DMDanToc")]
  public class SKDT_DMDanToc 
  {
    public SKDT_DMDanToc()
    {
      SKDT_HoSos = new HashSet<SKDT_HoSo>();
    }
    [Key, Required, MaxLength(2)]
    public string Ma { set; get; }
    [Required, MaxLength(250)]
    public string Ten { set; get; }
    [MaxLength(500)]
    public string TenKhac { set; get; }
    [MaxLength(500)]
    public string DiaBanChinh { set; get; }
    public ICollection<SKDT_HoSo> SKDT_HoSos { get; set; }
  }
}
