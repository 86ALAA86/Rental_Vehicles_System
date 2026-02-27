using Guna.UI2.WinForms;
using Rental_Vehicles_System.Global;
using RVS_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rental_Vehicles_System.Properties;
using Microsoft.Win32;


namespace Rental_Vehicles_System.Log_IN
{
    public partial class frmLogINSceen : Form
    {
        public frmLogINSceen()
        {
            InitializeComponent();

        }

        private int FailedAttempts = 0;
        private int WaittingTimeinSeconds = 60;


        private Timer lockoutTimer = new Timer();
      

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBox_Validating(object sender, CancelEventArgs e)
                    {
            Guna2TextBox Txt=sender as Guna2TextBox;
            ErrorProvider EP=new ErrorProvider();
            if(string.IsNullOrEmpty(Txt.Text))
            {
                EP.SetError(Txt, "This Field Can Not Be Empty");
                e.Cancel = true;
            }
            else
            {
                EP.SetError(Txt, null);
                e.Cancel = false;
            }
        }

        //
        private void _RemeberLoginData()
        {
            /*
            //Old Code : 
            if (chbRemeberMe.Checked)
            {
                Properties.setLoginInfo.Default.UserName = txtUserName.Text;
                Properties.setLoginInfo.Default.Password = txtPassword.Text;
                Properties.setLoginInfo.Default.RemeberMe = true ;
            }
            else
            {
                Properties.setLoginInfo.Default.UserName ="";
                Properties.setLoginInfo.Default.Password = "";
                Properties.setLoginInfo.Default.RemeberMe = false ;
            }
            Properties.setLoginInfo.Default.Save();

            */

            string KeyPath= @"HKEY_CURRENT_USER\Software\RentalVehiclesSystem";
           

            try
            {
                if( chbRemeberMe.Checked )
                {
                    Registry.SetValue(KeyPath,"UserName"  , txtUserName.Text.ToString(), RegistryValueKind.String);
                    Registry.SetValue(KeyPath,"Password"  , txtPassword.Text.ToString(), RegistryValueKind.String);
                    Registry.SetValue(KeyPath,"RemeberMe","1", RegistryValueKind.String);

                }
                else
                {
                    Registry.SetValue(KeyPath, "UserName","", RegistryValueKind.String);
                    Registry.SetValue(KeyPath, "Password", "", RegistryValueKind.String);
                    Registry.SetValue(KeyPath, "RemeberMe","0", RegistryValueKind.String);

                }

            }
            catch(Exception e) 
            {
                //Console.WriteLine(e.ToString());

                clsUtil.LogToEventLogger(e);
                clsUtil.LogToUserOnScreen(e);
                Registry.SetValue(KeyPath, "UserName", "", RegistryValueKind.String);
                Registry.SetValue(KeyPath, "Password", "", RegistryValueKind.String);
                Registry.SetValue(KeyPath, "RemeberMe", "0", RegistryValueKind.String);

            }


        }

        private void _DisplayLoginData()
        {
            /*
             //Old Code :

            if(!Properties.setLoginInfo.Default.RemeberMe)
            {
                return;
            }
            txtUserName.Text=  Properties.setLoginInfo.Default.UserName ;
            txtPassword.Text=  Properties.setLoginInfo.Default.Password ;
            chbRemeberMe.Checked= Properties.setLoginInfo.Default.RemeberMe;

            */

            string KeyPath = @"HKEY_CURRENT_USER\Software\RentalVehiclesSystem";

            try
            {
                string Remeber = (Registry.GetValue(KeyPath, "RemeberMe", "0")).ToString();
                if (Remeber=="1" )
                {
                    txtUserName.Text = Registry.GetValue(KeyPath, "UserName", null) as string;
                    txtPassword.Text = Registry.GetValue(KeyPath, "Password", null) as string;
                    chbRemeberMe.Checked=true;

                }
                else
                {
                    txtUserName.Text ="";
                    txtPassword.Text = "";
                    chbRemeberMe.Checked = false;
                }
            }
            catch (Exception e)
            {
                clsUtil.LogToEventLogger(e);
                clsUtil.LogToUserOnScreen(e);
                txtUserName.Text = "";
                txtPassword.Text = "";
                chbRemeberMe.Checked = false;
            }



        }

        //
        private void btnOK_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Please Enter A Value IN The TextBox Near Red Mark","Error",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtPassword.Text = txtUserName.Text = "";
                return;
            }
            if (FailedAttempts >= 2)
            {
                MessageBox.Show("Too Many Failed Attempts. Please Try Again After 1 Minute.", "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                txtPassword.Enabled = false;
                txtUserName.Enabled = false;
                btnOK.Enabled = false;
                lockoutTimer.Start();
                return;
            }

            clsUser User = clsUser.FindByUsernameAndPassword(txtUserName.Text,(txtPassword.Text));
            if (User==null)
            {
                MessageBox.Show("User Could Not Found , Try Again.", "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                FailedAttempts++;
                return;
            }
            if (!User.IsActive)
            {
                MessageBox.Show("This User Is Not Active ,Contact Your Admin.", "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                return;
            }

            _RemeberLoginData();
            clsGlobal.CurrentUser = User;
            this.DialogResult = DialogResult.OK;
            this.Close();
            return;

        }

        private void frmLogINSceen_Load(object sender, EventArgs e)
        {
            _DisplayLoginData();
            lockoutTimer.Interval = 100; // 1 second in milliseconds
            lockoutTimer.Tick += LockoutTimer_Tick;
        }

        private void LockoutTimer_Tick(object sender, EventArgs e)
        {
            if (WaittingTimeinSeconds > 0)
            {
                lblNote.Visible = true;
                lblNote.Text = "You Can Try Again In " + WaittingTimeinSeconds.ToString() + " ";
                WaittingTimeinSeconds--;
            }
            else
            {
                lblNote.Visible = false;
                lockoutTimer.Stop();
                txtPassword.Enabled = true;
                txtUserName.Enabled = true;
                btnOK.Enabled = true;
                FailedAttempts = 0;
                WaittingTimeinSeconds = 60;
                lblNote.Text = "";
                txtPassword.Text = "";
                txtUserName.Text = "";
                txtUserName.Focus();
            }
        }
    }
}
