namespace FilmBegetter.WEB.Models.ViewModels;

public class UserViewModel {
    
    public string Id { get; set; }
    
    public string Name { get; set; }

    public string Surname { get; set; }

    public DateTime? SubscriptionExpirationDare { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public bool IsBanned { get; set; }

    public DateTime? UnbanDate { get; set; }
    
    public ICollection<MovieCollectionViewModel> MovieCollections { get; set; }

    public ICollection<RatingViewModel> Ratings { get; set; }

    public ICollection<UserViewModel> Friends { get; set; }

    public ICollection<CommentViewModel> Comments { get; set; }
    
    public List<RoleViewModel> Roles { get; set; }

    public SubscriptionViewModel Subscription { get; set; }
    
    public string SubscriptionId { get; set; }
    
    public ICollection<FriendRequestDViewModel> SentFriendRequests { get; set; }
    
    public ICollection<FriendRequestDViewModel> RecievedFriendRequests { get; set; }
}