using CalorieCounterBusiness.Services;
using CalorieCounterDataAccess;
using CalorieCounterEntity;
using CalorieCounterPresentation.Properties;
using Microsoft.VisualBasic.ApplicationServices;
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
                   
                  var IsCheck = _foodService.FoodSearch(_foodEntity);
                    AdminFoodFormDataGridView.DataSource = IsCheck;
                    if (AdminFoodFormDataGridView.DataSource != null)
                    {

                        MessageBox.Show($"The food named  {_foodEntity.FoodName},has been successfully found!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
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
                    PictureDelete();
                }
                else
                {
                    MessageBox.Show("Please try again!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FoodTextBoxClear();
                    PictureDelete();
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
            //foreach (char item in foodName)
            //{
            //    if (char.IsDigit(item))
            //    {
            //        MessageBox.Show("Foodname sayı olarak girilemez");
            //        return;
            //    }
            //}

            _foodCategoryEntity = new FoodCategoryEntity();
            _foodCategoryEntity.FoodCategoryName = AdminFoodFormFoodCategoryNameTextBox.Text.Trim();
            int foodEntityFoodCategoryId = _foodService.FoodIdAdd(_foodCategoryEntity);
            var foodCalorie = int.Parse(AdminFoodFormFoodCalorieTextBox.Text.Trim());
            foodName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(foodName);

            try
            {
                if (!string.IsNullOrWhiteSpace(foodName) && foodEntityFoodCategoryId != null && foodCalorie != null)
                {
                    _foodEntity = new FoodEntity();
                    _foodEntity.FoodID = id;
                    _foodEntity.FoodName = foodName;
                    _foodEntity.FoodCategoryID = foodEntityFoodCategoryId;
                    _foodEntity.FoodCalorie = foodCalorie;

                    bool IsCheck = _foodService.FoodEdit(_foodEntity);
                    if (IsCheck)
                    {
                        MessageBox.Show("Editting Successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FoodFill();
                        FoodTextBoxClear();
                        PictureDelete();
                    }
                    else
                    {
                        MessageBox.Show("Please try again!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        FoodTextBoxClear();
                        PictureDelete();
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
           int _foodcategoryid= int.Parse(AdminFoodFormDataGridView.CurrentRow.Cells[2].Value.ToString());
            string foodcategoryname = _foodService.ComeFoodCategoryName(_foodcategoryid);
            AdminFoodFormFoodCategoryNameTextBox.Text = foodcategoryname;
            AdminFoodFormFoodCalorieTextBox.Text = AdminFoodFormDataGridView.CurrentRow.Cells[5].Value.ToString();
            AdminFoodFormPictureBox.ImageLocation = AdminFoodFormDataGridView.CurrentRow.Cells[6].Value.ToString();
            AdminFoodFormEditButton.Enabled = true;

            
            //var _PhotographID = AdminFoodFormDataGridView.CurrentRow.Cells["PhotographID"]; // cells.value.tostring();
            //var _PhotoLocation = _db.PhotographEntityTable.Where(x => x.PhotographID == _PhotographID).Select();
            // pathstring = _db.PhotographEntityTable.Where(x => x.Photo)
            // AdminFoodFormPictureBox.Image = Image.FromFile(pathstring);

        }
        //Ürün ekleme fonksiyonu. Add butonuna tıklandığında çalışıyor.
        private void FoodAdd()
        {
            string foodName = AdminFoodFormFoodNameTextBox.Text.Trim();
            //foreach (char item in foodName)
            //{
            //    if (char.IsDigit(item))
            //    {
            //        MessageBox.Show("Foodname sayı olarak girilemez");
            //        return;
            //    }
            //}
           
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
                    PhotographEntity _photographEntity = new PhotographEntity();
                    _photographEntity.PhotographName = foodName;
                    _photographEntity.Photograph= AdminFoodFormPictureBox.ImageLocation;
                    int foodEntityPhotographId = _foodService.FoodPhotographIdAdd(_photographEntity);
                    _photographEntity.PhotographID = foodEntityPhotographId;
                    _foodEntity.PhotographID=foodEntityPhotographId;
                    bool IsCheckPhotographEdit = _foodService.PhotographEdit(_photographEntity);


                    bool IsCheck = _foodService.FoodAddIsCheck(_foodEntity);
                    if (IsCheck)
                    {
                        bool Ischeckadd = _foodService.FoodAdd(_foodEntity);

                        if (Ischeckadd)
                        {
                            MessageBox.Show("Adding Successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FoodFill();
                            FoodTextBoxClear();
                            PictureDelete();
                        }
                        else
                        {
                            MessageBox.Show("Please try again!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            FoodTextBoxClear();
                            PictureDelete();
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
            //AdminFoodFormDataGridView.Columns["MealEntity"].Visible = false;
            //AdminFoodFormDataGridView.Columns["FoodCategoryEntity"].Visible = false;
            //AdminFoodFormDataGridView.Columns["PhotographEntity"].Visible = false;
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
                List<FoodCategoryEntity> _FoodCategoryEntityList = _db.FoodCategoryEntityTable.ToList();
                AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
                foreach (FoodCategoryEntity item in _FoodCategoryEntityList)
                {
                    ac.Add(item.FoodCategoryName);

                }
                AdminFoodFormFoodCategoryNameTextBox.AutoCompleteCustomSource = ac;
            }
            using (_db=new CalorieCounterContext())
            {
                List<FoodEntity> _FoodEntityList = _db.FoodEntityTable.ToList();
                AutoCompleteStringCollection aca = new AutoCompleteStringCollection();
                foreach (FoodEntity item in _FoodEntityList)
                {
                    aca.Add(item.FoodName);

                }
               AdminFoodFormFoodNameTextBox.AutoCompleteCustomSource = aca;
            }

            FoodFill();
            FoodTextBoxClear();
            AdminFoodFormEditButton.Enabled = false;

        }

        //private void AdminFoodFormFoodCategoryNameTextBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        using (_db = new CalorieCounterContext())
        //        {
        //            AdminFoodFormDataGridView.DataSource = _db.FoodCategoryEntityTable.Where(x => x.FoodCategoryName.Contains(AdminFoodFormFoodCategoryNameTextBox.Text)).ToList();
        //        }
        //    }
        //}

        private void AdminFoodFormFoodNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AdminFoodFormDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PictureDelete()
        {
            AdminFoodFormPictureBox.Image = null;
        }

        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            # region // folder browser dialong try
            //// Create a new instance of the FolderBrowserDialog class
            //FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            //// Show the FolderBrowserDialog to the user and get the result
            //DialogResult result = folderBrowserDialog.ShowDialog();

            //if (result == DialogResult.OK)
            //{
            //    // Get the path of the selected folder
            //    string folderPath = folderBrowserDialog.SelectedPath;

            //    // Get a list of all image files in the selected folder
            //    string[] imageFiles = Directory.GetFiles(folderPath, "*.*")
            //                        .Where(file => file.ToLower().EndsWith(".png") ||
            //                                       file.ToLower().EndsWith(".jpg") ||
            //                                       file.ToLower().EndsWith(".jpeg"))
            //                        .ToArray();

            //    // Load the first image in the list into a PictureBox control
            //    if (imageFiles.Length > 0)
            //    {
            //        AdminFoodFormPictureBox.ImageLocation = imageFiles[0];
            //    }
            //}
            #endregion
            
            OpenFileDialog Open = new OpenFileDialog();
            if(Open.ShowDialog() == DialogResult.OK)
            {
                
                AdminFoodFormPictureBox.ImageLocation = Open.FileName;
                PhotographEntity photographEntity=new PhotographEntity();
                photographEntity.Photograph = AdminFoodFormPictureBox.ImageLocation;
                bool Ischeckadd = _foodService.PhotographAdd(photographEntity);
              




                // AdminFoodFormPictureBox.Resize = 
            }

        }

        // geçici buton fotoğraf deneme işlemleri için 
        private void button1_Click(object sender, EventArgs e)
        {
            using (var _db = new CalorieCounterContext())
            {
                // Select the binary data from the photograph column where the ID is 1
                // var imagedata1 = _db.PhotographEntityTable
                //    .Where(t => t.PhotographID == 1)
                //    .Select(t => t.Photograph)
                //    .First();

                // byte[] imagedata2 = Encoding.UTF8.GetBytes(imagedata1);
                // C:\Users\mertk\OneDrive\Masaüstü\BAB Proje\Resources\photos\Absinthe.png

                var pathstring = Path.Combine("C:\\Users\\mertk\\OneDrive\\Masaüstü\\BAB Proje\\Resources\\photos\\Absinthe.png");

                // Load the binary image data into an Image object
                // MemoryStream memoryStream = new MemoryStream(imagedata2);
                // Image image = Image.FromStream(memoryStream);

                // Display the image in a PictureBox control
                AdminFoodFormPictureBox.Image = Image.FromFile(pathstring);
            }
            //            byte[] imageData = ... // binary data of the image
            //            MemoryStream memoryStream = new MemoryStream(imageData);
            //            Image image = Image.FromStream(memoryStream);

            // Encoding.UTF8.GetBytes yemiyor!
        }
    }
}
