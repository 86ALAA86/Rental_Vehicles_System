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
    public partial class ctrlShowVehicleInfoWithFilter : UserControl
    {
        public ctrlShowVehicleInfoWithFilter()
        {
            InitializeComponent();
        }

        private clsVehicle _Vehicle=new clsVehicle();
        public clsVehicle VehicleInfo { get { return _Vehicle; } }

        private void txtSearchValue_KeyPress(object sender, KeyPressEventArgs e)
        {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        /*  
        public event Action<clsVehicle> TheSelection;

        protected virtual void Selection (clsVehicle v)
        {
            Action<clsVehicle> handler = TheSelection;
            if (handler != null)
            {
                handler(v);
            }
        }

        */
        

        // i forgot to type "event" so i did += manualy .
        public  EventHandler<clsVehicle> OnVehicleSelected;

        protected virtual void VehicleSelected(clsVehicle Vehicle)
        {
            OnVehicleSelected?.Invoke(this,Vehicle);
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(!clsVehicle.IsVehicleExist(int.Parse(txtSearchValue.Text)))
            {
                MessageBox.Show("Vehicle With ID : "+txtSearchValue.Text +" Was Not Found ," +
                    "Please Try Again.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlShowVehicleInfo1.LoadDefaultValues();
                return;
            }
            ctrlShowVehicleInfo1._LoadVehicleInfo(int.Parse(txtSearchValue.Text));
            this._Vehicle = ctrlShowVehicleInfo1.VehicleInfo;

            if (OnVehicleSelected != null)
            {
                VehicleSelected( VehicleInfo);
            }
        }


        public void LoadDefaultValues()
        {
            ctrlShowVehicleInfo1.LoadDefaultValues();
        }

        public void LoadVehicleValues(int VehicleID)
        {
            ctrlShowVehicleInfo1._LoadVehicleInfo(VehicleID);
            _Vehicle = ctrlShowVehicleInfo1.VehicleInfo; 
        }
    }
}
