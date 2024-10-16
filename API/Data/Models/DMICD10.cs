using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Data.Abstract;

namespace Data.Models
{
    [Table("DMICD10")]
    public class DMICD10 : BaseEntity
    {
        [Required, MaxLength(200)]
        public string Ma { set; get; }
        [Required, MaxLength(500)]
        public string Ten { set; get; }
    }
}