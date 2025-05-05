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

        [HttpPost]
        public async Task<ActionResult<menu>> PostMenu(menu menu)
        {
            _appDbContext.Menu.Add(menu);
            await _appDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMenu), new { id = menu.id }, menu);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PostMenu(int id, menu menu)
        {
            if (id != menu.id)
            {
                return BadRequest();
            }

            _appDbContext.Entry(menu).State = EntityState.Modified;

            try
            {
                await _appDbContext.SaveChangesAsync();
            }catch (DbUpdateConcurrencyException)
            {
                if(!_appDbContext.Menu.Any(e => e.id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var menu = await _appDbContext.Menu.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            _appDbContext.Menu.Remove(menu);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
