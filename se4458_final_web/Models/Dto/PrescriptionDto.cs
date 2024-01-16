namespace se4458_final_web.Models.Dto
{
    public class PrescriptionDto
    {
        public int Id { get; set; }
        public int Tc { get; set; }

        public string FullName { get; set; }

        public string MedicineName { get; set; }

        public float Price { get; set; }
    }
}
