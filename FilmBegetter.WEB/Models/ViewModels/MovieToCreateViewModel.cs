using System.ComponentModel.DataAnnotations;

namespace FilmBegetter.WEB.Models.ViewModels;

public class MovieToCreateViewModel {

    [Required]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public string Country { get; set; }

    [Required]
    public string Director { get; set; }
    
    [Required]
    public DateTime PublicationDate { get; set; }

    [Required]
    public ICollection<string> Genres { get; set; }

    public IFormFile ImageFile { get; set; }
}