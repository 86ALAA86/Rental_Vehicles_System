using Guna.UI2.WinForms;
using RVS_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Rental_Vehicles_System.Specifications
{
    public partial class frmAddEditVehicleSpecification : Form
    {

        public EventHandler<int> VehicleSpecificationSaved;
         

        private void OnSpecificationSaved()
        {
            if (VehicleSpecificationSaved != null)
                VehicleSpecificationSaved?.Invoke(this, _VehicleSpecification.VehicleSpecificationID);
        }

        enum enMode { Add=0, Edit =1}

        public frmAddEditVehicleSpecification(int SpecificationID)
        {
            InitializeComponent();
            if (SpecificationID != -1)
            {
                _SpeciesID = SpecificationID;
                _Mode = enMode.Edit;
            }
        }

        public frmAddEditVehicleSpecification()
        {
            InitializeComponent();
            _SpeciesID = -1;
            _Mode = enMode.Add;
        
        }



        private clsVehicleSpecification _VehicleSpecification = null;
        private enMode _Mode=enMode.Add;
        private int _SpeciesID=-1;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Please select an item.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _VehicleSpecification =new clsVehicleSpecification();

            _VehicleSpecification.AspirationID=clsAspiration.GetByName(cbAspiration.Text).AspirationID;
            _VehicleSpecification.BodyID = clsBodies.GetByName(cbBodis.Text).BodyID;
            _VehicleSpecification.CylinderTypeID = clsCylinderType.GetByName(cbCylinderType.Text).CylinerTypeID;
            _VehicleSpecification.DriveTypeID = clsDriveType.GetByName(cbDriveType.Text).DriveTypeID;

            _VehicleSpecification.EngineID = clsEngine.GetByName(cbEngine.Text).EngineID;
            _VehicleSpecification.EngineBlockTypeID = clsEngineBlockType.GetByName(cbEngineBlock.Text).EngineBlockTypeID;
            _VehicleSpecification.FuelTypeID = clsFuelType.GetByName(cbFuelType.Text).FuelID;
            _VehicleSpecification.MakeID = clsMake.GetByName(cbMakes.Text).MakeID;
            Color color = PbVehicleColor.BackColor;
            string hex = $"#{color.R:X2}{color.G:X2}{color.B:X2}";
            _VehicleSpecification.HexColor = hex;

            if (!_VehicleSpecification.Save())
            {
                MessageBox.Show("Vehicle Specifications was not Saved .","Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Vehicle Specifications was Saved","Operation Done Successfully",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSave.Enabled=false; 

            OnSpecificationSaved();
            this.Close();
        }

        private void _LoadMakes()
        {
            DataTable dt = clsMake.GetAllMakes();
            foreach(DataRow dr in dt.Rows)
            {
                cbMakes.Items.Add(dr["MakeName"].ToString());
            }
        }

        private void _LoadFuelTypes()
        {
            DataTable dt = clsFuelType.GetAllFuelTypes();
            foreach (DataRow dr in dt.Rows)
            {
                cbFuelType.Items.Add(dr["FuelName"].ToString());
            }
        }

        private void _LoadAspirations()
        {
            DataTable dt = clsAspiration.GetAllAspirations();
            foreach (DataRow dr in dt.Rows)
            {
                cbAspiration.Items.Add(dr["AspirationName"].ToString());
            }
        }

        private void _LoadDriveTypes()
        {
            DataTable dt = clsDriveType.GetAllDriveTypes();
            foreach (DataRow dr in dt.Rows)
            {
                cbDriveType.Items.Add(dr["DriveType_Name"].ToString());
            }

        }

        private void _LoadBodyStyles()
        {
            DataTable dt = clsBodies.GetAllBodies();
            foreach (DataRow dr in dt.Rows)
            {
                cbBodis.Items.Add(dr["BodyName"].ToString());
            }
        }

        private void _LoadEngineBlocks()
        {
            DataTable dt = clsEngineBlockType.GetAllEngineBlockTypes();
            foreach(DataRow dr in dt.Rows)
            {
                cbEngineBlock.Items.Add(dr["BlockType"].ToString());
            }
        }

        private void _LoadCylinderTypes()
        {
            DataTable dt = clsCylinderType.GetAllCylinderTypes();
            foreach (DataRow dr in dt.Rows)
            {
                cbCylinderType.Items.Add(dr["CylinderName"].ToString());
            }

        }

        private void _LoadEngines()
        {
            DataTable dt = clsEngine.GetAllEngines();
            foreach (DataRow dr in dt.Rows)
            {
                cbEngine.Items.Add(dr["EngineName"].ToString());
            }
        }

        private void _LoadDataInComboBoxes()
        {
            _LoadAspirations();
            _LoadBodyStyles();
            _LoadEngineBlocks();
            _LoadCylinderTypes();

            _LoadEngines();
            _LoadDriveTypes();
            _LoadMakes();
            _LoadFuelTypes();

        }

        private void _LoadDefaultData()
        {
            lblVehilceID.Text = "N/A";
            cbAspiration.SelectedIndex = -1;
            cbBodis.SelectedIndex = -1;
            cbCylinderType.SelectedIndex = -1;
            cbDriveType.SelectedIndex = -1;
            cbEngine.SelectedIndex = -1;
            cbEngineBlock.SelectedIndex = -1;
            cbFuelType.SelectedIndex = -1;
            cbMakes.SelectedIndex = -1;

            PbVehicleColor.BackColor = Color.White;
            lblFormTitle.Text = "Add New Vehicle Specification";

            _VehicleSpecification = new clsVehicleSpecification();
        }

        private void _LoadSpecificationData()
        {
            if (_SpeciesID == -1)
                return;

            _VehicleSpecification = clsVehicleSpecification.Find(_SpeciesID);
            if (_VehicleSpecification == null)
                return;

            lblVehilceID.Text = _VehicleSpecification.VehicleSpecificationID.ToString();
            cbAspiration.SelectedIndex = cbAspiration.FindString(_VehicleSpecification.AspirationInfo.AspirationName);
            cbBodis.SelectedIndex = cbBodis.FindString(_VehicleSpecification.BodyInfo.BodyName);
            cbCylinderType.SelectedIndex = cbCylinderType.FindString(_VehicleSpecification.CylinderInfo.CylinderName);
            cbDriveType.SelectedIndex = cbDriveType.FindString(_VehicleSpecification.DriveTypeInfo.DriveName);
            cbEngine.SelectedIndex = cbEngine.FindString(_VehicleSpecification.EngineInfo.EngineName);
            cbEngineBlock.SelectedIndex = cbEngineBlock.FindString(_VehicleSpecification.EngineBlockInfo.BlockName);
            cbFuelType.SelectedIndex = cbFuelType.FindString(_VehicleSpecification.FuelInfo.FuelName);
            cbMakes.SelectedIndex = cbMakes.FindString(_VehicleSpecification.MakeInfo.MakeName);

            PbVehicleColor.BackColor = ColorTranslator.FromHtml(_VehicleSpecification.HexColor);
            lblFormTitle.Text= "Edit Vehicle Specification";

        }
    
        private void frmAddEditVehicleSpecification_Load(object sender, EventArgs e)
        {
            _LoadDataInComboBoxes();
            _LoadDefaultData();

            if (_Mode == enMode.Edit)
              _LoadSpecificationData();


        }

        private void PbVehicleColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
               PbVehicleColor.BackColor = colorDialog.Color;
            }
            Color color =PbVehicleColor.BackColor;
            string hex = $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }        

        private void ComboBox_Validating(object sender, CancelEventArgs e)
        {
            Guna2ComboBox CB = (Guna2ComboBox) sender;
            ErrorProvider errorProvider = new ErrorProvider();
            if (CB.SelectedIndex == -1)
            {
                errorProvider.SetError(CB, "You must select an option.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(CB, "");
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
