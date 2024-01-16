namespace se4458_final.Models.Dto
{
    public class MedicineWithPagingDto
    {
        public int Id { get; set; }

        public string MedicineName { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
