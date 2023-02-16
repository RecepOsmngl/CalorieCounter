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
    public partial class UserMealForm : Form
    {
        public UserMealForm()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            MainUserForm _MainUserForm = new MainUserForm();
            _MainUserForm.Show();
            this.Hide();
        }

        private void UserMealForm_Load(object sender, EventArgs e)
        {

        }
    }
}
