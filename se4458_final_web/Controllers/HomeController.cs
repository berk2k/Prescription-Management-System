using Microsoft.AspNetCore.Mvc;
using se4458_final_web.Svc;
using System.Threading.Tasks;
using se4458_final_web.Models.Dto;
using se4458_final_web.Svc;
using System.Net.Http;
using se4458_final_web.Models.ViewModel;

namespace se4458_final_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://your-api-base-url");
        }

        public async Task<IActionResult> Index()
        {
            var prescriptions = await _httpClient.GetFromJsonAsync<PrescriptionViewModel[]>("api/Prescription");
            return View(prescriptions);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PrescriptionDto prescriptionDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("api/Prescription/create", prescriptionDto);
                response.EnsureSuccessStatusCode();

                return RedirectToAction(nameof(Index));
            }

            return View(prescriptionDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var prescription = await _httpClient.GetFromJsonAsync<PrescriptionViewModel>($"api/Prescription/{id}");
            return View(prescription);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, PrescriptionDto updatedPrescriptionDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Prescription/update/{id}", updatedPrescriptionDto);
                response.EnsureSuccessStatusCode();

                return RedirectToAction(nameof(Index));
            }

            return View(updatedPrescriptionDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var prescription = await _httpClient.GetFromJsonAsync<PrescriptionViewModel>($"api/Prescription/{id}");
            return View(prescription);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Prescription/delete/{id}");
            response.EnsureSuccessStatusCode();

            return RedirectToAction(nameof(Index));
        }
    }
}
