namespace JwtAuthApi.Models.DTO;

public class GetPostDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Category { get; set; } = default!;
    public string Content { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public string Username { get; set; } = default!;
    
}