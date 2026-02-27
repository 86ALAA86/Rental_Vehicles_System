namespace Rental_Vehicles_System.Users
{
    partial class frmShowUserInfo
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
            this.ctrlShowUserInfo1 = new Rental_Vehicles_System.Users.ctrlShowUserInfo();
            this.SuspendLayout();
            // 
            // ctrlShowUserInfo1
            // 
            this.ctrlShowUserInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlShowUserInfo1.Name = "ctrlShowUserInfo1";
            this.ctrlShowUserInfo1.Size = new System.Drawing.Size(815, 411);
            this.ctrlShowUserInfo1.TabIndex = 0;
            this.ctrlShowUserInfo1.UserInfo = null;
            // 
            // frmShowUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 406);
            this.Controls.Add(this.ctrlShowUserInfo1);
            this.Name = "frmShowUserInfo";
            this.Text = "frmShowUserInfo";
            this.Load += new System.EventHandler(this.frmShowUserInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlShowUserInfo ctrlShowUserInfo1;
    }
}