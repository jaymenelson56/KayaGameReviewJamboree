using Microsoft.AspNetCore.Identity;

namespace KayaGameReviewJamboree.Models;

public class Review
{
    public int Id { get; set; }
    public string? Title { get; set ;}
    public string? Body { get; set; }
    public int UserId { get; set;}
    public int ReactionId { get; set; }
}