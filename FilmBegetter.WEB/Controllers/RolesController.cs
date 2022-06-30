using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.Domain;
using FilmBegetter.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmBegetter.WEB.Controllers; 

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase {

    private readonly IRoleService _roleService;

    private readonly IMapper _mapper;
        
    // GET: api/Roles
    public RolesController(IRoleService roleService, IMapper mapper) {
        _roleService = roleService;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> Get() {

        var source = await _roleService.GetAllRolesAsync();

        return Ok(_mapper.Map<List<RoleDto>, List<RoleViewModel>>(source));
    }

    // POST: api/Roles
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT: api/Roles/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE: api/Roles/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}