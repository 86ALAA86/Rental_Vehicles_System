namespace Rental_Vehicles_System.Customers
{
    partial class frmSearchForCustomers
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
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearchValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCustomersFilterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.AutoRoundedCorners = true;
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BorderColor = System.Drawing.Color.Navy;
            this.btnSearch.BorderThickness = 2;
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearch.FillColor = System.Drawing.Color.White;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(171, 117);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(112, 37);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.AutoRoundedCorners = true;
            this.txtSearchValue.BackColor = System.Drawing.Color.Transparent;
            this.txtSearchValue.BorderColor = System.Drawing.Color.Navy;
            this.txtSearchValue.BorderThickness = 2;
            this.txtSearchValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchValue.DefaultText = "";
            this.txtSearchValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtSearchValue.ForeColor = System.Drawing.Color.Black;
            this.txtSearchValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchValue.Location = new System.Drawing.Point(75, 65);
            this.txtSearchValue.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.PlaceholderText = "Search";
            this.txtSearchValue.SelectedText = "";
            this.txtSearchValue.Size = new System.Drawing.Size(308, 43);
            this.txtSearchValue.TabIndex = 4;
            this.txtSearchValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchValue_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search By :";
            // 
            // cbCustomersFilterBy
            // 
            this.cbCustomersFilterBy.AutoRoundedCorners = true;
            this.cbCustomersFilterBy.BackColor = System.Drawing.Color.Transparent;
            this.cbCustomersFilterBy.BorderColor = System.Drawing.Color.Navy;
            this.cbCustomersFilterBy.BorderRadius = 17;
            this.cbCustomersFilterBy.BorderThickness = 2;
            this.cbCustomersFilterBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCustomersFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomersFilterBy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCustomersFilterBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCustomersFilterBy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.cbCustomersFilterBy.ForeColor = System.Drawing.Color.Navy;
            this.cbCustomersFilterBy.ItemHeight = 30;
            this.cbCustomersFilterBy.Items.AddRange(new object[] {
            "CustomerID",
            "Driver License Number"});
            this.cbCustomersFilterBy.Location = new System.Drawing.Point(171, 9);
            this.cbCustomersFilterBy.Name = "cbCustomersFilterBy";
            this.cbCustomersFilterBy.Size = new System.Drawing.Size(275, 36);
            this.cbCustomersFilterBy.StartIndex = 0;
            this.cbCustomersFilterBy.TabIndex = 30;
            this.cbCustomersFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbCustomersFilterBy_SelectedIndexChanged);
            // 
            // frmSearchForCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(472, 166);
            this.Controls.Add(this.cbCustomersFilterBy);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchValue);
            this.Controls.Add(this.label1);
            this.Name = "frmSearchForCustomers";
            this.Text = "frmSearchForCustomers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchValue;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbCustomersFilterBy;
    }
}