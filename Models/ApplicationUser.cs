using Microsoft.AspNetCore.Identity;

namespace JwtAuthApi.Models;

public class ApplicationUser: IdentityUser
{
    public required string Name {get; set;}
    public required string Role {get; set;} // "User" or "Admin"
    public string? Image {get; set;} // URL
    public ICollection<Post> Posts {get; set;} = [];

}