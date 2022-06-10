using System;
using System.Threading.Tasks;
using CarWash_DAL.Data;
using CarWash_DAL.Interface;
using CarWash_DAL.Models;
namespace CarWash_BAL.Services
{
    public class WashNowService
    {
        public readonly IWashRepository<CwwashNow> washRepository;
        public WashNowService(IWashRepository<CwwashNow> _washRepository)
        {
            washRepository = _washRepository;
        }
        public async Task<CwwashNow> washRequest(washNow wash)
        {
            try
            {
                var user = await washRepository.washRequest(wash);
                if (user == null)
                {
                    return null;
                }
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
