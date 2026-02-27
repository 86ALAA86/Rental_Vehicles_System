namespace Rental_Vehicles_System
{
    partial class frmTest
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
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 580);
            this.Controls.Add(this.ctrlShowMaintenanceInfo1);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.Load += new System.EventHandler(this.frmTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Maintenance.ctrlShowMaintenanceInfo ctrlShowMaintenanceInfo1;
    }
}