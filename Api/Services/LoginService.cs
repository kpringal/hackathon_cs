using Api.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILogger _logger;

        public LoginService(ILogger<LoginService> logger)
        {
            _logger = logger;
        }

    }
}
