using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarWash_BAL;
using CarWash_DAL.Data;
using CarWash_BAL.Services;
namespace CarWashWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   
    public class UserProfileController : ControllerBase
    {
        /// <summary>
        ///   
        /// </summary>
        private readonly UserService userService;
        private readonly CarService carService;
        public UserProfileController(UserService _userService, CarService _carService)
        {

            userService = _userService;
            carService = _carService;
        }
        [HttpPost]
        [Route("AddUser")] 
        public async Task<IActionResult> AddUser([FromBody] UserProfile user)
        {
            try
            {
                await userService.CreateUser(user);
            }
            catch(Exception)
            {
                throw;
            }
            return Ok(user);
        }
        [HttpGet]
        [Route("GetUserbyEmail")]
        public async Task<IActionResult> GetUserbyEmail(string email)
        {
            try
            {
                var user = await userService.GetUserbyEmail(email);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("AddAddress")]
        public async Task<IActionResult> AddAddress([FromBody] Address cwaddress)
        {
            if (cwaddress == null)
            {
                return null;
            }
            await userService.AddAddress(cwaddress);
            return Ok(cwaddress);
        }
        [HttpGet]
        [Route("GetAddressbyEmail")]
        public async Task<IActionResult> GetAddressbyEmail(string email)
        {
            try
            {
                var user = await userService.GetAddressByEmail(email);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("AddCar")]
        public async Task<IActionResult> AddCar([FromBody] CarDetails cwcar)
        {
            if (cwcar == null)
            {
                return null;
            }
            await carService.AddCar(cwcar);
            return Ok(cwcar);
        }
        [HttpGet]
        [Route("GetCarsbyEmail")]
        public async Task<IActionResult> GetCarsbyId(string email)
        {
            try
            {
                var user = await carService.GetCarsbyId(email);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetAllCars")]
        public async Task<IActionResult> GetAllCars()
        {
           try
            {
                var cars = await carService.GetCarDetails();
                return Ok(cars);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
