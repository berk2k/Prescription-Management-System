// PrescriptionViewModel.cs

using se4458_final_web.Models.Dto;
using System.Collections.Generic;

namespace se4458_final_web.Models.ViewModel
{
    public class PrescriptionViewModel
    {
        public int Id { get; set; }
        public int Tc { get; set; }
        public string FullName { get; set; }

        // Collection of medications
        public List<MedicationDto> Medications { get; set; }
    }
}

