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

namespace CalorieCounterPresentation.AdminUI
{
    public partial class MainAdminForm : Form
    {
        public MainAdminForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            LoginForm _LoginForm = new LoginForm();
            _LoginForm.Show();
            this.Hide();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainAdminFormFoodButton_Click(object sender, EventArgs e)
        {
            AdminFoodForm _AdminFoodForm = new AdminFoodForm();
            _AdminFoodForm.Show();
            this.Hide();
        }

        private void MainAdminFormFoodCategoryButton_Click(object sender, EventArgs e)
        {
            AdminFoodCategoryForm _AdminFoodCategoryForm = new AdminFoodCategoryForm();
            _AdminFoodCategoryForm.Show();
            this.Hide();
        }

        private void MainAdminFormMealCategoryButton_Click(object sender, EventArgs e)
        {
            AdminMealCategoryForm _AdminMealCategoryForm = new AdminMealCategoryForm();
            _AdminMealCategoryForm.Show();
            this.Hide();
        }

        private void MainAdminFormStatsButton_Click(object sender, EventArgs e)
        {
            AdminStatsForm _AdminStatsForm  = new AdminStatsForm();
            _AdminStatsForm.Show();
            this.Hide();
        }
    }
}
