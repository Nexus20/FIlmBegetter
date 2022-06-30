using FilmBegetter.BLL.Dto;

namespace FilmBegetter.BLL.Interfaces;

public interface IRoleService {

    Task<List<RoleDto>> GetAllRolesAsync();
}