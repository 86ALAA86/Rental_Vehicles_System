namespace Rental_Vehicles_System.Specifications
{
    partial class frmShowSpecificationInfo
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
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlShowSpecificationInfo1 = new Rental_Vehicles_System.Specifications.ctrlShowSpecificationInfo();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AutoRoundedCorners = true;
            this.btnCancel.BackColor = System.Drawing.Color.BlueViolet;
            this.btnCancel.BorderColor = System.Drawing.Color.Purple;
            this.btnCancel.BorderThickness = 3;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(833, 365);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 45);
            this.btnCancel.TabIndex = 49;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ctrlShowSpecificationInfo1
            // 
            this.ctrlShowSpecificationInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlShowSpecificationInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlShowSpecificationInfo1.Name = "ctrlShowSpecificationInfo1";
            this.ctrlShowSpecificationInfo1.Size = new System.Drawing.Size(966, 413);
            this.ctrlShowSpecificationInfo1.TabIndex = 0;
            // 
            // frmShowSpecificationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 413);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ctrlShowSpecificationInfo1);
            this.Name = "frmShowSpecificationInfo";
            this.Text = "frmShowSpecificationInfo";
            this.Load += new System.EventHandler(this.frmShowSpecificationInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlShowSpecificationInfo ctrlShowSpecificationInfo1;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
    }
}