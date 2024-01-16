using se4458_final.Models;
using se4458_final.Models.Dto;

namespace se4458_final.Source.Svc
{
    public interface IPrescriptionService
    {
        public int CreatePrescription(PrescriptionDto prescriptionDto);

        public void DeletePrescription(int id);

        public void UpdatePrescription(PrescriptionDto updatedPrescriptionDto);

        public List<Prescription> GetPrescriptionsForDate(DateTime currentDate);
    }
}
