using Api.Helper;
using Api.Models;
using Api.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Linq;

namespace Api.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILogger _logger;
        private readonly Settings _setting;
        private readonly OfficeSpaceAllocationContext _officeSpaceAllocationContext;

        public LoginService(ILogger<LoginService> logger, IOptions<Settings> settings , OfficeSpaceAllocationContext officeSpaceAllocationContext)
        {
            _logger = logger;
            _setting = settings.Value;
            _officeSpaceAllocationContext = officeSpaceAllocationContext;
        }
    }
}
