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
    public class PendingSpaceRequestController : ControllerBase
    {
        private readonly IPendingRequestService _pendingRequestService;
        private readonly ILogger _logger;

        public PendingSpaceRequestController(IPendingRequestService managerService, ILogger<PendingSpaceRequestController> logger)
        {
            _pendingRequestService = managerService;
            _logger = logger;
        }

        [HttpPost("GetPendingSpaceRequest")]
        public async Task<GetPendingSpaceResponse> GetPendingSpaceRequest([FromBody] GetPendingSpaceRequest getPendingSpaceRequest)
        {
            _logger.LogInformation($"GetPendingSpaceRequest endpint invoked for.");
            var res = await _pendingRequestService.GetPendingSpaceRequest(getPendingSpaceRequest);
            _logger.LogInformation($"GetPendingSpaceResponse response created successfully, found {res?.AllPendingSpaceRequests?.Count} records");
            return res;
        }
    }
}
