using System.Threading.Tasks;
using CarWash_BAL.Services;
using CarWash_DAL.Data;
using Microsoft.AspNetCore.Mvc;
namespace CarWashWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class washController : ControllerBase
    {
        private readonly WashNowService washService;
        private readonly WashRequestService washRequestService;
        public washController(WashNowService _washService, WashRequestService _washRequestService)
        {
            washService = _washService;
            washRequestService = _washRequestService;
        }
        [HttpPost]
        [Route("WashNow")]
        public async Task<IActionResult> WashNow([FromBody] washNow wash)
        {
            await washService.washRequest(wash);
            return Ok(wash);
        }
        [HttpGet]
        [Route("GetWashRequest")]
        public async Task<IActionResult> GetWashRequest()
        {
            var cars = await washRequestService.getWashRequestDetails();
            return Ok(cars);
        }
        [HttpGet]
        [Route("GetWashRequestByEmail")]
        public async Task<IActionResult> GetWashRequestByEmail(string email)
        {
            var cars = await washRequestService.getWashRequestByEmail(email);
            return Ok(cars);
        }
        [HttpPut]
        [Route("AcceptWash")]
        public  IActionResult AcceptRequest(string carNum)
        {
            return Ok(washRequestService.AcceptRequest(carNum));
        }
        [HttpPut]
        [Route("RejectWash")]
        public IActionResult RejectRequest(string carNum)
        {
            return Ok(washRequestService.RejectRequest(carNum));
        }
    }
}
