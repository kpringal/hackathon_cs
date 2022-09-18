using BusinessEntity.Service;
using log4net;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Utility.ExceptionHelper;

namespace SpaceAllocationServiceLayer.Login
{
    public class LoginService
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private const String LoginUrl = @"https://cs-hackathon.azurewebsites.net/api/Login";

        public String SendLoginRequest(LoginRequest loginRequest)
        {
            try
            {
                SATService satService = new SATService();
                String response = satService.SendPostRequest(LoginUrl, loginRequest);

                return response;
            }
            catch(Exception ex)
            {
                _logger.Error($"Exception while sending login request. Exception: {ex.GetExceptionDetail()}");
                throw;
            }
        }
    }
}
