using se4458_final.Models;

namespace se4458_final.Source.Svc
{
    public interface IMedicineService
    {
        public List<string> GetMedicineByName(string name);

        
    }
}
