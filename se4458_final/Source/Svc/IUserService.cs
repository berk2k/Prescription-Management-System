using se4458_final.Models;

namespace se4458_final.Source.Svc
{
    public interface IUserService
    {
        public User GetUserByTc(int tc);
    }
}
