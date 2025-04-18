using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtAuthApi.Models;

[Table("Post")]
public class Post
{
    [Key]
    public int Id {get; set;}

    [Required]
    public required string Title {get; set;}

    [Required]
    public required string Category {get; set;}

    [Required]
    public required string Content {get; set;}

    [Required]
    public required string UserId {get; set;}

    [ForeignKey("UserId")]
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public ApplicationUser User {get; set;}

}