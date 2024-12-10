namespace KayaGameReviewJamboree.Models.DTOs;

public class ReviewListDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int UserProfileId { get; set; }
    public string? UserName { get; set; }
}