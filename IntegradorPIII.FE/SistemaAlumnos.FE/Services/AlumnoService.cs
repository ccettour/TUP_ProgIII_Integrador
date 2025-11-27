using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using IntegradorPIII.FE.Models;

namespace IntegradorPIII.FE.Services
{
    public class AlumnoService
    {
        private readonly HttpClient _httpClient;

        public AlumnoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obtener lista de alumnos (GET)
        public async Task<List<Alumno>> ObtenerAlumnosAsync()
        {
            var response = await _httpClient.GetAsync("api/Alumnos");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Alumno>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // Agregar alumno (POST)
        public async Task<bool> AgregarAlumnoAsync(Alumno alumno)
        {
            var json = JsonSerializer.Serialize(alumno);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Alumnos", content);
            return response.IsSuccessStatusCode;
        }

        // Actualizar alumno (PUT)
        public async Task<bool> ActualizarAlumnoAsync(Alumno alumno)
        {
            var json = JsonSerializer.Serialize(alumno);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/Alumnos/{alumno.Id}", content);
            return response.IsSuccessStatusCode;
        }

        // Eliminar alumno (DELETE)
        public async Task<bool> EliminarAlumnoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Alumnos/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
