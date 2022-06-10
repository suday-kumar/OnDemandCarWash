using System.Collections.Generic;
using System.Threading.Tasks;
using CarWash_DAL.Data;
using CarWash_DAL.Interface;
namespace CarWash_BAL.Services
{
    public class WashRequestService
    {
        public readonly IWashRequest<WashRequest> washrequestRepository;
        public WashRequestService(IWashRequest<WashRequest> _washrequestRepository)
        {
            washrequestRepository = _washrequestRepository;
        }
        public async Task<List<WashRequest>> getWashRequestDetails()
        {
            var requestDetails = await washrequestRepository.getWashRequestDetails();
            return requestDetails;
        }
        public async Task<List<WashRequest>> getWashRequestByEmail(string email)
        {
            var requestDetails = await washrequestRepository.getWashRequestByEmail(email);
            return requestDetails;
        }
        public string AcceptRequest(string carNum)
        {
            return washrequestRepository.AcceptRequest(carNum);
        }
        public string RejectRequest(string carNum)
        {
            return washrequestRepository.RejectRequest(carNum);
        }
    }
}
