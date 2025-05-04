using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_ASP.NET.Models;

namespace WebAPI_ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuMyRestoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public MenuMyRestoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<menu>>> GetMenu()
        {
            return await _appDbContext.Menu.ToListAsync();
        }
    }
}
