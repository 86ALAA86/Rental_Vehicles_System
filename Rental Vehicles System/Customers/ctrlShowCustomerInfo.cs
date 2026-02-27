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
    public partial class ctrlShowCustomerInfo : UserControl
    {
        public ctrlShowCustomerInfo()
        {
            InitializeComponent();
        }

        public clsCustomer CustomerInfo { get { return _Customer; } }

        private clsCustomer _Customer = new clsCustomer();
        public void LoadCustomerInfo(int CustomerID)
        {
            _Customer=clsCustomer.FindByCustomerID(CustomerID);
            if(CustomerInfo==null)
            {
                MessageBox.Show("CustomerInfo Was Not Found, Try Again Later.","Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            ctrlShowPersonInfo1.LoadPersonInfo(CustomerInfo.PersonID);
            lblCustomerID.Text=CustomerID.ToString();
            lblLicnseNumber.Text = CustomerInfo.DriverLicenseNumber.ToString();
        }

        public void LoadDefaultInfo()
        {
          
            ctrlShowPersonInfo1.LoadDefaultInfo();
            lblCustomerID.Text = "??";
            lblLicnseNumber.Text = "???";
        }

        public void LoadCustomerInfo(string LicenseNumber)
        {
            _Customer = clsCustomer.FindByLicenseNumber(LicenseNumber);
            if (CustomerInfo == null)
            {
                MessageBox.Show("CustomerInfo Was Not Found, Try Again Later.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            ctrlShowPersonInfo1.LoadPersonInfo(CustomerInfo.PersonID);
            lblCustomerID.Text = CustomerInfo.CustomerID.ToString();
            lblLicnseNumber.Text = CustomerInfo.DriverLicenseNumber.ToString();
        }


    }
}
