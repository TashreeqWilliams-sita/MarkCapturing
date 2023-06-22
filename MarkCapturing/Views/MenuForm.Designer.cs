
namespace MarkCapturing.Views
{
    partial class MenuForm
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSecurity = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnUpdateQuestionMarks = new System.Windows.Forms.Button();
            this.lblMenu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnExit.Location = new System.Drawing.Point(49, 158);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(230, 29);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnSecurity
            // 
            this.btnSecurity.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSecurity.Location = new System.Drawing.Point(49, 122);
            this.btnSecurity.Margin = new System.Windows.Forms.Padding(2);
            this.btnSecurity.Name = "btnSecurity";
            this.btnSecurity.Size = new System.Drawing.Size(230, 32);
            this.btnSecurity.TabIndex = 13;
            this.btnSecurity.Text = "Security and System Parameters";
            this.btnSecurity.UseVisualStyleBackColor = false;
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnReports.Location = new System.Drawing.Point(49, 90);
            this.btnReports.Margin = new System.Windows.Forms.Padding(2);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(230, 28);
            this.btnReports.TabIndex = 12;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = false;
            // 
            // btnUpdateQuestionMarks
            // 
            this.btnUpdateQuestionMarks.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnUpdateQuestionMarks.Location = new System.Drawing.Point(49, 49);
            this.btnUpdateQuestionMarks.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateQuestionMarks.Name = "btnUpdateQuestionMarks";
            this.btnUpdateQuestionMarks.Size = new System.Drawing.Size(230, 37);
            this.btnUpdateQuestionMarks.TabIndex = 11;
            this.btnUpdateQuestionMarks.Text = "Update question marks for candidate";
            this.btnUpdateQuestionMarks.UseVisualStyleBackColor = false;
            this.btnUpdateQuestionMarks.Click += new System.EventHandler(this.BtnUpdateQuestionMarks_Click);
            // 
            // lblMenu
            // 
            this.lblMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.Location = new System.Drawing.Point(11, 9);
            this.lblMenu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(298, 27);
            this.lblMenu.TabIndex = 10;
            this.lblMenu.Text = "Menu";
            this.lblMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 219);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSecurity);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnUpdateQuestionMarks);
            this.Controls.Add(this.lblMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MenuForm";
            this.Text = "Mark Capturing System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSecurity;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnUpdateQuestionMarks;
        private System.Windows.Forms.Label lblMenu;
    }
}