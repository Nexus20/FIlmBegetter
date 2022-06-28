namespace FilmBegetter.BLL.Interfaces;

public interface IFriendRequestService {

    Task CreateRequestAsync(string senderId, string recipientId);
}