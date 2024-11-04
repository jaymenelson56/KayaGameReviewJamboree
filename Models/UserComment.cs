using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KayaGameReviewJamboree.Models;

public class UserComment
{
    
    [Required]
    public string? Body { get; set; }
    [Required]
    public int ReviewId { get; set; }
    [Required]
    public int UserProfileId { get; set; }
    [ForeignKey(nameof(ReviewId))]
    public Review? Review { get; set; }
    [ForeignKey(nameof(UserProfileId))]
    public UserProfile? UserProfile { get; set;}
}   