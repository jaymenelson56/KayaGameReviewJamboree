using System.ComponentModel.DataAnnotations;

namespace KayaGameReviewJamboree.Models;

public class Reaction
{
    public int Id { get; set; }
    [Required]
    public string? Image { get; set; }
    [Required]
    public string? AltText { get; set; }
    [Required]
    public string? Description {get; set; }
}