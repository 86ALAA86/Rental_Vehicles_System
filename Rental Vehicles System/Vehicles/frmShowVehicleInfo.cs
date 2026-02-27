using Rental_Vehicles_System.Specifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_Vehicles_System.Vehicles
{
    public partial class frmShowVehicleInfo : Form
    {
        public frmShowVehicleInfo(int VehicleID)
        {
            InitializeComponent();
            _VehicleID = VehicleID;
        }

        private int _VehicleID;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowVehicleInfo_Load(object sender, EventArgs e)
        {
            ctrlShowVehicleInfo1._LoadVehicleInfo(_VehicleID);
        }

        
    }
}
