using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarWash_DAL.Data;
using CarWash_DAL.Models;
using CarWash_DAL.Interface;
namespace CarWash_BAL.Services
{
    public class CarService
    {
        public readonly ICarRepository<CwcarRecord> carRepository;
        public CarService(ICarRepository<CwcarRecord> _carRepository)
        {
            carRepository = _carRepository;
        }
        public async Task<string> AddCar(CarDetails car)
        {
            try
            {
                if (car == null)
                {
                    throw new ArgumentNullException(nameof(car));
                }
                else
                {
                    await carRepository.AddCar(car);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return car.Email;
        }
        public async Task<List<CarDetails>> GetCarDetails()
        {
            var cardetails = await carRepository.GetCarDetails();

            return cardetails;
        }
        public async Task<List<CarDetails>> GetCarsbyId(string email)
        {
            try
            {
                var user = await carRepository.GetCarsById(email);
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

