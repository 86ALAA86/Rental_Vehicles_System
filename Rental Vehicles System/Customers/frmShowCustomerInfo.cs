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
    public partial class frmShowCustomerInfo : Form
    {
        public frmShowCustomerInfo(int customerID)
        {
            InitializeComponent();
            _CustomerID = customerID;
        }
        private int _CustomerID;
        private void frmShowCustomerInfo_Load(object sender, EventArgs e)
        {
            ctrlShowCustomerInfo1.LoadCustomerInfo(_CustomerID);
        }
    }
}
