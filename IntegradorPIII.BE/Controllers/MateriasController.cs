using IntegradorPIII.BE.Data;
using IntegradorPIII.BE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntegradorPIII.BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MateriasController(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todas las materias
        [HttpGet]
        public IActionResult Get() => Ok(_context.Materias.ToList());

        // Obtener una materia por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Materia>> GetMateria(int id)
        {
            var materia = await _context.Materias.FindAsync(id);
            if (materia == null)
                return NotFound();

            return materia;
        }

        // Crear una nueva materia
        [HttpPost]
        public IActionResult Post([FromBody] Materia materia)
        {
            _context.Materias.Add(materia);
            _context.SaveChanges();
            return Ok(materia);
        }

        // Actualizar una materia existente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateria (int id, Materia materia)
        {
            if (id != materia.Id)
                return BadRequest();

            _context.Entry(materia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Materias.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // Eliminar una materia
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMateria(int id)
        {
            var materia = await _context.Materias.FindAsync(id);
            if (materia == null)
                return NotFound();

            _context.Materias.Remove(materia);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
