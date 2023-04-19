using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PGManagement.Respository;

namespace PGManagement.Controllers
{
    [Route("api/[controller]/{v:apiVersion}")]
    [ApiController]
    [ApiVersion("2.0")]
    public class ApiVersionController : ControllerBase
    {
        private readonly IAdmin _admin;
        public ApiVersionController(IAdmin admin)
        {
            _admin = admin;
        }

        [HttpGet("GetMasterData")]
        public async Task<IActionResult> GetMasterData()
        {
            var data = await _admin.GetMasterData();
            return Ok(JsonConvert.SerializeObject(data));
        }
    }
}
