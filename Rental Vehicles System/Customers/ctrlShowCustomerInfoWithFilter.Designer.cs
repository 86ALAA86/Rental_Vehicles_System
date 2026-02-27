namespace Rental_Vehicles_System.Customers
{
    partial class ctrlShowCustomerInfoWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.cbCustomersFilterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearchValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlShowCustomerInfo1 = new Rental_Vehicles_System.Customers.ctrlShowCustomerInfo();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackgroundImage = global::Rental_Vehicles_System.Properties.Resources.ChatGPT_Image_Nov_24__2025__08_25_23_PM1;
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.btnAdd);
            this.guna2Panel1.Controls.Add(this.cbCustomersFilterBy);
            this.guna2Panel1.Controls.Add(this.btnSearch);
            this.guna2Panel1.Controls.Add(this.txtSearchValue);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(813, 82);
            this.guna2Panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 21);
            this.label2.TabIndex = 31;
            this.label2.Text = "Search :";
            // 
            // btnAdd
            // 
            this.btnAdd.AutoRoundedCorners = true;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BorderColor = System.Drawing.Color.Navy;
            this.btnAdd.BorderThickness = 2;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.White;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(686, 40);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 37);
            this.btnAdd.TabIndex = 30;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.cbCustomersFilterBy.Location = new System.Drawing.Point(145, 24);
            this.cbCustomersFilterBy.Name = "cbCustomersFilterBy";
            this.cbCustomersFilterBy.Size = new System.Drawing.Size(275, 36);
            this.cbCustomersFilterBy.StartIndex = 0;
            this.cbCustomersFilterBy.TabIndex = 29;
            this.cbCustomersFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbCustomersFilterBy_SelectedIndexChanged);
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
            this.btnSearch.Location = new System.Drawing.Point(686, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(112, 37);
            this.btnSearch.TabIndex = 3;
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
            this.txtSearchValue.Location = new System.Drawing.Point(427, 21);
            this.txtSearchValue.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.PlaceholderText = "Search";
            this.txtSearchValue.SelectedText = "";
            this.txtSearchValue.Size = new System.Drawing.Size(254, 43);
            this.txtSearchValue.TabIndex = 2;
            this.txtSearchValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchValue_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search By :";
            // 
            // ctrlShowCustomerInfo1
            // 
            this.ctrlShowCustomerInfo1.Location = new System.Drawing.Point(2, 89);
            this.ctrlShowCustomerInfo1.Name = "ctrlShowCustomerInfo1";
            this.ctrlShowCustomerInfo1.Size = new System.Drawing.Size(813, 390);
            this.ctrlShowCustomerInfo1.TabIndex = 0;
            // 
            // ctrlShowCustomerInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.ctrlShowCustomerInfo1);
            this.Name = "ctrlShowCustomerInfoWithFilter";
            this.Size = new System.Drawing.Size(818, 482);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlShowCustomerInfo ctrlShowCustomerInfo1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchValue;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbCustomersFilterBy;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private System.Windows.Forms.Label label2;
    }
}
