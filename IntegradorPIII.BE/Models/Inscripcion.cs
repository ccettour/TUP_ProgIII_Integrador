using IntegradorPIII.BE.Models;
using System.Text.Json.Serialization;

public class Inscripcion
{
    public int Id { get; set; }
    public int AlumnoId { get; set; }
    public int MateriaId { get; set; }
    public DateTime FechaInscripcion { get; set; } = DateTime.Now;
}