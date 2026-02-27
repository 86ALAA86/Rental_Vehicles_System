namespace Rental_Vehicles_System.Returns
{
    partial class frmShowReturnInfo
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
            this.ctrlShowBookingInfo1 = new Rental_Vehicles_System.Rental_Booking.ctrlShowBookingInfo();
            this.ctrlReturnVehicleInfo1 = new Rental_Vehicles_System.Returns.ctrlReturnVehicleInfo();
            this.SuspendLayout();
            // 
            // ctrlShowBookingInfo1
            // 
            this.ctrlShowBookingInfo1.Location = new System.Drawing.Point(1, 0);
            this.ctrlShowBookingInfo1.Name = "ctrlShowBookingInfo1";
            this.ctrlShowBookingInfo1.RentalBookInfo = null;
            this.ctrlShowBookingInfo1.Size = new System.Drawing.Size(1020, 381);
            this.ctrlShowBookingInfo1.TabIndex = 0;
            // 
            // ctrlReturnVehicleInfo1
            // 
            this.ctrlReturnVehicleInfo1.Location = new System.Drawing.Point(50, 378);
            this.ctrlReturnVehicleInfo1.Name = "ctrlReturnVehicleInfo1";
            this.ctrlReturnVehicleInfo1.Size = new System.Drawing.Size(923, 368);
            this.ctrlReturnVehicleInfo1.TabIndex = 1;
            // 
            // frmShowReturnInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 747);
            this.Controls.Add(this.ctrlReturnVehicleInfo1);
            this.Controls.Add(this.ctrlShowBookingInfo1);
            this.Name = "frmShowReturnInfo";
            this.Text = "frmShowReturnInfo";
            this.Load += new System.EventHandler(this.frmShowReturnInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Rental_Booking.ctrlShowBookingInfo ctrlShowBookingInfo1;
        private ctrlReturnVehicleInfo ctrlReturnVehicleInfo1;
    }
}