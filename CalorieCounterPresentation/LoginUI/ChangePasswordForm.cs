using CalorieCounterBusiness.Services;
using CalorieCounterEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalorieCounterPresentation.LoginUI
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        // ***SERVICES***
        UserService _UserService = new UserService();

        // ***BUTTONS***
        // Close Button
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Back Button
        private void BackButton_Click(object sender, EventArgs e)
        {
            LoginForm _loginForm = new LoginForm();
            _loginForm.Show();
            this.Hide();
        }

        // Send My Password Button
        private void SendMyPasswordButton_Click(object sender, EventArgs e)
        {
            UserEntity _UserEntity = new UserEntity();

            _UserEntity.UserMail = ChangePasswordFormUserMailTextBox.Text.Trim();

            if (!_UserService.CheckUserExistence(_UserEntity))
            {
                MessageBox.Show("Mail address cannot be found, please use valid email address!");
                ClearChangePasswordFormFields();
                return;
            }

            _UserService.SendMail(_UserEntity);
            MessageBox.Show("Your password has been sent to your e-mail address.");
            ClearChangePasswordFormFields();

            LoginForm _loginForm = new LoginForm();
            _loginForm.Show();
            this.Hide();
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {

        }

        // ***LOCAL METHODS***
        private void ClearChangePasswordFormFields()
        {
            ChangePasswordFormUserMailTextBox.Clear();
        }
    }
}
