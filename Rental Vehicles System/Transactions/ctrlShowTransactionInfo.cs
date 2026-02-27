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

namespace Rental_Vehicles_System.Transactions
{
    public partial class ctrlShowTransactionInfo : UserControl
    {
        public ctrlShowTransactionInfo()
        {
            InitializeComponent();
        }

        public clsRentalTransaction TransactionInfo { get; set; } 

        public void LoadDefaultData()
        {
            lblTransactionID.Text = "?";
            lblBookingID.Text = "?";
            lblReturnID.Text = "?";
            lblIssueDate.Text = "????";
            lblUpdateDate.Text = "????";
            lblInitialAmount.Text = "?";
            lblTotalAmount.Text = "?";
            lblRemaining.Text = "?";
            lblRefund.Text= "?";
            lblPMethod.Text = "?";
            txtNotes.Clear();
            TransactionInfo = new clsRentalTransaction();
        }


        public void LoadTransactionData(int TransactionID)
        {
            TransactionInfo = clsRentalTransaction.FindByTransactionID(TransactionID);
            if (TransactionInfo == null)
            {
                return;
            }

            lblTransactionID.Text = TransactionInfo.TransactionID.ToString() ;
            lblBookingID.Text =TransactionInfo.BookingID.ToString() ;
            lblReturnID.Text = TransactionInfo.ReturnID.ToString() ;
            lblIssueDate.Text = TransactionInfo.TransactionDate.ToShortDateString() ;
            lblUpdateDate.Text = TransactionInfo.UpdatedTransactionDate.ToShortDateString();
            lblInitialAmount.Text = TransactionInfo.PaidInitialTotalDueAmount.ToString() ;
            lblTotalAmount.Text = TransactionInfo.ActualTotalDueAmount.ToString() ;
            lblRemaining.Text = TransactionInfo.TotalRemaining.ToString() ;
            lblRefund.Text = TransactionInfo.TotalRefundedAmount.ToString() ;
            lblPMethod.Text =TransactionInfo.PaymentMethodInfo.MethodName.ToString() ;
            txtNotes.Text=TransactionInfo.PaymentNotes.ToString() ;

        }

        private void txtNotes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
