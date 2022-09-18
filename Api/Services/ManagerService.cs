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
    public class ManagerService : IManagerService
    {
        private const string _procGetNextLevelUserInfoWithTotalTeamCount = "[dbo].[GetNextLevelUserInfoWithTotalTeamCount]";

        private readonly ILogger _logger;
        private readonly Settings _setting;
        private readonly OfficeSpaceAllocationContext _officeSpaceAllocationContext;

        public ManagerService(ILogger<ManagerService> logger, IOptions<Settings> settings, OfficeSpaceAllocationContext officeSpaceAllocationContext)
        {
            _logger = logger;
            _setting = settings.Value;
            _officeSpaceAllocationContext = officeSpaceAllocationContext;
        }
        public async Task<GetSubOrdinateResponse> GetNextLevelUserInfoWithTotalTeamCountSubOrdinateDetails(GetSubOrdinateRequest getSubOrdinateRequest)
        {
            GetSubOrdinateResponse getSubOrdinateResponse = null;
            try
            {
                _logger.LogInformation($"Fetching all immediate next level subordinates of '{getSubOrdinateRequest.UserKey}' user.");

                var sqlParams = new[] { new SqlParameter("@UserKey", getSubOrdinateRequest.UserKey) };
                var result = await _officeSpaceAllocationContext.SelectTable(_procGetNextLevelUserInfoWithTotalTeamCount, sqlParams);

                if (result?.Rows?.Count > 0)
                {
                    var immediateNextLevelSubOrdinatesList = result.AsEnumerable().Select(_ =>
                        new SubOrdinate()
                        {
                            FullName = _.Field<string>("FullName"),
                            OECode = _.Field<string>("OECode"),
                            TeamCount = _.Field<int>("TeamCount"),
                            FullNameWithOeCode = $"{_.Field<string>("FullName")} ({_.Field<string>("OECode")})"
                        }); ;

                    getSubOrdinateResponse = new GetSubOrdinateResponse() { UserKey = getSubOrdinateRequest.UserKey, SubOrdinates = immediateNextLevelSubOrdinatesList.ToList(), Comment = string.Empty, HasError = false };
                }
                else
                {
                    _logger.LogWarning($"No immediate subordinate for '{getSubOrdinateRequest.UserKey}'");
                    getSubOrdinateResponse = new GetSubOrdinateResponse() { HasError = false, Comment = $"No Subordinate records found for '{getSubOrdinateRequest.UserKey}'" };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while fetching subordinate details for '{getSubOrdinateRequest.UserKey}'");
                getSubOrdinateResponse = new GetSubOrdinateResponse() { HasError = true, Comment = ex.Message };
            }
            return getSubOrdinateResponse;
        }
    }
}
