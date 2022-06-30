using Microsoft.AspNetCore.Identity;

namespace FilmBegetter.DAL.Entities;

public class User : IdentityUser {

    public string Name { get; set; }

    public string Surname { get; set; }

    public DateTime? SubscriptionExpirationDare { get; set; }

    public virtual ICollection<MovieCollection> MovieCollections { get; set; }

    public virtual ICollection<Rating> Ratings { get; set; }

    public virtual ICollection<Comment> Comments { get; set; }
    
    public virtual ICollection<UserRole> UserRoles { get; set; }

    public virtual Subscription Subscription { get; set; }
    
    public string SubscriptionId { get; set; }

    public bool IsBanned { get; set; }

    public DateTime? UnbanDate { get; set; }
    
    public ICollection<CommentRatingUser> CommentRatings { get; set; }
    
    public ICollection<FriendRequest> SentFriendRequests { get; set; }
    
    public ICollection<FriendRequest> ReceivedFriendRequests { get; set; }
}