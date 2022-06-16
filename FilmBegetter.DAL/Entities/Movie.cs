namespace FilmBegetter.DAL.Entities;

public class Movie : BaseEntity {

    public string Title { get; set; }

    public string Description { get; set; }

    public string Country { get; set; }

    public string Director { get; set; }

    public DateTime PublicationDate { get; set; }

    public ICollection<MovieGenre> MovieGenres { get; set; }

    public ICollection<MovieMovieCollection> MovieCollections { get; set; }

    public ICollection<Rating> Ratings { get; set; }

    public ICollection<Comment> Comments { get; set; }

    public string ImagePath { get; set; }
}