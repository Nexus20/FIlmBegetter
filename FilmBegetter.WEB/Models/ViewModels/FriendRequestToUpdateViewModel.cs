using FilmBegetter.Domain;

namespace FilmBegetter.WEB.Models.ViewModels;

public class FriendRequestToUpdateViewModel {

    public string Id { get; set; }
        
    public FriendRequestStatus Status { get; set; }
}