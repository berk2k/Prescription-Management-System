using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace se4458_final.Models
{
    public class Medicine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string MedicineName { get; set; }

        public long Barcode { get; set; }

        public string ATC { get; set; }

        public string ATCName { get; set; }
        public string CompName { get; set; }

        public string PrescriptionType { get; set; }

        public string Status { get; set; }

        public string StatusDescription { get; set; }

        public long EssentialMedicineListStatus { get; set; }

        public long KidMedicineListStatus { get; set; }

        public long NewBornMedicineListStatus { get; set; }

        public DateTime ActivityDate { get; set; }




    }
}
