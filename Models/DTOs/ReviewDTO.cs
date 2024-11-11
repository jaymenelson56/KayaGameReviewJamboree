namespace KayaGameReviewJamboree.Models.DTOs;

public class ReviewDTO
{
    public int Id { get; set; }
    public string? Title { get; set ;}
    public string? Body { get; set; }
    public int UserProfileId { get; set;}
    public int ReactionId { get; set; }
    public UserProfileDTO? UserProfile { get; set; }
    public ReactionDTO? Reaction{ get; set; }
    public List<UserCommentDTO>? Comments { get; set; }
}