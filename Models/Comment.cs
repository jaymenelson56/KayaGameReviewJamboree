using Microsoft.AspNetCore.Identity;

namespace KayaGameReviewJamboree.Models;

public class Comment
{
    public int Id { get; set; }
    public string? Body { get; set; }
    public int ReviewId { get; set; }
    public int UserProfileId { get; set; }
    public Review? Review { get; set; }
    public UserProfile? UserProfile { get; set;}
}   