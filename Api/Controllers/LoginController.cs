using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Api.Filters;
using Microsoft.Extensions.Logging;
using Api.Models.Requests;
using Api.Models.Responses;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionFilter]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly ILogger _logger;

        public LoginController(ILoginService loginService, ILogger<LoginController> logger)
        {
            _loginService = loginService;
            _logger = logger;
        }
       
        [HttpPost]
        public async Task<LoginResponse> Login([FromBody] LoginRequest user)
        {
            _logger.LogInformation($"Login endpint invoked for {user}");
            var res = await _loginService.ValidateUser(user.EMail, user.Password);
            _logger.LogInformation($"Login response created successfully");
            return res;
        }
    }
}
