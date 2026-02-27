using Rental_Vehicles_System.Checks;
using Rental_Vehicles_System.Specifications;
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

namespace Rental_Vehicles_System.Vehicles
{
    public partial class ctrlShowVehicleInfo : UserControl
    {
        public ctrlShowVehicleInfo()
        {
            InitializeComponent();
        }

        private int _VehicleID;
        private clsVehicle _Vehicle=new clsVehicle();
        public clsVehicle VehicleInfo { get { return _Vehicle; } }

        private int _VehicleCheckID;
        private int _VehicleSpecificationID;

        public void LoadDefaultValues()
        {
           
            lblVehilceID.Text = "????";
            lblMileage.Text = "????";
            lblModel.Text = "????";
            lblPlate.Text = "????";
            lblTitle.Text = "Vehicle Info";
            lblUserName.Text = "????";
            lblYear.Text = "????";
            chbIsAvailable.Checked = false;
            lblRentalPrice.Text = "????";
            _Vehicle = new clsVehicle();
            btnCheckInfo.Enabled = false;
            btnSpesificationsInfo.Enabled = false;


        }
        private void btnCheckInfo_Click(object sender, EventArgs e)
        {
            if (!clsVehicleCheck.IsVehicleCheckExist(_VehicleCheckID))
            {
                MessageBox.Show("Vehicle Check Was Not Found, An Error Occurred.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmShowCheckInfo frm = new frmShowCheckInfo(_VehicleCheckID);
            frm.ShowDialog();
        }
        public void _LoadVehicleInfo(int VehicleId)
        {
            _VehicleID = VehicleId;
            _Vehicle = clsVehicle.Find(_VehicleID); 
            if(_Vehicle == null)
            {
                MessageBox.Show("Vehicle Was Not Found, An Error Occurred.","Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            _VehicleSpecificationID = _Vehicle.VehicleSpecificationID;
            _VehicleCheckID=_Vehicle.CurrentCheckID;

            lblVehilceID.Text = _VehicleID.ToString();
            lblMileage.Text =_Vehicle.Mileage.ToString();
            lblModel.Text = _Vehicle.Model.ToString();
            lblPlate.Text=_Vehicle.PlateNumber.ToString();
            lblTitle.Text = "Vehicle Info";
            lblUserName.Text=_Vehicle.CreatedByUserID.ToString();
            lblYear.Text = _Vehicle.Year.ToString();
            chbIsAvailable.Checked = _Vehicle.IsAvailableForRent;
            lblRentalPrice.Text=_Vehicle.RentalPricePerDay.ToString();

            btnCheckInfo.Enabled = true;
            btnSpesificationsInfo.Enabled = true;

        }

        private void btnSpesificationsInfo_Click(object sender, EventArgs e)
        {
            if (!clsVehicleSpecification.IsVehicleSpecificationsExist(_VehicleSpecificationID))
            {
                MessageBox.Show("Vehicle Specification Was Not Found, An Error Occurred.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmShowSpecificationInfo frm = new frmShowSpecificationInfo(_VehicleSpecificationID);
            frm.ShowDialog();
        }
    }
}
