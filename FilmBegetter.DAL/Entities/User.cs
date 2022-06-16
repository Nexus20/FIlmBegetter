using Microsoft.AspNetCore.Identity;

namespace FilmBegetter.DAL.Entities;

public class User : IdentityUser {

    public virtual ICollection<MovieCollection> MovieCollections { get; set; }

    public virtual ICollection<Rating> Ratings { get; set; }

    public virtual ICollection<User> Friends { get; set; }

    public virtual ICollection<Comment> Comments { get; set; }
    
    public virtual ICollection<UserRole> UserRoles { get; set; }

    public virtual Subscription Subscription { get; set; }
    
    public string SubscriptionId { get; set; }

    public bool IsBanned { get; set; }

    public DateTime? UnbanDate { get; set; }
}