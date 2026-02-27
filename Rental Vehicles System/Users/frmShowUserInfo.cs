using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_Vehicles_System.Users
{
    public partial class frmShowUserInfo : Form
    {
        public frmShowUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }
        private int _UserID;
        private void frmShowUserInfo_Load(object sender, EventArgs e)
        {
            ctrlShowUserInfo1.LoadUserInfo(_UserID);
        }
    }
}
