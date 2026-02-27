namespace Rental_Vehicles_System.People
{
    partial class frmAddEditPerson
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.cbCountries = new Guna.UI2.WinForms.Guna2ComboBox();
            this.llDeletePicture = new System.Windows.Forms.LinkLabel();
            this.llsetPicture = new System.Windows.Forms.LinkLabel();
            this.pbPersonImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.dtpDateOfBirth = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.rbFemale = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbMale = new Guna.UI2.WinForms.Guna2RadioButton();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNationalNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtLastName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtFirstName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackgroundImage = global::Rental_Vehicles_System.Properties.Resources.ChatGPT_Image_Nov_24__2025__08_20_19_PM;
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.Controls.Add(this.btnClose);
            this.guna2Panel1.Controls.Add(this.cbCountries);
            this.guna2Panel1.Controls.Add(this.llDeletePicture);
            this.guna2Panel1.Controls.Add(this.llsetPicture);
            this.guna2Panel1.Controls.Add(this.pbPersonImage);
            this.guna2Panel1.Controls.Add(this.dtpDateOfBirth);
            this.guna2Panel1.Controls.Add(this.rbFemale);
            this.guna2Panel1.Controls.Add(this.rbMale);
            this.guna2Panel1.Controls.Add(this.btnSave);
            this.guna2Panel1.Controls.Add(this.txtAddress);
            this.guna2Panel1.Controls.Add(this.txtPhone);
            this.guna2Panel1.Controls.Add(this.txtNationalNumber);
            this.guna2Panel1.Controls.Add(this.txtEmail);
            this.guna2Panel1.Controls.Add(this.txtLastName);
            this.guna2Panel1.Controls.Add(this.txtFirstName);
            this.guna2Panel1.Controls.Add(this.label13);
            this.guna2Panel1.Controls.Add(this.label14);
            this.guna2Panel1.Controls.Add(this.label15);
            this.guna2Panel1.Controls.Add(this.label16);
            this.guna2Panel1.Controls.Add(this.label17);
            this.guna2Panel1.Controls.Add(this.label18);
            this.guna2Panel1.Controls.Add(this.label19);
            this.guna2Panel1.Controls.Add(this.label20);
            this.guna2Panel1.Controls.Add(this.label23);
            this.guna2Panel1.Controls.Add(this.lblFormTitle);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(935, 451);
            this.guna2Panel1.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.AutoRoundedCorners = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderColor = System.Drawing.Color.Red;
            this.btnClose.BorderThickness = 2;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(485, 390);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(180, 45);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbCountries
            // 
            this.cbCountries.AutoRoundedCorners = true;
            this.cbCountries.BackColor = System.Drawing.Color.Transparent;
            this.cbCountries.BorderColor = System.Drawing.Color.Navy;
            this.cbCountries.BorderThickness = 2;
            this.cbCountries.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCountries.DropDownHeight = 150;
            this.cbCountries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountries.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCountries.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCountries.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCountries.ForeColor = System.Drawing.Color.Black;
            this.cbCountries.IntegralHeight = false;
            this.cbCountries.ItemHeight = 30;
            this.cbCountries.Location = new System.Drawing.Point(600, 252);
            this.cbCountries.Name = "cbCountries";
            this.cbCountries.Size = new System.Drawing.Size(202, 36);
            this.cbCountries.TabIndex = 1;
            this.cbCountries.Validating += new System.ComponentModel.CancelEventHandler(this.cbCountries_Validating);
            // 
            // llDeletePicture
            // 
            this.llDeletePicture.AutoSize = true;
            this.llDeletePicture.BackColor = System.Drawing.Color.Transparent;
            this.llDeletePicture.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.llDeletePicture.LinkColor = System.Drawing.Color.White;
            this.llDeletePicture.Location = new System.Drawing.Point(773, 219);
            this.llDeletePicture.Name = "llDeletePicture";
            this.llDeletePicture.Size = new System.Drawing.Size(144, 23);
            this.llDeletePicture.TabIndex = 29;
            this.llDeletePicture.TabStop = true;
            this.llDeletePicture.Text = "Delete Picture";
            this.llDeletePicture.Visible = false;
            this.llDeletePicture.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llDeletePicture_LinkClicked);
            // 
            // llsetPicture
            // 
            this.llsetPicture.AutoSize = true;
            this.llsetPicture.BackColor = System.Drawing.Color.Transparent;
            this.llsetPicture.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.llsetPicture.LinkColor = System.Drawing.Color.White;
            this.llsetPicture.Location = new System.Drawing.Point(788, 195);
            this.llsetPicture.Name = "llsetPicture";
            this.llsetPicture.Size = new System.Drawing.Size(114, 23);
            this.llsetPicture.TabIndex = 28;
            this.llsetPicture.TabStop = true;
            this.llsetPicture.Text = "Set Picture";
            this.llsetPicture.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llsetPicture_LinkClicked);
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackColor = System.Drawing.Color.Transparent;
            this.pbPersonImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPersonImage.ImageRotate = 0F;
            this.pbPersonImage.Location = new System.Drawing.Point(770, 42);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(150, 150);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 27;
            this.pbPersonImage.TabStop = false;
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.AutoRoundedCorners = true;
            this.dtpDateOfBirth.BackColor = System.Drawing.Color.Transparent;
            this.dtpDateOfBirth.BorderColor = System.Drawing.Color.Navy;
            this.dtpDateOfBirth.BorderThickness = 2;
            this.dtpDateOfBirth.Checked = true;
            this.dtpDateOfBirth.FillColor = System.Drawing.Color.White;
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(639, 337);
            this.dtpDateOfBirth.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDateOfBirth.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(292, 36);
            this.dtpDateOfBirth.TabIndex = 26;
            this.dtpDateOfBirth.Value = new System.DateTime(2025, 11, 24, 21, 30, 51, 309);
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.BackColor = System.Drawing.Color.Transparent;
            this.rbFemale.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbFemale.CheckedState.BorderThickness = 0;
            this.rbFemale.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbFemale.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbFemale.CheckedState.InnerOffset = -4;
            this.rbFemale.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.rbFemale.ForeColor = System.Drawing.Color.White;
            this.rbFemale.Location = new System.Drawing.Point(639, 86);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(104, 28);
            this.rbFemale.TabIndex = 25;
            this.rbFemale.Text = "Female";
            this.rbFemale.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbFemale.UncheckedState.BorderThickness = 2;
            this.rbFemale.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbFemale.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbFemale.UseVisualStyleBackColor = false;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.BackColor = System.Drawing.Color.Transparent;
            this.rbMale.Checked = true;
            this.rbMale.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbMale.CheckedState.BorderThickness = 0;
            this.rbMale.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbMale.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbMale.CheckedState.InnerOffset = -4;
            this.rbMale.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.rbMale.ForeColor = System.Drawing.Color.White;
            this.rbMale.Location = new System.Drawing.Point(554, 86);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(79, 28);
            this.rbMale.TabIndex = 24;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbMale.UncheckedState.BorderThickness = 2;
            this.rbMale.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbMale.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbMale.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.AutoRoundedCorners = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderColor = System.Drawing.Color.Green;
            this.btnSave.BorderThickness = 2;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(700, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 45);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.AutoRoundedCorners = true;
            this.txtAddress.BackColor = System.Drawing.Color.Transparent;
            this.txtAddress.BorderColor = System.Drawing.Color.Navy;
            this.txtAddress.BorderThickness = 2;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtAddress.ForeColor = System.Drawing.Color.Black;
            this.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.Location = new System.Drawing.Point(176, 312);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtAddress.PlaceholderText = "Address";
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(232, 45);
            this.txtAddress.TabIndex = 22;
            this.txtAddress.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_Validating);
            // 
            // txtPhone
            // 
            this.txtPhone.AutoRoundedCorners = true;
            this.txtPhone.BackColor = System.Drawing.Color.Transparent;
            this.txtPhone.BorderColor = System.Drawing.Color.Navy;
            this.txtPhone.BorderThickness = 2;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.DefaultText = "";
            this.txtPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtPhone.ForeColor = System.Drawing.Color.Black;
            this.txtPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.Location = new System.Drawing.Point(527, 163);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtPhone.PlaceholderText = "Phone";
            this.txtPhone.SelectedText = "";
            this.txtPhone.Size = new System.Drawing.Size(232, 45);
            this.txtPhone.TabIndex = 21;
            this.txtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_Validating);
            // 
            // txtNationalNumber
            // 
            this.txtNationalNumber.AutoRoundedCorners = true;
            this.txtNationalNumber.BackColor = System.Drawing.Color.Transparent;
            this.txtNationalNumber.BorderColor = System.Drawing.Color.Navy;
            this.txtNationalNumber.BorderThickness = 2;
            this.txtNationalNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNationalNumber.DefaultText = "";
            this.txtNationalNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNationalNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNationalNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNationalNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNationalNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNationalNumber.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtNationalNumber.ForeColor = System.Drawing.Color.Black;
            this.txtNationalNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNationalNumber.Location = new System.Drawing.Point(176, 390);
            this.txtNationalNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNationalNumber.Name = "txtNationalNumber";
            this.txtNationalNumber.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtNationalNumber.PlaceholderText = "Natioanl Number";
            this.txtNationalNumber.SelectedText = "";
            this.txtNationalNumber.Size = new System.Drawing.Size(232, 45);
            this.txtNationalNumber.TabIndex = 20;
            this.txtNationalNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtNationalNumber_Validating);
            // 
            // txtEmail
            // 
            this.txtEmail.AutoRoundedCorners = true;
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.BorderColor = System.Drawing.Color.Navy;
            this.txtEmail.BorderThickness = 2;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(176, 234);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtEmail.PlaceholderText = "Email";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(232, 45);
            this.txtEmail.TabIndex = 15;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // txtLastName
            // 
            this.txtLastName.AutoRoundedCorners = true;
            this.txtLastName.BackColor = System.Drawing.Color.Transparent;
            this.txtLastName.BorderColor = System.Drawing.Color.Navy;
            this.txtLastName.BorderThickness = 2;
            this.txtLastName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLastName.DefaultText = "";
            this.txtLastName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtLastName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtLastName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLastName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLastName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtLastName.ForeColor = System.Drawing.Color.Black;
            this.txtLastName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLastName.Location = new System.Drawing.Point(176, 156);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtLastName.PlaceholderText = "Last Name";
            this.txtLastName.SelectedText = "";
            this.txtLastName.Size = new System.Drawing.Size(232, 45);
            this.txtLastName.TabIndex = 14;
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_Validating);
            // 
            // txtFirstName
            // 
            this.txtFirstName.AutoRoundedCorners = true;
            this.txtFirstName.BackColor = System.Drawing.Color.Transparent;
            this.txtFirstName.BorderColor = System.Drawing.Color.Navy;
            this.txtFirstName.BorderThickness = 2;
            this.txtFirstName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFirstName.DefaultText = "";
            this.txtFirstName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFirstName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFirstName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFirstName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFirstName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.ForeColor = System.Drawing.Color.Black;
            this.txtFirstName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFirstName.Location = new System.Drawing.Point(176, 78);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtFirstName.PlaceholderText = "First Name";
            this.txtFirstName.SelectedText = "";
            this.txtFirstName.Size = new System.Drawing.Size(232, 45);
            this.txtFirstName.TabIndex = 13;
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(3, 163);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(161, 30);
            this.label13.TabIndex = 12;
            this.label13.Text = "Last Name :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(3, 241);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 30);
            this.label14.TabIndex = 11;
            this.label14.Text = "Email :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(3, 319);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(130, 30);
            this.label15.TabIndex = 10;
            this.label15.Text = "Address :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(427, 170);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(107, 30);
            this.label16.TabIndex = 9;
            this.label16.Text = "Phone :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(427, 85);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(121, 30);
            this.label17.TabIndex = 8;
            this.label17.Text = "Gender :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(3, 397);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(180, 30);
            this.label18.TabIndex = 7;
            this.label18.Text = "National NO :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(427, 255);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(167, 30);
            this.label19.TabIndex = 6;
            this.label19.Text = "Nationality :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(427, 340);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(193, 30);
            this.label20.TabIndex = 5;
            this.label20.Text = "Date Of Birth :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(3, 85);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(166, 30);
            this.label23.TabIndex = 2;
            this.label23.Text = "First Name :";
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblFormTitle.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(276, 0);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(423, 60);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Add Edit Person";
            // 
            // frmAddEditPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(935, 451);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "frmAddEditPerson";
            this.Text = "frmAddEditPerson";
            this.Load += new System.EventHandler(this.frmAddEditPerson_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ComboBox cbCountries;
        private System.Windows.Forms.LinkLabel llDeletePicture;
        private System.Windows.Forms.LinkLabel llsetPicture;
        private Guna.UI2.WinForms.Guna2PictureBox pbPersonImage;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDateOfBirth;
        private Guna.UI2.WinForms.Guna2RadioButton rbFemale;
        private Guna.UI2.WinForms.Guna2RadioButton rbMale;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private Guna.UI2.WinForms.Guna2TextBox txtNationalNumber;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtLastName;
        private Guna.UI2.WinForms.Guna2TextBox txtFirstName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label lblFormTitle;
    }
}