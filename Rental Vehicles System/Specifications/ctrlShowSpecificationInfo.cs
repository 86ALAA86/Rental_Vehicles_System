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

namespace Rental_Vehicles_System.Specifications
{
    public partial class ctrlShowSpecificationInfo : UserControl
    {
        public ctrlShowSpecificationInfo()
        {
            InitializeComponent();
        }

        private int _SpecificationID;
        private clsVehicleSpecification _Specification;

        public void LoadSpecificationData(int ID)
        {
            _SpecificationID = ID;
            _Specification=clsVehicleSpecification.Find(_SpecificationID);
            if(_Specification == null)
            {
                return;
            }

            lblTitle.Text = "Vehicle Specifications";

            lblSpecificationID.Text = _SpecificationID.ToString();
            lblMake.Text = clsMake.GetByID(_Specification.MakeID).MakeName;
            lblFuelType.Text = clsFuelType.GetByID(_Specification.FuelTypeID).FuelName;
            lblDriveType.Text = clsDriveType.GetByID(_Specification.DriveTypeID).DriveName;

            lblCylinderType.Text = clsCylinderType.GetByID(_Specification.CylinderTypeID).CylinderName;
            lblAspiration.Text = clsAspiration.GetByID(_Specification.AspirationID).AspirationName;
            lblEngine.Text = clsEngine.GetByID(_Specification.EngineID).EngineName;
            lblEngineBlock.Text = clsEngineBlockType.GetByID(_Specification.EngineBlockTypeID).BlockName;

            pbVehicleColor.FillColor = ColorTranslator.FromHtml(_Specification.HexColor);
            lblBody.Text = clsBodies.GetByID(_Specification.BodyID).BodyName;

        }


    }
}
