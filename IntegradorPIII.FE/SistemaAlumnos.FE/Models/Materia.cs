using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IntegradorPIII.FE.Models
{
    public class Materia
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public int Anio { get; set; }
        public int Cuatrimestre { get; set; }
    }
}