using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.DAL.Entities;
using FilmBegetter.DAL.Interfaces;

namespace FilmBegetter.BLL.Services;

public class MovieCollectionService : IMovieCollectionService {

    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;

    public MovieCollectionService(IMapper mapper, IUnitOfWork unitOfWork) {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateCollectionAsync(MovieCollectionDto dto) {

        var collection = _mapper.Map<MovieCollectionDto, MovieCollection>(dto);

        await _unitOfWork.GetRepository<IRepository<MovieCollection>, MovieCollection>().CreateAsync(collection);

        await _unitOfWork.SaveChangesAsync();
    }
}