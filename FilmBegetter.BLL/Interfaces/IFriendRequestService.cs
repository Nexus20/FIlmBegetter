using FilmBegetter.Domain;

namespace FilmBegetter.BLL.Interfaces;

public interface IFriendRequestService {

    Task CreateRequestAsync(string senderId, string recipientId);
    
    Task UpdateRequestAsync(string id, FriendRequestStatus status);
}