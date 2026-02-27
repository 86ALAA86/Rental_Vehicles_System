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

namespace Rental_Vehicles_System.Users
{
    public partial class frmChangeUserPasword : Form
    {
        public frmChangeUserPasword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }
        private int _UserID;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(clsUser.ChangePassword(_UserID,txtConfirmPassword.Text))
            {
                MessageBox.Show("User Password Was Updated Successfully.","Done",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);             
            }
            else
            {
                MessageBox.Show("User Password Was Not Updated.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnSave.Enabled = false;
            txtConfirmPassword.Enabled = false;
            txtNewPassword.Enabled = false;
            txtOldPassword.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangeUserPasword_Load(object sender, EventArgs e)
        {
            ctrlShowUserInfo1.LoadUserInfo(_UserID);
        }

        private void txtOldPassword_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider er = new ErrorProvider();
            if(string.IsNullOrEmpty(txtOldPassword.Text))
            {
                er.SetError(txtOldPassword, "Can Not Be Empty.");
                e.Cancel = true;
            }
            else if(clsUser.FindByUsernameAndPassword
                (ctrlShowUserInfo1.UserInfo.UserName, txtOldPassword.Text)==null)
            {
                er.SetError(txtOldPassword, "Wrong Password, Try Again.");
                e.Cancel = true;
            }
            else
            {
                er.SetError(txtOldPassword,null);
                e.Cancel = false;
            }

        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider er = new ErrorProvider();

            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                er.SetError(txtNewPassword, "Can Not Be Empty");
                e.Cancel = true;
            }
            else
            {
                er.SetError(txtNewPassword, null);
                e.Cancel = false;
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider er = new ErrorProvider();
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                er.SetError(txtConfirmPassword, "Can Not Be Empty.");
                e.Cancel = true;
            }
            else if (txtConfirmPassword.Text!=txtNewPassword.Text)
            {
                er.SetError(txtConfirmPassword, "Wrong Password, Try Again.");
                e.Cancel = true;
            }
            else
            {
                er.SetError(txtConfirmPassword, null);
                e.Cancel = false;
            }
        }
    }
}
