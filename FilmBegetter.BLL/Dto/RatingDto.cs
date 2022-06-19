namespace FilmBegetter.BLL.Dto;

public class RatingDto : BaseDto {

    public string MovieId { get; set; }

    public MovieDto Movie { get; set; }

    public string UserId { get; set; }

    public UserDto User { get; set; }

    public double RatingValue { get; set; }
}