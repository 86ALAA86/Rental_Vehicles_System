namespace Rental_Vehicles_System.Transactions
{
    partial class frmShowTransactionInfo
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
            this.ctrlShowTransactionInfo1 = new Rental_Vehicles_System.Transactions.ctrlShowTransactionInfo();
            this.SuspendLayout();
            // 
            // ctrlShowTransactionInfo1
            // 
            this.ctrlShowTransactionInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlShowTransactionInfo1.Name = "ctrlShowTransactionInfo1";
            this.ctrlShowTransactionInfo1.Size = new System.Drawing.Size(951, 388);
            this.ctrlShowTransactionInfo1.TabIndex = 0;
            this.ctrlShowTransactionInfo1.TransactionInfo = null;
            // 
            // frmShowTransactionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 389);
            this.Controls.Add(this.ctrlShowTransactionInfo1);
            this.Name = "frmShowTransactionInfo";
            this.Text = "frmShowTransactionInfo";
            this.Load += new System.EventHandler(this.frmShowTransactionInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlShowTransactionInfo ctrlShowTransactionInfo1;
    }
}