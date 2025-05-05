using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_ASP.NET.Models;

namespace WebAPI_ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployesMyRestoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public EmployesMyRestoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<employes>>> GetEmployes()
        {
            return await _appDbContext.Employes.ToListAsync();
        }

    }
}
