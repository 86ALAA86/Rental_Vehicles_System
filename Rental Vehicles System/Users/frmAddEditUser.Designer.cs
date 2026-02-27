namespace Rental_Vehicles_System.Users
{
    partial class frmAddEditUser
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditUser));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tbUserInfo = new System.Windows.Forms.TabPage();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.chbIsActive = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFormTitle1 = new System.Windows.Forms.Label();
            this.tbPersonInfo = new System.Windows.Forms.TabPage();
            this.ctrlShowPersonInfoWithFilter1 = new Rental_Vehicles_System.People.ctrlShowPersonInfoWithFilter();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.tbUserInfo.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.tbPersonInfo.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.guna2TabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "project.png");
            this.imageList1.Images.SetKeyName(1, "user (2).png");
            this.imageList1.Images.SetKeyName(2, "Userpng.png");
            // 
            // tbUserInfo
            // 
            this.tbUserInfo.Controls.Add(this.guna2Panel2);
            this.tbUserInfo.ImageKey = "user (2).png";
            this.tbUserInfo.Location = new System.Drawing.Point(184, 4);
            this.tbUserInfo.Name = "tbUserInfo";
            this.tbUserInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbUserInfo.Size = new System.Drawing.Size(876, 460);
            this.tbUserInfo.TabIndex = 1;
            this.tbUserInfo.Text = "   User Info";
            this.tbUserInfo.UseVisualStyleBackColor = true;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackgroundImage = global::Rental_Vehicles_System.Properties.Resources.Edit_User;
            this.guna2Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel2.Controls.Add(this.lblUserID);
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.Controls.Add(this.btnClose);
            this.guna2Panel2.Controls.Add(this.btnSave);
            this.guna2Panel2.Controls.Add(this.chbIsActive);
            this.guna2Panel2.Controls.Add(this.txtConfirmPassword);
            this.guna2Panel2.Controls.Add(this.txtPassword);
            this.guna2Panel2.Controls.Add(this.txtUserName);
            this.guna2Panel2.Controls.Add(this.label12);
            this.guna2Panel2.Controls.Add(this.label11);
            this.guna2Panel2.Controls.Add(this.label7);
            this.guna2Panel2.Controls.Add(this.label3);
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Controls.Add(this.lblFormTitle1);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(870, 454);
            this.guna2Panel2.TabIndex = 1;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Tahoma", 17F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.lblUserID.ForeColor = System.Drawing.Color.Black;
            this.lblUserID.Location = new System.Drawing.Point(175, 79);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(51, 35);
            this.lblUserID.TabIndex = 27;
            this.lblUserID.Text = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 30);
            this.label1.TabIndex = 26;
            this.label1.Text = "UserID :";
            // 
            // btnClose
            // 
            this.btnClose.AutoRoundedCorners = true;
            this.btnClose.BorderColor = System.Drawing.Color.Red;
            this.btnClose.BorderRadius = 21;
            this.btnClose.BorderThickness = 2;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(436, 399);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(180, 45);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoRoundedCorners = true;
            this.btnSave.BorderColor = System.Drawing.Color.Green;
            this.btnSave.BorderRadius = 21;
            this.btnSave.BorderThickness = 2;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(625, 399);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 45);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chbIsActive
            // 
            this.chbIsActive.AutoSize = true;
            this.chbIsActive.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.chbIsActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbIsActive.CheckedState.BorderRadius = 0;
            this.chbIsActive.CheckedState.BorderThickness = 0;
            this.chbIsActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbIsActive.Font = new System.Drawing.Font("Tahoma", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.chbIsActive.ForeColor = System.Drawing.Color.White;
            this.chbIsActive.Location = new System.Drawing.Point(611, 130);
            this.chbIsActive.Name = "chbIsActive";
            this.chbIsActive.Size = new System.Drawing.Size(163, 37);
            this.chbIsActive.TabIndex = 16;
            this.chbIsActive.Text = "Is Active ";
            this.chbIsActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbIsActive.UncheckedState.BorderRadius = 0;
            this.chbIsActive.UncheckedState.BorderThickness = 0;
            this.chbIsActive.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.AutoRoundedCorners = true;
            this.txtConfirmPassword.BorderColor = System.Drawing.Color.Navy;
            this.txtConfirmPassword.BorderThickness = 2;
            this.txtConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmPassword.DefaultText = "";
            this.txtConfirmPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtConfirmPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtConfirmPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.Black;
            this.txtConfirmPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmPassword.Location = new System.Drawing.Point(268, 338);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtConfirmPassword.PlaceholderText = "Confirm Password";
            this.txtConfirmPassword.SelectedText = "";
            this.txtConfirmPassword.Size = new System.Drawing.Size(315, 44);
            this.txtConfirmPassword.TabIndex = 15;
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // txtPassword
            // 
            this.txtPassword.AutoRoundedCorners = true;
            this.txtPassword.BorderColor = System.Drawing.Color.Navy;
            this.txtPassword.BorderThickness = 2;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Location = new System.Drawing.Point(188, 250);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(315, 44);
            this.txtPassword.TabIndex = 14;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // txtUserName
            // 
            this.txtUserName.AutoRoundedCorners = true;
            this.txtUserName.BorderColor = System.Drawing.Color.Navy;
            this.txtUserName.BorderThickness = 2;
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.DefaultText = "";
            this.txtUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtUserName.ForeColor = System.Drawing.Color.Black;
            this.txtUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserName.Location = new System.Drawing.Point(180, 162);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtUserName.PlaceholderText = "UserName";
            this.txtUserName.SelectedText = "";
            this.txtUserName.Size = new System.Drawing.Size(315, 44);
            this.txtUserName.TabIndex = 13;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(7, 257);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(150, 30);
            this.label12.TabIndex = 12;
            this.label12.Text = "Password :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(3, 345);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(258, 30);
            this.label11.TabIndex = 11;
            this.label11.Text = "Confirm Password :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 519);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 30);
            this.label7.TabIndex = 7;
            this.label7.Text = "First Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(506, 492);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "First Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "UserName :";
            // 
            // lblFormTitle1
            // 
            this.lblFormTitle1.AutoSize = true;
            this.lblFormTitle1.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle1.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle1.Location = new System.Drawing.Point(216, 0);
            this.lblFormTitle1.Name = "lblFormTitle1";
            this.lblFormTitle1.Size = new System.Drawing.Size(390, 60);
            this.lblFormTitle1.TabIndex = 0;
            this.lblFormTitle1.Text = "Add Edit Users";
            // 
            // tbPersonInfo
            // 
            this.tbPersonInfo.Controls.Add(this.ctrlShowPersonInfoWithFilter1);
            this.tbPersonInfo.Controls.Add(this.guna2Panel1);
            this.tbPersonInfo.ImageKey = "project.png";
            this.tbPersonInfo.Location = new System.Drawing.Point(184, 4);
            this.tbPersonInfo.Name = "tbPersonInfo";
            this.tbPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbPersonInfo.Size = new System.Drawing.Size(880, 464);
            this.tbPersonInfo.TabIndex = 0;
            this.tbPersonInfo.Text = "Person Info";
            this.tbPersonInfo.UseVisualStyleBackColor = true;
            // 
            // ctrlShowPersonInfoWithFilter1
            // 
            this.ctrlShowPersonInfoWithFilter1.EnableFilters = false;
            this.ctrlShowPersonInfoWithFilter1.Location = new System.Drawing.Point(8, 8);
            this.ctrlShowPersonInfoWithFilter1.Name = "ctrlShowPersonInfoWithFilter1";
            this.ctrlShowPersonInfoWithFilter1.Size = new System.Drawing.Size(820, 388);
            this.ctrlShowPersonInfoWithFilter1.TabIndex = 3;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackgroundImage = global::Rental_Vehicles_System.Properties.Resources.ChatGPT_Image_Nov_24__2025__08_20_19_PM;
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.Controls.Add(this.btnCancel);
            this.guna2Panel1.Controls.Add(this.btnNext);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(874, 458);
            this.guna2Panel1.TabIndex = 2;
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
            this.btnCancel.Location = new System.Drawing.Point(479, 399);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 45);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.AutoRoundedCorners = true;
            this.btnNext.BorderColor = System.Drawing.Color.Blue;
            this.btnNext.BorderRadius = 21;
            this.btnNext.BorderThickness = 2;
            this.btnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext.FillColor = System.Drawing.Color.White;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.Black;
            this.btnNext.Location = new System.Drawing.Point(645, 399);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(180, 45);
            this.btnNext.TabIndex = 28;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // guna2TabControl1
            // 
            this.guna2TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.guna2TabControl1.Controls.Add(this.tbPersonInfo);
            this.guna2TabControl1.Controls.Add(this.tbUserInfo);
            this.guna2TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2TabControl1.ImageList = this.imageList1;
            this.guna2TabControl1.ItemSize = new System.Drawing.Size(180, 40);
            this.guna2TabControl1.Location = new System.Drawing.Point(0, 0);
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.Size = new System.Drawing.Size(1068, 472);
            this.guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
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
            this.guna2TabControl1.TabButtonSize = new System.Drawing.Size(180, 40);
            this.guna2TabControl1.TabIndex = 0;
            this.guna2TabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            // 
            // frmAddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1068, 472);
            this.Controls.Add(this.guna2TabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAddEditUser";
            this.Text = "frmAddEditUser";
            this.Load += new System.EventHandler(this.frmAddEditUser_Load);
            this.tbUserInfo.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.tbPersonInfo.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2TabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tbUserInfo;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2CheckBox chbIsActive;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirmPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtUserName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFormTitle1;
        private System.Windows.Forms.TabPage tbPersonInfo;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private People.ctrlShowPersonInfoWithFilter ctrlShowPersonInfoWithFilter1;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
    }
}