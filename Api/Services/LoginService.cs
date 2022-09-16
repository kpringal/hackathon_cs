using Api.Helper;
using Api.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILogger _logger;
        private readonly Settings _setting;

        public LoginService(ILogger<LoginService> logger, IOptions<Settings> settings)
        {
            _logger = logger;
            //Just added for reference, how to get setting defined in appsettings.json
            _setting = settings.Value;
        }

    }
}
