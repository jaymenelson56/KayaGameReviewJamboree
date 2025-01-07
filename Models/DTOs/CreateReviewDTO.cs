namespace KayaGameReviewJamboree.Models.DTOs;

public class CreateReviewDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public int UserProfileId { get; set; }
    public int ReactionId { get; set; }
}