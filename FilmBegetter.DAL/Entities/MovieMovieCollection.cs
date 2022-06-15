namespace FilmBegetter.DAL.Entities;

public class MovieMovieCollection {

    public string MovieId { get; set; }

    public virtual Movie Movie { get; set; }

    public string MovieCollectionId { get; set; }

    public virtual MovieCollection MovieCollection { get; set; }
}