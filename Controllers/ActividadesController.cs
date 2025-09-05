using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private Actividades actividades;

        public ActividadesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Actividades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actividades>>> GetActividades()
        {
            return await _context.Actividades.ToListAsync();
        }

        // GET: api/Actividades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actividades>> GetActividad(int id)
        {
            var actividad = await _context.Actividades.FindAsync(id);

            if (actividad == null)
                return NotFound("Actividad no encontrada.");

            return actividad;
        }

        // POST: api/Actividades
        [HttpPost]
        public async Task<ActionResult<Actividades>> PostActividad([FromBody] Actividades actividad)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.Actividades.Add(actividades);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetActividad), new { id = actividad.Id }, actividad);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error al guardar la actividad: {ex.Message}");
            }
        }

        // PUT: api/Actividades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActividad(int id, [FromBody] Actividades actividad)
        {
            if (id != actividad.Id)
                return BadRequest("El ID no coincide.");

            _context.Entry(actividad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadExists(id))
                    return NotFound("Actividad no encontrada.");
                else
                    throw;
            }
        }

        // DELETE: api/Actividades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActividad(int id)
        {
            var actividad = await _context.Actividades.FindAsync(id);
            if (actividad == null)
                return NotFound("Actividad no encontrada.");

            _context.Actividades.Remove(actividad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActividadExists(int id)
        {
            return _context.Actividades.Any(a => a.Id == id);
        }
    }
}


