using Common.Constants;
using Data.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("ThongBao")]
    public class ThongBao : BaseEntity
    {
        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string UserId { get; set; }
        public bool IsView { get; set; } = false;
        public bool Hide { get; set; } = false;
        [Required]
        public string Title { get; set; } = null!;
        public string Description { get; set; }
        [Required]
        public string Content { get; set; } = null!;
        public int? type { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
