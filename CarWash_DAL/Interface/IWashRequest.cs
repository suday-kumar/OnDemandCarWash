using System.Collections.Generic;
using System.Threading.Tasks;
using CarWash_DAL.Data;
namespace CarWash_DAL.Interface
{
    public interface IWashRequest<T>
    {
        /// <summary>
        /// This Interface has Methods to Manage Wash Requests
        /// 1)getWashRequestDetails Method will return all records from WahRequest Table
        /// 2)getWashRequestByEmail Method to fetch particular Customer's Wash by taking Email as a parameter
        /// 3)AcceptRequest & RejectRequest Methods will return the Status of the Wash Requests
        /// /// </summary>
        Task<List<WashRequest>> getWashRequestDetails();
        Task<List<WashRequest>> getWashRequestByEmail(string email);
        string AcceptRequest(string carNum);
        string RejectRequest(string carNum);
    }
}
