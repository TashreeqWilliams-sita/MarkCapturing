
namespace MarkCapturing.Views
{
    partial class UpdateQuestionMarksForm
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
            this.lblUpdateMark = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnVerifyMarks = new System.Windows.Forms.Button();
            this.btnUpdateMarks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUpdateMark
            // 
            this.lblUpdateMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateMark.Location = new System.Drawing.Point(11, 9);
            this.lblUpdateMark.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUpdateMark.Name = "lblUpdateMark";
            this.lblUpdateMark.Size = new System.Drawing.Size(439, 25);
            this.lblUpdateMark.TabIndex = 11;
            this.lblUpdateMark.Text = "Updating Question Marks For Candidate";
            this.lblUpdateMark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUpdateMark.UseCompatibleTextRendering = true;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnExit.Location = new System.Drawing.Point(118, 140);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(224, 36);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnVerifyMarks
            // 
            this.btnVerifyMarks.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnVerifyMarks.Location = new System.Drawing.Point(118, 102);
            this.btnVerifyMarks.Margin = new System.Windows.Forms.Padding(2);
            this.btnVerifyMarks.Name = "btnVerifyMarks";
            this.btnVerifyMarks.Size = new System.Drawing.Size(224, 32);
            this.btnVerifyMarks.TabIndex = 9;
            this.btnVerifyMarks.Text = "Verify Marks";
            this.btnVerifyMarks.UseVisualStyleBackColor = false;
            // 
            // btnUpdateMarks
            // 
            this.btnUpdateMarks.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnUpdateMarks.Location = new System.Drawing.Point(118, 62);
            this.btnUpdateMarks.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateMarks.Name = "btnUpdateMarks";
            this.btnUpdateMarks.Size = new System.Drawing.Size(224, 36);
            this.btnUpdateMarks.TabIndex = 8;
            this.btnUpdateMarks.Text = "Update Question Marks";
            this.btnUpdateMarks.UseVisualStyleBackColor = false;
            this.btnUpdateMarks.Click += new System.EventHandler(this.BtnUpdateMarks_Click);
            // 
            // UpdateQuestionMarksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 201);
            this.Controls.Add(this.lblUpdateMark);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnVerifyMarks);
            this.Controls.Add(this.btnUpdateMarks);
            this.Name = "UpdateQuestionMarksForm";
            this.Text = "Mark Capturing System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateQuestionMarksForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUpdateMark;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnVerifyMarks;
        private System.Windows.Forms.Button btnUpdateMarks;
    }
}