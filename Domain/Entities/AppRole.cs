namespace Domain.Entities;

public class AppRole
{
    public int RoleId { get; set; }   
    public string RoleName { get; set; } = null!;
    public string IsActive { get; set; } = "Y";
}