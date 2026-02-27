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

namespace Rental_Vehicles_System.Customers
{
    public partial class ctrlShowCustomerInfoWithFilter : UserControl
    {
        public ctrlShowCustomerInfoWithFilter()
        {
            InitializeComponent();
        }

        private clsCustomer _Customer=new clsCustomer();

        public clsCustomer CustomerInfo {  get { return _Customer; } }



        private void btnSearch_Click(object sender, EventArgs e)
        {

            

            if (cbCustomersFilterBy.SelectedIndex == 0)
            {
                if (!clsCustomer.IsCustomerExistByCustomerID(int.Parse(txtSearchValue.Text.Trim())))
                {
                    MessageBox.Show("Customer Was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlShowCustomerInfo1.LoadDefaultInfo();
                    return;
                }

                ctrlShowCustomerInfo1.LoadCustomerInfo(int.Parse(txtSearchValue.Text.Trim()));
               this._Customer= ctrlShowCustomerInfo1.CustomerInfo;
            }
            else
            {
                if (!clsCustomer.IsCustomerExistByDriverLicenseNumber(txtSearchValue.Text.Trim()))
                {
                    MessageBox.Show("Customer Was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlShowCustomerInfo1.LoadDefaultInfo();
                    return;
                }


                ctrlShowCustomerInfo1.LoadCustomerInfo(txtSearchValue.Text.Trim());
                this._Customer = ctrlShowCustomerInfo1.CustomerInfo;
            }
        }

        private void txtSearchValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbCustomersFilterBy.SelectedIndex == 0)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbCustomersFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchValue.Clear();
            txtSearchValue.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer frm = new frmAddEditCustomer();
            frm.ShowDialog();
        }

        public void LoadDefaultValues()
        {
            ctrlShowCustomerInfo1.LoadDefaultInfo();
        }

        public void LoadCustomerInfo(int CustomerId)
        {
            ctrlShowCustomerInfo1.LoadCustomerInfo(CustomerId);
            _Customer = ctrlShowCustomerInfo1.CustomerInfo;
            
        }
    }
}
