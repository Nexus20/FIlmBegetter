using System.ComponentModel.DataAnnotations;

namespace FilmBegetter.WEB.Models.ViewModels;

public class MovieToUpdateViewModel {

    [Required]
    public string Id { get; set; }
    
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
    public string Genres { get; set; }
}