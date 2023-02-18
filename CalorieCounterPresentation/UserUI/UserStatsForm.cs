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

        private void AdminStatsForm_Load(object sender, EventArgs e)
        {
            UsersFill();
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
            CalorieCalculator();
        }

        #region RunTime-DataGridView
        Label lblBreakfast = new Label();
        Label lblLunch = new Label();
        Label lblDinner = new Label();
        Label lblSnacks = new Label();

        DataGridView dgvBreakfast = new DataGridView();
        DataGridView dgvLunch = new DataGridView();
        DataGridView dgvDinner = new DataGridView();
        DataGridView dgvSnacks = new DataGridView();
        #endregion

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
            TotalFoodList();
            CreateCountUsersMealDgv();
        }

        private void CreateCountUsersMealDgv()
        {
            int Width = UserStatsFormUsersMealDgv.Width / 4;
            UserStatsFormUsersMealDgv.Hide();
            dgvBreakfast.Location = new System.Drawing.Point(12, 300);
            dgvBreakfast.Size = new System.Drawing.Size(Width, UserStatsFormUsersMealDgv.Height - 16);
            dgvBreakfast.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvLunch.Location = new System.Drawing.Point(dgvBreakfast.Location.X + Width, 300);
            dgvLunch.Size = new System.Drawing.Size(Width, UserStatsFormUsersMealDgv.Height - 16);
            dgvLunch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvDinner.Location = new System.Drawing.Point(dgvLunch.Location.X + Width, 300);
            dgvDinner.Size = new System.Drawing.Size(Width, UserStatsFormUsersMealDgv.Height - 16);
            dgvDinner.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvSnacks.Location = new System.Drawing.Point(dgvDinner.Location.X + Width, 300);
            dgvSnacks.Size = new System.Drawing.Size(Width, UserStatsFormUsersMealDgv.Height - 16);
            dgvSnacks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            lblBreakfast.Location = new System.Drawing.Point(12, 284);
            lblLunch.Location = new System.Drawing.Point(lblBreakfast.Location.X + Width, 284);
            lblDinner.Location = new System.Drawing.Point(lblLunch.Location.X + Width, 284);
            lblSnacks.Location = new System.Drawing.Point(lblDinner.Location.X + Width, 284);

            lblBreakfast.Text = "Breakfast";
            lblLunch.Text = "Lunch";
            lblDinner.Text = "Dinner";
            lblSnacks.Text = "Snacks";

            this.Controls.Add(dgvBreakfast);
            this.Controls.Add(dgvLunch);
            this.Controls.Add(dgvDinner);
            this.Controls.Add(dgvLunch);
            this.Controls.Add(dgvSnacks);

            this.Controls.Add(lblBreakfast);
            this.Controls.Add(lblLunch);
            this.Controls.Add(lblDinner);
            this.Controls.Add(lblSnacks);

        }


        private void UserStatFormWeeklyMealCompare_Click(object sender, EventArgs e)
        {
            
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










        // kullanılmayanlar
        private void UserStatsFormDailyButton_Click(object sender, EventArgs e)
        {
            // Selamlar git hub deneme
        }

        private void UserStatsForm_Load(object sender, EventArgs e)
        {
            // Hasan 
        }

        private void UserStatsFormFoodCategoryButton_Click(object sender, EventArgs e)
        {
            CalorieCalculator();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void UserStatsFormMealCategoryButton_Click(object sender, EventArgs e)
        {
            WeeklyMealCompare();
            CreateCountUsersMealDgv();
        }

        private void UserStatsFormYearlyButton_Click(object sender, EventArgs e)
        {
            MonthlyMealCompare();
            CreateCountUsersMealDgv();
        }

        // KIYAS RAPORLARI

        // CATEGORY WEEKLY
        private void UserStatsFormMonthlyButton_Click(object sender, EventArgs e)
        {
            DataGridviewClear();
            WeeklyDvg1.DataSource = _ComparisonService.UserWeeklyFill(_selectuser);
            WeeklyDvg2.DataSource = _ComparisonService.UserWeeklyFill2(_selectuser);
        }

        // WeeklyDVG1
        DataGridView WeeklyDvg1 = new DataGridView();
        private void CreateCategoryDgv1()
        {
            int Width = UserStatsFormUsersMealDgv.Width / 2;
            UserStatsFormUsersMealDgv.Hide();
            WeeklyDvg1.Location = new System.Drawing.Point(12, 300);
            WeeklyDvg1.Size = new System.Drawing.Size(Width, UserStatsFormUsersMealDgv.Height - 16);
            WeeklyDvg1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.Controls.Add(WeeklyDvg1);
        }


        private void UserCountReportFill1(dynamic _breakfastFoodList)
        {
            UserStatsFormUsersMealDgv.ReadOnly = true;
            UserStatsFormUsersMealDgv.AllowUserToDeleteRows = false;
            WeeklyDvg1.DataSource = _breakfastFoodList;
        }

        // ------------------------------

        // WeeklyDVG2
        DataGridView WeeklyDvg2 = new DataGridView();
        private void CreateCategoryDgv2()
        {
            int Width = UserStatsFormUsersMealDgv.Width / 2;
            UserStatsFormUsersMealDgv.Hide();
            WeeklyDvg2.Location = new System.Drawing.Point(12, 300);
            WeeklyDvg2.Size = new System.Drawing.Size(Width, UserStatsFormUsersMealDgv.Height - 16);
            WeeklyDvg2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.Controls.Add(WeeklyDvg2);
        }


        private void UserCountReportFill2(dynamic _breakfastFoodList)
        {
            UserStatsFormUsersMealDgv.ReadOnly = true;
            UserStatsFormUsersMealDgv.AllowUserToDeleteRows = false;
            WeeklyDvg2.DataSource = _breakfastFoodList;
        }


        // KIYAS RAPORLARI

        // CATEGORY MONTHLY
        private void UserStatsFormWeeklyButton_Click(object sender, EventArgs e)
        {
            DataGridviewClear();
            MonthlyDvg1.DataSource = _ComparisonService.UserWeeklyFill(_selectuser);
            MonthlyDvg2.DataSource = _ComparisonService.UserWeeklyFill2(_selectuser);
        }

        // MonthlyDVG1
        DataGridView MonthlyDvg1 = new DataGridView();
        private void CreateCategoryDgv3()
        {
            int Width = UserStatsFormUsersMealDgv.Width / 2;
            UserStatsFormUsersMealDgv.Hide();
            MonthlyDvg1.Location = new System.Drawing.Point(12, 300);
            MonthlyDvg1.Size = new System.Drawing.Size(Width, UserStatsFormUsersMealDgv.Height - 16);
            MonthlyDvg1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.Controls.Add(MonthlyDvg1);
        }


        private void UserCountReportFill3(dynamic _breakfastFoodList)
        {
            UserStatsFormUsersMealDgv.ReadOnly = true;
            UserStatsFormUsersMealDgv.AllowUserToDeleteRows = false;
            MonthlyDvg1.DataSource = _breakfastFoodList;
        }

        // ------------------------------

        // MonthlyDVG2
        DataGridView MonthlyDvg2 = new DataGridView();
        private void CreateCategoryDgv4()
        {
            int Width = UserStatsFormUsersMealDgv.Width / 2;
            UserStatsFormUsersMealDgv.Hide();
            MonthlyDvg2.Location = new System.Drawing.Point(12, 300);
            MonthlyDvg2.Size = new System.Drawing.Size(Width, UserStatsFormUsersMealDgv.Height - 16);
            MonthlyDvg2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.Controls.Add(MonthlyDvg2);
        }


        private void UserCountReportFill4(dynamic _breakfastFoodList)
        {
            UserStatsFormUsersMealDgv.ReadOnly = true;
            UserStatsFormUsersMealDgv.AllowUserToDeleteRows = false;
            MonthlyDvg2.DataSource = _breakfastFoodList;
        }
    }
}
