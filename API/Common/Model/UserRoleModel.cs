using System.ComponentModel.DataAnnotations;

public class UserRoleModel
{
    [Key]
    public string ID { get; set; }
    public string RoleId { get; set; }
    public string UserId { get; set; }
}