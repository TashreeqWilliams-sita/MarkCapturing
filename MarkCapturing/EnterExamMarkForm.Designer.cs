﻿
namespace MarkCapturing
{
    partial class EnterExamMarkForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdatingQuestionMarks = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(193, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "System to Enter Exam Marks per Question";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnUpdatingQuestionMarks
            // 
            this.btnUpdatingQuestionMarks.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnUpdatingQuestionMarks.Location = new System.Drawing.Point(236, 107);
            this.btnUpdatingQuestionMarks.Name = "btnUpdatingQuestionMarks";
            this.btnUpdatingQuestionMarks.Size = new System.Drawing.Size(307, 45);
            this.btnUpdatingQuestionMarks.TabIndex = 1;
            this.btnUpdatingQuestionMarks.Text = "Updating of question marks per Candidate";
            this.btnUpdatingQuestionMarks.UseVisualStyleBackColor = false;
            this.btnUpdatingQuestionMarks.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button2.Location = new System.Drawing.Point(236, 158);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(307, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "Reports";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button3.Location = new System.Drawing.Point(236, 198);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(307, 39);
            this.button3.TabIndex = 3;
            this.button3.Text = "Security and System Parameters";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button4.Location = new System.Drawing.Point(236, 243);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(307, 36);
            this.button4.TabIndex = 4;
            this.button4.Text = "Exit";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // EnterExamMarkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(776, 411);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnUpdatingQuestionMarks);
            this.Controls.Add(this.label1);
            this.Name = "EnterExamMarkForm";
            this.Text = "Mark Capturing";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdatingQuestionMarks;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}