using Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace Data.Abstract
{
  public abstract class BaseEntity
  {
    [Key, Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
    public string Id
    {
      get; set;
    }
  }
}
