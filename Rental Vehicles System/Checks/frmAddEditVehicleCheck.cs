using Rental_Vehicles_System.Checks.Controls;
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

namespace Rental_Vehicles_System.Checks
{
    public partial class frmAddEditVehicleCheck : Form
    {        

        public EventHandler<int> CheckDataSaved;

        public void OnChecksFinished(int vehicleCheckID)
        {
            CheckDataSaved?.Invoke(this, vehicleCheckID);
        }

        public frmAddEditVehicleCheck(int VehicleCheckID)
        {
            InitializeComponent();           
            _VehicleCheckID = VehicleCheckID;
            _Mode = enMode.AddNew;

            if (VehicleCheckID != -1)
            {
               _Mode = enMode.Update;
            }
        }

        public frmAddEditVehicleCheck()
        {
            InitializeComponent();
           
        }


        enum enMode { AddNew = 0, Update = 1 }
        public int _VehicleCheckID;
        private enMode _Mode;
        private clsVehicleCheck _VehicleCheck { get; set; }

        private void btnOtherInfo_Click(object sender, EventArgs e)
        {
             frmCheckInfo frm = new frmCheckInfo(_VehicleCheck.EngineCheckID,_VehicleCheck.ExteriorCheckID,_VehicleCheck.InteriorCheckID);
            frm.CheckInfoBack += CheckDataReciver;
            frm.ShowDialog();
        }

        private void CheckDataReciver(object sender, int EnigneCheckID,int ExteriorCheckID,int InteriorCheckID)
        {
            lblEngineCheckID.Text = EnigneCheckID.ToString();
            lblExteiorCheckID.Text=ExteriorCheckID.ToString();
            lblInteriorCheckID.Text=InteriorCheckID.ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some Empty Fields Are Required.","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            try
            {
                _VehicleCheck.EngineCheckID = int.Parse(lblEngineCheckID.Text);
                _VehicleCheck.ExteriorCheckID = int.Parse(lblExteiorCheckID.Text);
                _VehicleCheck.InteriorCheckID = int.Parse(lblInteriorCheckID.Text);
            }
            catch
            {
                MessageBox.Show("Please Complete Vehicle Check Near The Red Mark ", "Error",                   
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

                ErrorProvider er = new ErrorProvider();
                er.SetError(btnOtherInfo, "Complete Here.");

                return;
            }


            _VehicleCheck.CheckDate = dtpCheckDate.Value;
            _VehicleCheck.FuelLevel=float.Parse(txtFuelLevel.Text);
            _VehicleCheck.CreatedByUserID = 1;
            _VehicleCheck.DamagedFound=chbDamagedFound.Checked;

            _VehicleCheck.GeneralNotes = txtGeneralNotes.Text;
            

            if(!_VehicleCheck.Save())
            {
                MessageBox.Show("Vehicle Check Was Not Saved , an Error occurred.","Error",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                clsEngineCheck.Delete(_VehicleCheck.EngineCheckID);
                clsExteriorCheck.Delete(_VehicleCheck.ExteriorCheckID);
                clsInteriorCheck.Delete(_VehicleCheck.InteriorCheckID);
                return;
            }
           
                MessageBox.Show("Vehicle Check Was  Saved , Operation Done Successfully", "Done", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            

            if(CheckDataSaved!=null)
            OnChecksFinished(_VehicleCheck.VehicleCheckID);

            this.Close();

        }
        private void _LoadVehicleCheckData()
        {
            _VehicleCheck=clsVehicleCheck.Find(_VehicleCheckID);
            if( _VehicleCheck == null )
            {
                MessageBox.Show("We Could Not Find Any Check To This Vehicle .",
                    "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            lblCheckID.Text = _VehicleCheck.VehicleCheckID.ToString();
            dtpCheckDate.Value = _VehicleCheck.CheckDate;
            chbDamagedFound.Checked = _VehicleCheck.DamagedFound;
            lblUserName.Text=_VehicleCheck.CreatedByUserID.ToString();
            txtGeneralNotes.Text = _VehicleCheck.GeneralNotes;
            txtFuelLevel.Text=_VehicleCheck.FuelLevel.ToString();
            lblEngineCheckID.Text=_VehicleCheck.EngineCheckID.ToString();
            lblExteiorCheckID.Text=_VehicleCheck.ExteriorCheckID.ToString() ;
            lblInteriorCheckID.Text = _VehicleCheck.InteriorCheckID.ToString();
        }

        private void _LoadDefaultVehicleCheckData()
        {
            _VehicleCheck = new clsVehicleCheck();


            lblCheckID.Text = "N/A";
            dtpCheckDate.Value = DateTime.Now;
            chbDamagedFound.Checked = false;
            lblUserName.Text = "N/A";
            txtGeneralNotes.Text = string.Empty;
            txtFuelLevel.Text = string.Empty;
            lblEngineCheckID.Text   = "N/A";
            lblExteiorCheckID.Text  = "N/A";
            lblInteriorCheckID.Text = "N/A";
        }


        private void frmAddEditVehicleCheck_Load(object sender, EventArgs e)
        {
            _LoadDefaultVehicleCheckData();
            if(_Mode==enMode.Update)
            {
                _LoadVehicleCheckData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            if (_Mode == enMode.AddNew)
            {
                clsInteriorCheck.Delete(int.Parse(lblInteriorCheckID.Text));
                clsExteriorCheck.Delete(int.Parse(lblExteiorCheckID.Text));
                clsEngineCheck.Delete(int.Parse(lblEngineCheckID.Text));
            }
            this.Close();
           
        }
    }
}
