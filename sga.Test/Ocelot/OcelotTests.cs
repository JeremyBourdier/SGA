using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace sga.Test.Ocelot
{
    public class OcelotRealIntegrationTests
    {
        private readonly HttpClient _client;

        public OcelotRealIntegrationTests()
        {
            // Apunta al Gateway real
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5255")
            };
        }

        [Fact]
        public async Task GetStudent_ShouldReturnOk()
        {
            // Llamamos a /academic/Student
            // microservicio real: academic -> Student
            var response = await _client.GetAsync("/academic/Student");

            // Si no están levantados Ocelot y el microservicio,
            // aquí podría fallar con “Connection refused”.
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var json = await response.Content.ReadAsStringAsync();
            Assert.False(string.IsNullOrEmpty(json), "Debería haber data de Student");
        }

        [Fact]
        public async Task GetCourse_ShouldReturnOk()
        {
            // Verifica endpoint /academic/Course
            var response = await _client.GetAsync("/academic/Course");
            // Esperamos 200 OK
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("credits", content);
        }

        [Fact]
        public async Task GetPermission_ShouldReturnOk()
        {
            // Llamamos /auth/Permission 
            // se reenvía a microservicio Auth en 5096 /api/Permission
            var response = await _client.GetAsync("/auth/Permission");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("Allows", content);
        }
    }
}
