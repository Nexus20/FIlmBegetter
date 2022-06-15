namespace FilmBegetter.DAL.Entities;

public class MovieCollection : BaseEntity {

    public string Name { get; set; }

    public string AuthorId { get; set; }

    public virtual User Author { get; set; }

    public virtual ICollection<MovieMovieCollection> MovieCollections { get; set; }
}