namespace FilmBegetter.DAL.Entities;

public class Rating : BaseEntity {

    public string MovieId { get; set; }

    public virtual Movie Movie { get; set; }

    public string? UserId { get; set; }

    public virtual User? User { get; set; }

    public double RatingValue { get; set; }
}