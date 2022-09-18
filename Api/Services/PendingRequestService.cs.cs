using Api.Helper;
using Api.Models;
using Api.Models.Requests;
using Api.Models.Responses;
using Api.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class PendingRequestService : IPendingRequestService
    {
        private const string _procGetPendingSpaceRequest = "[dbo].[GetPendingSpaceRequest]";

        private readonly ILogger _logger;
        private readonly Settings _setting;
        private readonly OfficeSpaceAllocationContext _officeSpaceAllocationContext;

        public PendingRequestService(ILogger<PendingRequestService> logger, IOptions<Settings> settings, OfficeSpaceAllocationContext officeSpaceAllocationContext)
        {
            _logger = logger;
            _setting = settings.Value;
            _officeSpaceAllocationContext = officeSpaceAllocationContext;
        }
        public async Task<GetPendingSpaceResponse> GetPendingSpaceRequest(GetPendingSpaceRequest getPendingSpaceRequest)
        {
            GetPendingSpaceResponse getPendingSpaceResponse = null;
            try
            {
                _logger.LogInformation($"Fetching all pending space allocation request for '{getPendingSpaceRequest.StartDate}' date.");

                var sqlParams = new[] { new SqlParameter("@StartDate", getPendingSpaceRequest.StartDate) };
                var result = await _officeSpaceAllocationContext.SelectTable(_procGetPendingSpaceRequest, sqlParams);

                if (result?.Rows?.Count > 0)
                {
                    var allPendingSpaceRequests = result.AsEnumerable().Select(_ =>
                        new PendingRequest()
                        {
                            SpaceRequestKey = _.Field<Guid>("SpaceRequestKey"),
                            FullName = _.Field<string>("FullName"),
                            AllocationDateTime = _.Field<DateTime>("AllocationDateTime"),
                            SeatCount = _.Field<int>("SeatCount")
                        }); ;

                    getPendingSpaceResponse = new GetPendingSpaceResponse() { AllPendingSpaceRequests = allPendingSpaceRequests.ToList(), Comment = string.Empty, HasError = false };
                }
                else
                {
                    _logger.LogWarning($"No space allocation pending request for '{getPendingSpaceRequest.StartDate}' date.");
                    getPendingSpaceResponse = new GetPendingSpaceResponse() { HasError = false, Comment = $"No space allocation pending request for '{getPendingSpaceRequest.StartDate}' date." };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while fetching space allocation pending request for '{getPendingSpaceRequest.StartDate}' date.");
                getPendingSpaceResponse = new GetPendingSpaceResponse() { HasError = true, Comment = ex.Message };
            }
            return getPendingSpaceResponse;
        }
    }
}
