using CalorieCounterBusiness.Services;
using CalorieCounterDataAccess;
using CalorieCounterEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        CalorieCounterContext _db;
        UserEntity _user;
        int _userId ;
        public UserMealForm(UserEntity currentuser)
        {
            InitializeComponent();
            _user = currentuser;
            _userId = _user.UserID;
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
        private void Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            object name = button.Name;
            switch (name)
            {
                case "UserMealFormAddButton": MealAdd(); break;
                case "UserMealFormEditButton": MealEdit(); break;
                case "UserMealFormDeleteButton": MealDelete(); break;
                case "UserMealFormSearchButton": MealSearch(); break;
            }
        }

        private void MealSearch()
        {
            throw new NotImplementedException();
        }

        private void MealDelete()
        {
            try
            {
                _mealEntity = new MealEntity();
               _mealEntity.MealID= id;


                bool IsCheck = _userMealService.MealDelete(_mealEntity);
                if (IsCheck)
                {
                    MessageBox.Show($"id {_mealEntity.MealID} has been deleted successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MealFill();
                    MealTextBoxClear();
                }
                else
                {
                    MessageBox.Show("Please try again!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MealTextBoxClear();
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Registration already exists!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MealEdit()
        {
            int MealCategoryId = (int)UserMealFormMealCategoryCmbox.SelectedValue;
            var MealTime = dateTimePicker1.Value.Date;
            string FoodName= UserMealFormFoodNameTextBox.Text;
            _foodEntity = new FoodEntity();
            _foodEntity.FoodName = FoodName;
            int foodEntityId =_userMealService.FoodIdAdd(_foodEntity);


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
                   
                    _mealEntity.MealCategoryID = MealCategoryId;
                    _mealEntity.MealTime = MealTime;
                    _mealEntity.FoodID = foodEntityId;
                    
                    _mealEntity.MealID = id;
                    _mealEntity.UserID = _userId;
                    _mealEntity.FoodPortion = FoodPortion;
                    _mealEntity.FoodTotalCalorie = ComeTotalCalorie();
                    UserMealFormFoodTotalCalorieLabel.Text = ComeTotalCalorie().ToString();

                    bool IscheckEdit = _userMealService.MealEdit(_mealEntity);
                    if (IscheckEdit)
                    {
                        MessageBox.Show("Editting Successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("please enter food name,foodcategoryıd and foodcalorie!");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Registration already exists!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var MealTime = dateTimePicker1.Value.Date;
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
            using (_db = new CalorieCounterContext())
            {
                List<FoodEntity> _FoodEntityList = _db.FoodEntityTable.ToList();
                AutoCompleteStringCollection aca = new AutoCompleteStringCollection();
                foreach (FoodEntity item in _FoodEntityList)
                {
                    aca.Add(item.FoodName);

                }
                UserMealFormFoodNameTextBox.AutoCompleteCustomSource = aca;
            }
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
        int id;
        bool FoodId;
        private void UserMealFormDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UserMealFormMealCategoryCmbox.Text = UserMealFormDataGridView.CurrentRow.Cells[3].Value.ToString();
            UserMealFormMealCategoryCmbox.DisplayMember = "MealCategoryName";
            UserMealFormMealCategoryCmbox.ValueMember = "MealCategoryID";
            dateTimePicker1.Value = (DateTime)UserMealFormDataGridView.CurrentRow.Cells[6].Value;
            UserMealFormFoodNameTextBox.Text = UserMealFormDataGridView.CurrentRow.Cells[2].Value.ToString();
           
            UserMealFormFoodPortionTextBox.Text = UserMealFormDataGridView.CurrentRow.Cells[4].Value.ToString();
            id = int.Parse(UserMealFormDataGridView.CurrentRow.Cells[7].Value.ToString());
            
            //AdminFoodFormFoodNameTextBox.Text = AdminFoodFormDataGridView.CurrentRow.Cells[1].Value.ToString();
            //id = int.Parse(AdminFoodFormDataGridView.CurrentRow.Cells[0].Value.ToString());
            //int _foodcategoryid = int.Parse(AdminFoodFormDataGridView.CurrentRow.Cells[2].Value.ToString());
            //string foodcategoryname = _foodService.ComeFoodCategoryName(_foodcategoryid);
            //AdminFoodFormFoodCategoryNameTextBox.Text = foodcategoryname;
            //AdminFoodFormFoodCalorieTextBox.Text = AdminFoodFormDataGridView.CurrentRow.Cells[4].Value.ToString();
            //AdminFoodFormEditButton.Enabled = true;
        }
    }
}
