namespace FilmBegetter.BLL.Entities;

public class Rating : BaseEntity {

    public string MovieId { get; set; }

    public Movie Movie { get; set; }

    public string UserId { get; set; }

    public User User { get; set; }

    public int Rating { get; set; }
}