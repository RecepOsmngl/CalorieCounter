namespace CalorieCounterPresentation.LoginUI
{
    partial class ChangePasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            this.ChangePasswordFormPictureBox1 = new System.Windows.Forms.PictureBox();
            this.ChangePasswordFormLabel1 = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ChangePasswordFormPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ChangePasswordFormPictureBox1
            // 
            this.ChangePasswordFormPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("ChangePasswordFormPictureBox1.Image")));
            this.ChangePasswordFormPictureBox1.Location = new System.Drawing.Point(133, 173);
            this.ChangePasswordFormPictureBox1.Name = "ChangePasswordFormPictureBox1";
            this.ChangePasswordFormPictureBox1.Size = new System.Drawing.Size(276, 330);
            this.ChangePasswordFormPictureBox1.TabIndex = 0;
            this.ChangePasswordFormPictureBox1.TabStop = false;
            // 
            // ChangePasswordFormLabel1
            // 
            this.ChangePasswordFormLabel1.AutoSize = true;
            this.ChangePasswordFormLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(52)))), ((int)(((byte)(99)))));
            this.ChangePasswordFormLabel1.Location = new System.Drawing.Point(652, 173);
            this.ChangePasswordFormLabel1.Name = "ChangePasswordFormLabel1";
            this.ChangePasswordFormLabel1.Size = new System.Drawing.Size(136, 16);
            this.ChangePasswordFormLabel1.TabIndex = 1;
            this.ChangePasswordFormLabel1.Text = "Sorry, we will be back!";
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
            this.CloseButton.TabIndex = 13;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.FlatAppearance.BorderSize = 0;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BackButton.ForeColor = System.Drawing.Color.Gray;
            this.BackButton.Location = new System.Drawing.Point(713, 453);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 35);
            this.BackButton.TabIndex = 14;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ChangePasswordFormLabel1);
            this.Controls.Add(this.ChangePasswordFormPictureBox1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePasswordForm";
            ((System.ComponentModel.ISupportInitialize)(this.ChangePasswordFormPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox ChangePasswordFormPictureBox1;
        private Label ChangePasswordFormLabel1;
        private Button CloseButton;
        private Button BackButton;
    }
}