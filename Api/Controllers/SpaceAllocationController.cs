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
    public class SpaceAllocationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ISpaceAllocationService _spaceAllocation;

        public SpaceAllocationController( ILogger<SpaceAllocationController> logger, ISpaceAllocationService spaceAllocation)
        {
            _logger = logger;
            _spaceAllocation = spaceAllocation;
        }

        [HttpGet]
        
        public async Task<AllocatedSpaceResponse> GetAllocatedSpace (Guid userId)
        {
            _logger.LogInformation($"GetAllocatedSpace endpint invoked for {userId}");
            var res = await _spaceAllocation.GetSpaceAllocationForUser(userId);
            _logger.LogInformation($"Space allocation response created successfully, found {res?.AllocatedSpaces?.Count} records");
            return res;
        }
    }
}
