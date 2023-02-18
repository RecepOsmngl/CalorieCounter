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

namespace CalorieCounterPresentation.UserUI
{
    public partial class UserStatsForm : Form
    {
        UserEntity _user;
        public UserStatsForm(UserEntity currentuser)
        {
            InitializeComponent();
            _user = currentuser; 
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            MainUserForm _MainUserForm = new MainUserForm(_user);
            _MainUserForm.Show();
            this.Hide();
        }

        private void UserStatsFormDailyButton_Click(object sender, EventArgs e)
        {
            // Selamlar git hub deneme
        }

        private void UserStatsForm_Load(object sender, EventArgs e)
        {
            // Hasan 
        }
    }
}
