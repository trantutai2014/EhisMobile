using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
  public class CheckPartion
  {
    /// <summary>
    /// Ngày ra trước thời gian partion của database
    /// </summary>
    public bool BeforePartion { get; set; } = false;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
  }
}
