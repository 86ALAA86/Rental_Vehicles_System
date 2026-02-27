namespace Rental_Vehicles_System.Vehicles
{
    partial class ctrlShowVehicleInfoWithFilter
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
            this.ctrlShowVehicleInfo1 = new Rental_Vehicles_System.Vehicles.ctrlShowVehicleInfo();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackgroundImage = global::Rental_Vehicles_System.Properties.Resources.ChatGPT_Image_Nov_16__2025__06_52_43_PM1;
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.Controls.Add(this.btnSearch);
            this.guna2Panel1.Controls.Add(this.txtSearchValue);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Location = new System.Drawing.Point(4, 3);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(960, 57);
            this.guna2Panel1.TabIndex = 1;
            // 
            // ctrlShowVehicleInfo1
            // 
            this.ctrlShowVehicleInfo1.Location = new System.Drawing.Point(4, 65);
            this.ctrlShowVehicleInfo1.Name = "ctrlShowVehicleInfo1";
            this.ctrlShowVehicleInfo1.Size = new System.Drawing.Size(960, 364);
            this.ctrlShowVehicleInfo1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search By Vehicle ID  :";
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
            this.txtSearchValue.Location = new System.Drawing.Point(318, 6);
            this.txtSearchValue.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.PlaceholderText = "Search";
            this.txtSearchValue.SelectedText = "";
            this.txtSearchValue.Size = new System.Drawing.Size(344, 43);
            this.txtSearchValue.TabIndex = 2;
            this.txtSearchValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchValue_KeyPress);
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
            this.btnSearch.Location = new System.Drawing.Point(683, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(116, 37);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ctrlShowVehicleInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlShowVehicleInfo1);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "ctrlShowVehicleInfoWithFilter";
            this.Size = new System.Drawing.Size(968, 433);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label1;
        private ctrlShowVehicleInfo ctrlShowVehicleInfo1;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchValue;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
    }
}
