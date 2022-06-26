using FilmBegetter.BLL.Dto;

namespace FilmBegetter.BLL.Interfaces;

public interface ICommentService {
    
    Task<CommentDto> CreateCommentAsync(CommentDto dto);
    
    Task UpdateRatingAsync(string userId, string commentId, int rating);
}