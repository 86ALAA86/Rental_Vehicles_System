namespace Rental_Vehicles_System.Checks
{
    partial class frmShowCheckInfo
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
            this.ctrlShowCheckInfo1 = new Rental_Vehicles_System.Checks.Controls.ctrlShowCheckInfo();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackgroundImage = global::Rental_Vehicles_System.Properties.Resources.AlbedoBase_XL_Simple_abstract_background_with_purple_shapes_on_3;
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.Controls.Add(this.ctrlShowCheckInfo1);
            this.guna2Panel1.Controls.Add(this.btnClose);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1079, 681);
            this.guna2Panel1.TabIndex = 0;
            // 
            // ctrlShowCheckInfo1
            // 
            this.ctrlShowCheckInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlShowCheckInfo1.Name = "ctrlShowCheckInfo1";
            this.ctrlShowCheckInfo1.Size = new System.Drawing.Size(1078, 617);
            this.ctrlShowCheckInfo1.TabIndex = 59;
            // 
            // btnClose
            // 
            this.btnClose.AutoRoundedCorners = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderColor = System.Drawing.Color.Navy;
            this.btnClose.BorderThickness = 2;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(888, 623);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(180, 45);
            this.btnClose.TabIndex = 58;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowCheckInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 681);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "frmShowCheckInfo";
            this.Text = "frmShowCheckInfo";
            this.Load += new System.EventHandler(this.frmShowCheckInfo_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Controls.ctrlShowCheckInfo ctrlShowCheckInfo1;
    }
}