using System.Collections.Generic;
using System.Threading.Tasks;
using CarWash_DAL.Data;
namespace CarWash_DAL.Interface
{
    public interface IUserRepository<T>
    {
        /// <summary>
        ///     The following methods performs operations on usertable
        ///     1) CreateUser Method has paramter UserProfile Class and inserts the user data in th database
        ///     2) AddAddress Method has paramter Address Class and inserts the user address in th database
        ///     3)  GetUserbyEmail Method takes user email as paramter and fetch the record from database
        ///     4) GetAddressbyEmail Method takes user email as paramter and fetch the address record from database
        /// </summary> 
        Task<T> CreateUser(UserProfile user);
        Task<List<UserProfile>> GetAllCustomers();
        Task<List<UserProfile>> GetAllWashers();

        Task<string> AddAddress(Address address);
        Task<UserProfile> GetUserbyEmail(string email);
        Task<Address> GetAddressbyEmail(string email);
    }
}
