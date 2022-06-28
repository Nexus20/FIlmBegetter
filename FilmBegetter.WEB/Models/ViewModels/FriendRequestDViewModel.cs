using FilmBegetter.Domain;

namespace FilmBegetter.WEB.Models.ViewModels;

public class FriendRequestDViewModel : BaseViewModel {

    public string User { get; set; }

    public FriendRequestStatus Status { get; set; }
}