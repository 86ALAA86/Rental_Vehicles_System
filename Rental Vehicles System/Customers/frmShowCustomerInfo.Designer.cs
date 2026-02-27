namespace Rental_Vehicles_System.Customers
{
    partial class frmShowCustomerInfo
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
            this.ctrlShowCustomerInfo1 = new Rental_Vehicles_System.Customers.ctrlShowCustomerInfo();
            this.SuspendLayout();
            // 
            // ctrlShowCustomerInfo1
            // 
            this.ctrlShowCustomerInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlShowCustomerInfo1.Name = "ctrlShowCustomerInfo1";
            this.ctrlShowCustomerInfo1.Size = new System.Drawing.Size(813, 390);
            this.ctrlShowCustomerInfo1.TabIndex = 0;
            // 
            // frmShowCustomerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 388);
            this.Controls.Add(this.ctrlShowCustomerInfo1);
            this.Name = "frmShowCustomerInfo";
            this.Text = "frmShowCustomerInfo";
            this.Load += new System.EventHandler(this.frmShowCustomerInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlShowCustomerInfo ctrlShowCustomerInfo1;
    }
}