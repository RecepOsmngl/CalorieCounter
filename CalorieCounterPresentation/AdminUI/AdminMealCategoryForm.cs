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
    public partial class AdminMealCategoryForm : Form
    {
        CalorieCounterContext _db;
        MealCategoryService _mealCategoryService = new MealCategoryService();
        MealCategoryEntity _mealCategory ;

        public AdminMealCategoryForm()
        {
            _db = new CalorieCounterContext();
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

        private void AdminMealCategoryForm_Load(object sender, EventArgs e)
        {

            using (_db = new CalorieCounterContext())
            {
                List<MealCategoryEntity> _MealCategoryEntityList = _db.MealCategoryEntityTable.ToList();
                AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
                foreach (MealCategoryEntity item in _MealCategoryEntityList)
                {
                    ac.Add(item.MealCategoryName);

                }
              AdminMealCategoryFormMealCategoryNameTextBox.AutoCompleteCustomSource = ac;
            }
            MealCategoryFill();
            CategoryNameClear();
            AdminMealCategoryFormAddButton.Click += Click;
            AdminMealCategoryFormEditButton.Click += Click;
            AdminMealCategoryFormDeleteButton.Click += Click;
            AdminMealCategoryFormSearchButton.Click += Click;
        }

        private void CmsClick(object? sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            object Tag = menuItem.Tag;
            switch (Tag)
            {
                case "1": TsmRefresh(); break;
            }
        }

        private void Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            object tag = button.Tag;
            switch (tag)
            {
                case "1": MealCategoryAdd(); break;
                case "2": MealCategoryEdit(); break;
                case "3": MealCategoryDelete(); break;
                case "4": MealCategorySearch(); break;
            }
        }

        private void TsmRefresh()
        {
            MealCategoryFill();
        }

        private void MealCategorySearch()
        {
            string mealCategoryName = AdminMealCategoryFormMealCategoryNameTextBox.Text.Trim();
            mealCategoryName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(mealCategoryName);
            try
            {
                if (!string.IsNullOrWhiteSpace(mealCategoryName))
                {
                    _mealCategory = new MealCategoryEntity();
                    _mealCategory.MealCategoryName = mealCategoryName;
                    List<MealCategoryEntity> _IsSearched = new List<MealCategoryEntity>();
                    _IsSearched = _mealCategoryService._MealCategorySearch(_mealCategory);
                    if (_IsSearched != null)
                    {
                        MessageBox.Show($"The meal category named  {_mealCategory.MealCategoryName},has been successfully found!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AdminMealCategoryFormDataGridView.DataSource = _IsSearched;
                        CategoryNameClear();
                    }
                    else
                    {
                        MessageBox.Show("No meal category found with this name!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MealCategoryFill();
                        CategoryNameClear();
                    }
                }
                else
                    MessageBox.Show("please enter meal category name!");
            }
            catch (Exception)
            {
                MessageBox.Show("please enter a valid meal category name!");
            }
        }

        private void MealCategoryDelete()
        {
            string mealCategoryName = AdminMealCategoryFormMealCategoryNameTextBox.Text.Trim();
            try
            {
                _mealCategory = new MealCategoryEntity();
                _mealCategory.MealCategoryName = mealCategoryName;
                _mealCategory.MealCategoryID = id;
                bool _IsDeleted = _mealCategoryService._MealCategoryDelete(_mealCategory);
                if (_IsDeleted)
                {
                    MessageBox.Show($"The meal category named  {_mealCategory.MealCategoryName},id {_mealCategory.MealCategoryID} has been deleted successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MealCategoryFill();
                    CategoryNameClear();
                }
                else
                {
                    MessageBox.Show("Please try again!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CategoryNameClear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("please select meal category name!");
            }
        }

        private void MealCategoryEdit()
        {
            string mealCategoryName = AdminMealCategoryFormMealCategoryNameTextBox.Text.Trim();
            mealCategoryName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(mealCategoryName);
            try
            {
                if (!string.IsNullOrWhiteSpace(mealCategoryName))
                {
                    _mealCategory = new MealCategoryEntity();
                    _mealCategory.MealCategoryID = id;
                    _mealCategory.MealCategoryName = mealCategoryName;
                    bool _IsEdit = _mealCategoryService._MealCategoryEdit(_mealCategory);
                    if (_IsEdit)
                    {
                        MessageBox.Show("Editting Successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MealCategoryFill();
                        CategoryNameClear();
                    }
                    else
                    {
                        MessageBox.Show("Please try again!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CategoryNameClear();
                    }
                }
            }
            catch (ObjectDisposedException)
            {
                MessageBox.Show("Please enter a valid meal name!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration already exists!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MealCategoryAdd()
        {
            string mealCategoryName = AdminMealCategoryFormMealCategoryNameTextBox.Text.Trim();
            mealCategoryName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(mealCategoryName);
            try
            {
                if (!string.IsNullOrWhiteSpace(mealCategoryName))
                {
                    _mealCategory = new MealCategoryEntity();
                    _mealCategory.MealCategoryName = mealCategoryName;
                    bool _IsCheck = _mealCategoryService._MealCategoryAddIsCheck(_mealCategory);
                    if (_IsCheck)
                    {
                        bool _IsAdd = _mealCategoryService._MealCategoryAdd(_mealCategory);
                        if (_IsAdd)
                        {
                            MessageBox.Show("Adding Successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MealCategoryFill();
                            CategoryNameClear();
                        }
                        else
                        {
                            MessageBox.Show("Please try again!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            CategoryNameClear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Registration already exists!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else MessageBox.Show("please enter meal category name!");
            }
            catch (ObjectDisposedException)
            {
                MessageBox.Show("Please enter a valid meal category name!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void MealCategoryFill()
        {
            AdminMealCategoryFormDataGridView.DataSource = _mealCategoryService.MealCategories();
            AdminMealCategoryFormDataGridView.Columns["MealEntity"].Visible = false;
        }
        private void CategoryNameClear()
        {
            AdminMealCategoryFormMealCategoryNameTextBox.Clear();
        }

        private void AdminMealCategoryFormEditButton_Click(object sender, EventArgs e)
        {

        }
        int id;
        private void AdminMealCategoryFormDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AdminMealCategoryFormMealCategoryNameTextBox.Text = AdminMealCategoryFormDataGridView.CurrentRow.Cells[1].Value.ToString();
            id = int.Parse(AdminMealCategoryFormDataGridView.CurrentRow.Cells[0].Value.ToString());
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
    }
}
