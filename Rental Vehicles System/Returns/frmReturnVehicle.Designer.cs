namespace Rental_Vehicles_System.Returns
{
    partial class frmReturnVehicle
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
            this.lblFormTitle1 = new System.Windows.Forms.Label();
            this.tbReturnInfo = new System.Windows.Forms.TabPage();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.CustomerPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.btnreturningcheck = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.lblActualTotalDueAmount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAdditonalCharges = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblConsumedMileage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblActualRentDays = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblReturnID = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtReturnNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtMileage = new Guna.UI2.WinForms.Guna2TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbBookingInfo = new System.Windows.Forms.TabPage();
            this.ctrlShowBookingInfo1 = new Rental_Vehicles_System.Rental_Booking.ctrlShowBookingInfo();
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.tbReturnInfo.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.CustomerPanel.SuspendLayout();
            this.tbBookingInfo.SuspendLayout();
            this.guna2TabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AutoRoundedCorners = true;
            this.btnCancel.BorderColor = System.Drawing.Color.Red;
            this.btnCancel.BorderRadius = 21;
            this.btnCancel.BorderThickness = 2;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(647, 335);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 45);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblFormTitle1
            // 
            this.lblFormTitle1.AutoSize = true;
            this.lblFormTitle1.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle1.ForeColor = System.Drawing.Color.Black;
            this.lblFormTitle1.Location = new System.Drawing.Point(294, 3);
            this.lblFormTitle1.Name = "lblFormTitle1";
            this.lblFormTitle1.Size = new System.Drawing.Size(448, 60);
            this.lblFormTitle1.TabIndex = 31;
            this.lblFormTitle1.Text = "Add Edit Returns";
            // 
            // tbReturnInfo
            // 
            this.tbReturnInfo.Controls.Add(this.guna2Panel1);
            this.tbReturnInfo.Location = new System.Drawing.Point(4, 44);
            this.tbReturnInfo.Name = "tbReturnInfo";
            this.tbReturnInfo.Size = new System.Drawing.Size(1023, 396);
            this.tbReturnInfo.TabIndex = 3;
            this.tbReturnInfo.Text = "Return Info";
            this.tbReturnInfo.UseVisualStyleBackColor = true;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackgroundImage = global::Rental_Vehicles_System.Properties.Resources.ReturnVehicleAdding;
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.Controls.Add(this.CustomerPanel);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1023, 396);
            this.guna2Panel1.TabIndex = 0;
            // 
            // CustomerPanel
            // 
            this.CustomerPanel.BackgroundImage = global::Rental_Vehicles_System.Properties.Resources.ReturnVehicleAdding;
            this.CustomerPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CustomerPanel.Controls.Add(this.btnreturningcheck);
            this.CustomerPanel.Controls.Add(this.btnSave);
            this.CustomerPanel.Controls.Add(this.btnCancel);
            this.CustomerPanel.Controls.Add(this.lblActualTotalDueAmount);
            this.CustomerPanel.Controls.Add(this.label7);
            this.CustomerPanel.Controls.Add(this.lblAdditonalCharges);
            this.CustomerPanel.Controls.Add(this.label6);
            this.CustomerPanel.Controls.Add(this.lblConsumedMileage);
            this.CustomerPanel.Controls.Add(this.label4);
            this.CustomerPanel.Controls.Add(this.lblActualRentDays);
            this.CustomerPanel.Controls.Add(this.label2);
            this.CustomerPanel.Controls.Add(this.lblReturnID);
            this.CustomerPanel.Controls.Add(this.label12);
            this.CustomerPanel.Controls.Add(this.txtReturnNotes);
            this.CustomerPanel.Controls.Add(this.label22);
            this.CustomerPanel.Controls.Add(this.txtMileage);
            this.CustomerPanel.Controls.Add(this.label16);
            this.CustomerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerPanel.Location = new System.Drawing.Point(0, 0);
            this.CustomerPanel.Name = "CustomerPanel";
            this.CustomerPanel.Size = new System.Drawing.Size(1023, 396);
            this.CustomerPanel.TabIndex = 5;
            // 
            // btnreturningcheck
            // 
            this.btnreturningcheck.AutoRoundedCorners = true;
            this.btnreturningcheck.BorderColor = System.Drawing.Color.Blue;
            this.btnreturningcheck.BorderRadius = 21;
            this.btnreturningcheck.BorderThickness = 3;
            this.btnreturningcheck.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnreturningcheck.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnreturningcheck.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnreturningcheck.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnreturningcheck.FillColor = System.Drawing.Color.White;
            this.btnreturningcheck.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnreturningcheck.ForeColor = System.Drawing.Color.Black;
            this.btnreturningcheck.Location = new System.Drawing.Point(667, 263);
            this.btnreturningcheck.Name = "btnreturningcheck";
            this.btnreturningcheck.Size = new System.Drawing.Size(271, 45);
            this.btnreturningcheck.TabIndex = 47;
            this.btnreturningcheck.Text = "Returning Check";
            this.btnreturningcheck.Click += new System.EventHandler(this.btnreturningcheck_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoRoundedCorners = true;
            this.btnSave.BorderColor = System.Drawing.Color.Green;
            this.btnSave.BorderRadius = 21;
            this.btnSave.BorderThickness = 3;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(830, 335);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 45);
            this.btnSave.TabIndex = 46;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblActualTotalDueAmount
            // 
            this.lblActualTotalDueAmount.AutoSize = true;
            this.lblActualTotalDueAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblActualTotalDueAmount.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.lblActualTotalDueAmount.ForeColor = System.Drawing.Color.White;
            this.lblActualTotalDueAmount.Location = new System.Drawing.Point(782, 202);
            this.lblActualTotalDueAmount.Name = "lblActualTotalDueAmount";
            this.lblActualTotalDueAmount.Size = new System.Drawing.Size(111, 30);
            this.lblActualTotalDueAmount.TabIndex = 45;
            this.lblActualTotalDueAmount.Text = "Amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(435, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(340, 30);
            this.label7.TabIndex = 44;
            this.label7.Text = "Actual Total Due Amount :";
            // 
            // lblAdditonalCharges
            // 
            this.lblAdditonalCharges.AutoSize = true;
            this.lblAdditonalCharges.BackColor = System.Drawing.Color.Transparent;
            this.lblAdditonalCharges.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.lblAdditonalCharges.ForeColor = System.Drawing.Color.White;
            this.lblAdditonalCharges.Location = new System.Drawing.Point(270, 202);
            this.lblAdditonalCharges.Name = "lblAdditonalCharges";
            this.lblAdditonalCharges.Size = new System.Drawing.Size(116, 30);
            this.lblAdditonalCharges.TabIndex = 43;
            this.lblAdditonalCharges.Text = "Charges";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(6, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(268, 30);
            this.label6.TabIndex = 42;
            this.label6.Text = "Additional Charges :";
            // 
            // lblConsumedMileage
            // 
            this.lblConsumedMileage.AutoSize = true;
            this.lblConsumedMileage.BackColor = System.Drawing.Color.Transparent;
            this.lblConsumedMileage.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.lblConsumedMileage.ForeColor = System.Drawing.Color.White;
            this.lblConsumedMileage.Location = new System.Drawing.Point(707, 110);
            this.lblConsumedMileage.Name = "lblConsumedMileage";
            this.lblConsumedMileage.Size = new System.Drawing.Size(160, 30);
            this.lblConsumedMileage.TabIndex = 41;
            this.lblConsumedMileage.Text = "ConMileage";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(435, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(267, 30);
            this.label4.TabIndex = 40;
            this.label4.Text = "Consumed Mileage :";
            // 
            // lblActualRentDays
            // 
            this.lblActualRentDays.AutoSize = true;
            this.lblActualRentDays.BackColor = System.Drawing.Color.Transparent;
            this.lblActualRentDays.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.lblActualRentDays.ForeColor = System.Drawing.Color.White;
            this.lblActualRentDays.Location = new System.Drawing.Point(251, 110);
            this.lblActualRentDays.Name = "lblActualRentDays";
            this.lblActualRentDays.Size = new System.Drawing.Size(133, 30);
            this.lblActualRentDays.TabIndex = 37;
            this.lblActualRentDays.Text = "RentDays";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 30);
            this.label2.TabIndex = 36;
            this.label2.Text = "Actual Rent Days :";
            // 
            // lblReturnID
            // 
            this.lblReturnID.AutoSize = true;
            this.lblReturnID.Font = new System.Drawing.Font("Tahoma", 17F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.lblReturnID.ForeColor = System.Drawing.Color.Black;
            this.lblReturnID.Location = new System.Drawing.Point(189, 16);
            this.lblReturnID.Name = "lblReturnID";
            this.lblReturnID.Size = new System.Drawing.Size(51, 35);
            this.lblReturnID.TabIndex = 35;
            this.lblReturnID.Text = "ID";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(6, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(153, 30);
            this.label12.TabIndex = 34;
            this.label12.Text = "Return ID :";
            // 
            // txtReturnNotes
            // 
            this.txtReturnNotes.AutoRoundedCorners = true;
            this.txtReturnNotes.BorderColor = System.Drawing.Color.Navy;
            this.txtReturnNotes.BorderThickness = 2;
            this.txtReturnNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtReturnNotes.DefaultText = "";
            this.txtReturnNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtReturnNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtReturnNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtReturnNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtReturnNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtReturnNotes.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtReturnNotes.ForeColor = System.Drawing.Color.Black;
            this.txtReturnNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtReturnNotes.Location = new System.Drawing.Point(4, 336);
            this.txtReturnNotes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReturnNotes.Name = "txtReturnNotes";
            this.txtReturnNotes.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtReturnNotes.PlaceholderText = "Return Notes";
            this.txtReturnNotes.SelectedText = "";
            this.txtReturnNotes.Size = new System.Drawing.Size(617, 44);
            this.txtReturnNotes.TabIndex = 32;
            this.txtReturnNotes.Validating += new System.ComponentModel.CancelEventHandler(this.txtReturnNotes_Validating);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(6, 294);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(101, 30);
            this.label22.TabIndex = 30;
            this.label22.Text = "Notes :";
            // 
            // txtMileage
            // 
            this.txtMileage.AutoRoundedCorners = true;
            this.txtMileage.BackColor = System.Drawing.Color.Transparent;
            this.txtMileage.BorderColor = System.Drawing.Color.Navy;
            this.txtMileage.BorderThickness = 2;
            this.txtMileage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMileage.DefaultText = "";
            this.txtMileage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMileage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMileage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMileage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMileage.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMileage.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtMileage.ForeColor = System.Drawing.Color.Black;
            this.txtMileage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMileage.Location = new System.Drawing.Point(575, 11);
            this.txtMileage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMileage.Name = "txtMileage";
            this.txtMileage.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtMileage.PlaceholderText = "Mileage";
            this.txtMileage.SelectedText = "";
            this.txtMileage.Size = new System.Drawing.Size(232, 45);
            this.txtMileage.TabIndex = 21;
            this.txtMileage.TextChanged += new System.EventHandler(this.txtMileage_TextChanged);
            this.txtMileage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMileage_KeyPress);
            this.txtMileage.Validating += new System.ComponentModel.CancelEventHandler(this.txtMileage_Validating);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(435, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(128, 30);
            this.label16.TabIndex = 9;
            this.label16.Text = "Mileage :";
            // 
            // tbBookingInfo
            // 
            this.tbBookingInfo.Controls.Add(this.ctrlShowBookingInfo1);
            this.tbBookingInfo.Location = new System.Drawing.Point(4, 44);
            this.tbBookingInfo.Name = "tbBookingInfo";
            this.tbBookingInfo.Size = new System.Drawing.Size(1023, 396);
            this.tbBookingInfo.TabIndex = 2;
            this.tbBookingInfo.Text = "Booking Info";
            this.tbBookingInfo.UseVisualStyleBackColor = true;
            // 
            // ctrlShowBookingInfo1
            // 
            this.ctrlShowBookingInfo1.Location = new System.Drawing.Point(5, 0);
            this.ctrlShowBookingInfo1.Name = "ctrlShowBookingInfo1";
            this.ctrlShowBookingInfo1.RentalBookInfo = null;
            this.ctrlShowBookingInfo1.Size = new System.Drawing.Size(1020, 381);
            this.ctrlShowBookingInfo1.TabIndex = 0;
            // 
            // guna2TabControl1
            // 
            this.guna2TabControl1.Controls.Add(this.tbBookingInfo);
            this.guna2TabControl1.Controls.Add(this.tbReturnInfo);
            this.guna2TabControl1.ItemSize = new System.Drawing.Size(219, 40);
            this.guna2TabControl1.Location = new System.Drawing.Point(3, 64);
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.Size = new System.Drawing.Size(1031, 444);
            this.guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.guna2TabControl1.TabButtonSize = new System.Drawing.Size(219, 40);
            this.guna2TabControl1.TabIndex = 1;
            this.guna2TabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // frmReturnVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1041, 518);
            this.Controls.Add(this.lblFormTitle1);
            this.Controls.Add(this.guna2TabControl1);
            this.Name = "frmReturnVehicle";
            this.Text = "frmReturnVehicle";
            this.Load += new System.EventHandler(this.frmReturnVehicle_Load);
            this.tbReturnInfo.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.CustomerPanel.ResumeLayout(false);
            this.CustomerPanel.PerformLayout();
            this.tbBookingInfo.ResumeLayout(false);
            this.guna2TabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private System.Windows.Forms.Label lblFormTitle1;
        private System.Windows.Forms.TabPage tbReturnInfo;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel CustomerPanel;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.Label lblActualTotalDueAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAdditonalCharges;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblConsumedMileage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblActualRentDays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblReturnID;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2TextBox txtReturnNotes;
        private System.Windows.Forms.Label label22;
        private Guna.UI2.WinForms.Guna2TextBox txtMileage;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TabPage tbBookingInfo;
        private Rental_Booking.ctrlShowBookingInfo ctrlShowBookingInfo1;
        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private Guna.UI2.WinForms.Guna2Button btnreturningcheck;
    }
}