namespace FilmBegetter.DAL.Entities;

public class MovieMovieCollection {

    public string MovieId { get; set; }

    public Movie Movie { get; set; }

    public string MovieCollectionId { get; set; }

    public MovieCollection MovieCollection { get; set; }
}