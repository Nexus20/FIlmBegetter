using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FilmBegetter.BLL.Services;

public class RoleService : IRoleService {

    private readonly RoleManager<Role> _roleManager;

    private readonly IMapper _mapper;
    
    public RoleService(RoleManager<Role> roleManager, IMapper mapper) {
        _roleManager = roleManager;
        _mapper = mapper;
    }

    public async Task<List<RoleDto>> GetAllRolesAsync() {

        var source = await _roleManager.Roles.ToListAsync();

        return _mapper.Map<List<Role>, List<RoleDto>>(source);
    }
}