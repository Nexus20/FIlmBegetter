namespace FilmBegetter.DAL.Entities;

public class MovieCollection : BaseEntity {

    public string Name { get; set; }

    public string AuthorId { get; set; }

    public User Author { get; set; }

    public ICollection<MovieMovieCollection> MovieCollections { get; set; }
}