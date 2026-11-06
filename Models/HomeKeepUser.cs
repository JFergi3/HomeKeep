using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HomeKeep.Models;

public class HomeKeepUser : IdentityUser
{
    [StringLength(40)]
public string DisplayName { get; set; } = "";
}