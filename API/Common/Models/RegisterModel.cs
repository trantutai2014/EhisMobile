namespace API.Common.Models
{
    public class RegisterModel 

    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string MaBV { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLocked { get; set; }
    }
}
