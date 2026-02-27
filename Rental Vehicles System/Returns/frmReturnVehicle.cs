using Rental_Vehicles_System.Checks;
using Rental_Vehicles_System.Global;
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
    public partial class frmReturnVehicle : Form
    {

        enum enMode { AddNew,Edit}
        enMode _Mode = enMode.AddNew;
        public frmReturnVehicle(int ID,bool AddNew=true)
        {
            InitializeComponent();
            if(AddNew)
            {
                _BookingID=ID;
                _Mode = enMode.AddNew;
            }
            else
            {
                _ReturnID=ID;
                _Mode = enMode.Edit;
            }
        }

        private int _BookingID=-1;
        private int _ReturnID=-1;

        
        private clsVehicleReturns _Return=new clsVehicleReturns();

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _LoadDefaultValues()
        {
            lblFormTitle1.Text = "Return A Vehicle";
            clsRentalBooking _Booking = clsRentalBooking.Find(_BookingID);

            if(_Booking==null )
            {
                MessageBox.Show("No Booking Info Was  Found .", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlShowBookingInfo1.LoadBookInfo(_BookingID);
          
            lblActualRentDays.Text = "???";
            lblActualTotalDueAmount.Text = "???";
            lblAdditonalCharges.Text = "???"; 
            lblReturnID.Text = "???";
            lblConsumedMileage.Text = "???";

            _Return = new clsVehicleReturns();
           
            _CalculateActualRentDays();

        }

        private void _LoadReturnValues()
        {
            lblFormTitle1.Text = "Edit Return Info";
            _Return = clsVehicleReturns.Find(_ReturnID);
            if (_Return == null)
            {
                MessageBox.Show("Return Info Was Not Found .", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlShowBookingInfo1.LoadBookInfo(_Return.BookingID);

            lblActualRentDays.Text = _Return.ActualRentalDays.ToString();
            lblActualTotalDueAmount.Text = _Return.ActualTotalDueAmount.ToString();
            lblAdditonalCharges.Text = _Return.AdditionalCharges.ToString();
            lblReturnID.Text = _ReturnID.ToString();
            lblConsumedMileage.Text = _Return.ConsumedMileage.ToString();
            _ReturnCheckID = _Return.ReturnCheckID;

            txtMileage.Enabled = true;
            txtReturnNotes.Enabled = true;
            btnSave.Enabled = true;

            txtMileage.Text = _Return.Mileage.ToString();
            txtReturnNotes.Text = _Return.ReturnNotes;



        }

        private void _CalculateActualRentDays()
        {
            lblActualRentDays.Text= (DateTime.Now - ctrlShowBookingInfo1.RentalBookInfo.RentalStartDate).Days.ToString();
            lblActualTotalDueAmount.Text=(int.Parse(lblActualRentDays.Text) * ctrlShowBookingInfo1.RentalBookInfo.RentalPricePerDay).ToString();
          
            lblAdditonalCharges.Text = (  int.Parse(lblActualTotalDueAmount.Text) - ctrlShowBookingInfo1.RentalBookInfo.InitialTotalDueAmount ).ToString();
        
        }

        private bool _UpdateVehicleInfo()
        {
            ctrlShowBookingInfo1.RentalBookInfo.VehicleInfo.Mileage = int.Parse(txtMileage.Text);
            ctrlShowBookingInfo1.RentalBookInfo.VehicleInfo.CurrentCheckID = _ReturnCheckID;
            ctrlShowBookingInfo1.RentalBookInfo.VehicleInfo.IsAvailableForRent = true;
            if(ctrlShowBookingInfo1.RentalBookInfo.VehicleInfo.Save())
            {
                return true;
            }
            return false;
        }

        private void frmReturnVehicle_Load(object sender, EventArgs e)
        {

           

            if (_Mode == enMode.Edit)
            {
                _LoadReturnValues();
            }
            else
            {
                _LoadDefaultValues();
            }
            
        }

        private void txtMileage_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider ER = new ErrorProvider();
            if (string.IsNullOrEmpty(txtMileage.Text))
            {
                ER.SetError(txtMileage, "Can Not Be Empty , Try Again.");
                e.Cancel = true;
                return;
            }
            if(int.Parse(txtMileage.Text)<=ctrlShowBookingInfo1.RentalBookInfo.VehicleInfo.Mileage)
            {
                ER.SetError(txtMileage, "You Can Not Enter A Value Smaller than "+ ctrlShowBookingInfo1.RentalBookInfo.VehicleInfo.Mileage);
                e.Cancel = true;
                return;
            }
            ER.SetError(txtMileage, null);
            e.Cancel = false;
            lblConsumedMileage.Text = Math.Abs(int.Parse(txtMileage.Text) - ctrlShowBookingInfo1.RentalBookInfo.VehicleInfo.Mileage).ToString();

        }

        private void txtMileage_KeyPress(object sender, KeyPressEventArgs e)
        { 
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please Fill All Required Fields .", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_ReturnCheckID==-1)
            {
                MessageBox.Show("You Need To Make a Check When Returning The Vehicle.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Return.ActualReturnDate = DateTime.Now.Date;
            _Return.ActualRentalDays = Convert.ToByte(lblActualRentDays.Text);
            _Return.Mileage = Convert.ToInt32(txtMileage.Text);
            _Return.ConsumedMileage = Convert.ToInt32(lblConsumedMileage.Text);
            _Return.ReturnNotes = txtReturnNotes.Text;
            _Return.AdditionalCharges = Convert.ToSingle(lblAdditonalCharges.Text);
            _Return.ActualTotalDueAmount = Convert.ToSingle(lblActualTotalDueAmount.Text);
            _Return.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _Return.ReturnCheckID = _ReturnCheckID;
            _Return.BookingID = ctrlShowBookingInfo1.RentalBookInfo.BookingID;

            clsRentalTransaction Transaction = clsRentalTransaction.FindByBookingID(_Return.BookingID);

            Transaction.ReturnID = -1;
            Transaction.ActualTotalDueAmount = _Return.ActualTotalDueAmount;
            Transaction.TotalRemaining = _Return.AdditionalCharges;
            Transaction.TotalRefundedAmount = 0;
            Transaction.UpdatedTransactionDate = DateTime.Now.Date;

            //لازم تزبط الحفط تبع الدفع 


            if (_Return.Save()|| _UpdateVehicleInfo())
            {
                Transaction.ReturnID = _Return.ReturnID;
                if (Transaction.Save())
                {
                    MessageBox.Show("Vehicle Returning Was  Saved ", "Done", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                    lblReturnID.Text = _ReturnID.ToString();
                    return;
                }
            }
            else
            {
               
                 MessageBox.Show("Vehicle Returning Was Not Saved , an Error occurred.", "Error", MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
                       
            }
        }

        private void txtReturnNotes_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider ER = new ErrorProvider();
            if (string.IsNullOrEmpty(txtReturnNotes.Text))
            {
                ER.SetError(txtReturnNotes, "Can Not Be Empty , Try Again.");
                e.Cancel = true;
            }
            else
            {
                ER.SetError(txtReturnNotes,null);
                e.Cancel = false;
            }
        }
        private void _HandelCheckInfo(object sender,int CheckID)
        {
            _ReturnCheckID = CheckID;
        }

        private int _ReturnCheckID = -1;
        private void btnreturningcheck_Click(object sender, EventArgs e)
        {
            frmAddEditVehicleCheck frm = null;
            if (_Mode==enMode.AddNew)
            {
                 frm = new frmAddEditVehicleCheck();
                frm.CheckDataSaved += _HandelCheckInfo;

            }
            else
            {
                 frm = new frmAddEditVehicleCheck(_ReturnCheckID);
            }
           
            frm.ShowDialog();
        }

        private void txtMileage_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
