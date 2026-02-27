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
    public partial class ctrlExteriorCheck : UserControl
    {
        public ctrlExteriorCheck()
        {
            InitializeComponent();
        }


        enum enMode { Add = 0, Edit = 1 }
        private clsExteriorCheck _ExteriorCheck=new clsExteriorCheck();
        private enMode _Mode = enMode.Add;

        private bool _Enabled = false;
        public bool EnableAll
        {
            set { _Enabled = value; }
            get { return _Enabled; }
        }

        private void _EnableAll()
        {
            chbLights.Enabled = true;
            chbMirrors.Enabled = true;
            chbPaint.Enabled = true;
            chbTires.Enabled = true;
            chbWindows.Enabled = true;

            txtExteriorNotes.Enabled = true;
        }


        public clsExteriorCheck ExteriorCheckInfo
        {
            get { return _GetExteriorCheck(); }
        }

        public void LoadExteriorCheckData(int ExteriorCheckID = -1)
        {
            if (ExteriorCheckID == -1)
            {
                _Mode = enMode.Add;
                _ExteriorCheck = new clsExteriorCheck();
            }
            else
            {
                _Mode = enMode.Edit;
                _ExteriorCheck = clsExteriorCheck.Find(ExteriorCheckID);

                chbLights.Checked = _ExteriorCheck.LightsOk;
                chbMirrors.Checked = _ExteriorCheck.MirrorsOk;
                chbTires.Checked = _ExteriorCheck.TiresOk;
                chbWindows.Checked = _ExteriorCheck.WindowsOk;
                chbPaint.Checked = _ExteriorCheck.PaintOk;
                txtExteriorNotes.Text = _ExteriorCheck.ExteriorNotes;

            }

            if (!_Enabled)
            {
                _EnableAll();
            }

        }

        private clsExteriorCheck _GetExteriorCheck()
        {
           _ExteriorCheck.MirrorsOk = chbMirrors.Checked;
            _ExteriorCheck.LightsOk = chbLights.Checked;
            _ExteriorCheck.TiresOk = chbTires.Checked;
            _ExteriorCheck.WindowsOk = chbWindows.Checked;
            _ExteriorCheck.PaintOk = chbPaint.Checked;
            _ExteriorCheck.ExteriorNotes = txtExteriorNotes.Text.Trim();
            return _ExteriorCheck;
        }



    }
}
