using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.DAL.Entities;
using FilmBegetter.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FilmBegetter.BLL.Services;

public class CommentService : ICommentService {
    
    private readonly IUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;

    private readonly UserManager<User> _userManager;

    public CommentService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager) {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<CommentDto> CreateCommentAsync(CommentDto dto) {

        var comment = _mapper.Map<CommentDto, Comment>(dto);

        await _unitOfWork.GetRepository<IRepository<Comment>, Comment>().CreateAsync(comment);

        await _unitOfWork.SaveChangesAsync();

        comment.Author = await _userManager.FindByIdAsync(comment.AuthorId);        

        return _mapper.Map<Comment, CommentDto>(comment);
    }

    public async Task UpdateRatingAsync(string userId, string commentId, int rating) {

        var comment = await _unitOfWork.GetRepository<IRepository<Comment>, Comment>()
            .FirstOrDefaultAsync(c => c.Id == commentId);

        if (comment.AuthorId == userId) {
        }

    }
}