namespace Explorer.Stakeholders.API.Dtos;

public class UserDto
{
    public long Id { get; set; }
    public string Username { get; set; }
    public UserRoleDto Role { get; set; }
    public bool IsActive { get; set; }
}

public enum UserRoleDto
{
    Administrator,
    Author,
    Tourist
}