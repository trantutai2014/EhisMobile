using Common.Constants;
using Data.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("UserLogins")]
    public class UserLogin : BaseEntity
    {
        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string ProviderKey { get; set; }

        [Required]
        public DateTime LoginTime { get; set; }

        [Required]
        public DateTime ExpiresTime { get; set; }

        [MaxLength(500)]
        public string RefreshToken { get; set; }

        public User User { get; set; }
    }
}