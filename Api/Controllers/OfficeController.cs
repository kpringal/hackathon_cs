using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Api.Filters;
using Microsoft.Extensions.Logging;
using Api.Models.Requests;
using Api.Models.Responses;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionFilter]
    public class OfficeController : Controller
    {
        private readonly IOfficeService _officeService;
        private readonly ILogger _logger;

        public OfficeController(IOfficeService officeService, ILogger<OfficeController> logger)
        {
            _officeService = officeService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<InsertOfficeResponse> InsertOffice(InsertOfficeRequest officeRequest)
        {
            _logger.LogInformation($"Office creation endpint invoked for {officeRequest}");
            var insertOfficeResponse = await _officeService.CreateOfficePremise(officeRequest);
            _logger.LogInformation($"Office created successfully");
            return insertOfficeResponse;
        }

        [HttpGet("GetAllOfficeDetails")]
        public async Task<AllOfficeDetailsResponse>GetAllOfficeDetails()
        {
            _logger.LogInformation($"GetAllOfficeDetails endpint invoked for.");
            var res = await _officeService.GetAllOfficeDetails();
            _logger.LogInformation($"AllOfficeDetailsResponse response created successfully, found {res?.AllOfficeDetails?.Count} records");
            return res;
        }
    }
}
