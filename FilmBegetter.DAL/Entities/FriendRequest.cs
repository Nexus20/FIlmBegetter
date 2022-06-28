using FilmBegetter.Domain;

namespace FilmBegetter.DAL.Entities;

public class FriendRequest : BaseEntity {

    public string SenderId { get; set; }

    public User Sender { get; set; }
    
    public string RecipientId { get; set; }

    public User Recipient { get; set; }

    public FriendRequestStatus Status { get; set; } = FriendRequestStatus.New;
}