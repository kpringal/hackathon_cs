using Api.Models;
using Api.Models.Responses;
using Api.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class SpaceAllocationService : ISpaceAllocationService
    {
        private const string _procGetUserAllOfficeSeatAllocationDetail = "[dbo].[GetUserAllOfficeSeatAllocationDetail]";

        private readonly ILogger _logger;
        private readonly OfficeSpaceAllocationContext _officeSpaceAllocationContext;

        public SpaceAllocationService(ILogger<LoginService> logger, OfficeSpaceAllocationContext officeSpaceAllocationContext)
        {
            _logger = logger;
            _officeSpaceAllocationContext = officeSpaceAllocationContext;
        }

        public async Task<AllocatedSpaceResponse> GetSpaceAllocationForUser(Guid userId)
        {
            AllocatedSpaceResponse response = null;
            try
            {
                _logger.LogInformation($"Fetching space allocation for {userId}");
                var sqlParams = new[] { new SqlParameter("@UserKey", userId) };

                var result = await _officeSpaceAllocationContext.SelectTable(_procGetUserAllOfficeSeatAllocationDetail, sqlParams);

                if (result?.Rows?.Count > 0)
                {
                    var allocatedSpace = result.AsEnumerable().Select(_ =>
                        new AllocatedSpace()
                        {
                            AllocationDateTime = _.Field<DateTime>("AllocationDateTime"),
                            OfficeName = _.Field<string>("OfficeName"),
                            FloorName = _.Field<string>("FloorName"),
                            SeatNumber = _.Field<string>("SeatNumber"),
                            OfficeKey = _.Field<Guid>("OfficeKey"),
                            OfficeFloorDetailKey = _.Field<Guid>("OfficeFloorDetailKey"),
                            OfficeSeatDetailKey = _.Field<Guid>("OfficeSeatDetailKey"),
                            UserOfficeSeatAllocationDetailKey = _.Field<Guid>("UserOfficeSeatAllocationDetailKey"),
                        });

                    response = new AllocatedSpaceResponse() { AllocatedSpaces = allocatedSpace.ToList(), Comment = string.Empty, IsError = false };
                }
                else
                {
                    _logger.LogWarning($"No records found for {userId} userid");
                    response = new AllocatedSpaceResponse() { IsError = false, Comment = "No Records found" };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while fetching allocation space for {userId}");
                response = new AllocatedSpaceResponse() { IsError = true, Comment = ex.Message };
            }
            return response;
        }
    }
}
