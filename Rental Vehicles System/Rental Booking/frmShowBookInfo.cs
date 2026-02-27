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
    public partial class frmShowBookInfo : Form
    {
        public frmShowBookInfo(int bookingID)
        {
            InitializeComponent();
            _BookingID = bookingID; 
        }
        private int _BookingID;

        private void frmShowBookInfo_Load(object sender, EventArgs e)
        {
            ctrlShowBookingInfo1.LoadBookInfo(_BookingID);
        }
    }
}
