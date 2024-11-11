using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace KayaGameReviewJamboree.Models;

public class UserProfile
{
    public int Id { get; set; }
    [Required(ErrorMessage = "First name is required")]
    public string? FirstName { get; set; }
    [Required(ErrorMessage = "Last name is required")]
    public string? LastName { get; set; }
    [Required]
    public string? Address { get; set; }
    
    [NotMapped]
    public string? Email { get; set; }
    [Required]

    public string? IdentityUserId { get; set; }

    public IdentityUser? IdentityUser { get; set; }

    public List<UserComment>? Comments { get; set; }

}