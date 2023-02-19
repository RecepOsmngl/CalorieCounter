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

namespace CalorieCounterPresentation.UserUI
{
    public partial class UserStatsForm : Form
    {
        UserEntity _selectuser = new UserEntity();
        AdminStatsService _adminStatsService = new AdminStatsService();
        ComparisonService _ComparisonService = new ComparisonService();

        public UserStatsForm(UserEntity currentuser)
        {
            InitializeComponent();
            _selectuser = currentuser; 
        }
        private void UserStatsForm_Load(object sender, EventArgs e)
        {
            dgvBreakfast.Hide();
            dgvLunch.Hide();
            dgvDinner.Hide();
            dgvSnacks.Hide();
            dgvUserAverageCalorie.Hide();
            dgvUserUserCalorie.Hide();
            UserStatsFormUsersMealDgv.Show();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            MainUserForm _MainUserForm = new MainUserForm(_selectuser);
            _MainUserForm.Show();
            this.Hide();
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

        private int BreakfastCalorieCalculator()
        {
            int BreakfastTotalCalorie = _adminStatsService.BreakfastTotalCalorie(_selectuser);
            //AdminStatsFormUsersMealDgv.Columns["TotalBreakfastCalorie"].ValueType = BreakfastTotalCalorie;
            return BreakfastTotalCalorie;
        }

        private int LunchCalorieCalculator()
        {

            int LunchTotalCalorie = _adminStatsService.LunchTotalCalorie(_selectuser);
            return LunchTotalCalorie;
        }

        private int DinnerCalorieCalculator()
        {
            int DinnerTotalCalorie = _adminStatsService.DinnerTotalCalorie(_selectuser);
            return DinnerTotalCalorie;
        }

        private int SnackCalorieCalculator()
        {

            int SnackTotalCalorie = _adminStatsService.SnackTotalCalorie(_selectuser);
            return SnackTotalCalorie;
        }

        private void UserStatsFormUsersMealDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridviewClear();
            _selectuser.UserID = int.Parse(UserStatsFormUsersMealDgv.CurrentRow.Cells[0].Value.ToString());
        }

        public void UsersFill()
        {
            UserStatsFormUsersMealDgv.DataSource = _adminStatsService.UserServiceFill();
            //AdminStatsFormUserDgv.Columns["UserPassword"].Visible = false;
            //AdminStatsFormUserDgv.Columns["UserHeight"].Visible = false;
            //AdminStatsFormUserDgv.Columns["UserWeight"].Visible = false;
            //AdminStatsFormUserDgv.Columns["UserGender"].Visible = false;
            //AdminStatsFormUserDgv.Columns["MealEntity"].Visible = false;
        }

        public void UserMealFill(int _TotalBreakfastCalorie, int _TotalLunchCalorie, int _TotalDinnerCalorie, int _TotalSnackCalorie, int _TotalCalorie)
        {
            DataGridviewClear();
            UserStatsFormUsersMealDgv.ReadOnly = true;
            UserStatsFormUsersMealDgv.AllowUserToDeleteRows = false;
            UserStatsFormUsersMealDgv.ColumnCount = 5;
            UserStatsFormUsersMealDgv.Columns[0].Name = "Breakfast Total Calorie";
            UserStatsFormUsersMealDgv.Columns[1].Name = "Lunch Total Calorie";
            UserStatsFormUsersMealDgv.Columns[2].Name = "Dinner Total Calorie";
            UserStatsFormUsersMealDgv.Columns[3].Name = "Snack Total Calorie";
            UserStatsFormUsersMealDgv.Columns[4].Name = "Total Calorie";
            UserStatsFormUsersMealDgv.Rows.Add(_TotalBreakfastCalorie, _TotalLunchCalorie, _TotalDinnerCalorie, _TotalSnackCalorie, _TotalCalorie);
            //AdminStatsFormUsersMealDgv.DataSource = _adminStatsService.FoodEntitie();
        }

        private void DataGridviewClear()
        {
            UserStatsFormUsersMealDgv.DataSource = null;
            UserStatsFormUsersMealDgv.Rows.Clear();
        }

        private void AdminEndofDayButton_Click(object sender, EventArgs e)
        {
            dgvBreakfast.Hide();
            dgvLunch.Hide();
            dgvDinner.Hide();
            dgvSnacks.Hide();
            dgvUserUserCalorie.Hide();
            dgvUserAverageCalorie.Hide();
            UserStatsFormUsersMealDgv.Show();
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
            UserStatsFormUsersMealDgv.ReadOnly = true;
            UserStatsFormUsersMealDgv.AllowUserToDeleteRows = false;
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
            UserStatsFormUsersMealDgv.Hide();
            dgvUserAverageCalorie.Hide();
            dgvUserUserCalorie.Hide();
            TotalFoodList();
        }

        private void UserStatFormWeeklyMealCompare_Click(object sender, EventArgs e)
        {
            dgvBreakfast.Show();
            dgvLunch.Show();
            dgvDinner.Show();
            dgvSnacks.Show();
            UserStatsFormUsersMealDgv.Hide();
            dgvUserAverageCalorie.Hide();
            dgvUserUserCalorie.Hide();
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
            UserStatsFormUsersMealDgv.Hide();
            dgvUserUserCalorie.Hide();
            dgvUserAverageCalorie.Hide();
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
        private void UserStatsFormFoodCategoryButton_Click(object sender, EventArgs e)
        {
            dgvBreakfast.Hide();
            dgvLunch.Hide();
            dgvDinner.Hide();
            dgvSnacks.Hide();
            dgvUserAverageCalorie.Hide();
            dgvUserUserCalorie.Hide();
            UserStatsFormUsersMealDgv.Show();
            CalorieCalculator();
        }




        // kullanılmayanlar
        private void UserStatsFormDailyButton_Click(object sender, EventArgs e)
        {
            // Selamlar git hub deneme
        }

       

        

        private void UserStatsFormMealCategoryButton_Click(object sender, EventArgs e)
        {
            WeeklyMealCompare();
        }

        private void UserStatsFormYearlyButton_Click(object sender, EventArgs e)
        {
            MonthlyMealCompare();
        }

        // KIYAS RAPORLARI

        // CATEGORY 
        private void UserStatsFormMonthlyButton_Click(object sender, EventArgs e)
        {
            DataGridviewClear();
            dgvUserUserCalorie.DataSource = _ComparisonService.UserMonthlyFill(_selectuser);
            dgvUserAverageCalorie.DataSource = _ComparisonService.UserMontlyhFill2(_selectuser);
            dgvUserAverageCalorie.Show();
            dgvUserUserCalorie.Show();
            dgvBreakfast.Hide();
            dgvLunch.Hide();
            dgvDinner.Hide();
            dgvSnacks.Hide();
            UserStatsFormUsersMealDgv.Hide();
        }

        private void UserStatsFormWeeklyButton_Click(object sender, EventArgs e)
        {
            DataGridviewClear();
            dgvUserUserCalorie.DataSource = _ComparisonService.UserWeeklyFill(_selectuser);
            dgvUserAverageCalorie.DataSource = _ComparisonService.UserWeeklyFill2(_selectuser);
            dgvUserAverageCalorie.Show();
            dgvUserUserCalorie.Show();
            dgvBreakfast.Hide();
            dgvLunch.Hide();
            dgvDinner.Hide();
            dgvSnacks.Hide();
            UserStatsFormUsersMealDgv.Hide();
        }
    }
}
