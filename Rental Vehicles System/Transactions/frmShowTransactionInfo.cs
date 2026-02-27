using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_Vehicles_System.Transactions
{
    public partial class frmShowTransactionInfo : Form
    {
        public frmShowTransactionInfo(int Id)
        {
            InitializeComponent();
            _id = Id;
        }
        private int _id;

        private void frmShowTransactionInfo_Load(object sender, EventArgs e)
        {
            ctrlShowTransactionInfo1.LoadTransactionData(_id);
        }
    }
}
