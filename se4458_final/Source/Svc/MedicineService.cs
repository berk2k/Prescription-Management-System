using Microsoft.EntityFrameworkCore;
using se4458_final.Context;
using se4458_final.Models;

namespace se4458_final.Source.Svc
{
    public class MedicineService : IMedicineService
    {
        private readonly PharmacyDbContext _pharmacyDb;

        public MedicineService(PharmacyDbContext pharmacyDb)
        {
            _pharmacyDb = pharmacyDb;


        }
        public List<string> GetMedicineByName(string name)
        {
            try
            {
                var medicineNames = _pharmacyDb.Medicines_New
                    .Where(m => EF.Functions.Like(m.MedicineName, $"%{name}%"))
                    .Select(m => m.MedicineName)
                    .ToList();


                return medicineNames;
            }
            catch (Exception ex)
            {
                // Hata durumunda gerekli işlemleri yapabilirsiniz.
                throw;
            }
        }

        

    }
}
