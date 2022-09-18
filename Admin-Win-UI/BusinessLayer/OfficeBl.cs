using BusinessEntity;
using BusinessEntity.Service.Response;
using log4net;
using Newtonsoft.Json;
using SpaceAllocationServiceLayer.Office;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Utility.ExceptionHelper;
using System.Linq;

namespace BusinessLayer
{
    public class OfficeBl
    {

        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        public String CreateNewOffice(OfficeFloorDetail officeFloorDetail)
        {
            try
            {
                OfficeService officeService = new OfficeService();
                return officeService.CreateNewOffice(officeFloorDetail);
            }
            catch(Exception ex)
            {
                _logger.Error($"Exception while creating new office. Exception: {ex.GetExceptionDetail()}");
                throw;
            }
        }

        public AllOfficeFloorDetailResponse GetAllOfficeFloorDetails()
        {
            try
            {
                OfficeService officeService = new OfficeService();
                String allOfficeFloorDetails = officeService.GetAllOfficeFloorDetails();

                AllOfficeFloorDetailResponse allOfficeFloorDetailResponse = JsonConvert.DeserializeObject<AllOfficeFloorDetailResponse>(allOfficeFloorDetails);

                return allOfficeFloorDetailResponse;
            }
            catch (Exception ex)
            {
                _logger.Error($"Exception while getting all office fllow details. Exception: {ex.GetExceptionDetail()}");
                throw;
            }
        }

        public List<String> GetActiveOffices()
        {
            try
            {
                OfficeService officeService = new OfficeService();
                String allOfficeFloorDetails = officeService.GetAllOfficeFloorDetails();

                AllOfficeFloorDetailResponse allOfficeFloorDetailResponse = JsonConvert.DeserializeObject<AllOfficeFloorDetailResponse>(allOfficeFloorDetails);

                if(allOfficeFloorDetailResponse == null || allOfficeFloorDetailResponse.allOfficeDetails == null)
                {
                    return new List<String>();
                }

                return allOfficeFloorDetailResponse.allOfficeDetails.ToList().Select(a=>a.officeName).Distinct().ToList();
            }
            catch (Exception ex)
            {
                _logger.Error($"Exception while getting all office fllow details. Exception: {ex.GetExceptionDetail()}");
                throw;
            }
        }
    }
}
