using Common.Constants;
using Data.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("UserRoles")]
    public class UserRole : BaseEntity
    {
        public UserRole()
        {
            Id = Guid.NewGuid().ToString();
        }

        [MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string UserId { get; set; }

        [MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string RoleId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
    }
}
