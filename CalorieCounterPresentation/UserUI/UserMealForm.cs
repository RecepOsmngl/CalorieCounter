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
    public partial class UserMealForm : Form
    {
        MealService _userMealService;
        MealEntity _mealEntity;
        FoodEntity _foodEntity;
        int _userId = 3;
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
        private void Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            object name = button.Name;
            switch (name)
            {
                case "UserMealFormAddButton": MealAdd(); break;
                    //case "UserMealFormEditButton": MealEdit(); break;
                    //case "UserMealFormDeleteButton": MealDelete(); break;
                    //case "UserMealFormSearchButton": MealSearch(); break;
            }
        }

        private void MealAdd()
        {
            //var foodCalorie = 0;
            //int _DefaultCalorie = 0;
            //bool _IsParsedHeight = int.TryParse(AdminFoodFormFoodCalorieTextBox.Text.Trim(), out _DefaultCalorie);
            //if (_IsParsedHeight)
            //{
            //    foodCalorie = int.Parse(AdminFoodFormFoodCalorieTextBox.Text.Trim());
            //}
            //else
            //{
            //    foodCalorie = _DefaultCalorie;
            //}

            //CategoryID = (int)cmbKategoriler.SelectedValue
            int MealCategoryId = (int)UserMealFormMealCategoryCmbox.SelectedValue;
            var MealTime = dateTimePicker1.Value;
            var FoodName = UserMealFormFoodNameTextBox.Text;

            var FoodPortion = 0;
            int _DefaultPortion = 0;
            bool _IsParsedPortion = int.TryParse(UserMealFormFoodPortionTextBox.Text.Trim(), out _DefaultPortion);
            if (_IsParsedPortion)
                FoodPortion = int.Parse(UserMealFormFoodPortionTextBox.Text.Trim());
            else
                FoodPortion = _DefaultPortion;


            try
            {
                if (!string.IsNullOrWhiteSpace(FoodName) && FoodPortion != 0 && MealCategoryId != 0 && MealTime != null)
                {
                    _mealEntity = new MealEntity();
                    _foodEntity = new FoodEntity();
                    _mealEntity.MealCategoryID = MealCategoryId;
                    _mealEntity.MealTime = MealTime;
                    _foodEntity.FoodName = FoodName;
                    int FoodId = _userMealService.FoodIdAdd(_foodEntity);
                    _mealEntity.FoodID = FoodId;
                    /* bakılacak*/
                    _mealEntity.UserID = _userId;
                    _mealEntity.FoodPortion = FoodPortion;
                    _mealEntity.FoodTotalCalorie = ComeTotalCalorie();
                    UserMealFormFoodTotalCalorieLabel.Text = ComeTotalCalorie().ToString();


                    bool Ischeckadd = _userMealService.MealAdd(_mealEntity);

                    if (Ischeckadd)
                    {
                        MessageBox.Show("Adding Successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MealFill();
                        MealTextBoxClear();
                    }
                    else
                    {
                        MessageBox.Show("Please try again!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MealTextBoxClear();
                    }




                }
                else
                {
                    MessageBox.Show("please enter food name,FoodPortion,MealTime and MealCategoryId!");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }




        }
        private int ComeTotalCalorie()
        {
            _foodEntity = new FoodEntity();
            var FoodName = UserMealFormFoodNameTextBox.Text;
            _foodEntity.FoodName = FoodName;
            int FoodCalorie = _userMealService.FoodCalorie(_foodEntity);
            int FoodPortion = int.Parse(UserMealFormFoodPortionTextBox.Text);
            int TotalCalorie = FoodCalorie * FoodPortion;
            return TotalCalorie;

        }
        private void ComboboxFill()
        {
            _userMealService = new MealService();
            //AdminFoodFormDataGridView.DataSource = _foodService.FoodEntitie();
            UserMealFormMealCategoryCmbox.DataSource = _userMealService.MealCategoryEntitie();
            UserMealFormMealCategoryCmbox.DisplayMember = "MealCategoryName";
            UserMealFormMealCategoryCmbox.ValueMember = "MealCategoryID";
        }

        private void UserMealForm_Load(object sender, EventArgs e)
        {
            UserMealFormLabel8.Text = "100 gr";
            ComboboxFill();
            MealFill();
        }
        public void MealFill()
        {
            UserMealFormDataGridView.DataSource = _userMealService.MealEntitie(_userId);
            //AdminFoodFormDataGridView.Columns["MealEntity"].Visible = false;
            //AdminFoodFormDataGridView.Columns["FoodCategoryEntity"].Visible = false;
            //AdminFoodFormDataGridView.Columns["PhotographEntity"].Visible = false;
        }
        private void MealTextBoxClear()
        {
           UserMealFormFoodNameTextBox.Clear();
           UserMealFormFoodPortionTextBox.Clear();
          
        }

        private void UserMealFormAddButton_Click(object sender, EventArgs e)
        {

        }
    }
}
