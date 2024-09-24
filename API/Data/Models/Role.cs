
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
    [Table("Roles")]
    public class Role : BaseEntity, IDateTracking, IPersonTracking, ISwitchable
    {
        public Role()
        {
            Id = Guid.NewGuid().ToString();
            UserRoles = new HashSet<UserRole>();
            RoleNavigationMenus = new HashSet<RoleNavigationMenu>();
        }

        [Required, MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }

    [MaxLength(ValidatorConsts.MaxLengthGuid)]
      public string CreatorUserId { get; set; }

        [MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string LastModifierUserId { get; set; }

        [MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string DeleterUserId { get; set; }

        public bool IsLocked { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<RoleNavigationMenu> RoleNavigationMenus { get; set; }
    }
}
