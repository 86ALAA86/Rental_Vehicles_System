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
    public partial class ctrlEngineCheck : UserControl
    {

        public ctrlEngineCheck()
        {
            InitializeComponent();
        }

        enum enMode { Add = 0, Edit = 1 }
        private clsEngineCheck _EngineCheck=new clsEngineCheck();
        private enMode _Mode=enMode.Add;

        public clsEngineCheck EngineCheckInfo
        {
            get { return _GetEngineCheck(); }          
        }

        private bool _Enabled = false;
        public bool EnableAll
        {
            set { _Enabled = value; }
            get { return _Enabled; }
        }

        private void _EnableAll()
        {
            chbEngineNoise.Enabled=true;
            chbEngineStarts.Enabled=true;
            chbOilLevel.Enabled=true;
            chbWarning.Enabled=true;
            txtEngineNotes.Enabled=true;
        }

        public void LoadEngineCheckData(int EngineCheckID=-1)
        {
            if(EngineCheckID ==-1)
            {
                _Mode = enMode.Add;
                _EngineCheck = new clsEngineCheck();
            }
            else
            {
               _Mode=enMode.Edit;
                _EngineCheck = clsEngineCheck.Find(EngineCheckID);

                chbEngineNoise.Checked = _EngineCheck.EngineNoiseOk;
                chbOilLevel.Checked = _EngineCheck.OilLevelOk;
                chbEngineStarts.Checked = _EngineCheck.EngineStartsOk;
                chbWarning.Checked = _EngineCheck.WarningLightsOk;
                txtEngineNotes.Text = _EngineCheck.EngineNotes;
            }

            if(!_Enabled)
            {
                _EnableAll();
            }

        }

        private clsEngineCheck _GetEngineCheck()
        {

            _EngineCheck.EngineNoiseOk = chbEngineNoise.Checked;
            _EngineCheck.OilLevelOk = chbOilLevel.Checked;
            _EngineCheck.EngineStartsOk = chbEngineStarts.Checked;
            _EngineCheck.WarningLightsOk = chbWarning.Checked;
            _EngineCheck.EngineNotes = txtEngineNotes.Text.Trim();
            return _EngineCheck;
        }
      
    }
}
