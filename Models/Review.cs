using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace KayaGameReviewJamboree.Models;

public class Review
{
    public int Id { get; set; }
    [Required]
    public string? Title { get; set ;}
    [Required]
    public string? Body { get; set; }
    [Required]
    public int UserId { get; set;}
    [Required]
    public int ReactionId { get; set; }
    [ForeignKey(nameof(UserId))]
    public UserProfile UserProfile { get; set; }
}