using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmBegetter.WEB.Controllers; 

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase {
        
    // GET: api/Roles
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
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