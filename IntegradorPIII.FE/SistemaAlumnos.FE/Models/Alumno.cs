using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorPIII.FE.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Legajo { get; set; }
        public DateTime FechaNacimiento { get; set; }

    }
}
