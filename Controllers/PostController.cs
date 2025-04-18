using JwtAuthApi.Data;
using JwtAuthApi.Models;
using JwtAuthApi.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController(ApplicationDbContext context) : ControllerBase
{
    private readonly ApplicationDbContext _context = context;

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var posts = await _context.Posts
            .Include(p => p.User)
            .Select(p => new GetPostDto {
                Id = p.Id,
                Title = p.Title,
                Category = p.Category,
                Content = p.Content,
                UserId = p.UserId,
                Username = p.User.UserName!
            })
            .ToListAsync();
            
        return Ok(posts);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostDto dto)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (userId == null) return Unauthorized();

        var post = new Post
        {
            Title = dto.Title,
            Category = dto.Category,
            Content = dto.Content,
            UserId = userId
        };

        _context.Posts.Add(post);
        await _context.SaveChangesAsync();

        return Ok(post);
    }
}
