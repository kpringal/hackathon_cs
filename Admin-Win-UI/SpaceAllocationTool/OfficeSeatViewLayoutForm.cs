using BusinessEntity.Service;
using BusinessEntity.Service.Response;
using BusinessLayer;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Utility;
using Utility.ExceptionHelper;

namespace SpaceAllocationTool
{
    public partial class OfficeSeatViewLayoutForm : Form
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Guid OfficeKey { get; }
        public Guid OfficeFloorDetailKey { get; }

        public OfficeSeatViewLayoutForm(Guid officeKey, Guid officeFloorDetailKey)
        {
            InitializeComponent();
            this.OfficeKey = officeKey;
            this.OfficeFloorDetailKey = officeFloorDetailKey;
        }

        private void ShowErrorMessage(String message, bool showDetailException = false)
        {
            try
            {
                if (showDetailException)
                {
                    MessageBox.Show(message, StringConstant.ErrorCapsOn, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(StringConstant.GeneralApplicationError, StringConstant.ErrorCapsOn, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(message: $"Exception while showing error message dialog. Exception: {ex.GetExceptionDetail()}");
                throw;
            }
        }

        private void ShowSuccessMessage(String message)
        {
            try
            {
                MessageBox.Show(message, StringConstant.SuccessCapsOn, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _logger.Error(message: $"Exception while showing error message dialog. Exception: {ex.GetExceptionDetail()}");
                throw;
            }
        }


        private void OfficeSeatViewLayoutForm_Load(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                String error = $"Exception while loading the office seat view form. Exception: {ex.GetExceptionDetail()}";
                _logger.Error(error);
                ShowErrorMessage(error, true);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                UserOfficeSeatAllocationDetailForFloorRequest userOfficeSeatAllocationDetailForFloorRequest = new UserOfficeSeatAllocationDetailForFloorRequest()
                {
                    userKey = new Guid(LoginForm.LoginResponse.userKey), 
                    OfficeFloorDetailKey = this.OfficeFloorDetailKey,
                    startDate = dtpAllocationFrom.Value,
                    endDate = dtpAllocationTo.Value
                };

                OfficeBl officeBl = new OfficeBl();
                UserOfficeSeatAllocationDetailForFloorResponse userOfficeSeatAllocationDetailForFloorResponse = officeBl.GetUserOfficeSeatAllocationDetailForFloor(userOfficeSeatAllocationDetailForFloorRequest);

                if(userOfficeSeatAllocationDetailForFloorResponse != null && userOfficeSeatAllocationDetailForFloorResponse.allocatedSpaces != null && userOfficeSeatAllocationDetailForFloorResponse.allocatedSpaces.Any())
                {
                    dgvUserOfficeFloorSeatAllocationDetails.DataSource = userOfficeSeatAllocationDetailForFloorResponse.allocatedSpaces.ToList();

                    dgvUserOfficeFloorSeatAllocationDetails.Columns["officeKey"].Visible = false;
                    dgvUserOfficeFloorSeatAllocationDetails.Columns["officeFloorDetailKey"].Visible = false;
                    dgvUserOfficeFloorSeatAllocationDetails.Columns["officeSeatDetailKey"].Visible = false;
                    dgvUserOfficeFloorSeatAllocationDetails.Columns["userOfficeSeatAllocationDetailKey"].Visible = false;
                }
                else
                {
                    ShowSuccessMessage($"No Booking Found!");
                }
            }
            catch (Exception ex)
            {
                String error = $"Exception while viewing office seat view form. Exception: {ex.GetExceptionDetail()}";
                _logger.Error(error);
                ShowErrorMessage(error, true);
            }
        }
    }
}
