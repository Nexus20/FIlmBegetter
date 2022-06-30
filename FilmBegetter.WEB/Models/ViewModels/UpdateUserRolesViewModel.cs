using System.ComponentModel.DataAnnotations;

namespace FilmBegetter.WEB.Models.ViewModels;

public class UpdateUserRolesViewModel {
    
    [Required]
    public string UserId { get; set; }

    [Required]
    public List<string> Roles { get; set; }
}