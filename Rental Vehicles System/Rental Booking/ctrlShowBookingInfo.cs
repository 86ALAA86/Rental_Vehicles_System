using Rental_Vehicles_System.Checks;
using Rental_Vehicles_System.Customers;
using Rental_Vehicles_System.Vehicles;
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

namespace Rental_Vehicles_System.Rental_Booking
{
    public partial class ctrlShowBookingInfo : UserControl
    {
        public ctrlShowBookingInfo()
        {
            InitializeComponent();
        }
        public clsRentalBooking RentalBookInfo { get;set; }

        private int _VehicleID;
        private int _CustomerID;
        private int _InitialCheckID;
        public void LoadBookInfo(int BookID)
       {
            RentalBookInfo=clsRentalBooking.Find(BookID);
            if (RentalBookInfo == null)
            {
                MessageBox.Show("No Book With ID : "+BookID.ToString()+ " Found!","Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            _CustomerID = RentalBookInfo.CustomerID;
            _InitialCheckID = RentalBookInfo.InitialCheckID;
            _VehicleID = RentalBookInfo.VehicleID;

            lblBookID.Text = RentalBookInfo.BookingID.ToString();
            lblAmount.Text=RentalBookInfo.InitialTotalDueAmount.ToString();

            lblCustomer.Text = RentalBookInfo.CustomerInfo.PersonInfo.FullName;
            lblDropoffLocation.Text = RentalBookInfo.DropoffLocation;

            lblPickupLocation.Text = RentalBookInfo.PickupLocation;
            lblStartDate.Text = RentalBookInfo.RentalStartDate.ToShortDateString();

            lblEndDate.Text = RentalBookInfo.RentalEndDate.ToShortDateString();
            lblRentDays.Text = RentalBookInfo.InitialRentalDays.ToString();

            lblVehicle.Text = RentalBookInfo.VehicleInfo.PlateNumber.ToString();
            lblUser.Text = RentalBookInfo.UserInfo.UserName;

            lblPricePerDay.Text=RentalBookInfo.RentalPricePerDay.ToString();

            btnCheckInfo.Enabled = true;
            btnCustomerInfo.Enabled = true;
            btnVehicleInfo.Enabled = true;

        }

        public void LoadDefaultInfo()
        {




            lblBookID.Text = "???";
            lblAmount.Text = "???";

            lblCustomer.Text = "???";
            lblDropoffLocation.Text = "???";

            lblPickupLocation.Text = "???";
            lblStartDate.Text = "???";

            lblEndDate.Text = "???";
            lblRentDays.Text = "???";

            lblVehicle.Text = "???";
            lblUser.Text = "???";

            lblPricePerDay.Text = "???";

            btnCheckInfo.Enabled = false;
            btnCustomerInfo.Enabled = false;
            btnVehicleInfo.Enabled = false;

        }
        private void btnVehicleInfo_Click(object sender, EventArgs e)
        {
            frmShowVehicleInfo frm = new frmShowVehicleInfo(_VehicleID);
            frm.ShowDialog();
        }

        private void btnCustomerInfo_Click(object sender, EventArgs e)
        {
            frmShowCustomerInfo frm = new frmShowCustomerInfo(_CustomerID);
            frm.ShowDialog();
        }

        private void btnCheckInfo_Click(object sender, EventArgs e)
        {
            frmShowCheckInfo frm = new frmShowCheckInfo(_InitialCheckID);
            frm.ShowDialog();
        }
    }
}
