using Microsoft.EntityFrameworkCore;
using se4458_final.Context;
using se4458_final.Models;
using se4458_final.Models.Dto;

namespace se4458_final.Source.Svc
{
    public class PrescriptionService : IPrescriptionService
    {

        private readonly PharmacyDbContext _pharmacyDb;

        public PrescriptionService(PharmacyDbContext pharmacyDb)
        {
            _pharmacyDb = pharmacyDb;


        }
        public int CreatePrescription(PrescriptionDto prescriptionDto)
        {
            try
            {
                var prescription = new Prescription
                {
                    Tc = prescriptionDto.Tc,
                    PharmacyName = prescriptionDto.PharmacyName,
                    FullName = prescriptionDto.FullName,
                    MedicineName = prescriptionDto.MedicineName,
                    Price = prescriptionDto.Price,
                    PrescriptionDate = prescriptionDto.PrescriptionDate
                };

                _pharmacyDb.Prescriptions.Add(prescription);
                _pharmacyDb.SaveChanges();

                return prescription.Id;
            }
            catch (DbUpdateException ex)
            {
                // Log or print the inner exception details
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");

                // Handle the exception or rethrow if necessary
                throw;
            }
        }


        public void DeletePrescription(int id)
        {
            
            var prescription = _pharmacyDb.Prescriptions.Find(id);

            if (prescription != null)
            {
                
                _pharmacyDb.Prescriptions.Remove(prescription);
                _pharmacyDb.SaveChanges();
            }
        }

        public void UpdatePrescription(PrescriptionDto updatedPrescriptionDto)
        {
            
            var existingPrescription = _pharmacyDb.Prescriptions.Find(updatedPrescriptionDto.Id);

            if (existingPrescription != null)
            {
                
                existingPrescription.Tc = updatedPrescriptionDto.Tc;
                existingPrescription.FullName = updatedPrescriptionDto.FullName;
                existingPrescription.MedicineName = updatedPrescriptionDto.MedicineName;
                existingPrescription.Price = updatedPrescriptionDto.Price;

                
                _pharmacyDb.SaveChanges();
            }
        }

        public List<Prescription> GetPrescriptionsForDate(DateTime currentDate)
        {
            // Assuming you have a PrescriptionDate column in your Prescription model
            return _pharmacyDb.Prescriptions
                .Where(p => p.PrescriptionDate.Date == currentDate.Date)
                .ToList();
        }
    }
}
