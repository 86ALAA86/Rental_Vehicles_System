using Guna.UI2.WinForms;
using Rental_Vehicles_System.Checks;
using Rental_Vehicles_System.Global;
using Rental_Vehicles_System.Rental_Booking;
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
    public partial class frmAddEditMaintenance : Form
    {

        enum enMode { AddNew, Update }
        enMode _Mode = enMode.AddNew;

        public frmAddEditMaintenance(int ID, bool AddNew = true)
        {
            InitializeComponent();
            if (AddNew)
            {
                _VehicleID=ID;
                _Mode = enMode.AddNew;
            }
            else
            {
                _MaintenanceID=ID;
                _Mode = enMode.Update;
            }

        }
        private int _VehicleID=-1;
        private int _MaintenanceID=-1;
        private clsMaintenance _Maintenance;
        private int _CheckID = -1;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsVehicleCheck Check = clsVehicleCheck.Find(_CheckID);
            if (_Mode == enMode.AddNew && Check != null)
            {
                Check.Delete();
            }

            this.Close();
        }
        private void _HandelVehicleCheckInfo(object sender,int CheckID)
        {
            _CheckID=CheckID;
            lblCheckID.Text= CheckID.ToString();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            frmAddEditVehicleCheck frm;

            if(_Mode==enMode.AddNew)
            {
                frm = new frmAddEditVehicleCheck();
                frm.CheckDataSaved += _HandelVehicleCheckInfo;
            }
            else
            frm= new frmAddEditVehicleCheck(_CheckID);

            
            frm.ShowDialog();
        }

        private void _LoadDefaultData()
        {
            ctrlShowVehicleInfo1._LoadVehicleInfo(_VehicleID) ;
            _Maintenance=new clsMaintenance();
            lblVehicleID.Text=_VehicleID.ToString();
            lblDate.Text= DateTime.Now.ToShortDateString();
            txtCost.Clear();
            txtDescription.Clear();


        }

        private void _LoadMaintenanceData()
        {
            _Maintenance = clsMaintenance.Find(_MaintenanceID);
            if(_Maintenance==null)
            {
                MessageBox.Show("Maintenance record not found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblMaintenanceID.Text = _Maintenance.MaintenanceID.ToString();
            _VehicleID = _Maintenance.VehicleID;
            ctrlShowVehicleInfo1._LoadVehicleInfo(_Maintenance.VehicleID);
            lblVehicleID.Text = _VehicleID.ToString();
            lblDate.Text = _Maintenance.MaintenanceDate.ToShortDateString() ;
            txtCost.Text=_Maintenance.Cost.ToString();
            txtDescription.Text=_Maintenance.Description.ToString();
            _CheckID= _Maintenance.MaintenanceCheckID;
            lblCheckID.Text= _Maintenance.MaintenanceCheckID.ToString();

        }

        private void frmAddEditMaintenance_Load(object sender, EventArgs e)
        {


            if (_Mode == enMode.Update)
            {
                _LoadMaintenanceData();
            }
            else
            {
                _LoadDefaultData();
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider ER = new ErrorProvider();
            Guna2TextBox txt = sender as Guna2TextBox;

            if (string.IsNullOrEmpty(txt.Text))
            {
                ER.SetError(txt, "Can Not Be Empty , Try Again.");
                e.Cancel = true;
                return;
            }
           
            ER.SetError(txt, null);
            e.Cancel = false;

        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please correct the errors and try again.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_CheckID == -1)
            {
                MessageBox.Show("Please perform a vehicle check before saving maintenance.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           

            _Maintenance.MaintenanceDate = DateTime.Now.Date;
            _Maintenance.MaintenanceCheckID = _CheckID;
            _Maintenance.VehicleID = _VehicleID;

            _Maintenance.Cost = float.Parse(txtCost.Text);
            _Maintenance.Description = txtDescription.Text;
            _Maintenance.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            int PreviosCheckID = ctrlShowVehicleInfo1.VehicleInfo.CurrentCheckID;
            ctrlShowVehicleInfo1.VehicleInfo.CurrentCheckID = _CheckID;

            if(_Maintenance.Save()&& ctrlShowVehicleInfo1.VehicleInfo.Save())
            {
                MessageBox.Show("Vehicle Maintenance Saved Successfully","Done",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblMaintenanceID.Text = _Maintenance.MaintenanceID.ToString();

                if (_Mode == enMode.AddNew)
                {
                    clsVehicleCheck Check = clsVehicleCheck.Find(PreviosCheckID);

                    Check.Delete();
                }
                

                this.Close();
            }
            else
            {
                MessageBox.Show("Vehicle Maintenance Was Not Saved ", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)

        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
