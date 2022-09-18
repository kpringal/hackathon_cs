using Api.Models.Requests;
using Api.Models.Responses;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoSeatAllocateController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IAutoSeatAllocationService _autoSeatAllocationService;

        public AutoSeatAllocateController( ILogger<AutoSeatAllocateController> logger, IAutoSeatAllocationService autoSeatAllocationService)
        {
            _logger = logger;
            _autoSeatAllocationService = autoSeatAllocationService;
        }

        [HttpPost]
        public async Task<AutoSeatAllocateResponse> AutoSeatAllocation([FromBody] AutoSeatAllocateRequest request)
        {
            _logger.LogInformation($"AutoSeatAllocation endpint invoked for {request}");
            var res = await _autoSeatAllocationService.AutoAllocateSeats(request);
            _logger.LogInformation($"AutoSeatAllocateResponse response created successfully");
            return res;
        }
    }
}
