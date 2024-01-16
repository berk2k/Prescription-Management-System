namespace se4458_final.Models.Dto
{
    public class PrescriptionDto
    {
        public int Id { get; set; }
        public int Tc { get; set; }

        public string PharmacyName { get; set; }
        public string FullName { get; set; }

        public string MedicineName { get; set; }

        public float Price { get; set; }

        public DateTime PrescriptionDate { get; set; }
    }
}
