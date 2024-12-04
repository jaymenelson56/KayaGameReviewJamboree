using KayaGameReviewJamboree.Data;
using KayaGameReviewJamboree.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KayaGameReviewJamboree.Controllers;

[ApiController]
[Route("api/[Controller]")]

public class ReviewController : ControllerBase
{
    private KayaGameReviewJamboreeDbContext _dbContext;

    public ReviewController(KayaGameReviewJamboreeDbContext context)
    {
        _dbContext = context;
    }
    [HttpGet]

    public IActionResult Get()
    {
        return Ok(_dbContext.Reviews
        .Select(r => new Review
        {
            Id = r.Id,
            Title = r.Title,
            Body = r.Body,
            UserProfileId = r.UserProfileId,
            ReactionId = r.ReactionId,

        }));
    }
}