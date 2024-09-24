using Common.Constants;
using Data.Abstract;
using Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDP.Data.Models
{
    [Table("UserExternalApis")]
    public class UserExternalApi : BaseEntity, ISwitchable
    {
        public UserExternalApi()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Required, MaxLength(250)]
        public string ApiKey { get; set; }

        [Required, MaxLength(250)]
        public string Domain { get; set; }

        [Required, MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string UserId { get; set; }

        public bool IsLocked { get; set; }

        public virtual User User { get; set; }
    }
}
