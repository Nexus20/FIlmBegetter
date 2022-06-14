using Microsoft.AspNetCore.Identity;

namespace FilmBegetter.DAL.Entities;

public class User : IdentityUser {

    public ICollection<MovieCollection> MovieCollections { get; set; }

    public ICollection<Rating> Ratings { get; set; }

    public ICollection<User> Friends { get; set; }

    public ICollection<Comment> Comments { get; set; }
    
    public ICollection<UserRole> UserRoles { get; set; }

    public Subscription Subscription { get; set; }

    public bool IsBanned { get; set; }

    public DateTime? UnbanDate { get; set; }
}