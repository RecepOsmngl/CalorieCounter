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

        public void LoginForm_Load(object sender, EventArgs e)
        {
            //AutoScaleDime.text = this.ActiveControl;
        }

        //Button button = (Button)sender
        //public void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)13)
        //    {
        //        LoginButton_Click();
        //    }
        //}




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
            LoginButtonClickMethod();
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

        private void LoginFormUserPasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginButtonClickMethod();
            }
        }

        public void LoginButtonClickMethod()
        {
            UserEntity _UserEntity = new UserEntity();
            _UserEntity.UserMail = LoginFormUserMailTextBox.Text;
            _UserEntity.UserPassword = LoginFormUserPasswordTextBox.Text;
            

            string _LoginCheck = _UserService.UserLogin(_UserEntity);
            if (_LoginCheck == "3")
            {
                MessageBox.Show("Kullanıcı bulunamadı!");
            }
            if (_LoginCheck == "2")
            {
                MessageBox.Show("Şifre veya kullanıcı adı yanlış, tekrar giriş yapınız.");
            }
            if (_LoginCheck == "1")
            {
                if (_UserEntity.UserMail.ToLower() == "admin@gmail.com")
                {
                    MainAdminForm _MainAdminform = new MainAdminForm();
                    _MainAdminform.Show();
                    this.Hide();
                }
                else
                {

                  _UserEntity=  _UserService.UserStateChange(_UserEntity);
                    MainUserForm _MainUserForm = new MainUserForm(_UserEntity);
                    _MainUserForm.Show();
                    this.Hide();
                }
            }
        }
    }
}
