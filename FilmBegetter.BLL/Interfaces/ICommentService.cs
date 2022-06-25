using FilmBegetter.BLL.Dto;
using FilmBegetter.DAL.Entities;

namespace FilmBegetter.BLL.Interfaces;

public interface ICommentService {
    
    Task<CommentDto> CreateCommentAsync(CommentDto dto);
}