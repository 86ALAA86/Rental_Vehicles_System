using Guna.UI2.WinForms;
using Rental_Vehicles_System.Global;
using Rental_Vehicles_System.Properties;
using RVS_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_Vehicles_System.Users
{
    public partial class frmAddEditUser : Form
    {
        enum enMode { AddNew=0, Edit=1 }
        public frmAddEditUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddEditUser(int UserId)
        {
            InitializeComponent();
            _UserID = UserId;
            _Mode = enMode.Edit;
        }

        private int _UserID;
        private clsUser _User;
        private enMode _Mode= enMode.AddNew;

        private void _LoadDefaultValues()
        {
            lblFormTitle1.Text = "Add User";
            lblUserID.Text = "?";
            _User = new clsUser();
            btnNext.Enabled = false;
            ctrlShowPersonInfoWithFilter1.EnableFilters = true;
            ctrlShowPersonInfoWithFilter1.LoadDefaultValues();
            btnSave.Enabled = false;

            txtConfirmPassword.Enabled = false;
            txtPassword.Enabled= false;
            txtUserName.Enabled = false;
        }

        private void _LoadUserInfo()
        {
            lblFormTitle1.Text = "Edit User";
            _User = clsUser.FindByUserID(_UserID);
            
            if(_User == null)
            {
                MessageBox.Show("User Was Not Found.", "Error", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
                return;
            }

            //txtConfirmPassword.Text = _User.Password;
            //txtPassword.Text = _User.Password;

            txtUserName.Text = _User.UserName;
            chbIsActive.Checked= _User.IsActive;

            lblUserID.Text = _User.UserID.ToString() ;
            btnNext.Enabled = true ;
            ctrlShowPersonInfoWithFilter1.EnableFilters = false;
            ctrlShowPersonInfoWithFilter1.LoadPersonInfo(_User.PersonID);
            btnSave.Enabled = true;

            txtConfirmPassword.Enabled = true;
            txtPassword.Enabled = true;
            txtUserName.Enabled = true;
        }
        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _LoadDefaultValues();
            if(_Mode==enMode.Edit)
            {
                _LoadUserInfo();
            }
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("There is Some Messing Values, " +
               "Please Enter a Value In TextBox Near The RedMark.", "Error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }

           

            _User.PersonID=ctrlShowPersonInfoWithFilter1.PersonInfo.PersonID;
            _User.UserName = txtUserName.Text;
            _User.Password = txtConfirmPassword.Text;
            _User.IsActive = chbIsActive.Checked;
            

            
            if (!_User.Save())
            {
                MessageBox.Show("User Was Not Saved, An Error Occored", "Error", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("User Was Saved, Operation Done Successfully", "Done", MessageBoxButtons.OK,
             MessageBoxIcon.Information);
            lblUserID.Text = _User.UserID.ToString();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider er = new ErrorProvider();

            if(string.IsNullOrEmpty(txtUserName.Text))
            {
                er.SetError(txtUserName,"UserName Can Not Be Empty.");
                e.Cancel = true ;
            }

            if (_Mode == enMode.AddNew)
            {

                if (clsUser.isUserExist(txtUserName.Text.Trim()))
                {

                    er.SetError(txtUserName, "username is used by another user");
                   e.Cancel=true;
                }
                else
                {
                    er.SetError(txtUserName, null);
                    e.Cancel = false;
                };
            }
            else
            {
                //incase update make sure not to use anothers user name
                if (_User.UserName != txtUserName.Text.Trim())
                {
                    if (clsUser.isUserExist(txtUserName.Text.Trim()))
                    {
                        er.SetError(txtUserName, "username is used by another user");
                       e.Cancel=true;
                    }
                    else
                    {
                        er.SetError(txtUserName, null);
                     e.Cancel=false;
                    };
                }
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider er = new ErrorProvider();

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                er.SetError(txtPassword, "Password Can Not Be Empty.");
                e.Cancel = true;
            }
            else
            {
                er.SetError(txtPassword, null);
                e.Cancel = false;
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider er = new ErrorProvider();

            if(string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                er.SetError(txtConfirmPassword, "Can Not Be Empty");
                e.Cancel = true;
            }
            else
            {
                er.SetError(txtConfirmPassword, null);
                e.Cancel = false;
            }

            if (txtConfirmPassword.Text!=txtPassword.Text)
            {
                er.SetError(txtConfirmPassword, "No Match.");
                e.Cancel = true;
            }
            else
            {
                er.SetError(txtConfirmPassword, null);
                e.Cancel = false;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(ctrlShowPersonInfoWithFilter1.PersonInfo.PersonID!=-1)
            {
                guna2TabControl1.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("Please Select A Person First.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(_Mode==enMode.AddNew
               && ctrlShowPersonInfoWithFilter1.PersonInfo.PersonID!=-1)
            {
                ctrlShowPersonInfoWithFilter1.PersonInfo.DeletePerson();
                this.Close();
            }
            this.Close();
        }

        
    }
}
