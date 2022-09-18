using Api.Models;
using Api.Models.Requests;
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
        private const string _procGetUserAllOfficeSeatAllocationDetail = "[dbo].[GetUserOfficeSeatAllocationDetailForDay]";
        private const string _insertUserOfficeSeatAllocationDetails = "[dbo].[InsertUserOfficeSeatAllocationDetails]";
        private const string _insertUserOfficeSeatAllocationDetail = "[dbo].[InsertUserOfficeSeatAllocationDetail]";

        private readonly ILogger _logger;
        private readonly OfficeSpaceAllocationContext _officeSpaceAllocationContext;

        public SpaceAllocationService(ILogger<LoginService> logger, OfficeSpaceAllocationContext officeSpaceAllocationContext)
        {
            _logger = logger;
            _officeSpaceAllocationContext = officeSpaceAllocationContext;
        }

        public async Task<AllocationResponse> AllocateSeats(AllocateSeatRequest request)
        {
            AllocationResponse response;
            if (string.IsNullOrEmpty(request.UserName) || request.StartAllocationDateTime < DateTime.Now)
            {
                response = new AllocationResponse() { Comment = "Invalide seat allocation request, UserName is empty or StartAllocationDate is less then current time" };
                _logger.LogWarning(response.Comment);
            }
            else
            {
                _logger.LogInformation($"Allocating requested Seat");
                var sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("@UserKey", request.UserKey));
                sqlParams.Add(new SqlParameter("@UserName", request.UserName));
                sqlParams.Add(new SqlParameter("@EndAllocationDateTime", request.EndAllocationDateTime));
                sqlParams.Add(new SqlParameter("@StartAllocationDateTime", request.StartAllocationDateTime));
                sqlParams.Add(new SqlParameter("@OfficeSeatDetailKeys", request.OfficeSeatDetailKeys));
                var result = await _officeSpaceAllocationContext.SaveToTable(_insertUserOfficeSeatAllocationDetails, sqlParams.ToArray());
                if (result > 0)
                    response = new AllocationResponse() { Comment = "Seat allocates successfully", HasError = false };
                else
                    response = new AllocationResponse() { Comment = "Something wrong with seat allocation ", HasError = true };
            }
            return response;
        }
        public async Task<AllocationResponse> AllocateSpace(AllocateSpaceRequest request)
        {
            AllocationResponse response;
            if (string.IsNullOrEmpty(request.UserName) || request.StartAllocationDateTime < DateTime.Now)
            {
                response = new AllocationResponse() { Comment = "Invalide space request, UserName is empty or StartAllocationDate is less then current time" };
                _logger.LogWarning(response.Comment);
            }
            else
            {
                _logger.LogInformation($"Allocating requested Space");
                var sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("@UserKey", request.UserKey));
                sqlParams.Add(new SqlParameter("@UserName", request.UserName));
                sqlParams.Add(new SqlParameter("@AllocationDateTime", request.StartAllocationDateTime));
                sqlParams.Add(new SqlParameter("@OfficeSpaceDetailKey", request.OfficeSeatDetailKeys));
                var result = await _officeSpaceAllocationContext.SaveToTable(_insertUserOfficeSeatAllocationDetail, sqlParams.ToArray());
                if (result > 0)
                    response = new AllocationResponse() { Comment = "Space allocates successfully", HasError = false };
                else
                    response = new AllocationResponse() { Comment = "Something wrong with space allocation ", HasError = true };
            }
            return response;
        }
        public async Task<AllocatedSpaceResponse> GetSpaceAllocationForUser(GetAllocatedSpaceRequest request)
        {
            AllocatedSpaceResponse response = null;
            try
            {
                if (request.StartAllocationDateTime > request.EndAllocationDateTime)
                {
                    _logger.LogInformation($"Invalid startdate and enddate in request. End date should be grater then start date");
                    response = new AllocatedSpaceResponse() { Comment = "Start date should less then End date", HasError = true };
                }

                _logger.LogInformation($"Fetching space allocation for {request}");
                var sqlParams = new[]
                {
                    new SqlParameter("@UserKey", request.UserId),
                        new SqlParameter("@StartAllocationDateTime", request.StartAllocationDateTime),
                            new SqlParameter("@EndAllocationDateTime", request.EndAllocationDateTime)
                };

                var result = await _officeSpaceAllocationContext.SelectTable(_procGetUserAllOfficeSeatAllocationDetail, sqlParams);

                if (result?.Rows?.Count > 0)
                {
                    var allocatedSpace = result.AsEnumerable().Select(_ =>
                        new AllocatedSpace()
                        {
                            AllocationDateTime = _.Field<DateTime>("AllocationDateTime"),
                            OfficeName = _.Field<string>("OfficeName"),
                            FloorName = _.Field<string>("FloorName"),
                            ZoneName = _.Field<string>("ZoneName"),
                            SeatNumber = _.Field<string>("SeatNumber"),
                            OfficeKey = _.Field<Guid>("OfficeKey"),
                            OfficeFloorDetailKey = _.Field<Guid>("OfficeFloorDetailKey"),
                            OfficeSeatDetailKey = _.Field<Guid>("OfficeSeatDetailKey"),
                            UserOfficeSeatAllocationDetailKey = _.Field<Guid>("UserOfficeSeatAllocationDetailKey"),
                            SpaceAllocatedTo = _.Field<string>("SpaceAllocatedTo")
                        });

                    response = new AllocatedSpaceResponse() { AllocatedSpaces = allocatedSpace.ToList(), Comment = string.Empty, HasError = false };
                }
                else
                {
                    _logger.LogWarning($"No records found for {request.UserId} userid");
                    response = new AllocatedSpaceResponse() { HasError = false, Comment = "No Records found" };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while fetching allocation space for {request.UserId}");
                response = new AllocatedSpaceResponse() { HasError = true, Comment = ex.Message };
            }
            return response;
        }
    }
}
