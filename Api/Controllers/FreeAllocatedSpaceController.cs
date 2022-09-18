using Api.Models.Requests;
using Api.Models.Responses;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Api.Filters.ExceptionFilter]
    public class FreeAllocatedSpaceController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IFreeAllocatedSpaceService _freeSpaceService;

        public FreeAllocatedSpaceController(ILogger<FreeAllocatedSpaceController> logger, IFreeAllocatedSpaceService freeAllocatedSpaceService)
        {
            _logger = logger;
            _freeSpaceService = freeAllocatedSpaceService;
        }

        [HttpPost]
        public async Task<FreeAllocatedSpaceResponse> FreeAllocatedSpace([FromBody] FreeAllocatedSpaceRequest freeAllocatedSpaceRequest)
        {
            _logger.LogInformation($"FreeAllocatedSpace endpint invoked for '{freeAllocatedSpaceRequest.UserKey}'");
            var res = await _freeSpaceService.FreeAllocatedSpace(freeAllocatedSpaceRequest);
            _logger.LogInformation($"Allocated space freed up successfully for '{res.UserKey}'");
            return res;

        }
    }
}
