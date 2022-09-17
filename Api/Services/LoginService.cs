using Api.Helper;
using Api.Models;
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
    public class LoginService : ILoginService
    {
        private const string _procGetUserInfo = "[dbo].[GetUserInfo]";

        private readonly ILogger _logger;
        private readonly Settings _setting;
        private readonly OfficeSpaceAllocationContext _officeSpaceAllocationContext;

        public LoginService(ILogger<LoginService> logger, IOptions<Settings> settings, OfficeSpaceAllocationContext officeSpaceAllocationContext)
        {
            _logger = logger;
            _setting = settings.Value;
            _officeSpaceAllocationContext = officeSpaceAllocationContext;
        }

        public async Task<LoginResponse> ValidateUser(string email, string password)
        {
            LoginResponse response = null;
            try
            {
                _logger.LogInformation($"Fetching user for {email}");
                var sqlParams = new[] { new SqlParameter("@EmailAddress", email),
                                        new SqlParameter("@Pwd", password)};

                var result = await _officeSpaceAllocationContext.SelectTable(_procGetUserInfo, sqlParams);

                if (result?.Rows?.Count > 0)
                {
                    var roles = result.AsEnumerable().Select(_ => _.Field<string>("RoleName")).ToList();
                    var fullName = result.AsEnumerable().Select(_ => _.Field<string>("FullName")).FirstOrDefault();
                    var userKey = result.AsEnumerable().Select(_ => _.Field<Guid>("UserKey")).FirstOrDefault();

                    response = new LoginResponse() { HasError = false, Role = roles, UserKey = userKey, UserName = fullName };
                    _logger.LogInformation( response.ToString());
                }
                else
                {
                    _logger.LogWarning($"User not found for {email}");
                    response = new LoginResponse() { HasError = false, Comment = "User not registered" };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while validating user");
                response = new LoginResponse() { Comment = ex.Message, HasError = true };
            }
            return response;
        }
    }
}
