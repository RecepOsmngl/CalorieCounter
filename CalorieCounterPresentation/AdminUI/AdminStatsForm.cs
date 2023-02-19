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
        ComparisonServiceAdmin _ComparisonServiceAdmin = new ComparisonServiceAdmin();
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
           
        }

        private void AdminStatsForm_Load(object sender, EventArgs e)
        {
            UsersFill();
            dgvBreakfast.Hide();
            dgvLunch.Hide();
            dgvDinner.Hide();
            dgvSnacks.Hide();
            dgvCategoryComparisonAverageCalorie.Hide();
            dgvCategoryComparisonUserCalorie.Hide();
            AdminStatsFormUsersMealDgv.Show();
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

            //AdminStatsFormUsersMealDgv.DataSource = _adminStatsService.FoodEntitie();
        }


       private void DataGridviewClear()
        {
            AdminStatsFormUsersMealDgv.DataSource = null;
            AdminStatsFormUsersMealDgv.Rows.Clear();
        }

        private void AdminEndofDayButton_Click(object sender, EventArgs e)
        {
            dgvBreakfast.Hide();
            dgvLunch.Hide();
            dgvDinner.Hide();
            dgvSnacks.Hide();
            dgvCategoryComparisonAverageCalorie.Hide();
            dgvCategoryComparisonUserCalorie.Hide();
            AdminStatsFormUsersMealDgv.Show();
            CalorieCalculator();
        }

        private void TotalFoodList()
        {
            var breakfastFood = BreakfastFoodCountList();
            var lunchFood = LunchFoodCountList();
            var dinnerFood = DinnerFoodCountList();
            var snacksFood = SnacksCountList();
            UserCountReportFill(breakfastFood, lunchFood, dinnerFood, snacksFood);
        }

        private dynamic SnacksCountList()
        {
            var SnackFoodList = _adminStatsService.SnacksFoodList(_selectuser);
            return SnackFoodList;
        }

        private dynamic DinnerFoodCountList()
        {
            var DinnerFoodList = _adminStatsService.DinnerFoodList(_selectuser);
            return DinnerFoodList;
        }

        private dynamic LunchFoodCountList()
        {
            var LunchFoodList = _adminStatsService.LunchFoodList(_selectuser);
            return LunchFoodList;
        }

        private void UserCountReportFill(dynamic _breakfastFoodList, dynamic _lunchFoodList, dynamic _dinnerFoodList, dynamic _snacksFoodList)
        {
            AdminStatsFormUsersMealDgv.ReadOnly = true;
            AdminStatsFormUsersMealDgv.AllowUserToDeleteRows = false;
            dgvBreakfast.DataSource = _breakfastFoodList;
            dgvLunch.DataSource = _lunchFoodList;
            dgvDinner.DataSource = _dinnerFoodList;
            dgvSnacks.DataSource = _snacksFoodList;
        }

        private dynamic BreakfastFoodCountList()
        {
            var BreakfastFoodList = _adminStatsService.BreakfastFoodList(_selectuser);
            return BreakfastFoodList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvBreakfast.Show();
            dgvLunch.Show();
            dgvDinner.Show();
            dgvSnacks.Show();
            AdminStatsFormUsersMealDgv.Hide();
            dgvCategoryComparisonAverageCalorie.Hide();
            dgvCategoryComparisonUserCalorie.Hide();
            TotalFoodList();
        }

        private void UserStatFormWeeklyMealCompare_Click(object sender, EventArgs e)
        {
            dgvBreakfast.Show();
            dgvLunch.Show();
            dgvDinner.Show();
            dgvSnacks.Show();
            AdminStatsFormUsersMealDgv.Hide();
            dgvCategoryComparisonAverageCalorie.Hide();
            dgvCategoryComparisonUserCalorie.Hide();
            WeeklyMealCompare();
        }

        private void WeeklyMealCompare()
        {
            var breakfastMealWeeklyCompare = BreakfastWeeklyMealCompare();
            var lunchMealWeeklyCompare = LunchWeeklyMealCompare();
            var dinnerMealWeeklyCompare = DinnerWeeklyMealCompare();
            var snacksMealWeeklyCompare = SnacksWeeklyMealCompare();
            UserCountReportFill(breakfastMealWeeklyCompare, lunchMealWeeklyCompare, dinnerMealWeeklyCompare, snacksMealWeeklyCompare);
        }

        private dynamic BreakfastWeeklyMealCompare()
        {
            var BreakfastweeklyMealCompare = _adminStatsService.BreakfastWeeklyMealCompareList(_selectuser);
            return BreakfastweeklyMealCompare;
        }
        private dynamic LunchWeeklyMealCompare()
        {
            var LunchweeklyMealCompare = _adminStatsService.LunchWeeklyMealCompareList(_selectuser);
            return LunchweeklyMealCompare;
        }
        private dynamic DinnerWeeklyMealCompare()
        {
            var DinnerweeklyMealCompare = _adminStatsService.DinnerWeeklyMealCompareList(_selectuser);
            return DinnerweeklyMealCompare;
        }
        private dynamic SnacksWeeklyMealCompare()
        {
            var SnacksweeklyMealCompare = _adminStatsService.SnacksWeeklyMealCompareList(_selectuser);
            return SnacksweeklyMealCompare;
        }

        private void UserStatFormMonthlyMealCompare_Click(object sender, EventArgs e)
        {
            dgvBreakfast.Show();
            dgvLunch.Show();
            dgvDinner.Show();
            dgvSnacks.Show();
            AdminStatsFormUsersMealDgv.Hide();
            dgvCategoryComparisonAverageCalorie.Hide();
            dgvCategoryComparisonUserCalorie.Hide();
            MonthlyMealCompare();
        }

        private void MonthlyMealCompare()
        {
            var breakfastMealMonthlyCompare = BreakfastMonthyMealCompare();
            var lunchMealMonthlyCompare = LunchMonthlyMealCompare();
            var dinnerMealMonthlyCompare = DinnerMonthlyMealCompare();
            var snacksMealMonthlyCompare = SnacksMonthlyMealCompare();
            UserCountReportFill(breakfastMealMonthlyCompare, lunchMealMonthlyCompare, dinnerMealMonthlyCompare, snacksMealMonthlyCompare);
        }

        private object SnacksMonthlyMealCompare()
        {
            var SnacksMonthlyMealCompare = _adminStatsService.SnacksMonthlyMealCompareList(_selectuser);
            return SnacksMonthlyMealCompare;
        }

        private object DinnerMonthlyMealCompare()
        {
            var DinnerMonthlyMealCompare = _adminStatsService.DinnerMonthlyMealCompareList(_selectuser);
            return DinnerMonthlyMealCompare;
        }

        private object LunchMonthlyMealCompare()
        {

            var LunchMonthlyMealCompare = _adminStatsService.LunchMonthlyMealCompareList(_selectuser);
            return LunchMonthlyMealCompare;
        }

        private object BreakfastMonthyMealCompare()
        {
            var BreakfastMonthlyMealCompare = _adminStatsService.BreakfastMonthlyMealCompareList(_selectuser);
            return BreakfastMonthlyMealCompare;
        }
        private void UserStatsFormMealCategoryButton_Click(object sender, EventArgs e)
        {
            WeeklyMealCompare();
        }

        private void UserStatFormMonthlyMealCompare_Click_1(object sender, EventArgs e)
        {
            MonthlyMealCompare();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TotalFoodList();
        }





        // WEEKLY CATEGORY COMPARISON BUTTON
        private void UserStatsFormMonthlyButton_Click(object sender, EventArgs e)
        {
            DataGridviewClear();
            dgvCategoryComparisonAverageCalorie.DataSource = _ComparisonServiceAdmin.AdminMonthlyFill(_selectuser);
            dgvCategoryComparisonUserCalorie.DataSource = _ComparisonServiceAdmin.AdminMontlyhFill2(_selectuser);
            dgvCategoryComparisonAverageCalorie.Show();
            dgvCategoryComparisonUserCalorie.Show();
            dgvBreakfast.Hide();
            dgvLunch.Hide();
            dgvDinner.Hide();
            dgvSnacks.Hide();
            AdminStatsFormUsersMealDgv.Hide();
        }

        // MONTHLY CATEGORY COMPARISON BUTTON
        private void UserStatsFormWeeklyButton_Click(object sender, EventArgs e)
        {
            DataGridviewClear();
            dgvCategoryComparisonAverageCalorie.DataSource = _ComparisonServiceAdmin.AdminWeeklyFill(_selectuser);
            dgvCategoryComparisonUserCalorie.DataSource = _ComparisonServiceAdmin.AdminWeeklyFill2(_selectuser);
            dgvCategoryComparisonAverageCalorie.Show();
            dgvCategoryComparisonUserCalorie.Show();
            dgvBreakfast.Hide();
            dgvLunch.Hide();
            dgvDinner.Hide();
            dgvSnacks.Hide();
            AdminStatsFormUsersMealDgv.Hide();
        }

        private void AdminStatsFormUsersMealDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
