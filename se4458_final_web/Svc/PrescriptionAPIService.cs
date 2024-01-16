using se4458_final_web.Models.Dto;

namespace se4458_final_web.Svc
{
    public class PrescriptionAPIService
    {
        private readonly HttpClient _httpClient;

        public PrescriptionAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // Configure the base URL of your API
            _httpClient.BaseAddress = new Uri("https://localhost:7027/api/Prescription/create");
        }

        // Implement methods to interact with your API
        // Example:
        public async Task<HttpResponseMessage> CreatePrescription(PrescriptionDto prescriptionDto)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("Prescription/create", prescriptionDto);

                // Handle the response here if needed

                return response;
            }
            catch (HttpRequestException ex)
            {
                // Handle the exception (e.g., log, return a default response, etc.)
                Console.WriteLine($"HTTP request failed: {ex.Message}");
                throw;
            }
        }

    }
}
