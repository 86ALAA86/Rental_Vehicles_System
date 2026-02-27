namespace Rental_Vehicles_System.Vehicles
{
    partial class frmShowVehicleInfo
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.ctrlShowVehicleInfo1 = new Rental_Vehicles_System.Vehicles.ctrlShowVehicleInfo();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackgroundImage = global::Rental_Vehicles_System.Properties.Resources.AlbedoBase_XL_Simple_abstract_background_with_purple_shapes_on_3;
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.Controls.Add(this.ctrlShowVehicleInfo1);
            this.guna2Panel1.Controls.Add(this.btnCancel);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(960, 491);
            this.guna2Panel1.TabIndex = 0;
            // 
            // ctrlShowVehicleInfo1
            // 
            this.ctrlShowVehicleInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlShowVehicleInfo1.Name = "ctrlShowVehicleInfo1";
            this.ctrlShowVehicleInfo1.Size = new System.Drawing.Size(960, 433);
            this.ctrlShowVehicleInfo1.TabIndex = 49;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoRoundedCorners = true;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.Purple;
            this.btnCancel.BorderThickness = 3;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(777, 439);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 45);
            this.btnCancel.TabIndex = 48;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmShowVehicleInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 491);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "frmShowVehicleInfo";
            this.Text = "frmShowVehicleInfo";
            this.Load += new System.EventHandler(this.frmShowVehicleInfo_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private ctrlShowVehicleInfo ctrlShowVehicleInfo1;
    }
}