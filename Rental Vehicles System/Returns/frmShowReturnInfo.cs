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
    public partial class frmShowReturnInfo : Form
    {
        public frmShowReturnInfo(int ID)
        {
            InitializeComponent();
            ReturnID = ID;
        }
        private int ReturnID;
        private void frmShowReturnInfo_Load(object sender, EventArgs e)
        {
            ctrlReturnVehicleInfo1.LoadReturnValues(ReturnID);
            ctrlShowBookingInfo1.LoadBookInfo(ctrlReturnVehicleInfo1.ReturnInfo.BookingID);
        }
    }
}
