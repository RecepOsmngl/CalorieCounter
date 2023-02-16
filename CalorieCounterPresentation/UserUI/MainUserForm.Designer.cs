namespace CalorieCounterPresentation.UserUI
{
    partial class MainUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUserForm));
            this.MainUserFormPictureBox = new System.Windows.Forms.PictureBox();
            this.MainUserFormLabel1 = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.MainUserFormMealButton = new System.Windows.Forms.Button();
            this.MainUserFormStatsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainUserFormPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainUserFormPictureBox
            // 
            this.MainUserFormPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("MainUserFormPictureBox.Image")));
            this.MainUserFormPictureBox.Location = new System.Drawing.Point(142, 173);
            this.MainUserFormPictureBox.Name = "MainUserFormPictureBox";
            this.MainUserFormPictureBox.Size = new System.Drawing.Size(244, 328);
            this.MainUserFormPictureBox.TabIndex = 0;
            this.MainUserFormPictureBox.TabStop = false;
            // 
            // MainUserFormLabel1
            // 
            this.MainUserFormLabel1.AutoSize = true;
            this.MainUserFormLabel1.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MainUserFormLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(186)))), ((int)(((byte)(247)))));
            this.MainUserFormLabel1.Location = new System.Drawing.Point(237, 123);
            this.MainUserFormLabel1.Name = "MainUserFormLabel1";
            this.MainUserFormLabel1.Size = new System.Drawing.Size(149, 34);
            this.MainUserFormLabel1.TabIndex = 1;
            this.MainUserFormLabel1.Text = "Welcome!";
            // 
            // CloseButton
            // 
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CloseButton.ForeColor = System.Drawing.Color.Gray;
            this.CloseButton.Location = new System.Drawing.Point(747, 12);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(41, 35);
            this.CloseButton.TabIndex = 26;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExitButton.ForeColor = System.Drawing.Color.Gray;
            this.ExitButton.Location = new System.Drawing.Point(713, 453);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 35);
            this.ExitButton.TabIndex = 27;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainUserFormMealButton
            // 
            this.MainUserFormMealButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(89)))), ((int)(((byte)(83)))));
            this.MainUserFormMealButton.FlatAppearance.BorderSize = 0;
            this.MainUserFormMealButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MainUserFormMealButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MainUserFormMealButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(52)))), ((int)(((byte)(99)))));
            this.MainUserFormMealButton.Location = new System.Drawing.Point(458, 225);
            this.MainUserFormMealButton.Name = "MainUserFormMealButton";
            this.MainUserFormMealButton.Size = new System.Drawing.Size(240, 35);
            this.MainUserFormMealButton.TabIndex = 28;
            this.MainUserFormMealButton.Text = "Meal";
            this.MainUserFormMealButton.UseVisualStyleBackColor = false;
            this.MainUserFormMealButton.Click += new System.EventHandler(this.MainUserFormMealButton_Click);
            // 
            // MainUserFormStatsButton
            // 
            this.MainUserFormStatsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(89)))), ((int)(((byte)(83)))));
            this.MainUserFormStatsButton.FlatAppearance.BorderSize = 0;
            this.MainUserFormStatsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MainUserFormStatsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MainUserFormStatsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(52)))), ((int)(((byte)(99)))));
            this.MainUserFormStatsButton.Location = new System.Drawing.Point(458, 293);
            this.MainUserFormStatsButton.Name = "MainUserFormStatsButton";
            this.MainUserFormStatsButton.Size = new System.Drawing.Size(240, 35);
            this.MainUserFormStatsButton.TabIndex = 29;
            this.MainUserFormStatsButton.Text = "Stats";
            this.MainUserFormStatsButton.UseVisualStyleBackColor = false;
            this.MainUserFormStatsButton.Click += new System.EventHandler(this.MainUserFormStatsButton_Click);
            // 
            // MainUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.MainUserFormStatsButton);
            this.Controls.Add(this.MainUserFormMealButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.MainUserFormLabel1);
            this.Controls.Add(this.MainUserFormPictureBox);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainUserForm";
            this.Load += new System.EventHandler(this.MainUserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainUserFormPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox MainUserFormPictureBox;
        private Label MainUserFormLabel1;
        private Button CloseButton;
        private Button ExitButton;
        private Button MainUserFormMealButton;
        private Button MainUserFormStatsButton;
    }
}