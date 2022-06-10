using System.Threading.Tasks;
using CarWash_DAL.Data;
using CarWash_DAL.Models;
namespace CarWash_DAL.Interface
{
    public interface ILoginRepository<T>
    {
        /// <summary>
        ///  The following methods are declared for User Authentication
        ///     1) CustomerLogin Method has paramter of Login Class and fetch the Customer data from the database
        ///     2) WasherLogin Method has paramter of Login Class and fetch the Customer data from the database        ///
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>userProfile</returns>
        /// <param name="Washer"></param>
        /// <returns>userProfile</returns>
        Task<CwuserProfile> CustomerLogin(Login customer);
        Task<CwuserProfile> WasherLogin(Login washer);
    }
 }
