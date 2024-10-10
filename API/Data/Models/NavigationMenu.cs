using Common;
using Common.Constants;
using Data.Abstract;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Models
{
    [Table("NavigationMenus")]
    public class NavigationMenu : BaseEntity, ISortable
    {
        public NavigationMenu()
        {
            Id = Guid.NewGuid().ToString();
            ChildNavMenus = new HashSet<NavigationMenu>();
            RoleNavigationMenus = new HashSet<RoleNavigationMenu>();
        }

        [Required, MaxLength(128)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Code { get; set; }

        [MaxLength(256)]
        public string Url { get; set; }

        [MaxLength(50)]
        public string Icon { get; set; }

        [MaxLength(50)]
        public string Svg { get; set; }

        public bool Root { get; set; }

        public string Bullet { get; set; }

        [MaxLength(ValidatorConsts.MaxLengthGuid)]
        public string ParentId { get; set; }

        public bool IsSection { get; set; }

        public bool IsLockClient { get; set; } = false;

        public int SortOrder { get; set; }

        public NavigationMenu ParentNavMenu { get; set; }
        public ICollection<NavigationMenu> ChildNavMenus { get; set; }

        public ICollection<RoleNavigationMenu> RoleNavigationMenus { get; set; }

    }
}
