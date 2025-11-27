using IntegradorPIII.BE.Data; 
using IntegradorPIII.BE.Models; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace IntegradorPIII.BE.Controllers
{
   [ApiController]
    [Route("api/[controller]")]
    public class InscripcionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InscripcionesController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Inscripciones
        [HttpPost]
        public async Task<ActionResult<Inscripcion>> PostInscripcion([FromBody] Inscripcion inscripcion)
        {
            if (inscripcion == null)
            {
                return BadRequest("Los datos de inscripción son inválidos.");
            }

            var existeInscripcion = await _context.Inscripciones
                .AnyAsync(i => i.AlumnoId == inscripcion.AlumnoId && i.MateriaId == inscripcion.MateriaId);

            if (existeInscripcion)
            {
                return Conflict("El alumno ya se encuentra inscripto en esta materia.");
            }

            try
            {
                _context.Inscripciones.Add(inscripcion);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetInscripcion), new { id = inscripcion.Id }, inscripcion);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Error al guardar la inscripción en la base de datos.");
            }
        }

        // Obtener inscripciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inscripcion>>> GetInscripciones()
        {
            return await _context.Inscripciones.ToListAsync();
        }

        // Obtener inscripcion por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Inscripcion>> GetInscripcion(int id)
        {
            var inscripcion = await _context.Inscripciones.FindAsync(id);

            if (inscripcion == null)
            {
                return NotFound();
            }

            return inscripcion;
        }

        // Cancelar inscripcion
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscripcion(int id)
        {
            var inscripcion = await _context.Inscripciones.FindAsync(id);
            if (inscripcion == null)
                return NotFound();

            _context.Inscripciones.Remove(inscripcion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}