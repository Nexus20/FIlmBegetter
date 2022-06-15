namespace FilmBegetter.BLL.Dto;

public class MovieDto : BaseDto {

    public string Title { get; set; }

    public string Description { get; set; }

    public string Country { get; set; }

    public string Director { get; set; }

    public DateTime PublicationDate { get; set; }

    public ICollection<GenreDto> Genres { get; set; }

    public ICollection<MovieCollectionDto> MovieCollections { get; set; }

    public ICollection<RatingDto> Ratings { get; set; }

    public ICollection<CommentDto> Comments { get; set; }

    public string ImagePath { get; set; }
}