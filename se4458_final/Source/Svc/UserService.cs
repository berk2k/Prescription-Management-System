using se4458_final.Context;
using se4458_final.Models;

namespace se4458_final.Source.Svc
{
    public class UserService : IUserService
    {

        private readonly PharmacyDbContext _pharmacyDb;

        public UserService(PharmacyDbContext pharmacyDb)
        {
            _pharmacyDb = pharmacyDb;
            

        }
        public User GetUserByTc(int tc)
        {
            throw new NotImplementedException();
        }
    }
}
