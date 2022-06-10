using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWash_BAL;
using CarWash_BAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarWashWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserService userservice;
        private readonly WashRequestService washrequestservice;

        public AdminController(UserService _userservice, WashRequestService _washrequestservice)
        {
            userservice = _userservice;
            washrequestservice = _washrequestservice;
        }

        [HttpGet]
        [Route("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var customers = await userservice.GetAllCustomers();
                return Ok(customers);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("GetAllWashers")]
        public async Task<IActionResult> GetAllWashers()
        {
            try
            {
                var washers = await userservice.GetAllWashers();
                return Ok(washers);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("GetAllWashRequests")]
        public async Task<IActionResult> GetAllWashRequests()
        {
            try
            {
                var washrequests = await washrequestservice.getWashRequestDetails();
                return Ok(washrequests);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
