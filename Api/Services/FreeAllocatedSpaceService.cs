using Api.Models;
using Api.Models.Requests;
using Api.Models.Responses;
using Api.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Api.Services
{
    public class FreeAllocatedSpaceService : IFreeAllocatedSpaceService
    {
        private const string _procDeleteUserOfficeSeatAllocationDetail = "[dbo].[DeleteUserOfficeSeatAllocationDetail]";

        private readonly ILogger _logger;
        private readonly OfficeSpaceAllocationContext _officeSpaceAllocationContext;

        public FreeAllocatedSpaceService(ILogger<LoginService> logger, OfficeSpaceAllocationContext officeSpaceAllocationContext)
        {
            _logger = logger;
            _officeSpaceAllocationContext = officeSpaceAllocationContext;
        }

        public async Task<FreeAllocatedSpaceResponse> FreeAllocatedSpace(FreeAllocatedSpaceRequest freeAllocatedSpaceRequest)
        {
            FreeAllocatedSpaceResponse response = null;
            try
            {
                _logger.LogInformation($"Freeing space for '{freeAllocatedSpaceRequest.UserKey}' user key.");
                var sqlParams = new[] { new SqlParameter("@UserKey", freeAllocatedSpaceRequest.UserKey),
                                        new SqlParameter("@OfficeSeatDetailKey", freeAllocatedSpaceRequest.OfficeSeatDetailKey),
                                        new SqlParameter("@AllocationDateTime", freeAllocatedSpaceRequest.AllocatedDateTime),};

                var result = await _officeSpaceAllocationContext.SelectTable(_procDeleteUserOfficeSeatAllocationDetail, sqlParams);

                if (result?.Rows?.Count > 0)
                    response = new FreeAllocatedSpaceResponse() { UserKey = freeAllocatedSpaceRequest.UserKey, Comment = $"Space freed up successfully", IsError = false };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while freeing up allocated space for {freeAllocatedSpaceRequest.UserKey}");
                response = new FreeAllocatedSpaceResponse() { IsError = true, Comment = $"{ex.Message}" };
            }
            return response;
        }
    }
}
