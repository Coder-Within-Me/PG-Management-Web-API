using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PGManagement.Exception_Handling;
using PGManagement.Models.DTO;
using PGManagement.Models.Response;
using PGManagement.Respository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PGManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _admin;
        private readonly ILogger<AdminController> _logger;
        public AdminController(IAdmin admin, ILogger<AdminController> logger)
        {
            _admin = admin;
            _logger = logger;
        }

        
        [HttpGet("GetAllData/{pagenumber}/{pagesize}")]
        public async Task<IActionResult> GetAllData([FromRoute] int pagenumber, [FromRoute] int pagesize)
        {
            _logger.LogInformation("PageNumber : " + pagenumber + " PageSize : " + pagesize);
            var data = await _admin.GetAllData(pagenumber,pagesize);
            return Ok(JsonConvert.SerializeObject(data));
        }

        //[ApiVersion("1.0")]
        [HttpGet("GetMasterData")]
        //[HttpGet("GetMasterData/{v:apiVersion}")]
        public async Task<IActionResult> GetMasterData()
        {
            _logger.LogInformation("Called GetMasterData Function.");
            var data = await _admin.GetMasterData();
            _logger.LogInformation("Returning these details :" + data);
            return Ok(JsonConvert.SerializeObject(data));
        }

        [HttpPost("CreateNew")]
        public async Task<IActionResult> CreateNew([FromBody]CreateNewGuestDTO FormData)
        {
            var data = await _admin.CreateNew(FormData);
            _logger.LogInformation("Called CreateNew Method to insert new record.");
            return Ok(JsonConvert.SerializeObject(data));
        }

    }
}
