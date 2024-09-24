namespace API.Model
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string MaBV { get; set; }
        public DateTime? LockOutDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }
        public string CreatorUserId { get; set; }
        public string LastModifierUserId { get; set; }
        public string DeleterUserId { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLocked { get; set; }
    }
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
