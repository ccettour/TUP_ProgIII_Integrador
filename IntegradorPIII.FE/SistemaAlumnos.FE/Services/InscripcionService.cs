using IntegradorPIII.FE.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace IntegradorPIII.FE.Services
{
    public class InscripcionService
    {
        private readonly HttpClient _httpClient;

        public InscripcionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<(bool Exito, string Mensaje)> InscribirAlumnoAsync(Inscripcion inscripcion)
        {
            try
            {
                var json = JsonSerializer.Serialize(inscripcion);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/Inscripciones", content);

                var cuerpo = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return (true, "Inscripción realizada correctamente.");
                }

                return (false, $"Error {response.StatusCode}: {cuerpo}");
            }
            catch (HttpRequestException ex)
            {
                return (false, "Error de comunicación con el servidor: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return (false, "Error inesperado: " + ex.Message);
            }
        }

        public async Task<List<Inscripcion>> ObtenerInscripcionesAsync()
        {
            var response = await _httpClient.GetAsync("api/Inscripciones");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<Inscripcion>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<bool> EliminarInscripcionAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Inscripciones/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
