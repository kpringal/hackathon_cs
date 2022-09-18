using BusinessEntity;
using BusinessEntity.Service;
using log4net;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Utility.ExceptionHelper;

namespace SpaceAllocationServiceLayer.Office
{
    public class OfficeService
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private const String CreateOfficeUrl = @"https://cs-hackathon.azurewebsites.net/api/Office/InsertOffice";
        
        private const String GetAllOfficeDetailsUrl = @"https://cs-hackathon.azurewebsites.net/api/Office/GetAllOfficeDetails";

        private const String GetUserOfficeSeatAllocationDetailForFloorUrl = @"https://cs-hackathon.azurewebsites.net/api/SpaceAllocation/AllocatedSpaceForFloor";

        private const String GetPendingSpaceRequest = @"https://cs-hackathon.azurewebsites.net/api/PendingSpaceRequest/GetPendingSpaceRequest";

        public String CreateNewOffice(OfficeFloorDetail officeFloorDetail)
        {
            try
            {
                SATService satService = new SATService();
                String response = satService.SendPostRequest(CreateOfficeUrl, officeFloorDetail);
                                
                return response;
            }
            catch (Exception ex)
            {
                _logger.Error($"Exception while creating new office. Exception: {ex.GetExceptionDetail()}");
                throw;
            }
        }

        public String GetAllOfficeFloorDetails()
        {
            try
            {
                SATService satService = new SATService();
                String response = satService.SendGetRequest(GetAllOfficeDetailsUrl);

                return response;
            }
            catch (Exception ex)
            {
                _logger.Error($"Exception while getting all office floor details. Exception: {ex.GetExceptionDetail()}");
                throw;
            }
        }

        public String GetUserOfficeSeatAllocationDetailForFloor(UserOfficeSeatAllocationDetailForFloorRequest userOfficeSeatAllocationDetailForFloorRequest)
        {
            try
            {
                SATService satService = new SATService();
                String response = satService.SendPostRequest(GetUserOfficeSeatAllocationDetailForFloorUrl, userOfficeSeatAllocationDetailForFloorRequest);

                return response;
            }
            catch (Exception ex)
            {
                _logger.Error($"Exception while GetUserOfficeSeatAllocationDetailForFloor. Exception: {ex.GetExceptionDetail()}");
                throw;
            }
        }
    }
}
