using KayaGameReviewJamboree.Data;
using KayaGameReviewJamboree.Models;
using KayaGameReviewJamboree.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;


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
        .Include(r => r.UserProfile)
        .ThenInclude(up => up.IdentityUser)
        .Include(r => r.Reaction)
        .Include(r => r.Comments)
        .ThenInclude(c => c.UserProfile)
        .Select(r => new Review
        {
            Id = r.Id,
            Title = r.Title,
            Body = r.Body,
            UserProfileId = r.UserProfileId,
            ReactionId = r.ReactionId,
            UserProfile = new UserProfile
            {
                Id = r.UserProfile.Id,
                FirstName = r.UserProfile.FirstName,
                LastName = r.UserProfile.LastName,
                Address = r.UserProfile.Address,
                Email = r.UserProfile.IdentityUser.Email,
                UserName = r.UserProfile.IdentityUser.UserName,
                IdentityUserId = r.UserProfile.IdentityUserId

            },
            Reaction = new Reaction
            {
                Id = r.Reaction.Id,
                Image = r.Reaction.Image,
                AltText = r.Reaction.AltText,
                Description = r.Reaction.Description
            },
            Comments = r.Comments.Select(c => new UserComment
            {
                Body = c.Body,
                ReviewId = c.ReviewId,
                UserProfileId = c.UserProfileId,
                Review = null,
                UserProfile = new UserProfile
                {
                    Id = c.UserProfile.Id,
                    FirstName = c.UserProfile.FirstName,
                    LastName = c.UserProfile.LastName,
                    Email = c.UserProfile.IdentityUser.Email,
                    UserName = c.UserProfile.IdentityUser.UserName
                }

            }).ToList()


        }).ToList()
        );
    }

    [HttpGet("list")]
    public IActionResult GetList()
    {
        {
            return Ok(_dbContext.Reviews
            .Include(r => r.UserProfile)
            .ThenInclude(up => up.IdentityUser)
            .Select(r => new ReviewListDTO
            {
                Id = r.Id,
                Title = r.Title,
                UserProfileId = r.UserProfileId,
                UserName = r.UserProfile.IdentityUser.UserName
            }).ToList()
            );
        }
    }

    /*get review by id
    include username
    include reactions
    include comments

    get review body, title, id, userprofile(username, id), reaction(id, image, alt text), comments

*/

    [HttpGet("{id}")]

    public IActionResult GetReviewById(int id)
    {
        {
            ReviewDTO review = _dbContext.Reviews
            .Where(r => r.Id == id)
            .Include(r => r.UserProfile)
            .ThenInclude(up => up.IdentityUser)
            .Include(r => r.Reaction)
            .Include(r => r.Comments)
            .Select(r => new ReviewDTO
            {
                Id = r.Id,
                Title = r.Title,
                Body = r.Body,
                UserProfileId = r.UserProfileId,
                ReactionId = r.ReactionId,
                UserName = r.UserProfile.IdentityUser.UserName,
                ReactionImage = r.Reaction.Image,
                AltText = r.Reaction.AltText

            }).FirstOrDefault();
            if (review == null)
            {
                return NotFound($"Review with ID {id} was not found.");
            }

            return Ok(review);
        }
    }

    /*
    create comments
    */

}