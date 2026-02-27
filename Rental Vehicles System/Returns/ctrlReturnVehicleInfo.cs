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

namespace Rental_Vehicles_System.Returns
{
    public partial class ctrlReturnVehicleInfo : UserControl
    {
        public ctrlReturnVehicleInfo()
        {
            InitializeComponent();
        }

        private clsVehicleReturns _Return;
        public clsVehicleReturns ReturnInfo { get { return _Return; } }

        public void LoadDefaultValues()
        {
            _Return = new clsVehicleReturns();

            lblReturnID.Text = "?";
            lblRentDays.Text = "?";
            lblReturnDate.Text = "?";

            lblConsumedMileage.Text = "?";
            lblMileage.Text = "?";
            lblAdditionalCharges.Text = "?";
            lblActualAmount.Text = "?";

            txtNotes.Clear();
        }

        public void LoadReturnValues(int ID)
        {
            _Return = clsVehicleReturns.Find(ID);
            if (_Return == null)
            {
                MessageBox.Show("Return Info Was Not Found", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblReturnID.Text = _Return.ReturnID.ToString();
            lblRentDays.Text = _Return.ActualRentalDays.ToString();
            lblReturnDate.Text = _Return.ActualReturnDate.ToShortDateString();

            lblConsumedMileage.Text = _Return.ConsumedMileage.ToString();
            lblMileage.Text =_Return.Mileage.ToString() ;
            lblAdditionalCharges.Text =_Return.AdditionalCharges.ToString() ;
            lblActualAmount.Text =_Return.ActualTotalDueAmount.ToString() ;

            txtNotes.Text=_Return.ReturnNotes.ToString();
        }


    }
}
