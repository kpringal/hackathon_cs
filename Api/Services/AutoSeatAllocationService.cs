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
    public class AutoSeatAllocationService : IAutoSeatAllocationService
    {
        private const string _procGetNextLevelUserInfoWithTotalTeamCount = "[dbo].[GetNextLevelUserInfoWithTotalTeamCount]";
        private const string _prodGetAvailableUserOfficeSeatAllocationDetailForDay = "[dbo].[GetAvailableUserOfficeSeatAllocationDetailForDay]";

        private readonly ILogger _logger;
        private readonly ISpaceAllocationService _spaceAllocationService;
        private readonly OfficeSpaceAllocationContext _officeSpaceAllocationContext;


        public AutoSeatAllocationService(ILogger<LoginService> logger, ISpaceAllocationService spaceAllocationService, OfficeSpaceAllocationContext officeSpaceAllocationContext)
        {
            _logger = logger;
            _officeSpaceAllocationContext = officeSpaceAllocationContext;
            _spaceAllocationService = spaceAllocationService;
        }

        public async Task<AutoSeatAllocateResponse> AutoAllocateSeats(AutoSeatAllocateRequest request)
        {
            AutoSeatAllocateResponse response = null;
            try
            {
                _logger.LogInformation($"Validating request");

                if (request.StartDate > request.EndDate)
                {
                    _logger.LogInformation($"Invalid startdate and enddate in request. End date should be grater then start date");
                    response = new AutoSeatAllocateResponse() { Comment = "Start date should less then End date", HasError = true, UserKey = request.UserKey };
                }
                else if (request.StartDate < DateTime.Now)
                {
                    _logger.LogInformation($"Invalid startdate. End date should be grater then curent date time {DateTime.Now}");
                    response = new AutoSeatAllocateResponse() { Comment = "nvalid startdate. End date should be grater then curent date time {DateTime.Now}", HasError = true, UserKey = request.UserKey };
                }
                else if (request.Allocation <= 0)
                {
                    _logger.LogInformation($"Invalid allocation. It should be grater then 0");
                    response = new AutoSeatAllocateResponse() { Comment = "Invalid allocation. It should be grater then 0", HasError = true, UserKey = request.UserKey };
                }
                else
                {
                    var allocatedSeat = GetAllAssignedSeat(request).Result;
                    var users = GetUsersInChain(request).Result;
                    response = AllocateAndSaveSeats(request, allocatedSeat, users);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while validating user");
                response = new AutoSeatAllocateResponse() { Comment = ex.Message, HasError = true };
            }
            return response;
        }

        private AutoSeatAllocateResponse AllocateAndSaveSeats(AutoSeatAllocateRequest request, List<AllocatedSpace> allocatedSeat, List<DownstreamUerInfo> users)
        {
            var totalSeatNeeded = users.Sum(_ => _.AllocatedSeats);
            if (totalSeatNeeded > allocatedSeat.Count)
            {
                var res = new AutoSeatAllocateResponse() { UserKey = request.UserKey, Comment = $"Allocation failed as need seat is higher then available seats, Needed Seat: {totalSeatNeeded}, Available Seat: {allocatedSeat.Count}", HasError = false };
                _logger.LogInformation(res.Comment);
                return res;
            }


            AutoSeatAllocateResponse response = new AutoSeatAllocateResponse();
            response.UserKey = request.UserKey;
            response.DownstreamUerInfos = new List<DownstreamUerInfo>();

            var seats = allocatedSeat.Select(_ => _.OfficeSeatDetailKey).ToList();
            _logger.LogInformation("Started saving seat allocation");

            for (int i = 0; i < users.Count; i++)
            {
                AllocateSeatRequest req = new AllocateSeatRequest()
                {
                    StartAllocationDateTime = request.StartDate,
                    EndAllocationDateTime = request.EndDate,
                    UserKey = users[i].UserKey,
                    UserName = users[i].FullName
                };

                if (i == users.Count - 1)
                {
                    req.OfficeSeatDetailKeys += string.Join(',', seats);
                }
                else
                {
                    for (int p = 0; i < users[i].AllocatedSeats; p++)
                    {
                        string seat = Convert.ToString(seats[0]);
                        req.OfficeSeatDetailKeys += seat + ",";
                        seats.RemoveAt(0);
                    }
                }

                req.OfficeSeatDetailKeys = req.OfficeSeatDetailKeys.Substring(0, req.OfficeSeatDetailKeys.Length - 1);
                _logger.LogInformation($"Allocation request prepared for {request}");


                _logger.LogInformation($"Started allocating/saving seats");
                var res = _spaceAllocationService.AllocateSeats(req);
                _logger.LogInformation($"Seats allocted/saved successfully");

                var useInfo = new DownstreamUerInfo()
                {
                    AllocatedSeats = i == users.Count - 1 ? seats.Count : users[i].AllocatedSeats,
                    FullName = users[i].FullName,
                    TeamSize = users[i].TeamSize,
                    UserKey = users[i].UserKey,
                    SeatsList = req.OfficeSeatDetailKeys.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                    HasError = res.Result.HasError,
                    Comment = res.Result.Comment
                };
                response.DownstreamUerInfos.Add(useInfo);
            }
            _logger.LogInformation($"Seats allocted/saved successfully for all users");
            return response;
        }


        private async Task<List<AllocatedSpace>> GetAllAssignedSeat(AutoSeatAllocateRequest request)
        {
            _logger.LogInformation($"Fetching space allocation for {request}");
            var sqlParams = new[]
            {
                    new SqlParameter("@UserKey", request.UserKey),
                        new SqlParameter("@StartAllocationDateTime", request.StartDate),
                            new SqlParameter("@EndAllocationDateTime", request.EndDate)
                };

            var result = await _officeSpaceAllocationContext.SelectTable(_prodGetAvailableUserOfficeSeatAllocationDetailForDay, sqlParams);
            List<AllocatedSpace> allocatedSpaces = new List<AllocatedSpace>();
            if (result?.Rows?.Count > 0)
            {
                allocatedSpaces = result.AsEnumerable().Select(_ =>
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
                        SpaceAllocatedTo = _.Field<string>("SpaceAllocatedTo")
                    }).ToList();
            }
            _logger.LogInformation($"Fetched space allocation for {request}, found {allocatedSpaces.Count} records");
            return allocatedSpaces;
        }

        private async Task<List<DownstreamUerInfo>> GetUsersInChain(AutoSeatAllocateRequest request)
        {
            _logger.LogInformation($"Fetching reportee users for {request}");
            var sqlParams = new[] { new SqlParameter("@UserKey", request.UserKey) };

            var result = await _officeSpaceAllocationContext.SelectTable(_procGetNextLevelUserInfoWithTotalTeamCount, sqlParams);
            List<DownstreamUerInfo> downstreamUerInfos = new List<DownstreamUerInfo>();
            if (result?.Rows?.Count > 0)
            {
                downstreamUerInfos = result.AsEnumerable().Select(_ =>
                    new DownstreamUerInfo()
                    {
                        TeamSize = _.Field<int>("TeamCount"),
                        FullName = _.Field<string>("FullName"),
                        UserKey = _.Field<Guid>("UserKey"),
                        AllocatedSeats = Convert.ToInt32(Math.Floor(_.Field<int>("TeamCount") * request.Allocation / 100))
                    }).ToList();
            }
            _logger.LogInformation($"Fetched reportee users for {request}, found {downstreamUerInfos.Count} records");
            return downstreamUerInfos;
        }
    }
}
