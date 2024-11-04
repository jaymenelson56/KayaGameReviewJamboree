using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KayaGameReviewJamboree.Models;

public class Review
{
    public int Id { get; set; }
    [Required]
    public string? Title { get; set ;}
    [Required]
    public string? Body { get; set; }
    [Required]
    public int UserProfileId { get; set;}
    [Required]
    public int ReactionId { get; set; }
    [ForeignKey(nameof(UserProfileId))]
    public UserProfile? UserProfile { get; set; }
    [ForeignKey(nameof(ReactionId))]
    public Reaction? Reaction{ get; set; }
}