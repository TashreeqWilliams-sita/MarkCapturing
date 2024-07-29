
namespace MarkCapturing.Views
{
    partial class SystemSecurityForm
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
            this.LblSystemSecurity = new System.Windows.Forms.Label();
            this.BtnResetPassword = new System.Windows.Forms.Button();
            this.BtnRegisterUser = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblSystemSecurity
            // 
            this.LblSystemSecurity.AutoSize = true;
            this.LblSystemSecurity.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSystemSecurity.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblSystemSecurity.Location = new System.Drawing.Point(42, 21);
            this.LblSystemSecurity.Name = "LblSystemSecurity";
            this.LblSystemSecurity.Size = new System.Drawing.Size(353, 25);
            this.LblSystemSecurity.TabIndex = 0;
            this.LblSystemSecurity.Text = "Security and System Parameters";
            this.LblSystemSecurity.Click += new System.EventHandler(this.LblSystemSecurity_Click);
            // 
            // BtnResetPassword
            // 
            this.BtnResetPassword.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BtnResetPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnResetPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnResetPassword.Location = new System.Drawing.Point(92, 59);
            this.BtnResetPassword.Name = "BtnResetPassword";
            this.BtnResetPassword.Size = new System.Drawing.Size(216, 39);
            this.BtnResetPassword.TabIndex = 3;
            this.BtnResetPassword.Text = "Reset Password";
            this.BtnResetPassword.UseVisualStyleBackColor = false;
            this.BtnResetPassword.Click += new System.EventHandler(this.BtnResetPassword_Click);
            // 
            // BtnRegisterUser
            // 
            this.BtnRegisterUser.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BtnRegisterUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRegisterUser.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.BtnRegisterUser.Location = new System.Drawing.Point(92, 105);
            this.BtnRegisterUser.Name = "BtnRegisterUser";
            this.BtnRegisterUser.Size = new System.Drawing.Size(216, 39);
            this.BtnRegisterUser.TabIndex = 4;
            this.BtnRegisterUser.Text = "Register New User";
            this.BtnRegisterUser.UseVisualStyleBackColor = false;
            this.BtnRegisterUser.Click += new System.EventHandler(this.BtnRegisterUser_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.button5.Location = new System.Drawing.Point(92, 150);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(216, 39);
            this.button5.TabIndex = 7;
            this.button5.Text = "Update Question paper";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BtnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnExit.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.BtnExit.Location = new System.Drawing.Point(92, 195);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(216, 39);
            this.BtnExit.TabIndex = 8;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // SystemSecurityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.CancelButton = this.BtnExit;
            this.ClientSize = new System.Drawing.Size(442, 267);
            this.ControlBox = false;
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.BtnRegisterUser);
            this.Controls.Add(this.BtnResetPassword);
            this.Controls.Add(this.LblSystemSecurity);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "SystemSecurityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mark Capturing System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblSystemSecurity;
        private System.Windows.Forms.Button BtnResetPassword;
        private System.Windows.Forms.Button BtnRegisterUser;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button BtnExit;
    }
}