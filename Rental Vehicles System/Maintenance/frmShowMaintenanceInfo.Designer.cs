namespace Rental_Vehicles_System.Maintenance
{
    partial class frmShowMaintenanceInfo
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
            this.ctrlShowMaintenanceInfo1 = new Rental_Vehicles_System.Maintenance.ctrlShowMaintenanceInfo();
            this.SuspendLayout();
            // 
            // ctrlShowMaintenanceInfo1
            // 
            this.ctrlShowMaintenanceInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlShowMaintenanceInfo1.MaintenanceInfo = null;
            this.ctrlShowMaintenanceInfo1.Name = "ctrlShowMaintenanceInfo1";
            this.ctrlShowMaintenanceInfo1.Size = new System.Drawing.Size(838, 314);
            this.ctrlShowMaintenanceInfo1.TabIndex = 0;
            // 
            // frmShowMaintenanceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 314);
            this.Controls.Add(this.ctrlShowMaintenanceInfo1);
            this.Name = "frmShowMaintenanceInfo";
            this.Text = "frmShowMaintenanceInfo";
            this.Load += new System.EventHandler(this.frmShowMaintenanceInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlShowMaintenanceInfo ctrlShowMaintenanceInfo1;
    }
}