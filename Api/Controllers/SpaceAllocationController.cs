using Api.Models.Requests;
using Api.Models.Responses;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Api.Filters.ExceptionFilter]
    public class SpaceAllocationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ISpaceAllocationService _spaceAllocation;

        public SpaceAllocationController( ILogger<SpaceAllocationController> logger, ISpaceAllocationService spaceAllocation)
        {
            _logger = logger;
            _spaceAllocation = spaceAllocation;
        }

        [HttpPost]
        public async Task<AllocatedSpaceResponse> GetAllocatedSpace ([FromBody] GetAllocatedSpaceRequest request)
        {
            _logger.LogInformation($"GetAllocatedSpace endpint invoked for {request}");
            var res = await _spaceAllocation.GetSpaceAllocationForUser(request);
            _logger.LogInformation($"Space allocation response created successfully, found {res?.AllocatedSpaces?.Count} records");
            return res;
        }

        [HttpPost("AllocateSpace")]
        public async Task<AllocationResponse> AllocateSpace([FromBody] AllocateSpaceRequest request)
        {
            _logger.LogInformation($"AllocateSpace endpint invoked for {request}");
            var res = await _spaceAllocation.AllocateSpace(request);
            _logger.LogInformation($"Space allocation response created successfully");
            return res;
        }


        [HttpPost("AllocateSeats")]
        public async Task<AllocationResponse> AllocateSeats([FromBody] AllocateSeatRequest request)
        {
            _logger.LogInformation($"AllocateSeats endpint invoked for {request}");
            var res = await _spaceAllocation.AllocateSeats(request);
            _logger.LogInformation($"Space allocation response created successfully");
            return res;
        }

    }
}
