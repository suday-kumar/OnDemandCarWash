using System.Threading.Tasks;
using CarWash_DAL.Interface;
using CarWash_DAL.Models;
using CarWash_DAL.Data;
namespace CarWash_BAL.Services
{
    public class LoginService
    {
        public readonly ILoginRepository<CwuserProfile> loginRepository;
        public LoginService(ILoginRepository<CwuserProfile> _loginRepository)
        {
            loginRepository = _loginRepository;
        }
        public async Task<CwuserProfile> CustomerLogin(Login login)
        {
            return await loginRepository.CustomerLogin(login);
        }
        public async Task<CwuserProfile> WasherLogin(Login login)
        {
            return await loginRepository.WasherLogin(login);
        }
    }
}
