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
    public partial class frmCheckInfo : Form
    {
        public frmCheckInfo(int EngineCheckID,int ExteriorCheckID,int InteriorCheckID)
        {
            InitializeComponent();
            _Mode = enMode.Add;
            _EngineCheckID= EngineCheckID;
            _ExteriorCheckID= ExteriorCheckID;
            _InteriorCheckID= InteriorCheckID;
            if (EngineCheckID != -1)
                _Mode = enMode.Update;
        }
        enum enMode { Add=0, Update=1 }


        private int _EngineCheckID;
        private int _ExteriorCheckID;
        private int _InteriorCheckID;
        private enMode _Mode;

        public delegate void VehcileCheckBackData(object sender, int EngineCheckID,int ExteriorCheckID,int InteriorCheckID);
        public event VehcileCheckBackData CheckInfoBack;


        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!ctrlCheck1.EngineCheckInfo.Save())
            {
                MessageBox.Show("Vehicle Check Info was Not Save Due UnKnown Error.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            int EngineCheckID = ctrlCheck1.EngineCheckInfo.EngineCheckID;

            if (!ctrlCheck1.ExteriorCheckInfo.SaveExteriorCheck())
            {
                MessageBox.Show("Vehicle Check Info was Not Save Due UnKnown Error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlCheck1.EngineCheckInfo.Delete();
                return;
            }

            int ExteriorCheckID= ctrlCheck1.ExteriorCheckInfo.ExteriorCheckID;

            if (!ctrlCheck1.InteriorCheckInfo.Save())
            {
                MessageBox.Show("Vehicle Check Info was Not Save Due UnKnown Error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlCheck1.EngineCheckInfo.Delete();
                ctrlCheck1.ExteriorCheckInfo.Delete();
                return;
            }

            int InteriorCheckID = ctrlCheck1.InteriorCheckInfo.InteriorCheckID;

            if (CheckInfoBack != null)
                CheckInfoBack?.Invoke(this,EngineCheckID,ExteriorCheckID,InteriorCheckID);
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCheckInfo_Load(object sender, EventArgs e)
        {
            ctrlCheck1.EnableAll = true;
            if(_Mode==enMode.Add) 
            ctrlCheck1.LoadVehicleCheckData();
            else
             ctrlCheck1.LoadVehicleCheckData(_EngineCheckID,_ExteriorCheckID,_InteriorCheckID);
        }
    }
}
