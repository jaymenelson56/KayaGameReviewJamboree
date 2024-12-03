using KayaGameReviewJamboree.Data;
using KayaGameReviewJamboree.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KayaGameReviewJamboree.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class UserProfileController : ControllerBase
{
    private KayaGameReviewJamboreeDbContext _dbContext;

    public UserProfileController(KayaGameReviewJamboreeDbContext context)
    {
        _dbContext = context;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .Select(up => new UserProfile
        {
            Id = up.Id,
            FirstName = up.FirstName,
            LastName = up.LastName,
            Address = up.Address,
            Email = up.IdentityUser.UserName,
            IdentityUserId = up.IdentityUserId
        }));
    }
}