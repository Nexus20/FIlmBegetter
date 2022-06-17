using System.ComponentModel.DataAnnotations;

namespace FilmBegetter.WEB.Models.ViewModels; 

public class AuthenticationViewModel {
    
    [Required(ErrorMessage = "Email is required.")]
    public string? Email { get; set; }
    
    [Required(ErrorMessage = "Password is required.")]
    public string? Password { get; set; }
}