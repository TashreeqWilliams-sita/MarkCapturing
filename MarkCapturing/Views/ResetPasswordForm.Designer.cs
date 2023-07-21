
namespace MarkCapturing.Views
{
    partial class ResetPasswordForm
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
            this.BtnResetPassword = new System.Windows.Forms.Button();
            this.lblTypeNewPassword = new System.Windows.Forms.Label();
            this.lblConfirmNewPassword = new System.Windows.Forms.Label();
            this.lblChangingPasswordFor = new System.Windows.Forms.Label();
            this.lblResetPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.BtnExit = new System.Windows.Forms.Button();
            this.lblUsernameChangingPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnResetPassword
            // 
            this.BtnResetPassword.Location = new System.Drawing.Point(39, 186);
            this.BtnResetPassword.Name = "BtnResetPassword";
            this.BtnResetPassword.Size = new System.Drawing.Size(137, 31);
            this.BtnResetPassword.TabIndex = 0;
            this.BtnResetPassword.Text = "Reset Password";
            this.BtnResetPassword.UseVisualStyleBackColor = true;
            this.BtnResetPassword.Click += new System.EventHandler(this.BtnResetPassword_Click);
            // 
            // lblTypeNewPassword
            // 
            this.lblTypeNewPassword.AutoSize = true;
            this.lblTypeNewPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeNewPassword.Location = new System.Drawing.Point(12, 91);
            this.lblTypeNewPassword.Name = "lblTypeNewPassword";
            this.lblTypeNewPassword.Size = new System.Drawing.Size(143, 19);
            this.lblTypeNewPassword.TabIndex = 2;
            this.lblTypeNewPassword.Text = "Type New Password";
            // 
            // lblConfirmNewPassword
            // 
            this.lblConfirmNewPassword.AutoSize = true;
            this.lblConfirmNewPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblConfirmNewPassword.Location = new System.Drawing.Point(12, 137);
            this.lblConfirmNewPassword.Name = "lblConfirmNewPassword";
            this.lblConfirmNewPassword.Size = new System.Drawing.Size(164, 19);
            this.lblConfirmNewPassword.TabIndex = 3;
            this.lblConfirmNewPassword.Text = "Confirm New Password";
            // 
            // lblChangingPasswordFor
            // 
            this.lblChangingPasswordFor.AutoSize = true;
            this.lblChangingPasswordFor.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblChangingPasswordFor.Location = new System.Drawing.Point(12, 50);
            this.lblChangingPasswordFor.Name = "lblChangingPasswordFor";
            this.lblChangingPasswordFor.Size = new System.Drawing.Size(170, 19);
            this.lblChangingPasswordFor.TabIndex = 4;
            this.lblChangingPasswordFor.Text = "Changing password for: ";
            // 
            // lblResetPassword
            // 
            this.lblResetPassword.AutoSize = true;
            this.lblResetPassword.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblResetPassword.Location = new System.Drawing.Point(141, 9);
            this.lblResetPassword.Name = "lblResetPassword";
            this.lblResetPassword.Size = new System.Drawing.Size(180, 25);
            this.lblResetPassword.TabIndex = 5;
            this.lblResetPassword.Text = "Reset Password";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(197, 89);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(188, 21);
            this.txtNewPassword.TabIndex = 6;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(197, 135);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(188, 21);
            this.txtConfirmPassword.TabIndex = 7;
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(197, 186);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(137, 31);
            this.BtnExit.TabIndex = 9;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // lblUsernameChangingPassword
            // 
            this.lblUsernameChangingPassword.AutoSize = true;
            this.lblUsernameChangingPassword.Location = new System.Drawing.Point(194, 54);
            this.lblUsernameChangingPassword.Name = "lblUsernameChangingPassword";
            this.lblUsernameChangingPassword.Size = new System.Drawing.Size(0, 13);
            this.lblUsernameChangingPassword.TabIndex = 10;
            // 
            // ResetPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(411, 244);
            this.ControlBox = false;
            this.Controls.Add(this.lblUsernameChangingPassword);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblResetPassword);
            this.Controls.Add(this.lblChangingPasswordFor);
            this.Controls.Add(this.lblConfirmNewPassword);
            this.Controls.Add(this.lblTypeNewPassword);
            this.Controls.Add(this.BtnResetPassword);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ResetPasswordForm";
            this.Text = "Mark Capturing System - Reset Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnResetPassword;
        private System.Windows.Forms.Label lblTypeNewPassword;
        private System.Windows.Forms.Label lblConfirmNewPassword;
        private System.Windows.Forms.Label lblChangingPasswordFor;
        private System.Windows.Forms.Label lblResetPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Label lblUsernameChangingPassword;
    }
}