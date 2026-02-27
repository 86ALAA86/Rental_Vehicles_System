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
    public partial class frmShowCheckInfo : Form
    {
        public frmShowCheckInfo(int CheckID)
        {
            InitializeComponent();
            _CheckID = CheckID;
        }
        private int _CheckID;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowCheckInfo_Load(object sender, EventArgs e)
        {
           
            ctrlShowCheckInfo1.LoadCheckInfo(_CheckID);

            
        }
    }
}
