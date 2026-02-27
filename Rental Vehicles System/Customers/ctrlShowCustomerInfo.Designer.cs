namespace Rental_Vehicles_System.Customers
{
    partial class ctrlShowCustomerInfo
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
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLicnseNumber = new System.Windows.Forms.Label();
            this.ctrlShowPersonInfo1 = new Rental_Vehicles_System.Users.ctrlShowPersonInfo();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackgroundImage = global::Rental_Vehicles_System.Properties.Resources.ChatGPT_Image_Nov_24__2025__08_25_23_PM;
            this.guna2Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel2.Controls.Add(this.lblLicnseNumber);
            this.guna2Panel2.Controls.Add(this.label3);
            this.guna2Panel2.Controls.Add(this.lblCustomerID);
            this.guna2Panel2.Controls.Add(this.label8);
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Location = new System.Drawing.Point(0, 309);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(812, 79);
            this.guna2Panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Customer Info :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(12, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(188, 30);
            this.label8.TabIndex = 29;
            this.label8.Text = "Customer ID :";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomerID.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.lblCustomerID.ForeColor = System.Drawing.Color.White;
            this.lblCustomerID.Location = new System.Drawing.Point(200, 36);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(44, 30);
            this.lblCustomerID.TabIndex = 30;
            this.lblCustomerID.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(293, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(330, 30);
            this.label3.TabIndex = 31;
            this.label3.Text = "Driving Licnese Number :";
            // 
            // lblLicnseNumber
            // 
            this.lblLicnseNumber.AutoSize = true;
            this.lblLicnseNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblLicnseNumber.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.lblLicnseNumber.ForeColor = System.Drawing.Color.White;
            this.lblLicnseNumber.Location = new System.Drawing.Point(633, 36);
            this.lblLicnseNumber.Name = "lblLicnseNumber";
            this.lblLicnseNumber.Size = new System.Drawing.Size(47, 30);
            this.lblLicnseNumber.TabIndex = 32;
            this.lblLicnseNumber.Text = "No";
            // 
            // ctrlShowPersonInfo1
            // 
            this.ctrlShowPersonInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlShowPersonInfo1.Name = "ctrlShowPersonInfo1";
            this.ctrlShowPersonInfo1.Size = new System.Drawing.Size(812, 306);
            this.ctrlShowPersonInfo1.TabIndex = 0;
            // 
            // ctrlShowCustomerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.ctrlShowPersonInfo1);
            this.Name = "ctrlShowCustomerInfo";
            this.Size = new System.Drawing.Size(813, 390);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Users.ctrlShowPersonInfo ctrlShowPersonInfo1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label lblLicnseNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
    }
}
