using IntegradorPIII.FE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IntegradorPIII.FE.Services
{
    public class MateriaService
    {
        private readonly HttpClient _httpClient;

        public MateriaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Listar materias (GET)
        public async Task<List<Materia>> ObtenerMateriasAsync()
        {
            var response = await _httpClient.GetAsync("api/Materias");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Materia>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // Agregar materia (POST)
        public async Task<bool> AgregarMateriaAsync(Materia materia)
        {
            var json = JsonSerializer.Serialize(materia);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Materias", content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Error: {response.StatusCode}\n{error}");
                return false;
            }

            return true;
        }

        // Actualizar materia (PUT)
        public async Task<bool> ActualizarMateriaAsync(Materia materia)
        {
            var json = JsonSerializer.Serialize(materia);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/Materias/{materia.Id}", content);
            return response.IsSuccessStatusCode;
        }

        // Eliminar materia (DELETE)
        public async Task<bool> EliminarMateriaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Materias/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
