using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Api.Filters;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using System;
using Api.Helper;
using Api.Models.Requests;
using Api.Models.Responses;
using System.Collections.Generic;

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
        public LoginResponse Login(LoginRequest user)
        {
            _logger.LogInformation($"Login endpint invoked");
            var res = new LoginResponse() { Comment = string.Empty, IsError = false, Role = new List<string>() { "1", "Admin", "Test" }, UserName = "pk" };
            _logger.LogInformation($"Login response created successfully");
            return res;
        }
    }
}
