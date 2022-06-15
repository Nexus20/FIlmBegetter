namespace FilmBegetter.DAL.Entities;

public class Movie : BaseEntity {

    public string Title { get; set; }

    public string Description { get; set; }

    public string Country { get; set; }

    public string Director { get; set; }

    public DateTime PublicationDate { get; set; }

    public virtual ICollection<MovieGenre> MovieGenres { get; set; }

    public virtual ICollection<MovieMovieCollection> MovieCollections { get; set; }

    public virtual ICollection<Rating> Ratings { get; set; }

    public virtual ICollection<Comment> Comments { get; set; }

    public string ImagePath { get; set; }
}