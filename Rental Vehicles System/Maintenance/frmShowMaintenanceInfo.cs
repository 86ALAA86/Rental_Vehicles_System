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
    public partial class frmShowMaintenanceInfo : Form
    {
        public frmShowMaintenanceInfo(int ID)
        {
            InitializeComponent();
            _Id=ID;
        }

        private int _Id;
        private void frmShowMaintenanceInfo_Load(object sender, EventArgs e)
        {
            ctrlShowMaintenanceInfo1.LoadMaintenanceData(_Id);
        }
    }
}
