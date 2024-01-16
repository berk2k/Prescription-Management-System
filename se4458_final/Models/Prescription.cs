using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace se4458_final.Models
{
    public class Prescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string PharmacyName { get; set; }

        public int Tc {  get; set; }

        public string FullName { get; set; }

        public string MedicineName { get; set; }

        public float Price { get; set; }

        public DateTime PrescriptionDate { get; set; }
    }
}
