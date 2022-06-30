using System.ComponentModel.DataAnnotations;

namespace FilmBegetter.WEB.Models.ViewModels; 

public class UserToUpdateViewModel {

    [Required]
    public string Id { get; set; }
        
    [Required]
    public string Name { get; set; }
        
    [Required]
    public string Surname { get; set; }
        
    [Required]
    public string Email { get; set; }
}