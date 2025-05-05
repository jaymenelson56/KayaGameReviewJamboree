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
    private readonly KayaGameReviewJamboreeDbContext _dbContext;

    public ReviewController(KayaGameReviewJamboreeDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            List<Review> reviews = _dbContext.Reviews
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
                }).ToList();

            return Ok(reviews);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while retrieving reviews: {ex.Message}");
        }
    }

    [HttpGet("list")]
    public IActionResult GetList()
    {
        try
        {
            List<ReviewListDTO> list = _dbContext.Reviews
                .Include(r => r.UserProfile)
                .ThenInclude(up => up.IdentityUser)
                .Select(r => new ReviewListDTO
                {
                    Id = r.Id,
                    Title = r.Title,
                    UserProfileId = r.UserProfileId,
                    UserName = r.UserProfile.IdentityUser.UserName
                }).ToList();

            return Ok(list);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while retrieving the review list: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetReviewById(int id)
    {
        try
        {
            ReviewDTO? review = _dbContext.Reviews
                .Where(r => r.Id == id)
                .Include(r => r.UserProfile)
                .ThenInclude(up => up.IdentityUser)
                .Include(r => r.Comments)
                .ThenInclude(c => c.UserProfile)
                .ThenInclude(uc => uc.IdentityUser)
                .Include(r => r.Reaction)
                .Select(r => new ReviewDTO
                {
                    Id = r.Id,
                    Title = r.Title,
                    Body = r.Body,
                    UserProfileId = r.UserProfileId,
                    ReactionId = r.ReactionId,
                    UserName = r.UserProfile.IdentityUser.UserName,
                    ReactionImage = r.Reaction.Image,
                    AltText = r.Reaction.AltText,
                    Comments = r.Comments.Select(c => new DisplayedCommentDTO
                    {
                        Id = c.Id,
                        Body = c.Body,
                        ReviewId = c.ReviewId,
                        UserProfileId = c.UserProfileId,
                        UserName = c.UserProfile.IdentityUser.UserName
                    }).ToList()
                }).FirstOrDefault();

            if (review == null)
            {
                return NotFound($"Review with ID {id} was not found.");
            }

            return Ok(review);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while retrieving the review: {ex.Message}");
        }
    }

    [HttpPost("comments")]
    public IActionResult CreateComment([FromBody] CreateCommentDTO createCommentDTO)
    {
        if (createCommentDTO == null)
        {
            return BadRequest("Comment data is required.");
        }

        try
        {
            Review? review = _dbContext.Reviews.FirstOrDefault(r => r.Id == createCommentDTO.ReviewId);
            UserProfile? user = _dbContext.UserProfiles.FirstOrDefault(up => up.Id == createCommentDTO.UserProfileId);

            if (review == null)
            {
                return NotFound($"Review with ID {createCommentDTO.ReviewId} was not found.");
            }

            if (user == null)
            {
                return NotFound($"User with ID {createCommentDTO.UserProfileId} was not found.");
            }

            UserComment newComment = new UserComment
            {
                Body = createCommentDTO.body,
                ReviewId = createCommentDTO.ReviewId,
                UserProfileId = createCommentDTO.UserProfileId
            };

            _dbContext.UserComments.Add(newComment);
            _dbContext.SaveChanges();

            return CreatedAtAction("GetReviewById", new { id = createCommentDTO.ReviewId }, newComment);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while creating the comment: {ex.Message}");
        }
    }

    [HttpPost]
    public IActionResult CreateReview([FromBody] CreateReviewDTO createReviewDTO)
    {
        if (createReviewDTO == null)
        {
            return BadRequest("Review data is required.");
        }

        try
        {
            Review newReview = new Review
            {
                Title = createReviewDTO.Title,
                Body = createReviewDTO.Body,
                UserProfileId = createReviewDTO.UserProfileId,
                ReactionId = createReviewDTO.ReactionId
            };

            _dbContext.Reviews.Add(newReview);
            _dbContext.SaveChanges();

            return CreatedAtAction("GetReviewById", new { id = newReview.Id }, newReview);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while creating the review: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public IActionResult EditReview(int id, [FromBody] EditReviewDTO editReviewDTO)
    {
        if (editReviewDTO == null || id <= 0)
        {
            return BadRequest("Invalid data provided.");
        }

        try
        {
            Review? review = _dbContext.Reviews.FirstOrDefault(r => r.Id == id);
            if (review == null)
            {
                return NotFound($"Review with ID {id} not found.");
            }

            review.Title = editReviewDTO.Title ?? review.Title;
            review.Body = editReviewDTO.Body ?? review.Body;
            review.ReactionId = editReviewDTO.ReactionId;

            _dbContext.Reviews.Update(review);
            _dbContext.SaveChanges();

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while updating the review: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteReview(int id)
    {
        try
        {
            Review? review = _dbContext.Reviews.Find(id);
            if (review == null)
            {
                return NotFound($"Review with ID {id} not found.");
            }

            _dbContext.Reviews.Remove(review);
            _dbContext.SaveChanges();

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while deleting the review: {ex.Message}");
        }
    }
}