using FilmBegetter.Domain;

namespace FilmBegetter.WEB.Models.ViewModels;

public class FriendRequestViewModel : BaseViewModel {

    public string User { get; set; }

    public FriendRequestStatus Status { get; set; }
}