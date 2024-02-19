
namespace piqe.Models;
public class UserDTO
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public UserType UserType { get; set; }
    public DateTime Birthday { get; set; }

    public static User ToUser(UserDTO userDTO)
    {
        return new User()
        {
            AccessLevel = UserAccessLevel.Readonly,
            DateCreated = DateTime.UtcNow,
            DateUpdated = null,
            Email = userDTO.Email,
            FirstName = userDTO.FirstName,
            LastName = userDTO.LastName,
            Name = string.Format($"{userDTO.LastName}, {userDTO.FirstName}"),
            IsDeleted = false,
            Username = GenerateUsername(userDTO),
            UserType = userDTO.UserType
        };
    }

    private static string GenerateUsername(UserDTO userDTO)
    {
        string firstName = userDTO.FirstName.Substring(0, 3);
        string lastName = userDTO.LastName.Substring(0, 3);
        string year = userDTO.Birthday.ToString("yy");
        return $"{firstName}{lastName}{year}";
    }
}
