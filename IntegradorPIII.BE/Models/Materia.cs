namespace IntegradorPIII.BE.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required int Anio { get; set; }
        public required int Cuatrimestre { get; set; }
    }
}
