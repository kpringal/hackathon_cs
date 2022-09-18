using BusinessEntity.Service;
using BusinessEntity.Service.Response;
using log4net;
using Newtonsoft.Json;
using SpaceAllocationServiceLayer.Login;
using System;
using System.Reflection;
using Utility.ExceptionHelper;

namespace BusinessLayer
{
    public class LoginBl
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public LoginResponse Login(LoginRequest loginRequest)
        {
            try
            {
                LoginService loginService = new LoginService();
                String loginResponse = loginService.SendLoginRequest(loginRequest);

                LoginResponse loginReponse = JsonConvert.DeserializeObject<LoginResponse>(loginResponse);

                return loginReponse;
            }
            catch(Exception ex)
            {
                _logger.Error($"Exception while doing login. Exception: {ex.GetExceptionDetail()}");
                throw;
            }
        }
    }
}
