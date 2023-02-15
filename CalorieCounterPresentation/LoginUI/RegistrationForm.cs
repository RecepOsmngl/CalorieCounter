using CalorieCounterBusiness.Services;
using CalorieCounterEntity;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CalorieCounterPresentation.LoginUI
{
    public partial class RegistrationForm : Form
    {
        // github try v4

        public RegistrationForm()
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
            LoginForm _LoginForm= new LoginForm();
            _LoginForm.Show();
            this.Hide();
        }

        // Register Button
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            UserEntity _UserEntity = new UserEntity();

            _UserEntity.UserMail = RegistrationFormUserMailTextBox.Text.Trim();
            _UserEntity.UserPassword = RegistrationFormUserPasswordTextBox.Text.Trim();
            _UserEntity.UserName = RegistrationFormUserNameTextBox.Text.Trim();
            _UserEntity.UserSurname = RegistrationFormUserSurnameTextBox.Text.Trim();

            // Height
            int _DefaultHeight = 0;
            bool _IsParsedHeight = int.TryParse(RegistrationFormUserHeightTextBox.Text.Trim(), out _DefaultHeight);
            if(_IsParsedHeight)
            {
                _UserEntity.UserHeight = int.Parse(RegistrationFormUserHeightTextBox.Text.Trim());
            }
            else
            {
                _UserEntity.UserHeight = _DefaultHeight;
            }

            // Weight
            int _DefaultWeight = 0;
            bool _IsParsedWeight = int.TryParse(RegistrationFormUserHeightTextBox.Text.Trim(), out _DefaultWeight);
            if (_IsParsedWeight)
            {
                _UserEntity.UserHeight = int.Parse(RegistrationFormUserHeightTextBox.Text.Trim());
            }
            else
            {
                _UserEntity.UserHeight = _DefaultHeight;
            }

            
            if (RegistrationFormUserGenderComboBox.SelectedItem != null)
            {
                _UserEntity.UserGender = RegistrationFormUserGenderComboBox.SelectedItem.ToString();
            }
            else
            {
                _UserEntity.UserGender = null;
            }



            // Mail Extension Check
            bool _MailExtensionCheck = _UserService.MailValidation(_UserEntity);
            if (_MailExtensionCheck == false)
            {
                MessageBox.Show("Please use one of mail addresses below!");
                ClearRegistrationFormFields();
                return;
            };

            // Password Check
            if (_UserEntity.UserMail == "" && _UserEntity.UserPassword == "")
            {
                MessageBox.Show("E-mail or password cannot be empty!");
                ClearRegistrationFormFields();
                return;
            }

            if (RegistrationFormUserPasswordTextBox.Text != RegistrationFormConfirmPasswordTextBox.Text)
            {
                MessageBox.Show("Passwords do not match!");
                ClearRegistrationFormFields();
                return;
            }

            if(IsLengthCheck == false || IsLowerCheck == false || IsUpperCheck == false || IsDigitCheck == false)
            {
                MessageBox.Show("Please satistify the password requirements!");
                ClearRegistrationFormFields();
                return;
            }

            if (_UserService.CheckUserExistence(_UserEntity))
            {
                MessageBox.Show("This mail already in use, please use different one!");
                ClearRegistrationFormFields();
                return;
            }


            // Adding User
            bool _IsRegistered = _UserService.AddUser(_UserEntity);
            if (_IsRegistered == true)
            {
                MessageBox.Show("Registration Completed!");
                LoginForm _LoginForm = new LoginForm();
                _LoginForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please try again later!");
                LoginForm _LoginForm = new LoginForm();
                _LoginForm.Show();
                this.Hide();
            }


        }

        // ***CHECKBOXES***
        private void RegistrationFormCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RegistrationFormCheckBox.Checked == true)
            {
                RegistrationFormUserPasswordTextBox.PasswordChar = '\0';
                RegistrationFormConfirmPasswordTextBox.PasswordChar = '\0';
            }
            else
            {
                RegistrationFormUserPasswordTextBox.PasswordChar = '*';
                RegistrationFormConfirmPasswordTextBox.PasswordChar = '*';
            }
        }

        // ***LOCAL METHODS***
        private void ClearRegistrationFormFields()
        {
            RegistrationFormUserMailTextBox.Clear();
            RegistrationFormUserPasswordTextBox.Clear();
            RegistrationFormConfirmPasswordTextBox.Clear();
            RegistrationFormUserNameTextBox.Clear();
            RegistrationFormUserSurnameTextBox.Clear();
            RegistrationFormUserHeightTextBox.Clear();
            RegistrationFormUserWeightTextBox.Clear();
        }

        // Password Check

        // Global Variables
        bool IsLengthCheck = false;
        bool IsLowerCheck = false;
        bool IsUpperCheck = false;
        bool IsDigitCheck = false;

        private void RegistrationFormUserPasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Length Check
            if (RegistrationFormUserPasswordTextBox.Text.Length > 7)
            {
                IsLengthCheck = true;
                PasswordCheckMinimumCharacterLabel.ForeColor = Color.FromArgb(55, 52, 99);
            }
            else
            {
                IsLengthCheck = false;
                PasswordCheckMinimumCharacterLabel.ForeColor = Color.FromArgb(249, 89, 83);
            }

            // Lowercase Check
            if (RegistrationFormUserPasswordTextBox.Text.Any(char.IsLower))
            {
                IsLowerCheck = true;
                PasswordCheckLowercaseLabel.ForeColor = Color.FromArgb(55, 52, 99);
            }
            else
            {
                IsLowerCheck = false;
                PasswordCheckLowercaseLabel.ForeColor = Color.FromArgb(249, 89, 83);
            }

            // Uppercase Check
            if (RegistrationFormUserPasswordTextBox.Text.Any(char.IsUpper))
            {
                IsUpperCheck = true;
                PasswordCheckUppercaseLabel.ForeColor = Color.FromArgb(55, 52, 99);
            }
            else
            {
                IsUpperCheck = false;
                PasswordCheckUppercaseLabel.ForeColor = Color.FromArgb(249, 89, 83);
            }

            // Digit Check
            if (RegistrationFormUserPasswordTextBox.Text.Any(char.IsDigit))
            {
                IsDigitCheck = true;
                PasswordCheckNumeralLabel.ForeColor = Color.FromArgb(55, 52, 99);
            }
            else
            {
                IsDigitCheck = false;
                PasswordCheckNumeralLabel.ForeColor = Color.FromArgb(249, 89, 83);
            }
        }

        private void RegistrationFormUserGenderTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
