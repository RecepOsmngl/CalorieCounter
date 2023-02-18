using CalorieCounterEntity;
using CalorieCounterPresentation.LoginUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalorieCounterPresentation.UserUI
{
    public partial class MainUserForm : Form
    {
        UserEntity _user;
        public MainUserForm(UserEntity currentuser)
        {
            InitializeComponent();
            _user= currentuser;

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            LoginForm _LoginForm = new LoginForm();
            _LoginForm.Show();
            this.Hide();
        }

        private void MainUserFormMealButton_Click(object sender, EventArgs e)
        {
            UserMealForm _UserMealForm = new UserMealForm(_user);
            _UserMealForm.Show();
            this.Hide();
        }

        private void MainUserFormStatsButton_Click(object sender, EventArgs e)
        {
            UserStatsForm _UserStatsForm = new UserStatsForm(_user);
            _UserStatsForm.Show();
            this.Hide();
        }

        private void MainUserForm_Load(object sender, EventArgs e)
        {

        }
    }
}
