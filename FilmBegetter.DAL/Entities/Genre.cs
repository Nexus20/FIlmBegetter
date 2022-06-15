namespace FilmBegetter.DAL.Entities;

public class Genre : BaseEntity {

    public string Name { get; set; }

    public virtual ICollection<MovieGenre> MovieGenres { get; set; }
}