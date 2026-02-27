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
    public partial class frmSearchForCustomers : Form
    {
        public frmSearchForCustomers()
        {
            InitializeComponent();
        }

        public EventHandler<clsCustomer> CustomerFound;

        protected virtual void OnCustomerFound(clsCustomer CustomerInfo)
        {
            CustomerFound?.Invoke(this, CustomerInfo);
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {



            if (cbCustomersFilterBy.SelectedIndex == 0)
            {
                if (!clsCustomer.IsCustomerExistByCustomerID(int.Parse(txtSearchValue.Text.Trim())))
                {
                    MessageBox.Show("Customer Was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    OnCustomerFound(null);
                    return;
                }

                OnCustomerFound(clsCustomer.FindByCustomerID(int.Parse(txtSearchValue.Text.Trim())));
            }
            else
            {
                if (!clsCustomer.IsCustomerExistByDriverLicenseNumber(txtSearchValue.Text.Trim()))
                {
                    MessageBox.Show("Customer Was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    OnCustomerFound(null);
                    return;
                }

                OnCustomerFound(clsCustomer.FindByLicenseNumber(txtSearchValue.Text.Trim()));
            }
        }

        private void txtSearchValue_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cbCustomersFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchValue.Clear();
            txtSearchValue.Focus();
        }

    }
}
