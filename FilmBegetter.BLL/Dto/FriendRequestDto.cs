using FilmBegetter.Domain;

namespace FilmBegetter.BLL.Dto;

public class FriendRequestDto : BaseDto {

    public string User { get; set; }

    public FriendRequestStatus Status { get; set; }
}