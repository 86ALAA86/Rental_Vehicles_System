using Guna.UI2.WinForms;
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
    public partial class frmAddEditVehicles : Form
    {
        public frmAddEditVehicles(int VehicleID)
        {
            InitializeComponent();
            
            _VehicleID=VehicleID;
            _Mode = enMode.Add;
            if (VehicleID != -1)
            {
                _Mode = enMode.Edit;
            }
        }

        enum enMode { Add=0,Edit=1}


        private enMode _Mode;

        private int _VehicleID = -1;

        private clsVehicle _Vehicle = null;

        private clsVehicleSpecification _VehicleSpecification = null;

        private clsVehicleCheck _VehicleCheck = null;

        private void btnSpecificationInfo_Click(object sender, EventArgs e)
        {
            frmAddEditVehicleSpecification frm = new frmAddEditVehicleSpecification(_Vehicle.VehicleSpecificationID);
            frm.VehicleSpecificationSaved += SpecificationReciver;
            frm.ShowDialog();
        }

        private void SpecificationReciver(object sender,int SpecificationID)
        {
            _VehicleSpecification = clsVehicleSpecification.Find(SpecificationID);
            lblSpecificationID.Text = SpecificationID.ToString();
        }

        private void btnCheckInfo_Click(object sender, EventArgs e)
        {
            frmAddEditVehicleCheck frm = new frmAddEditVehicleCheck(_Vehicle.CurrentCheckID);
            frm.CheckDataSaved += VehicleCheckReceveir;
            frm.ShowDialog();
        }

        private void VehicleCheckReceveir(object sender,int vehicleCheckID)
        {
            _VehicleCheck = clsVehicleCheck.Find(vehicleCheckID);
            lblCheckInfo.Text = vehicleCheckID.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields Are Empty ", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            _Vehicle.VehicleSpecificationID =int .Parse( lblSpecificationID.Text);
            _Vehicle.CurrentCheckID=int .Parse( lblCheckInfo.Text);

            _Vehicle.CreatedByUserID = 1;
            _Vehicle.Model = txtModel.Text;
            _Vehicle.Mileage = int.Parse(txtMileage.Text);
            _Vehicle.Year = txtYear.Text;
            _Vehicle.PlateNumber = txtPlateNumber.Text;
            _Vehicle.RentalPricePerDay=float.Parse(txtRentalPricePerDay.Text);
            _Vehicle.IsAvailableForRent = chbIsAvailable.Checked;

            if (_Vehicle.Save())
            {
                MessageBox.Show("Vehicle Saved Successfully ","Operation Done",MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                lblVehilceID .Text= _Vehicle.VehicleID.ToString();
                btnSave.Enabled = false;
                this.Close();

            }
            else
            {
                MessageBox.Show("Vehicle was Not Saved Successfully ", "Operation Failed", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            
           
        }

        private void TextBoxes_Validating(object sender, CancelEventArgs e)
        {
            Guna2TextBox Txt = sender as Guna2TextBox;
            ErrorProvider errorProvider = new ErrorProvider();
            if(string.IsNullOrEmpty(Txt.Text ))
            {
                errorProvider.SetError(Txt, "This Value Is Empty");
                e.Cancel=true;
            }
            else
            {
                errorProvider.SetError(Txt, null);
            }
        }

        private void _LoadDefaultValues()
        {
            _Vehicle = new clsVehicle();

            lblVehilceID.Text = "N/A";
            lblUserName.Text = 1.ToString();
            lblSpecificationID.Text = "N/A";
            lblCheckInfo.Text = "N/A";

            chbIsAvailable.Checked=true;

            txtMileage.Text = string.Empty;
            txtPlateNumber.Text = string.Empty;
            txtRentalPricePerDay.Text = string.Empty;
            txtYear.Text = string.Empty;
            txtModel.Text = string.Empty;

            lblFormTitle.Text = "Add New Vehicle Info";


        }

        private void _LoadVehicleValues()
        {
            _Vehicle = clsVehicle.Find(_VehicleID);
            if( _Vehicle == null )
            {
                MessageBox.Show("Vehicle Was Not Found ,Please Try Again.","Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }

            lblVehilceID.Text = _Vehicle.VehicleID.ToString(); ;
            lblUserName.Text = 1.ToString();
            lblSpecificationID.Text = _Vehicle.VehicleSpecificationID.ToString() ;
            lblCheckInfo.Text = _Vehicle.CurrentCheckID.ToString();

            chbIsAvailable.Checked = _Vehicle.IsAvailableForRent;

            txtMileage.Text = _Vehicle.Mileage.ToString() ;
            txtPlateNumber.Text =_Vehicle.PlateNumber;
            txtRentalPricePerDay.Text = _Vehicle.RentalPricePerDay.ToString();
            txtYear.Text = _Vehicle.Year.ToString();
            txtModel.Text = _Vehicle.Model.ToString();

            lblFormTitle.Text = "Edit Vehicle Info";

        }


        private void frmAddEditVehicles_Load(object sender, EventArgs e)
        {
            _LoadDefaultValues();
            if(_Mode==enMode.Edit)
            {
                _LoadVehicleValues();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
