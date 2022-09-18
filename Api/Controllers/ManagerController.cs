using Api.Models.Requests;
using Api.Models.Responses;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Api.Filters;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionFilter]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;
        private readonly ILogger _logger;

        public ManagerController(IManagerService managerService, ILogger<ManagerController> logger)
        {
            _managerService = managerService;
            _logger = logger;
        }

        [HttpPost("GetNextLevelUserInfoWithTotalTeamCount")]
        public async Task<GetSubOrdinateResponse> GetNextLevelUserInfoWithTotalTeamCount([FromBody] GetSubOrdinateRequest getSubOrdinateRequest)
        {
            _logger.LogInformation($"GetNextLevelUserInfoWithTotalTeamCount endpint invoked for.");
            var res = await _managerService.GetNextLevelUserInfoWithTotalTeamCountSubOrdinateDetails(getSubOrdinateRequest);
            _logger.LogInformation($"GetSubOrdinateResponse response created successfully, found {res?.SubOrdinates?.Count} records");
            return res;
        }
    }
}
