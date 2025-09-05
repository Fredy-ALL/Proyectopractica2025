using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;       // DbContext
using ToDoApi.Models;     // Modelo SeguimientoActividad
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguimientoActividadesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public SeguimientoActividadesController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/seguimientoactividades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeguimientoActividad>>> GetSeguimientoActividades()
        {
            return await _db.SeguimientoActividades.ToListAsync();
        }

        // GET: api/seguimientoactividades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeguimientoActividad>> GetSeguimientoActividad(int id)
        {
            var seguimiento = await _db.SeguimientoActividades.FindAsync(id);

            if (seguimiento == null)
            {
                return NotFound();
            }

            return seguimiento;
        }

        // POST: api/seguimientoactividades
        [HttpPost]
        public async Task<ActionResult<SeguimientoActividad>> PostSeguimientoActividad(SeguimientoActividad seguimiento)
        {
            _db.SeguimientoActividades.Add(seguimiento);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSeguimientoActividad), new { id = seguimiento.Id }, seguimiento);
        }

        // PUT: api/seguimientoactividades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeguimientoActividad(int id, SeguimientoActividad seguimiento)
        {
            if (id != seguimiento.Id)
            {
                return BadRequest();
            }

            _db.Entry(seguimiento).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.SeguimientoActividades.Any(e => e.Id == id))
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

        // DELETE: api/seguimientoactividades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeguimientoActividad(int id)
        {
            var seguimiento = await _db.SeguimientoActividades.FindAsync(id);
            if (seguimiento == null)
            {
                return NotFound();
            }

            _db.SeguimientoActividades.Remove(seguimiento);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}