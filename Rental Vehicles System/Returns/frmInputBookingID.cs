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

namespace Rental_Vehicles_System.Returns
{
    public partial class frmInputBookingID : Form
    {
        public frmInputBookingID()
        {
            InitializeComponent();
        }

        public EventHandler<int> OnInputBookingIDChanged;

        public void InputBookingIDChanged(int BookingID)
        {
            if (OnInputBookingIDChanged != null)
                OnInputBookingIDChanged?.Invoke(this,BookingID);
        }

        private void txtRentalBookingID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void btnSearchForID_Click(object sender, EventArgs e)
        {
            if (clsRentalBooking.IsBookingExists(int.Parse(txtRentalBookingID.Text)))
            {
                if(!clsRentalBooking.IsBookingReturned(int.Parse(txtRentalBookingID.Text)))
                {
                    InputBookingIDChanged(int.Parse(txtRentalBookingID.Text));
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Rental Booking Is Returned and Done. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }
            else
            {
                MessageBox.Show("Rental Booking ID not found. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
