namespace Domain.Entities;

public class AppUser
{
    public int UserId { get; set; }   
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int AppRoleId { get; set; }
    public string IsActive { get; set; } = "Y";
}