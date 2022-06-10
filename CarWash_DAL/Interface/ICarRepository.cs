using System.Collections.Generic;
using System.Threading.Tasks;
using CarWash_DAL.Data;
namespace CarWash_DAL.Interface
{
    public interface ICarRepository<T>
    {
        /// <summary>
        /// This Interface has methods declared to perform operations on Customer Car Details
        /// 1)AddCar Method will insert a New Car Data in Database Table
        /// 2)GetCarDetails Method will fetch all Car Records from the database Table
        /// 3)GetCarsById Method will take paramter as Cuatomer Email to fetch particular Car details from the database Table
        /// </summary>
        /// <param name="car"> </param>
        ///     <returns> Car RegistrationNumber</returns>
        /// <param name="email"> </param>
        /// <returns>CarDetails</returns>
        Task<string> AddCar(CarDetails car);
        Task<List<CarDetails>> GetCarDetails();
        Task<List<CarDetails>> GetCarsById(string email);
    }
}
