using MDP.Common.Constants;
using MDP.Data.Abstract;
using MDP.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.Data.Models.SKDT
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
