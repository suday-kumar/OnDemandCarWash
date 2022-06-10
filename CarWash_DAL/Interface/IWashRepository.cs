using System.Threading.Tasks;
using CarWash_DAL.Data;
namespace CarWash_DAL.Interface
{
    public interface IWashRepository<T>
    {
        /// <summary>
        /// This Interface Declares Methods to Send Wash Request to the Washer
        /// </summary>
        /// <param name="wash"></param>
        Task<T> washRequest(washNow wash);
    }
}
