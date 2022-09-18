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

namespace SpaceAllocationTool
{
    public partial class AdminMainForm : Form
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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


        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void btnGetOfficeDetails_Click(object sender, EventArgs e)
        {
            try
            {
                ExistingOfficeDetailsForm existingOfficeDetailsForm = new ExistingOfficeDetailsForm();
                existingOfficeDetailsForm.Show();
            }
            catch(Exception ex)
            {
                String error = $"Exception while getting office details. Exception: {ex.GetExceptionDetail()}";
                _logger.Error(error);
                ShowErrorMessage(error, true);                
            }
        }

        private void btnCreateNewOfficeDetail_Click(object sender, EventArgs e)
        {
            try
            {
                NewOfficeSetUpForm newOfficeSetUpForm = new NewOfficeSetUpForm();
                newOfficeSetUpForm.Show();
            }
            catch (Exception ex)
            {
                String error = $"Exception while creating new office details. Exception: {ex.GetExceptionDetail()}";
                _logger.Error(error);
                ShowErrorMessage(error, true);
            }
        }
    }
}
