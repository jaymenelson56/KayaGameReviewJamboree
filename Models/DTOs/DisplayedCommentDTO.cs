namespace KayaGameReviewJamboree.Models.DTOs;

public class DisplayedCommentDTO
{
    public int Id { get; set; }
    public string? Body { get; set; }
    public int ReviewId { get; set; }
    public int UserProfileId { get; set; }
    public string? UserName { get; set; }
}