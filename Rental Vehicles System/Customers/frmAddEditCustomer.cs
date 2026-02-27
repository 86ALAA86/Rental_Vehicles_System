using Rental_Vehicles_System.Global;
using RVS_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_Vehicles_System.Customers
{
    public partial class frmAddEditCustomer : Form
    {

        enum enMode { AddNew,Edit}
        public frmAddEditCustomer()
        {
            InitializeComponent();
            _CustomerID = -1;
            _Mode = enMode.AddNew;
        }
        public frmAddEditCustomer(int CID)
        {
            InitializeComponent();
            _CustomerID = CID;
            _Mode = enMode.Edit;
        }

        private int _CustomerID;
        enMode _Mode = enMode.AddNew;
        private clsCustomer _Customer;


        private void _LoadDefaultValues()
        {
            lblFormTitle1.Text = "Add Customer";
            lblCustomerID.Text = "?";
            _Customer = new clsCustomer();
            btnNext.Enabled = false;
            ctrlShowPersonInfoWithFilter1.EnableFilters = true;
            ctrlShowPersonInfoWithFilter1.LoadDefaultValues();
            btnSave.Enabled = false;

            txtDLN.Enabled = false;
            txtCDLN.Enabled = false;
        }
        private void _LoadCustomerInfo()
        {
            lblFormTitle1.Text = "Edit Customer";
            _Customer = clsCustomer.FindByCustomerID(_CustomerID);

            if (_Customer == null)
            {
                MessageBox.Show("Customer Was Not Found.", "Error", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
                return;
            }


            txtDLN.Text = _Customer.DriverLicenseNumber;
            txtCDLN.Text = _Customer.DriverLicenseNumber;


            lblCustomerID.Text = _Customer.CustomerID.ToString();
            btnNext.Enabled = true;
            ctrlShowPersonInfoWithFilter1.EnableFilters = false;
            ctrlShowPersonInfoWithFilter1.LoadPersonInfo(_Customer.PersonID);
            btnSave.Enabled = true;


            txtCDLN.Enabled = true;
            txtDLN.Enabled = true;

        }
        private void frmAddEditCustomer_Load(object sender, EventArgs e)
        {
            _LoadDefaultValues();
            if (_Mode == enMode.Edit)
            {
                _LoadCustomerInfo();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("There is Some Messing Values, " +
               "Please Enter a Value In TextBox Near The RedMark.", "Error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }

            _Customer.PersonID = ctrlShowPersonInfoWithFilter1.PersonInfo.PersonID;
            _Customer.DriverLicenseNumber = txtCDLN.Text;
            _Customer.CreatedByUserID=clsGlobal.CurrentUser.UserID;

           


            if (!_Customer.Save())
            {
                MessageBox.Show("Customer Was Not Saved, An Error Occored", "Error", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Customer Was Saved, Operation Done Successfully", "Done", MessageBoxButtons.OK,
             MessageBoxIcon.Information);
            lblCustomerID.Text = _Customer.CustomerID.ToString();
        }

        private void txtDLN_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider er = new ErrorProvider();

            if (string.IsNullOrEmpty(txtDLN.Text))
            {
                er.SetError(txtDLN, "License Number Can Not Be Empty.");
                e.Cancel = true;
            }
            else
            {
                er.SetError(txtDLN, null);
                e.Cancel = false;
            }
        }

        private void txtCDLN_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider er = new ErrorProvider();

            if (string.IsNullOrEmpty(txtCDLN.Text))
            {
                er.SetError(txtCDLN, "Can Not Be Empty");
                e.Cancel = true;
            }
            else
            {
                er.SetError(txtCDLN, null);
                e.Cancel = false;
            }

            if (txtCDLN.Text != txtDLN.Text)
            {
                er.SetError(txtCDLN, "No Match.");
                e.Cancel = true;
            }
            else
            {
                er.SetError(txtCDLN, null);
                e.Cancel = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew
               && ctrlShowPersonInfoWithFilter1.PersonInfo.PersonID != -1)
            {
                ctrlShowPersonInfoWithFilter1.PersonInfo.DeletePerson();
                this.Close();
            }
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlShowPersonInfoWithFilter1.PersonInfo.PersonID != -1)
            {
                guna2TabControl1.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("Please Select A Person First.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


    }
}
