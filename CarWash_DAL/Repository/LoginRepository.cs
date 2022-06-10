using System.Linq;
using System.Threading.Tasks;
using CarWash_DAL.Interface;
using CarWash_DAL.Models;
using Microsoft.EntityFrameworkCore;
using CarWash_DAL.Data;
namespace CarWash_DAL.Repository
{
    public class LoginRepository : ILoginRepository<CwuserProfile>
    {
        private readonly CarWashDBContext carWashDatabaseContext;
        public LoginRepository(CarWashDBContext _carWashDatabaseContext)
        {
            carWashDatabaseContext = _carWashDatabaseContext;
        }
        public async Task<CwuserProfile> CustomerLogin(Login customer)
        {
            var Role = new Login()
            {
                UserEmail = customer.UserEmail,
                UserPassword = customer.UserPassword,
                UserRole = "Customer"
            };
            var user = await carWashDatabaseContext.CwuserProfiles.Where(x => x.UserEmail == Role.UserEmail && x.UserPassword == Role.UserPassword && x.UserRole == Role.UserRole)

                .Select(x => new CwuserProfile
                {
                    UserId = x.UserId,
                    UserFirstName = x.UserFirstName,
                    UserEmail = x.UserEmail,
                    UserMobileNumber = x.UserMobileNumber,
                    UserLastName = x.UserLastName,
                    UserRole = x.UserRole,
                    UserGender = x.UserGender,
                    UserCreatedDate = x.UserCreatedDate
                }).FirstOrDefaultAsync();
            return user;
        }
        public async Task<CwuserProfile> WasherLogin(Login washer)
        {
            var Role = new Login()
            {
                UserEmail = washer.UserEmail,
                UserPassword = washer.UserPassword,
                UserRole = "Washer"
            };
            var user = await carWashDatabaseContext.CwuserProfiles.Where(x => x.UserEmail == Role.UserEmail && x.UserPassword == Role.UserPassword && x.UserRole == Role.UserRole)
                .Select(x => new CwuserProfile
                {
                    UserId = x.UserId,
                    UserFirstName = x.UserFirstName,
                    UserEmail = x.UserEmail,
                    UserMobileNumber = x.UserMobileNumber,
                    UserLastName = x.UserLastName,
                    UserRole = x.UserRole,
                    UserGender = x.UserGender,
                    UserCreatedDate = x.UserCreatedDate
                }).FirstOrDefaultAsync();
            return user;
        }

    }
}
