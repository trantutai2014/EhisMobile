using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Data.Abstract;

namespace Data.Models.SKDT
{
  [Table("SoTheBHYT")]
  public class SoTheBHYT : BaseEntity
  {
    public SoTheBHYT()
    {
      Id = Guid.NewGuid().ToString();
    }

    [Required, MaxLength(20)]
    public string SoThe { set; get; }
    [Required, MaxLength(12)]
    public string CCCD { set; get; }
  }
}
