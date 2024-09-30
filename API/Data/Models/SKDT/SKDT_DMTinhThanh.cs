using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.SKDT
{
  [Table("SKDT_DMTinhThanh")]
  public class SKDT_DMTinhThanh
  {
    public SKDT_DMTinhThanh()
    {
      SKDT_DMQuanHuyens = new HashSet<SKDT_DMQuanHuyen>();
    }
    [Key, Required, MaxLength(2)]
    public string Ma { get; set; }
    [Required, MaxLength(255)]
    public string Ten { get; set; }
    public virtual ICollection<SKDT_DMQuanHuyen> SKDT_DMQuanHuyens { get; set; }
  }
}
