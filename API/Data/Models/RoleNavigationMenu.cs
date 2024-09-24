using Common.Constants;
using Data.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDP.Data.Models
{
    [Table("RoleNavigationMenus")]
    public class RoleNavigationMenu : BaseEntity
    {
        public RoleNavigationMenu()
        {
            Id = Guid.NewGuid().ToString();
        }

        [MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string RoleId { get; set; }

        [MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string NavigationMenuId { get; set; }

        public int Value { get; set; }

        public Role Role { get; set; }
        public NavigationMenu NavigationMenu { get; set; }
    }
}
