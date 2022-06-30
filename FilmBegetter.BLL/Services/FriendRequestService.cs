using FilmBegetter.BLL.Interfaces;
using FilmBegetter.DAL.Entities;
using FilmBegetter.DAL.Interfaces;
using FilmBegetter.Domain;

namespace FilmBegetter.BLL.Services;

public class FriendRequestService : IFriendRequestService {

    private readonly IUnitOfWork _unitOfWork;

    public FriendRequestService(IUnitOfWork unitOfWork) {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateRequestAsync(string senderId, string recipientId) {

        var request = new FriendRequest() {
            SenderId = senderId,
            RecipientId = recipientId
        };

        await _unitOfWork.GetRepository<IRepository<FriendRequest>, FriendRequest>().CreateAsync(request);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateRequestAsync(string id, FriendRequestStatus status) {

        var request = await _unitOfWork.GetRepository<IRepository<FriendRequest>, FriendRequest>()
            .FirstOrDefaultAsync(r => r.Id == id);

        request.Status = status;
        
        _unitOfWork.GetRepository<IRepository<FriendRequest>, FriendRequest>().Update(request);

        await _unitOfWork.SaveChangesAsync();
    }
}