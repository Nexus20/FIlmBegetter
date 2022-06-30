using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.BLL.Utils.Exceptions;
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
            throw new UnableToUpdateCommentRatingException(
                "Unable to update comment rating! Comment author can't rate his own comments");
        }

        var commentRating = await _unitOfWork.GetRepository<IRepository<CommentRatingUser>, CommentRatingUser>()
            .FirstOrDefaultAsync(cru => cru.UserId == userId && cru.CommentId == commentId);

        if (commentRating != null) {
            throw new UnableToUpdateCommentRatingException(
                "Unable to update comment rating! You have already rated this comment");
        }

        commentRating = new CommentRatingUser {
            CommentId = commentId,
            UserId = userId,
            Rating = rating
        };

        await _unitOfWork.GetRepository<IRepository<CommentRatingUser>, CommentRatingUser>()
            .CreateAsync(commentRating);

        await _unitOfWork.SaveChangesAsync();
    }
}