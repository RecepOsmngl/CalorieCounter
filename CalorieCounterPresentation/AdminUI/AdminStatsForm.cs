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

namespace CalorieCounterPresentation.AdminUI
{
    public partial class AdminStatsForm : Form
    {
        UserEntity _selectuser = new UserEntity();
        AdminStatsService _adminStatsService = new AdminStatsService();
        public AdminStatsForm()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            MainAdminForm _MainAdminForm = new MainAdminForm();
            _MainAdminForm.Show();
            this.Hide();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void CalorieCalculator()
        {
            int TotalBreakfastCalorie = BreakfastCalorieCalculator();
            int TotalLunchCalorie = LunchCalorieCalculator();
            int TotalDinnerCalorie = DinnerCalorieCalculator();
            int TotalSnackCalorie = SnackCalorieCalculator();
            int TotalCalorie = TotalBreakfastCalorie + TotalLunchCalorie + TotalDinnerCalorie + TotalSnackCalorie;
            UserMealFill(TotalBreakfastCalorie, TotalLunchCalorie, TotalDinnerCalorie, TotalSnackCalorie, TotalCalorie);


        }

        private int SnackCalorieCalculator()
        {
         
            int SnackTotalCalorie = _adminStatsService.SnackTotalCalorie(_selectuser);
            return SnackTotalCalorie;
        }

        private int DinnerCalorieCalculator()
        {
            
            int DinnerTotalCalorie = _adminStatsService.DinnerTotalCalorie(_selectuser);
            return DinnerTotalCalorie;
        }

        private int LunchCalorieCalculator()
        {
           
            int LunchTotalCalorie = _adminStatsService.LunchTotalCalorie(_selectuser);
            return LunchTotalCalorie;
        }

        private int BreakfastCalorieCalculator()
        {
           
            int BreakfastTotalCalorie = _adminStatsService.BreakfastTotalCalorie(_selectuser);
            //AdminStatsFormUsersMealDgv.Columns["TotalBreakfastCalorie"].ValueType = BreakfastTotalCalorie;
            return BreakfastTotalCalorie;

        }

        private void AdminStatsFormUserDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridviewClear();

            _selectuser.UserID = int.Parse(AdminStatsFormUserDgv.CurrentRow.Cells[0].Value.ToString());




        }
        public void UsersFill()
        {
            AdminStatsFormUserDgv.DataSource = _adminStatsService.UserServiceFill();
            AdminStatsFormUserDgv.Columns["UserPassword"].Visible = false;
            AdminStatsFormUserDgv.Columns["UserHeight"].Visible = false;
            AdminStatsFormUserDgv.Columns["UserWeight"].Visible = false;
            AdminStatsFormUserDgv.Columns["UserGender"].Visible = false;
            AdminStatsFormUserDgv.Columns["MealEntity"].Visible = false;


        }

        private void AdminStatsForm_Load(object sender, EventArgs e)
        {
            UsersFill();

        }
        public void UserMealFill(int _TotalBreakfastCalorie, int _TotalLunchCalorie, int _TotalDinnerCalorie, int _TotalSnackCalorie, int _TotalCalorie)
        {
            DataGridviewClear();
            AdminStatsFormUsersMealDgv.ReadOnly = true;
            AdminStatsFormUsersMealDgv.AllowUserToDeleteRows = false;
            AdminStatsFormUsersMealDgv.ColumnCount = 5;
            AdminStatsFormUsersMealDgv.Columns[0].Name = "Breakfast Total Calorie";
            AdminStatsFormUsersMealDgv.Columns[1].Name = "Lunch Total Calorie";
            AdminStatsFormUsersMealDgv.Columns[2].Name = "Dinner Total Calorie";
            AdminStatsFormUsersMealDgv.Columns[3].Name = "Snack Total Calorie";
            AdminStatsFormUsersMealDgv.Columns[4].Name = "Total Calorie";
            AdminStatsFormUsersMealDgv.Rows.Add(_TotalBreakfastCalorie, _TotalLunchCalorie, _TotalDinnerCalorie, _TotalSnackCalorie, _TotalCalorie);



        }
       private void DataGridviewClear()
        {
            AdminStatsFormUsersMealDgv.DataSource = null;
            AdminStatsFormUsersMealDgv.Rows.Clear();
        }

        private void AdminEndofDayButton_Click(object sender, EventArgs e)
        {

            CalorieCalculator();
        }

    
    }
}
