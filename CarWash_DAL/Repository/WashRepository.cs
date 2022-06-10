using System;
using System.Linq;
using System.Threading.Tasks;
using CarWash_DAL.Data;
using CarWash_DAL.Interface;
using CarWash_DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace CarWash_DAL.Repository
{
    public class WashRepository : IWashRepository<CwwashNow>
    {
        private readonly CarWashDBContext carWashDatabaseContext;
        public WashRepository(CarWashDBContext _carWashDatabaseContext)
        {
            carWashDatabaseContext = _carWashDatabaseContext;
        }
        public async Task<CwwashNow> washRequest(washNow wash)
        {
            var user = await carWashDatabaseContext.CwuserProfiles.Where(x => x.UserEmail == wash.Email).FirstOrDefaultAsync();
            var washCar = new CwwashNow()
            {
                UserId = user.UserId,
                WashNowWashNotes = wash.WashNowWashNotes,
                WashNowCarLocation = wash.WashNowCarLocation,
                WashNowSelectedCar = wash.WashNowSelectedCar,
                PackageName = wash.packageName,
                RequestStatus="Request Sent"
            };
            try
            {
                if (carWashDatabaseContext != null)
                {
                    await carWashDatabaseContext.CwwashNows.AddAsync(washCar);
                    await carWashDatabaseContext.SaveChangesAsync();
                    return washCar;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }
    }
}
