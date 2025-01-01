namespace KayaGameReviewJamboree.Models.DTOs;

public class CreateCommentDTO
{
    public string? body { get; set; }
    public int ReviewId {get; set; }
    public int UserProfileId { get; set; }
}