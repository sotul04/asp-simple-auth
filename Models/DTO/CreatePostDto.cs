namespace JwtAuthApi.Models.DTO;

public class CreatePostDto
{
    public required string Title { get; set; }
    public required string Category { get; set; }
    public required string Content { get; set; }
}