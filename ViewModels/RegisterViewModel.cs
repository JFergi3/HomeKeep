using System.ComponentModel.DataAnnotations;

namespace HomeKeep.ViewModels;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    [Display(Name = "Display name")]
    [StringLength(40, MinimumLength = 2)]
    public string DisplayName { get; set; } = "";

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare(nameof(Password), ErrorMessage = "The two passwords don't match.")]
    public string ConfirmPassword { get; set; } = "";
}