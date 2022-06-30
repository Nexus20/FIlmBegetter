using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.DAL.Entities;
using FilmBegetter.DAL.Interfaces;

namespace FilmBegetter.BLL.Services;

public class GenreService : IGenreService {
    
    private readonly IUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;

    public GenreService(IUnitOfWork unitOfWork, IMapper mapper) {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GenreDto>> GetAllGenresAsync() {

        var source = await _unitOfWork.GetRepository<IRepository<Genre>, Genre>().FindAllAsync();

        return _mapper.Map<List<Genre>, List<GenreDto>>(source);
    }
}