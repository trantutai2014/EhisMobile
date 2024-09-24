
using Common.Constants;
using Data.Abstract;
using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDP.Data.Models
{
    [Table("Users")]
    public class User : BaseEntity, IDateTracking, IPersonTracking, IHasSoftDelete, ISwitchable
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            UserRoles = new HashSet<UserRole>();
            UserExternalApis = new HashSet<UserExternalApi>();
        }

    [Required, MaxLength(50)]
    public string Username { get; set; } = null!;

        [Required, MaxLength(128)]
        public string Password { get; set; } = null!;

    [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        [MaxLength(250)]
        public string? Email { get; set; }

        [MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string? MaBV { get; set; }

        public DateTime? LockOutDate { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }

        [MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string CreatorUserId { get; set; }

        [MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string LastModifierUserId { get; set; }

        [MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string DeleterUserId { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsLocked { get; set; }

        public DMCoSo DMCoSo { get; set; }
        public UserLogin UserLogin { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserExternalApi> UserExternalApis { get; set; }
    }
}
