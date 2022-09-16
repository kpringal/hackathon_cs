using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Api.Filters;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using System;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly ILogger _logger;

        public LoginController(ILoginService loginService, ILogger<LoginController> logger)
        {
            _loginService = loginService;
            _logger = logger;
        }

        [ExceptionFilter]
        [HttpPost]
        public string Create(object user)
        {
            _logger.LogInformation($"Create endpint invoked");
            return "user created";
        }
    }
}
