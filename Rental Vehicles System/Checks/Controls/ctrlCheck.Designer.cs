namespace Rental_Vehicles_System.Checks.Controls
{
    partial class ctrlCheck
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
            this.ctrlInteriorCheck1 = new Rental_Vehicles_System.Checks.Controls.ctrlInteriorCheck();
            this.ctrlExteriorCheck1 = new Rental_Vehicles_System.Checks.Controls.ctrlExteriorCheck();
            this.ctrlEngineCheck1 = new Rental_Vehicles_System.Checks.Controls.ctrlEngineCheck();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackgroundImage = global::Rental_Vehicles_System.Properties.Resources.AlbedoBase_XL_Simple_abstract_background_with_purple_shapes_on_3__1_;
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.Controls.Add(this.ctrlInteriorCheck1);
            this.guna2Panel1.Controls.Add(this.ctrlExteriorCheck1);
            this.guna2Panel1.Controls.Add(this.ctrlEngineCheck1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(940, 410);
            this.guna2Panel1.TabIndex = 0;
            // 
            // ctrlInteriorCheck1
            // 
            this.ctrlInteriorCheck1.Location = new System.Drawing.Point(38, 270);
            this.ctrlInteriorCheck1.Name = "ctrlInteriorCheck1";
            this.ctrlInteriorCheck1.Size = new System.Drawing.Size(865, 132);
            this.ctrlInteriorCheck1.TabIndex = 3;
            // 
            // ctrlExteriorCheck1
            // 
            this.ctrlExteriorCheck1.Location = new System.Drawing.Point(38, 137);
            this.ctrlExteriorCheck1.Name = "ctrlExteriorCheck1";
            this.ctrlExteriorCheck1.Size = new System.Drawing.Size(865, 132);
            this.ctrlExteriorCheck1.TabIndex = 2;
            this.ctrlExteriorCheck1.Load += new System.EventHandler(this.ctrlExteriorCheck1_Load);
            // 
            // ctrlEngineCheck1
            // 
            this.ctrlEngineCheck1.Location = new System.Drawing.Point(4, 4);
            this.ctrlEngineCheck1.Name = "ctrlEngineCheck1";
            this.ctrlEngineCheck1.Size = new System.Drawing.Size(932, 132);
            this.ctrlEngineCheck1.TabIndex = 1;
            // 
            // ctrlCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "ctrlCheck";
            this.Size = new System.Drawing.Size(940, 410);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private ctrlInteriorCheck ctrlInteriorCheck1;
        private ctrlExteriorCheck ctrlExteriorCheck1;
        private ctrlEngineCheck ctrlEngineCheck1;
    }
}
