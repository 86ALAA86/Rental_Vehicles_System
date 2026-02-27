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
    public partial class ctrlCheck : UserControl
    {
        public ctrlCheck()
        {
            InitializeComponent();
        }


        enum enMode { Add = 0, Edit = 1 }
        private enMode _Mode = enMode.Add;

        private bool _Enabled = false;
        public bool EnableAll
        { 
            set { _Enabled = value; } 
            get { return _Enabled; } 
        }


        public clsEngineCheck EngineCheckInfo
        {
            get { return ctrlEngineCheck1.EngineCheckInfo;  }
        }

        public clsExteriorCheck ExteriorCheckInfo
        {
            get { return ctrlExteriorCheck1.ExteriorCheckInfo; }
        }

        public clsInteriorCheck InteriorCheckInfo
        {
            get { return ctrlInteriorCheck1.InteriorCheckInfo; }
        }



        public void LoadVehicleCheckData(int EngineCheckID = -1,int ExteriorCheckID=-1,int InteriorCheckID=-1)
        {

            ctrlEngineCheck1.Enabled = _Enabled;
            ctrlExteriorCheck1.Enabled = _Enabled;
            ctrlInteriorCheck1.Enabled = _Enabled;
            


            if (EngineCheckID==-1||ExteriorCheckID==-1||InteriorCheckID==-1)
            {
                _Mode = enMode.Add;
                ctrlEngineCheck1.LoadEngineCheckData(-1);
                ctrlExteriorCheck1.LoadExteriorCheckData(-1);
                ctrlInteriorCheck1.LoadInteriorCheckData(-1);
            }
            else
            {
                _Mode = enMode.Edit;
                ctrlEngineCheck1.LoadEngineCheckData(EngineCheckID);
                ctrlExteriorCheck1.LoadExteriorCheckData(ExteriorCheckID);
                ctrlInteriorCheck1.LoadInteriorCheckData(InteriorCheckID);

            }

          

        }

        private void ctrlExteriorCheck1_Load(object sender, EventArgs e)
        {

        }
    }
}
