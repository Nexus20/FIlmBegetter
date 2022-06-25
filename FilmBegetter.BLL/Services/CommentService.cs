using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.DAL.Entities;
using FilmBegetter.DAL.Interfaces;

namespace FilmBegetter.BLL.Services;

public class CommentService : ICommentService {
    
    private readonly IUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;

    public CommentService(IUnitOfWork unitOfWork, IMapper mapper) {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<string> CreateCommentAsync(CommentDto dto) {

        var comment = _mapper.Map<CommentDto, Comment>(dto);

        await _unitOfWork.GetRepository<IRepository<Comment>, Comment>().CreateAsync(comment);

        await _unitOfWork.SaveChangesAsync();

        return comment.Id;
    }
}