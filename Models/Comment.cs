using Microsoft.AspNetCore.Identity;

namespace KayaGameReviewJamboree.Models;

public class Comment
{
    public int Id { get; set; }
    public string? Body { get; set; }
    public int ReviewId { get; set; }
    public int UserId { get; set; }
}