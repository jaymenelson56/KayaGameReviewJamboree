using KayaGameReviewJamboree.Data;
using KayaGameReviewJamboree.Models;
using KayaGameReviewJamboree.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace KayaGameReviewJamboree.Controllers;

[ApiController]
[Route("api/[Controller]")]

public class ReactionController : ControllerBase
{
    private KayaGameReviewJamboreeDbContext _dbContext;

    public ReactionController(KayaGameReviewJamboreeDbContext context)
    {
        _dbContext = context;
    }
    [HttpGet]

    public IActionResult Get()
    {
        try
        {
        return Ok(_dbContext.Reactions
        .Select(r => new ReactionDTO
        {
            Id = r.Id,
            Image = r.Image,
            AltText = r.AltText,
            Description = r.Description
        }));
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while retrieving reactions: {ex.Message}");
        }
    }
}
