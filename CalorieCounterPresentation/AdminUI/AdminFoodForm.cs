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

namespace CalorieCounterPresentation.AdminUI
{
    public partial class AdminFoodForm : Form
    {

        CalorieCounterContext _db;
        FoodService _foodService = new FoodService();
        FoodEntity _foodEntity ;
        FoodCategoryEntity _foodCategoryEntity;
        public AdminFoodForm()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            MainAdminForm _MainAdminForm = new MainAdminForm();
            _MainAdminForm.Show();
            this.Hide();
        }
        //Butonların isimleriyle bağlı olan fonksiyon.Butonlara tıklandığında ismine göre fonksiyonları çalıştırıyor.
        private void Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            object name = button.Name;
            switch (name)
            {
                case "AdminFoodFormAddButton": FoodAdd(); break;
                case "AdminFoodFormEditButton": FoodEdit(); break;
                case "AdminFoodFormDeleteButton": FoodDelete(); break;
                case "AdminFoodFormSearchButton": FoodSearch(); break;
            }
        }
        //Menustripten gelen clicke bağlı fonksiyon.
        public void CsmClick(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            object name = menuItem.Name;
            switch (name)
            {
                case "csmRefresh": TsmRefresh(); break;
            }
        }
        //Menustripten refreshe tıklanırsa bu method çalışacak ve datagridview datayla dolacak.

        private void TsmRefresh()
        {
            FoodFill();
        }
        //Ürün arama butonuna basıldığında çalışcak fonksiyon. Databasede ürün varsa datagridviewe yazdıracak.

        private void FoodSearch()
        {
            string foodName = AdminFoodFormFoodNameTextBox.Text.Trim();
            foodName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(foodName);
            try
            {
                if (!string.IsNullOrWhiteSpace(foodName))
                {
                    _foodEntity = new FoodEntity();
                    _foodEntity.FoodName = foodName;
                    List<FoodEntity> IsCheck = new List<FoodEntity>();
                    IsCheck = _foodService.FoodSearch(_foodEntity);
                    if (IsCheck.Count != 0)
                    {

                        MessageBox.Show($"The food named  {_foodEntity.FoodName},has been successfully found!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AdminFoodFormDataGridView.DataSource = IsCheck;
                        //IsCheck.Clear();
                        FoodTextBoxClear();
                    }
                    else
                    {
                        MessageBox.Show("Please try again!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        FoodFill();
                        FoodTextBoxClear();
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
        //Datagridviewden seçilen ürünün databaseden silinmesini gerçekleştiren fonksiyon.

        private void FoodDelete()
        {

            try
            {
                _foodEntity = new FoodEntity();
                _foodEntity.FoodID = id;


                bool IsCheck = _foodService.FoodDelete(_foodEntity);
                if (IsCheck)
                {
                    MessageBox.Show($"id {_foodEntity.FoodID} has been deleted successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FoodFill();
                    FoodTextBoxClear();
                }
                else
                {
                    MessageBox.Show("Please try again!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FoodTextBoxClear();
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Registration already exists!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Ürün güncelleme fonksiyonu.Edit butonuna basıldığında çalışıyor.
        private void FoodEdit()
        {
            string foodName = AdminFoodFormFoodNameTextBox.Text.Trim();
            var foodCategoryId = int.Parse(AdminFoodFormFoodCategoryNameTextBox.Text.Trim());
            var foodCalorie = int.Parse(AdminFoodFormFoodCalorieTextBox.Text.Trim());
            foodName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(foodName);

            try
            {
                if (!string.IsNullOrWhiteSpace(foodName) && foodCategoryId != null && foodCalorie != null)
                {
                    _foodEntity = new FoodEntity();
                    _foodEntity.FoodID = id;
                    _foodEntity.FoodName = foodName;
                    _foodEntity.FoodCategoryID = foodCategoryId;
                    _foodEntity.FoodCalorie = foodCalorie;

                    bool IsCheck = _foodService.FoodEdit(_foodEntity);
                    if (IsCheck)
                    {
                        MessageBox.Show("Editting Successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FoodFill();
                        FoodTextBoxClear();
                    }
                    else
                    {
                        MessageBox.Show("Please try again!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        FoodTextBoxClear();
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
        //Datagridviewde seçilen ürünün ıd sini bu şekilde elde edip güncelleme fonksiyonunda kullanıyoruz.
        int id;

        //Datagridviewde ürünün üstüne tıklandığında ürün içeriklerini textboxları atayan fonksiyon.
        private void AdminFoodFormDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AdminFoodFormFoodNameTextBox.Text = AdminFoodFormDataGridView.CurrentRow.Cells[1].Value.ToString();
            id = int.Parse(AdminFoodFormDataGridView.CurrentRow.Cells[0].Value.ToString());
            AdminFoodFormFoodCategoryNameTextBox.Text = AdminFoodFormDataGridView.CurrentRow.Cells[2].Value.ToString();
            AdminFoodFormFoodCalorieTextBox.Text = AdminFoodFormDataGridView.CurrentRow.Cells[4].Value.ToString();
            
        }
        //Ürün ekleme fonksiyonu. Add butonuna tıklandığında çalışıyor.
        private void FoodAdd()
        {
            string foodName = AdminFoodFormFoodNameTextBox.Text.Trim();
            var foodCategoryName = AdminFoodFormFoodCategoryNameTextBox.Text.Trim();

            var foodCalorie=0;
            int _DefaultCalorie = 0;
            bool _IsParsedHeight = int.TryParse(AdminFoodFormFoodCalorieTextBox.Text.Trim(), out _DefaultCalorie);
            if (_IsParsedHeight)
            {
                foodCalorie = int.Parse(AdminFoodFormFoodCalorieTextBox.Text.Trim());
            }
            else
            {
                foodCalorie = _DefaultCalorie;
            }


            //var foodCalorie = int.Parse(AdminFoodFormFoodCalorieTextBox.Text.Trim());
            foodName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(foodName);

            try
            {
                if (!string.IsNullOrWhiteSpace(foodName) && foodCategoryName != null && foodCalorie != 0)
                {
                    _foodEntity = new FoodEntity();
                    _foodEntity.FoodName = foodName;
                    _foodCategoryEntity=new FoodCategoryEntity();
                    _foodCategoryEntity.FoodCategoryName = foodCategoryName;
                    int foodEntityFoodCategoryId= _foodService.FoodIdAdd(_foodCategoryEntity);
                    //_foodEntity.FoodCategoryEntity.FoodCategoryName=foodCategoryName;
                    _foodEntity.FoodCategoryID = foodEntityFoodCategoryId;
                    _foodEntity.FoodCalorie = foodCalorie;

                    bool IsCheck = _foodService.FoodAddIsCheck(_foodEntity);
                    if (IsCheck)
                    {
                        bool Ischeckadd = _foodService.FoodAdd(_foodEntity);

                        if (Ischeckadd)
                        {
                            MessageBox.Show("Adding Successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FoodFill();
                            FoodTextBoxClear();
                        }
                        else
                        {
                            MessageBox.Show("Please try again!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            FoodTextBoxClear();
                        }
                    }


                    else
                    {
                        MessageBox.Show("The food you entered is available in the list", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        //Tablodaki ürünleri datagridviewe dolduran fonksiyon.
        public void FoodFill()
        {
            AdminFoodFormDataGridView.DataSource = _foodService.FoodEntitie();
            AdminFoodFormDataGridView.Columns["MealEntity"].Visible = false;
            AdminFoodFormDataGridView.Columns["FoodCategoryEntity"].Visible = false;
            AdminFoodFormDataGridView.Columns["PhotographEntity"].Visible = false;
            AdminFoodFormDataGridView.Columns["PhotographID"].Visible = false;
        }
        //Textboxları temizleyen fonksiyon.
        private void FoodTextBoxClear()
        {
            AdminFoodFormFoodNameTextBox.Clear();
            AdminFoodFormFoodCategoryNameTextBox.Clear();
            AdminFoodFormFoodCalorieTextBox.Clear();
        }

        private void AdminFoodForm_Load(object sender, EventArgs e)
        {

            using (_db = new CalorieCounterContext())
            {
                AdminFoodFormDataGridView.DataSource = _db.FoodCategoryEntityTable.ToList();
                AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
                foreach (FoodCategoryEntity item in AdminFoodFormDataGridView.DataSource as List<FoodCategoryEntity>)
                {
                    ac.Add(item.FoodCategoryName);

                }
                AdminFoodFormFoodCategoryNameTextBox.AutoCompleteCustomSource = ac;
            }

            FoodFill();
            FoodTextBoxClear();
        }

        private void AdminFoodFormFoodCategoryNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                using (_db =new CalorieCounterContext())
                {
                   AdminFoodFormDataGridView.DataSource= _db.FoodCategoryEntityTable.Where(x=>x.FoodCategoryName.Contains(AdminFoodFormFoodCategoryNameTextBox.Text)).ToList();
                }
            }

        }

        private void AdminFoodFormFoodNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AdminFoodFormDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
