using System;
using System.Windows.Forms;

namespace SouthAfricaMuni
{
    partial class ServiceRequest
    {
        private System.ComponentModel.IContainer components = null;
       

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblHeader = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSubmitIssue = new System.Windows.Forms.Button();
            this.dgvIssues = new System.Windows.Forms.DataGridView();
            this.IssueID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnViewDetails = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnBackToMain = new System.Windows.Forms.Button();
            this.treeViewCategories = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssues)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(120, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(260, 32);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Service Request Status";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(20, 60);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 29);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Text = "Search...";
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            // 
            // btnSubmitIssue
            // 
            this.btnSubmitIssue.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSubmitIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitIssue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubmitIssue.ForeColor = System.Drawing.Color.White;
            this.btnSubmitIssue.Location = new System.Drawing.Point(330, 60);
            this.btnSubmitIssue.Name = "btnSubmitIssue";
            this.btnSubmitIssue.Size = new System.Drawing.Size(180, 29);
            this.btnSubmitIssue.TabIndex = 2;
            this.btnSubmitIssue.Text = "Report an issue";
            this.btnSubmitIssue.UseVisualStyleBackColor = false;
            this.btnSubmitIssue.Click += new System.EventHandler(this.BtnSubmitIssue_Click);
            // 
            // dgvIssues
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dgvIssues.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIssues.BackgroundColor = System.Drawing.Color.White;
            this.dgvIssues.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvIssues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIssues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IssueID,
            this.Location,
            this.Category,
            this.btnViewDetails});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIssues.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIssues.Location = new System.Drawing.Point(28, 95);
            this.dgvIssues.Name = "dgvIssues";
            this.dgvIssues.RowHeadersVisible = false;
            this.dgvIssues.Size = new System.Drawing.Size(540, 250);
            this.dgvIssues.TabIndex = 3;
            this.dgvIssues.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIssues_CellContentClick);
            // 
            // IssueID
            // 
            this.IssueID.HeaderText = "Issue ID";
            this.IssueID.Name = "IssueID";
            this.IssueID.Width = 150;
            // 
            // Location
            // 
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            this.Location.Width = 150;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.Width = 150;
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.HeaderText = "Details";
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Text = "View";
            this.btnViewDetails.UseColumnTextForButtonValue = true;
            this.btnViewDetails.Width = 100;
            // 
            // btnBackToMain
            // 
            this.btnBackToMain.BackColor = System.Drawing.Color.DarkGreen;
            this.btnBackToMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToMain.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBackToMain.ForeColor = System.Drawing.Color.White;
            this.btnBackToMain.Location = new System.Drawing.Point(20, 360);
            this.btnBackToMain.Name = "btnBackToMain";
            this.btnBackToMain.Size = new System.Drawing.Size(540, 35);
            this.btnBackToMain.TabIndex = 4;
            this.btnBackToMain.Text = "Back to Main Menu";
            this.btnBackToMain.UseVisualStyleBackColor = false;
            this.btnBackToMain.Click += new System.EventHandler(this.BtnBackToMain_Click);
            // 
            // treeViewCategories
            // 
            this.treeViewCategories.Location = new System.Drawing.Point(580, 50);
            this.treeViewCategories.Name = "treeViewCategories";
            this.treeViewCategories.Size = new System.Drawing.Size(200, 350);
            this.treeViewCategories.TabIndex = 5;
            // 
            // ServiceRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treeViewCategories);
            this.Controls.Add(this.btnBackToMain);
            this.Controls.Add(this.dgvIssues);
            this.Controls.Add(this.btnSubmitIssue);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ServiceRequest";
            this.Text = "Service Request Status";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssues)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search...";
                txtSearch.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = System.Drawing.Color.Black;
            }
        }

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSubmitIssue;
        private System.Windows.Forms.DataGridView dgvIssues;
        private System.Windows.Forms.Button btnBackToMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssueID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewButtonColumn btnViewDetails;
        private System.Windows.Forms.TreeView treeViewCategories;
    }
}
