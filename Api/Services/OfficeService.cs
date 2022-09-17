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
    public class OfficeService : IOfficeService
    {
        private const string _procInsertOffice = "[dbo].[InsertOffice]";

        private readonly ILogger _logger;
        private readonly Settings _setting;
        private readonly OfficeSpaceAllocationContext _officeSpaceAllocationContext;

        public OfficeService(ILogger<OfficeService> logger, IOptions<Settings> settings, OfficeSpaceAllocationContext officeSpaceAllocationContext)
        {
            _logger = logger;
            _setting = settings.Value;
            _officeSpaceAllocationContext = officeSpaceAllocationContext;
        }

        public async Task<InsertOfficeResponse> CreateOfficePremise(InsertOfficeRequest insertOfficeRequest)
        {
            InsertOfficeResponse response = null;
            try
            {
                _logger.LogInformation($"Creating office with : '{insertOfficeRequest}'");
                var sqlParams = new[] { new SqlParameter("@OfficeName", insertOfficeRequest.OfficeName),
                                        new SqlParameter("@FloorName", insertOfficeRequest.FloorName),
                                        new SqlParameter("@ZoneName", insertOfficeRequest.ZoneName),
                                        new SqlParameter("@SeatCount", insertOfficeRequest.SeatCount),
                                        new SqlParameter("@UserName", insertOfficeRequest.UserName)};

                var result = await _officeSpaceAllocationContext.SelectTable(_procInsertOffice, sqlParams);

                if (result?.Rows?.Count > 0)
                {
                    var officeKey = result.AsEnumerable().Select(_ => _.Field<Guid>("OfficeKey")).FirstOrDefault();

                    var message = $"Office created with '{insertOfficeRequest.OfficeName}' OfficeName, '{insertOfficeRequest.FloorName}' floor, '{insertOfficeRequest.ZoneName}' zone, '{insertOfficeRequest.SeatCount}' seats.";
                    response = new InsertOfficeResponse() { IsError = false, OfficeKey = officeKey, Comment = message};
                    _logger.LogInformation(response.ToString());
                }
                else
                {
                    _logger.LogWarning($"Office '{insertOfficeRequest.OfficeName}' already present");
                    response = new InsertOfficeResponse() { IsError = false, Comment = "Office already present." };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating office");
                response = new InsertOfficeResponse() { Comment = ex.Message, IsError = true };
            }
            return response;
        }
    }
}
