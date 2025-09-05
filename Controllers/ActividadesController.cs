using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;     // Tu DbContext
using ToDoApi.Models;   // Tus modelos Actividad y Usuario
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ActividadesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/actividades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actividad>>> GetActividades()
        {
            return await _context.Actividades.Include(a => a.Usuario).ToListAsync();
        }

        // GET: api/actividades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actividad>> GetActividad(int id)
        {
            var actividad = await _context.Actividades
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (actividad == null)
            {
                return NotFound();
            }

            return actividad;
        }

        // POST: api/actividades
        [HttpPost]
        public async Task<ActionResult<Actividad>> PostActividad(Actividad actividad)
        {
            // Verificar que el usuario exista
            var usuarioExistente = await _context.Usuarios.FindAsync(actividad.UsuarioId);
            if (usuarioExistente == null)
            {
                return BadRequest("El usuario no existe.");
            }

            // Attach del usuario existente para que EF Core no intente insertarlo
            actividad.Usuario = usuarioExistente;
            _context.Actividades.Add(actividad);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest("Ocurrió un error al guardar la actividad.");
            }

            return CreatedAtAction(nameof(GetActividad), new { id = actividad.Id }, actividad);
        }

        // PUT: api/actividades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActividad(int id, Actividad actividad)
        {
            if (id != actividad.Id)
            {
                return BadRequest();
            }

            // Verificar que el usuario exista
            var usuarioExistente = await _context.Usuarios.FindAsync(actividad.UsuarioId);
            if (usuarioExistente == null)
            {
                return BadRequest("El usuario no existe.");
            }

            actividad.Usuario = usuarioExistente;
            _context.Entry(actividad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Actividades.Any(e => e.Id == id))
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

        // DELETE: api/actividades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActividad(int id)
        {
            var actividad = await _context.Actividades.FindAsync(id);
            if (actividad == null)
            {
                return NotFound();
            }

            _context.Actividades.Remove(actividad);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
