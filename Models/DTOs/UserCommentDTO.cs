namespace KayaGameReviewJamboree.Models.DTOs;

public class UserCommentDTO
{
    public string? Body { get; set; }
    public int ReviewId { get; set; }
    public int UserProfileId { get; set; }
    public ReviewDTO? Review { get; set; }
    public UserProfileDTO? UserProfile { get; set;}
}   