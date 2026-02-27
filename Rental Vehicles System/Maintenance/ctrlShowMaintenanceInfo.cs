using Rental_Vehicles_System.Checks;
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

namespace Rental_Vehicles_System.Maintenance
{
    public partial class ctrlShowMaintenanceInfo : UserControl
    {
        public ctrlShowMaintenanceInfo()
        {
            InitializeComponent();
        }

        private int _VehicleID;
        private int _CheckID;
        public clsMaintenance MaintenanceInfo { get; set; }

        public void LoadDefaultValues()
        {
            lblCheckID.Text = "?";
            lblCost.Text = "?";
            lblVehicleID.Text = "?";
            lblMaintenanceID.Text = "?";
            lblDate.Text = "????";

            btnCheck.Enabled = false;
            btnVehicle.Enabled = false;
            txtDescription.Clear();

            _VehicleID = -1;
            _CheckID = -1;
            MaintenanceInfo = new clsMaintenance();

        }

        public void LoadMaintenanceData(int MentenanceID)
        {
            MaintenanceInfo=clsMaintenance.Find(MentenanceID);
            if(MaintenanceInfo == null)
            {
                return;
            }

            lblCheckID.Text =MaintenanceInfo.MaintenanceCheckID.ToString();
            lblCost.Text = MaintenanceInfo.Cost.ToString();
            lblVehicleID.Text =  MaintenanceInfo.VehicleID.ToString();
            lblMaintenanceID.Text =  MaintenanceInfo.MaintenanceID.ToString();
            lblDate.Text =  MaintenanceInfo.MaintenanceDate.ToShortDateString();

            btnCheck.Enabled = true ;
            btnVehicle.Enabled = true;
            txtDescription.Text = MaintenanceInfo.Description;

            _VehicleID = MaintenanceInfo.VehicleID;
            _CheckID = MaintenanceInfo.MaintenanceCheckID;

        }


        private void btnCheck_Click(object sender, EventArgs e)
        {
            frmShowCheckInfo frm = new frmShowCheckInfo(_CheckID);
            frm.ShowDialog();
        }

        private void btnVehicle_Click(object sender, EventArgs e)
        {
            frmShowVehicleInfo frm = new frmShowVehicleInfo(_VehicleID);
            frm.ShowDialog();
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
           // e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

          //  if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Ins || e.KeyChar == (char)Keys.Delete)         
                e.Handled = true; // Cancels the key from being processed
            
        }
    }
}
