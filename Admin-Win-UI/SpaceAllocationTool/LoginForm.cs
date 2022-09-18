using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility.ExceptionHelper;
using Utility;
using BusinessEntity.Service;
using BusinessEntity.Service.Response;
using BusinessLayer;

namespace SpaceAllocationTool
{
    public partial class LoginForm : Form
    {
        public static LoginResponse LoginResponse;

        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public LoginForm()
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


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                txtEmailAddress.Focus();
                txtEmailAddress.Text = "eon2.manager@cs.com";
                txtPassword.Text = "success";
            }
            catch(Exception ex)
            {
                String errorMessage = $"Exception while loading the form. Exception: {ex.GetExceptionDetail()}";
                _logger.Error(errorMessage);
                ShowErrorMessage(errorMessage);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtEmailAddress.Text))
                {
                    ShowErrorMessage($"Kindly enter valid email address.", true);
                    txtEmailAddress.Focus();
                    return;
                }

                if (String.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    ShowErrorMessage($"Kindly enter valid password.", true);
                    txtPassword.Focus();
                    return;
                }

                LoginRequest loginRequest = new LoginRequest();
                loginRequest.eMail = txtEmailAddress.Text;
                loginRequest.password = txtPassword.Text;

                LoginBl loginBl = new LoginBl();
                LoginResponse = loginBl.Login(loginRequest);

                if(LoginResponse != null && LoginResponse.hasError)
                {
                    ShowErrorMessage(LoginResponse.comment.ToString(), true);                    
                    return;
                }
                else if(LoginResponse != null && LoginResponse.role != null && LoginResponse.role.Any() && !LoginResponse.role.Contains("ADMIN"))
                {
                    ShowErrorMessage("You do not have Admin Roles. Please enter credential details for admin.", true);
                    txtEmailAddress.Focus();
                    return;
                }
                else if (LoginResponse != null && LoginResponse.role != null && LoginResponse.role.Any() && LoginResponse.role.Contains("ADMIN"))
                {
                    AdminMainForm adminMainForm = new AdminMainForm();
                    adminMainForm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                String errorMessage = $"Exception while loading the form. Exception: {ex.GetExceptionDetail()}";
                _logger.Error(errorMessage);
                ShowErrorMessage(errorMessage);
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
                String errorMessage = $"Exception while closing the form. Exception: {ex.GetExceptionDetail()}";
                _logger.Error(errorMessage);
                ShowErrorMessage(errorMessage);
            }
        }
    }
}
