using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace bugTracker.Models;

public class ApplicationUser : IdentityUser
{
    public string? Nome { get; set; }
    public string? Cargo { get; set; }

    public ICollection<HistoryModel>? History { get; set; } 
}
