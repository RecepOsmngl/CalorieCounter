using CalorieCounterBusiness.Services;
using CalorieCounterEntity;
using CalorieCounterPresentation.AdminUI;
using CalorieCounterPresentation.UserUI;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // ***SERVICES***
        UserService _UserService = new UserService();

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        // ***BUTTONS***
        // Close Button
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Forgot Password Button
        private void ForgotPasswordButton_Click(object sender, EventArgs e)
        {
            ChangePasswordForm _ChangePasswordForm = new ChangePasswordForm();
            _ChangePasswordForm.Show();
            this.Hide();
        }

        // Dont Have An Account Button
        private void DontHaveAnAccountButton_Click(object sender, EventArgs e)
        {
            RegistrationForm _RegistrationForm = new RegistrationForm();
            _RegistrationForm.Show();
            this.Hide();
        }

        // Login Button
        private void LoginButton_Click(object sender, EventArgs e)
        {
            UserEntity _UserEntity = new UserEntity();
            _UserEntity.UserMail = LoginFormUserMailTextBox.Text;
            _UserEntity.UserPassword = LoginFormUserPasswordTextBox.Text;

            bool _Logincheck = _UserService.UserLogin(_UserEntity);
            if (_Logincheck == true)
            {
                if (_UserEntity.UserMail == "admin")
                {
                    MainAdminForm _MainAdminform = new MainAdminForm();
                    _MainAdminform.Show();
                    this.Hide();
                }
                else
                {
                    MainUserForm _MainUserForm = new MainUserForm();
                    _MainUserForm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Incorrect email address or password!");
            }
        }

        // ***CHECKBOXES***
        private void LoginFormCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (LoginFormCheckBox.Checked == true)
            {
                LoginFormUserPasswordTextBox.PasswordChar = '\0';
            }
            else
            {
                LoginFormUserPasswordTextBox.PasswordChar = '*';
            }
        }
    }
}
