namespace Data.Interfaces
{
    public interface IPersonTracking
    {
        string CreatorUserId { get; set; }
        string LastModifierUserId { get; set; }
        string DeleterUserId { get; set; }
    }
}