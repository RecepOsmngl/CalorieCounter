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
    public partial class AdminFoodCategoryForm : Form
    {
        CalorieCounterContext _db;
        FoodCategoryService _foodCategoryService = new FoodCategoryService();
        FoodCategoryEntity _foodCategoryEntity = new FoodCategoryEntity();
        public AdminFoodCategoryForm()
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
                case "AdminFoodCategoryFormAddButton": FoodCategoryAdd(); break;
                case "AdminFoodCategoryFormEditButton": FoodCategoryEdit(); break;
                case "AdminFoodCategoryFormDeleteButton": FoodCategoryDelete(); break;
                case "AdminFoodCategoryFormSearchButton": FoodCategorySearch(); break;
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
        private void FoodCategorySearch()
        {
            string foodName = AdminFoodCategoryFormFoodCategoryNameTextBox.Text.Trim();
            foodName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(foodName);
            try
            {
                if (!string.IsNullOrWhiteSpace(foodName))
                {
                    _foodCategoryEntity.FoodCategoryName = foodName;
                    List<FoodCategoryEntity> IsCheck = new List<FoodCategoryEntity>();
                    IsCheck = _foodCategoryService.FoodCategorySearch(_foodCategoryEntity);
                    if (IsCheck.Count != 0)
                    {

                        MessageBox.Show($"The foodcategory named  {_foodCategoryEntity.FoodCategoryName},has been successfully found!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AdminFoodCategoryFormDataGridView.DataSource = IsCheck;
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
                    MessageBox.Show("please enter foodcategory name!");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Registration already exists!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        //Datagridviewden seçilen ürünün databaseden silinmesini gerçekleştiren fonksiyon.
        private void FoodCategoryDelete()
        {

            try
            {
                _foodCategoryEntity.FoodCategoryID = id;


                bool IsCheck = _foodCategoryService.FoodCategoryDelete(_foodCategoryEntity);
                if (IsCheck)
                {
                    MessageBox.Show($"id {_foodCategoryEntity.FoodCategoryName} has been deleted successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void FoodCategoryEdit()
        {
            string foodName = AdminFoodCategoryFormFoodCategoryNameTextBox.Text.Trim();
            foodName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(foodName);

            try
            {
                if (!string.IsNullOrWhiteSpace(foodName))
                {
                    _foodCategoryEntity.FoodCategoryID = id;
                    _foodCategoryEntity.FoodCategoryName = foodName;


                    bool IsCheck = _foodCategoryService.FoodCategoryEdit(_foodCategoryEntity);
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
                    MessageBox.Show("please enter food name!");
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
            AdminFoodCategoryFormFoodCategoryNameTextBox.Text = AdminFoodCategoryFormDataGridView.CurrentRow.Cells[1].Value.ToString();
            id = int.Parse(AdminFoodCategoryFormDataGridView.CurrentRow.Cells[0].Value.ToString());

        }

        //Ürün ekleme fonksiyonu. Add butonuna tıklandığında çalışıyor.
        private void FoodCategoryAdd()
        {
            _db = new CalorieCounterContext();
            string foodName = AdminFoodCategoryFormFoodCategoryNameTextBox.Text.Trim();

            foodName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(foodName);
            try
            {
                if (!string.IsNullOrWhiteSpace(foodName))
                {
                    _foodCategoryEntity.FoodCategoryName = foodName;
                    bool IsCheck = _foodCategoryService.FoodCategoryAddIsCheck(_foodCategoryEntity);
                    if (IsCheck)
                    {
                        bool Ischeckadd = _foodCategoryService.FoodCategoryAdd(_foodCategoryEntity);

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
                        MessageBox.Show("The foodcategory you entered is available in the list", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("please enter foodcategory name!");
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
            AdminFoodCategoryFormDataGridView.DataSource = _foodCategoryService.FoodCategoryEntitie();
            AdminFoodCategoryFormDataGridView.Columns["FoodEntity"].Visible = false;
            //AdminFoodCategoryFormDataGridView.Columns["FoodCategoryEntity"].Visible = false;
        }
        //Textboxları temizleyen fonksiyon.
        private void FoodTextBoxClear()
        {
            AdminFoodCategoryFormFoodCategoryNameTextBox.Clear();

        }



        private void AdminFoodCategoryFormDataGridView_Click(object sender, EventArgs e)
        {

        }

        private void AdminFoodCategoryForm_Load(object sender, EventArgs e)
        {
            FoodFill();
            FoodTextBoxClear();
        }
    }
}
