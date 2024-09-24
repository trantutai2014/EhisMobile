
using System.ComponentModel.DataAnnotations;

public class UserRoleModel
{
  [Key]
    public string ID { get; set; } = null!;
    public string? RoleId { get; set; }
    public string? UserId { get; set; }
}
