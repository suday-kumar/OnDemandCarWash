using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWash_DAL.Models;
using CarWash_DAL.Interface;
using CarWash_DAL.Data;
using Microsoft.EntityFrameworkCore;
namespace CarWash_DAL.Repository
{
    public class CarRepository : ICarRepository<CwcarRecord>
    {
        private readonly CarWashDBContext carWashDatabaseContext;
        public CarRepository(CarWashDBContext _carWashDatabaseContext)
        {
            carWashDatabaseContext = _carWashDatabaseContext;
        }
        public async Task<string> AddCar(CarDetails cwcar)
        {
            var user = await carWashDatabaseContext.CwuserProfiles.Where(x => x.UserEmail == cwcar.Email).FirstOrDefaultAsync();
            var newCar = new CwcarRecord()
            {
                UserId = user.UserId,
                CarCompany = cwcar.CarCompany,
                CarModel = cwcar.CarModel,
                CarRegistrationNumber = cwcar.CarRegistrationNumber,
                CarColor = cwcar.CarColor,
            };
            try
            {
                if (carWashDatabaseContext != null)
                {
                    await carWashDatabaseContext.CwcarRecords.AddAsync(newCar);
                    await carWashDatabaseContext.SaveChangesAsync();
                    return user.UserEmail;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }
        public async Task<List<CarDetails>> GetCarDetails()
        {
            return await (from u in carWashDatabaseContext.CwcarRecords
                          select new CarDetails
                          {
                              CarCompany = u.CarCompany,
                              CarModel = u.CarModel,
                              CarRegistrationNumber = u.CarRegistrationNumber,
                              CarColor = u.CarColor,
                          }).ToListAsync();

        }
        public async Task<List<CarDetails>> GetCarsById(string email)
        {
            if (carWashDatabaseContext != null)
            {
                var user = await carWashDatabaseContext.CwuserProfiles.Where(x => x.UserEmail == email).FirstOrDefaultAsync();

                return await (from u in carWashDatabaseContext.CwcarRecords
                              where u.UserId == user.UserId
                              select new CarDetails
                              {
                                  CarCompany = u.CarCompany,
                                  CarModel = u.CarModel,
                                  CarRegistrationNumber = u.CarRegistrationNumber,
                                  CarColor = u.CarColor,

                              }).ToListAsync();
            }
            return null;
        }
    }
}
