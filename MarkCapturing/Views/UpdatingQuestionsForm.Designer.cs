
namespace MarkCapturing.Views
{
    partial class UpdatingQuestionsForm
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnShowMarksheetNumber = new System.Windows.Forms.Button();
            this.btnShowOutstandingMarks = new System.Windows.Forms.Button();
            this.lblMarksheetStatus = new System.Windows.Forms.Label();
            this.txtMarksheetStatus = new System.Windows.Forms.TextBox();
            this.txtMarksheetNumber = new System.Windows.Forms.TextBox();
            this.lblMarksheetNo = new System.Windows.Forms.Label();
            this.lblUpdatingQuestionMarks = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Location = new System.Drawing.Point(21, 154);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 12;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(419, 244);
            this.tableLayoutPanel.TabIndex = 15;
            // 
            // btnShowMarksheetNumber
            // 
            this.btnShowMarksheetNumber.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnShowMarksheetNumber.Location = new System.Drawing.Point(501, 352);
            this.btnShowMarksheetNumber.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowMarksheetNumber.Name = "btnShowMarksheetNumber";
            this.btnShowMarksheetNumber.Size = new System.Drawing.Size(166, 46);
            this.btnShowMarksheetNumber.TabIndex = 22;
            this.btnShowMarksheetNumber.Text = "Show Marksheet numbers for a Candidate";
            this.btnShowMarksheetNumber.UseVisualStyleBackColor = false;
            // 
            // btnShowOutstandingMarks
            // 
            this.btnShowOutstandingMarks.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnShowOutstandingMarks.Location = new System.Drawing.Point(501, 294);
            this.btnShowOutstandingMarks.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowOutstandingMarks.Name = "btnShowOutstandingMarks";
            this.btnShowOutstandingMarks.Size = new System.Drawing.Size(166, 40);
            this.btnShowOutstandingMarks.TabIndex = 21;
            this.btnShowOutstandingMarks.Text = "Show Outstanding marks";
            this.btnShowOutstandingMarks.UseVisualStyleBackColor = false;
            // 
            // lblMarksheetStatus
            // 
            this.lblMarksheetStatus.AutoSize = true;
            this.lblMarksheetStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarksheetStatus.Location = new System.Drawing.Point(349, 72);
            this.lblMarksheetStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMarksheetStatus.Name = "lblMarksheetStatus";
            this.lblMarksheetStatus.Size = new System.Drawing.Size(116, 17);
            this.lblMarksheetStatus.TabIndex = 20;
            this.lblMarksheetStatus.Text = "Marksheet status";
            // 
            // txtMarksheetStatus
            // 
            this.txtMarksheetStatus.Enabled = false;
            this.txtMarksheetStatus.Location = new System.Drawing.Point(475, 71);
            this.txtMarksheetStatus.Margin = new System.Windows.Forms.Padding(2);
            this.txtMarksheetStatus.Name = "txtMarksheetStatus";
            this.txtMarksheetStatus.Size = new System.Drawing.Size(208, 20);
            this.txtMarksheetStatus.TabIndex = 19;
            // 
            // txtMarksheetNumber
            // 
            this.txtMarksheetNumber.Location = new System.Drawing.Point(150, 72);
            this.txtMarksheetNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtMarksheetNumber.Name = "txtMarksheetNumber";
            this.txtMarksheetNumber.Size = new System.Drawing.Size(160, 20);
            this.txtMarksheetNumber.TabIndex = 18;
            this.txtMarksheetNumber.Text = "32222631";
            this.txtMarksheetNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMarksheetNumber_KeyDown);
            // 
            // lblMarksheetNo
            // 
            this.lblMarksheetNo.AutoSize = true;
            this.lblMarksheetNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarksheetNo.Location = new System.Drawing.Point(18, 72);
            this.lblMarksheetNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMarksheetNo.Name = "lblMarksheetNo";
            this.lblMarksheetNo.Size = new System.Drawing.Size(128, 17);
            this.lblMarksheetNo.TabIndex = 17;
            this.lblMarksheetNo.Text = "Marksheet Number";
            // 
            // lblUpdatingQuestionMarks
            // 
            this.lblUpdatingQuestionMarks.AutoSize = true;
            this.lblUpdatingQuestionMarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatingQuestionMarks.Location = new System.Drawing.Point(219, 9);
            this.lblUpdatingQuestionMarks.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUpdatingQuestionMarks.Name = "lblUpdatingQuestionMarks";
            this.lblUpdatingQuestionMarks.Size = new System.Drawing.Size(221, 24);
            this.lblUpdatingQuestionMarks.TabIndex = 16;
            this.lblUpdatingQuestionMarks.Text = "Updating Question Marks";
            // 
            // UpdatingQuestionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 419);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.btnShowMarksheetNumber);
            this.Controls.Add(this.btnShowOutstandingMarks);
            this.Controls.Add(this.lblMarksheetStatus);
            this.Controls.Add(this.txtMarksheetStatus);
            this.Controls.Add(this.txtMarksheetNumber);
            this.Controls.Add(this.lblMarksheetNo);
            this.Controls.Add(this.lblUpdatingQuestionMarks);
            this.Name = "UpdatingQuestionsForm";
            this.Text = "Mark Capturing System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdatingQuestionsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button btnShowMarksheetNumber;
        private System.Windows.Forms.Button btnShowOutstandingMarks;
        private System.Windows.Forms.Label lblMarksheetStatus;
        private System.Windows.Forms.TextBox txtMarksheetStatus;
        private System.Windows.Forms.TextBox txtMarksheetNumber;
        private System.Windows.Forms.Label lblMarksheetNo;
        private System.Windows.Forms.Label lblUpdatingQuestionMarks;
    }
}