using BusinessEntity.Service.Response;
using BusinessLayer;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Utility;
using Utility.ExceptionHelper;
using System.Linq;

namespace SpaceAllocationTool
{
    public partial class ExistingOfficeDetailsForm : Form
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ExistingOfficeDetailsForm()
        {
            InitializeComponent();
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

        private AllOfficeFloorDetailResponse GetAllOfficeFloorDetails()
        {
            try
            {
                OfficeBl officeBl = new OfficeBl();
                return officeBl.GetAllOfficeFloorDetails();
            }
            catch(Exception ex)
            {
                _logger.Error($"Exception while getting all office floor details. Exception: {ex.GetExceptionDetail()}");
                throw;
            }
        }

        private void ExistingOfficeDetailsForm_Load(object sender, EventArgs e)
        {
            try
            {
                AllOfficeFloorDetailResponse allOfficeFloorDetailResponse = GetAllOfficeFloorDetails();

                if(allOfficeFloorDetailResponse != null && allOfficeFloorDetailResponse.allOfficeDetails != null && allOfficeFloorDetailResponse.allOfficeDetails.Any())
                {
                    dgvOfficeDetails.DataSource = allOfficeFloorDetailResponse.allOfficeDetails.OrderBy(a => a.officeName).ThenBy(a => a.floorName).ThenBy(a => a.zoneName).ToList();

                    DataGridViewButtonColumn viewButtonColumn = new DataGridViewButtonColumn();
                    viewButtonColumn.Name = "viewBtnColumn";
                    viewButtonColumn.HeaderText = "View";
                    viewButtonColumn.Text = "View";
                    viewButtonColumn.UseColumnTextForButtonValue = true;
                    if (dgvOfficeDetails.Columns["viewBtnColumn"] == null)
                    {
                        dgvOfficeDetails.Columns.Add(viewButtonColumn);
                    }

                    dgvOfficeDetails.Columns["officeKey"].Visible = false;
                    dgvOfficeDetails.Columns["officeFloorDetailKey"].Visible = false;
                }
                else
                {
                    ShowSuccessMessage("No Office Details Found!");
                }
            }
            catch (Exception ex)
            {
                String error = $"Exception while loading the existing office details form. Exception: {ex.GetExceptionDetail()}";
                _logger.Error(error);
                ShowErrorMessage(error, true);
            }
        }

        private void dgvOfficeDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvOfficeDetails.Columns["viewBtnColumn"].Index)
            {
                Guid officeKey = new Guid(dgvOfficeDetails.Rows[e.RowIndex].Cells["officeKey"].Value.ToString());
                Guid officeFloorDetailKey = new Guid(dgvOfficeDetails.Rows[e.RowIndex].Cells["officeFloorDetailKey"].Value.ToString());

                OfficeSeatViewLayoutForm officeSeatViewLayoutForm = new OfficeSeatViewLayoutForm(officeKey, officeFloorDetailKey);
                officeSeatViewLayoutForm.Show();
            }
        }
    }
}
