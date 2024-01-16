using se4458_final.Models.Dto;
using se4458_final.Models.Dto;

namespace se4458_final.Source.Svc
{
    public interface IPharmaciesService
    {
        public LoginResponseDTO Login(LoginReguestDTO loginReguestDTO);
    }
}
