using Microsoft.AspNetCore.Mvc;
using se4458_final.Source.Svc;
using System.Threading.Tasks;

namespace se4458_final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyReportController : ControllerBase
    {
        private readonly DailyReportService _dailyReportService;

        public DailyReportController(DailyReportService dailyReportService)
        {
            _dailyReportService = dailyReportService;
        }

        [HttpPost("trigger")]
        public IActionResult TriggerDailyReport()
        {
            
            Task.Run(() => _dailyReportService.SendDailyReportsAsync());

            return Ok("Daily report generation triggered.");
        }
    }
}

