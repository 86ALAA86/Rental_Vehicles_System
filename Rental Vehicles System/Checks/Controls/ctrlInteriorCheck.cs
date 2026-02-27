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
    public partial class ctrlInteriorCheck : UserControl
    {
        public ctrlInteriorCheck()
        {
            InitializeComponent();
        }

        private bool _Enabled = false;
        public bool EnableAll
        {
            set { _Enabled = value; }
            get { return _Enabled; }
        }

        private void _EnableAll()
        {
            chbDashboard.Enabled = true;
            chbOdor.Enabled = true;
            chbSeats.Enabled = true;

            txtInteriorNotes.Enabled = true;
        }

        enum enMode { Add = 0, Edit = 1 }
        private clsInteriorCheck _InteriorCheck=new clsInteriorCheck();
        private enMode _Mode = enMode.Add;

        public clsInteriorCheck InteriorCheckInfo
        {
            get { return _GetInteriorCheck(); }
        }

        public void LoadInteriorCheckData(int InteriorCheckID = -1)
        {
            if (InteriorCheckID == -1)
            {
                _Mode = enMode.Add;
                _InteriorCheck = new clsInteriorCheck();
            }
            else
            {
                _Mode = enMode.Edit;
                _InteriorCheck = clsInteriorCheck.Find(InteriorCheckID);

               chbDashboard.Checked = _InteriorCheck.DashboardOk;
                chbSeats.Checked = _InteriorCheck.SeatsOk;
                chbOdor.Checked = _InteriorCheck.OdorOk;
                txtInteriorNotes.Text = _InteriorCheck.InteriorNotes;
            }

            if(!_Enabled)
            {
                _EnableAll();
            }

        }

        private clsInteriorCheck _GetInteriorCheck()
        {
            _InteriorCheck.InteriorNotes = txtInteriorNotes.Text;
            _InteriorCheck.DashboardOk = chbDashboard.Checked;
            _InteriorCheck.SeatsOk = chbSeats.Checked;
            _InteriorCheck.OdorOk = chbOdor.Checked;
            return _InteriorCheck;
        }


    }
}
