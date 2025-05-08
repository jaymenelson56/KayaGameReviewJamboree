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
        try
        {
            List<UserProfile> userProfiles = _dbContext.UserProfiles
                   .Include(up => up.IdentityUser)
                   .Select(up => new UserProfile
                   {
                       Id = up.Id,
                       FirstName = up.FirstName,
                       LastName = up.LastName,
                       Address = up.Address,
                       UserName = up.IdentityUser.UserName,
                       Email = up.IdentityUser.Email,
                       IdentityUserId = up.IdentityUserId
                   }).ToList();

            return Ok(userProfiles);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while retrieving user profiles: {ex.Message}");
        }
    }
}