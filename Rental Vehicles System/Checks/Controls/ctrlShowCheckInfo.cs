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

namespace Rental_Vehicles_System.Checks.Controls
{
    public partial class ctrlShowCheckInfo : UserControl
    {
        public ctrlShowCheckInfo()
        {
            InitializeComponent();
        }

        public void LoadCheckInfo(int CheckID)
        {
            clsVehicleCheck VehicleCheck = clsVehicleCheck.Find(CheckID);
            if (VehicleCheck == null)
            {
                return;
            }
            lblTitle.Text = "Vehicle Check";
            lblCheckID.Text = CheckID.ToString();
            lblDamagedFound.Text = (VehicleCheck.DamagedFound) ? "Yes" : "No";
            lblCheckDate.Text=VehicleCheck.CheckDate.ToShortDateString();
            lblFuelLevel.Text=VehicleCheck.FuelLevel.ToString();
            txtGeneralNotes.Text = VehicleCheck.GeneralNotes;
            txtGeneralNotes.Enabled = false;

            ctrlCheck1.Enabled=false;

            ctrlCheck1.LoadVehicleCheckData
                (VehicleCheck.EngineCheckID, VehicleCheck.ExteriorCheckID, VehicleCheck.InteriorCheckID);

        }

    }
}
