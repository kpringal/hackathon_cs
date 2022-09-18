using BusinessEntity;
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
    public partial class NewOfficeSetUpForm : Form
    {

        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        List<FloorDetail> floorDetails = new List<FloorDetail>();

        static int rowId = 0;

        public NewOfficeSetUpForm()
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if(String.IsNullOrWhiteSpace(txtOfficeName.Text))
                {
                    ShowErrorMessage("Kindly enter valid office name.", true);
                    txtOfficeName.Focus();
                    return;
                }

                if(dtpAvailableTo.Value < dtpAvailableFrom.Value)
                {
                    ShowErrorMessage("Available To Date should be greate than Available From Date.", true);
                    dtpAvailableFrom.Focus();
                    return;
                }

                if (dtpAvailableTo.Value < DateTime.Now.Date)
                {
                    ShowErrorMessage("Available From Date should be greater than current date.", true);
                    dtpAvailableFrom.Focus();
                    return;
                }


                HashSet<String> uniqueFloorZones = new HashSet<String>();

                for (int i = 0; i < this.floorDetails.Count; i++)
                {
                    FloorDetail floorDetail = this.floorDetails[i];

                    if (
                        (!String.IsNullOrWhiteSpace(floorDetail.ZoneName) || floorDetail.SeatCount > 0) &&
                        String.IsNullOrWhiteSpace(floorDetail.FloorName)
                      )
                    {
                        String error = $"Kindly enter valid floor name for row # {i + 1}.";
                        ShowErrorMessage(error, true);
                        return;
                    }

                    String floorName = floorDetail.FloorName?.Trim();
                    String zoneName = floorDetail.ZoneName?.Trim();

                    if(floorName == null)
                    {
                        floorName = String.Empty;
                    }

                    if(zoneName == null)
                    {
                        zoneName = String.Empty;
                    }

                    if (String.IsNullOrWhiteSpace(floorName) && String.IsNullOrWhiteSpace(zoneName))
                    {
                        continue;
                    }

                    String floorZone = floorName + "-->" + zoneName;

                    if(uniqueFloorZones.Contains(floorZone))
                    {
                        String error = $"Duplicate floor and zone name for row # {i + 1}. Floor Name: {floorName}, Zone Name: {zoneName}";
                        ShowErrorMessage(error, true);
                        return;
                    }
                    else
                    {
                        uniqueFloorZones.Add(floorZone);
                    }
                }


                OfficeBl officeBl = new OfficeBl();

                List<String> activeOffices = officeBl.GetActiveOffices();

                activeOffices = activeOffices.Select(a => a.ToUpper().Trim()).ToList();

                if (activeOffices!=null && activeOffices.Contains(txtOfficeName.Text.ToUpper()))
                {
                    ShowErrorMessage($"Office {txtOfficeName.Text} is already exists!", true);
                    txtOfficeName.Focus();
                    return;
                }

                for (int i = 0; i < this.floorDetails.Count; i++)
                {
                    FloorDetail floorDetail = this.floorDetails[i];

                    if (!String.IsNullOrWhiteSpace(floorDetail.FloorName))
                    {
                        officeBl.CreateNewOffice(new OfficeFloorDetail() { 
                            officeName = txtOfficeName.Text,
                            floorName = floorDetail.FloorName,
                            zoneName = floorDetail.ZoneName,
                            seatCount = floorDetail.SeatCount,
                            userName = Environment.UserName
                        });
                    }
                }

                ShowSuccessMessage("Office is created successfully!");
            }
            catch(Exception ex)
            {
                String error = $"Exception while creating new office. Exception: {ex.GetExceptionDetail()}";
                _logger.Error(error);
                ShowErrorMessage(error, true);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                String error = $"Exception while closing the creating new office form. Exception: {ex.GetExceptionDetail()}";
                _logger.Error(error);
                ShowErrorMessage(error, true);
            }
        }

        private void NewOfficeSetUpForm_Load(object sender, EventArgs e)
        {
            try
            {
                dtpAvailableFrom.Value = DateTime.Now.Date;
                dtpAvailableTo.Value = DateTime.Now.Date.AddMonths(1);
                dtpAvailableTo.MaxDate = DateTime.Now.Date.AddYears(1);

                floorDetails.AddRange(new List<FloorDetail>() {
                    new FloorDetail() {Id = ++rowId },
                    new FloorDetail() {Id = ++rowId }, 
                    new FloorDetail() {Id = ++rowId },
                    new FloorDetail() {Id = ++rowId },
                    new FloorDetail() {Id = ++rowId },
                    new FloorDetail() {Id = ++rowId },
                    new FloorDetail() {Id = ++rowId },
                    new FloorDetail() {Id = ++rowId },
                    new FloorDetail() {Id = ++rowId },
                    new FloorDetail() {Id = ++rowId },
                    new FloorDetail() {Id = ++rowId },
                    new FloorDetail() {Id = ++rowId }
                });

                dgFloorDetails.DataSource = floorDetails;
            }
            catch(Exception ex)
            {
                String error = $"Exception while loading the new office form. Exception: {ex.GetExceptionDetail()}";
                _logger.Error(error);
                ShowErrorMessage(error, true);
            }
        }

        private void btnAddNewRow_Click(object sender, EventArgs e)
        {
            try
            {
                this.floorDetails.Add(new FloorDetail() { Id = ++rowId });

                dgFloorDetails.DataSource = null;
                dgFloorDetails.DataSource = floorDetails;
            }
            catch (Exception ex)
            {
                String error = $"Exception while adding new row. Exception: {ex.GetExceptionDetail()}";
                _logger.Error(error);
                ShowErrorMessage(error, true);
            }
        }
    }
}
