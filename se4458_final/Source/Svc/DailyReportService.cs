namespace se4458_final.Source.Svc
{
    public class DailyReportService : BackgroundService
    {
        private readonly IEmailService _emailService;
        private readonly IPrescriptionService _rescriptionService;

        public DailyReportService(IEmailService emailService, IPrescriptionService rescriptionService)
        {
            _emailService = emailService;
            _rescriptionService = rescriptionService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
               
                var now = DateTime.Now;
                var nextRunTime = new DateTime(now.Year, now.Month, now.Day, 1, 0, 0).AddDays(1);

                
                var delay = nextRunTime - now;

                
                await Task.Delay(delay, stoppingToken);

                
                await SendDailyReportsAsync();
            }
        }

        public async Task SendDailyReportsAsync()
        {
            var currentDate = DateTime.Today;
            var prescriptions = _rescriptionService.GetPrescriptionsForDate(currentDate);

            // Group prescriptions by pharmacy
            var prescriptionsByPharmacy = prescriptions.GroupBy(p => p.PharmacyName);

            // Send email reports for each pharmacy
            foreach (var pharmacyGroup in prescriptionsByPharmacy)
            {
                var pharmacyName = pharmacyGroup.Key;
                var prescriptionCount = pharmacyGroup.Count();
                var totalAmount = pharmacyGroup.Sum(p => p.Price);

                var emailBody = $"To: {pharmacyName}\nYou have submitted {prescriptionCount} prescriptions today.\nTotal amount is {totalAmount} TL.";

                // Send email
                await _emailService.SendEmailAsync(pharmacyName, "Daily Prescription Report", emailBody);
            }
        }
    }
}
