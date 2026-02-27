using RVS_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_Business_Layer
{
    public  class clsRentalTransaction
    {
        enum enMode { AddNew = 0, Update = 1 };

        enMode _Mode = enMode.AddNew;

        public int BookingID { get; set; }
        public int TransactionID { get; set; }
        public int ReturnID { get; set; }
        public DateTime TransactionDate { get; set; }

        public DateTime UpdatedTransactionDate { get; set; }
        public string PaymentNotes { get; set; }
        public float PaidInitialTotalDueAmount { get; set; }
        public float ActualTotalDueAmount { get; set; }
        public float TotalRemaining { get; set; }
        public float TotalRefundedAmount { get; set; }
        public int CreatedByUserID { get; set; }
        public int PaymentMethodID { get; set; }

        public clsRentalBooking BookingInfo { get; set; }
        public clsVehicleReturns ReturnInfo { get; set; }
        public clsUser UserInfo { get; set; }
        public clsPaymentMethods PaymentMethodInfo { get; set; }


        public  clsRentalTransaction()
        {
            this.BookingID = -1;
            this.TransactionID = -1;
            this.ReturnID = -1;
            this.PaymentMethodID = -1;
            this.TransactionDate = DateTime.Now;
            this.UpdatedTransactionDate = DateTime.MinValue;
            this.PaymentNotes = string.Empty;
            this.PaidInitialTotalDueAmount = 0;
            this.ActualTotalDueAmount = 0;
            this.TotalRemaining = 0;
            this.TotalRefundedAmount = 0;
            this.CreatedByUserID = -1;

            this.BookingInfo = new clsRentalBooking();
            this.ReturnInfo = new clsVehicleReturns();
            this.UserInfo = new clsUser();
            this.PaymentMethodInfo = null;

            this._Mode = enMode.AddNew;
        }

        private clsRentalTransaction(int TransactionID,int BookingID, int ReturnID, DateTime TransactionDate, DateTime UpdatedTransactionDate,
            string PaymentNotes, float PaidInitialTotalDueAmount, float ActualTotalDueAmount,
            float TotalRemaining, float TotalRefundedAmount, int CreatedByUserID, int PaymentMethodID)
        {
            this.TransactionID = TransactionID;
            this.BookingID = BookingID;
            this.ReturnID = ReturnID;
            this.TransactionDate = TransactionDate;
            this.UpdatedTransactionDate = UpdatedTransactionDate;
            this.PaymentNotes = PaymentNotes;
            this.PaidInitialTotalDueAmount = PaidInitialTotalDueAmount;
            this.ActualTotalDueAmount = ActualTotalDueAmount;
            this.TotalRemaining = TotalRemaining;
            this.TotalRefundedAmount = TotalRefundedAmount;
            this.CreatedByUserID = CreatedByUserID;
            this.PaymentMethodID = PaymentMethodID;

            BookingInfo = clsRentalBooking.Find(BookingID);
            ReturnInfo = clsVehicleReturns.Find(ReturnID);
            UserInfo = clsUser.FindByUserID(CreatedByUserID);
            PaymentMethodInfo = clsPaymentMethods.GetByID(PaymentMethodID);

            _Mode = enMode.Update;

        }

        public static DataTable GetAllRentalTransaction()
        {
            return clsRentalTransactionsData.GetAllRentalTransaction();
        }

        private bool _AddNewTransaction()
        {
            this.TransactionID = clsRentalTransactionsData.AddNewRentalTransaction(this.BookingID, this.ReturnID,
                this.PaymentNotes, this.PaidInitialTotalDueAmount, this.ActualTotalDueAmount, this.TotalRemaining,
                this.TotalRefundedAmount, this.TransactionDate, this.UpdatedTransactionDate, this.CreatedByUserID,
                this.PaymentMethodID);
            return (this.TransactionID != -1);
                
        }

        private bool _UpdateTransaction()
        {
            return clsRentalTransactionsData.UpdateTransaction(this.TransactionID,this.BookingID, this.ReturnID,
                this.PaymentNotes, this.PaidInitialTotalDueAmount, this.ActualTotalDueAmount, this.TotalRemaining,
                this.TotalRefundedAmount, this.TransactionDate, this.UpdatedTransactionDate, this.CreatedByUserID,
                this.PaymentMethodID);

        }
        public static bool PayRefurnds(int TransactionID)
        {
            return clsRentalTransactionsData.PayRefurnds(TransactionID);
        }

        public static bool IsRefunded(int TransactionID)
        {
            return clsRentalTransactionsData.IsRefunded(TransactionID);
        }
        public static clsRentalTransaction FindByTransactionID(int TransactionID)
        {
            int BookingID=-1;int  ReturnID=-1;
               string PaymentNotes=""; float PaidInitialTotalDueAmount=0;float ActualTotalDueAmount=0;
           float TotalRemaining=0;
            float TotalRefundedAmount=0;DateTime TransactionDate=DateTime.Now;
            DateTime UpdatedTransactionDate=DateTime.MinValue;int CreatedByUserID=-1;
            int PaymentMethodID =-1;

            if(clsRentalTransactionsData.GetTransactionInfoByTransctionID
                (TransactionID,ref BookingID,ref ReturnID,
                ref PaymentNotes,ref PaidInitialTotalDueAmount, ref ActualTotalDueAmount,ref TotalRemaining,
                ref TotalRefundedAmount, ref TransactionDate, ref UpdatedTransactionDate, ref CreatedByUserID,
                ref PaymentMethodID))
            {
                return new clsRentalTransaction(TransactionID, BookingID, ReturnID, TransactionDate,
                    UpdatedTransactionDate, PaymentNotes, PaidInitialTotalDueAmount, ActualTotalDueAmount,
                    TotalRemaining, TotalRefundedAmount, CreatedByUserID, PaymentMethodID);
            }
            else
            {
                return null;
            }

        }

        public static clsRentalTransaction FindByBookingID(int BookingID )
        {
            int TransactionID = -1; int ReturnID = -1;
            string PaymentNotes = ""; float PaidInitialTotalDueAmount = 0; float ActualTotalDueAmount = 0;
            float TotalRemaining = 0;
            float TotalRefundedAmount = 0; DateTime TransactionDate = DateTime.Now;
            DateTime UpdatedTransactionDate = DateTime.MinValue; int CreatedByUserID = -1;
            int PaymentMethodID = -1;

            if (clsRentalTransactionsData.GetTransactionInfoByBookingID
                (BookingID,ref TransactionID, ref ReturnID,
                ref PaymentNotes, ref PaidInitialTotalDueAmount, ref ActualTotalDueAmount, ref TotalRemaining,
                ref TotalRefundedAmount, ref TransactionDate, ref UpdatedTransactionDate, ref CreatedByUserID,
                ref PaymentMethodID))
            {
                return new clsRentalTransaction(TransactionID, BookingID, ReturnID, TransactionDate,
                    UpdatedTransactionDate, PaymentNotes, PaidInitialTotalDueAmount, ActualTotalDueAmount,
                    TotalRemaining, TotalRefundedAmount, CreatedByUserID, PaymentMethodID);
            }
            else
            {
                return null;
            }

        }

        public static clsRentalTransaction FindByReturnID(int ReturnID)
        {
            int TransactionID = -1; int BookingID = -1;
            string PaymentNotes = ""; float PaidInitialTotalDueAmount = 0; float ActualTotalDueAmount = 0;
            float TotalRemaining = 0;
            float TotalRefundedAmount = 0; DateTime TransactionDate = DateTime.Now;
            DateTime UpdatedTransactionDate = DateTime.MinValue; int CreatedByUserID = -1;
            int PaymentMethodID = -1;

            if (clsRentalTransactionsData.GetTransactionInfoReturnID
                (ReturnID, ref TransactionID, ref BookingID,
                ref PaymentNotes, ref PaidInitialTotalDueAmount, ref ActualTotalDueAmount, ref TotalRemaining,
                ref TotalRefundedAmount, ref TransactionDate, ref UpdatedTransactionDate, ref CreatedByUserID,
                ref PaymentMethodID))
            {
                return new clsRentalTransaction(TransactionID, BookingID, ReturnID, TransactionDate,
                    UpdatedTransactionDate, PaymentNotes, PaidInitialTotalDueAmount, ActualTotalDueAmount,
                    TotalRemaining, TotalRefundedAmount, CreatedByUserID, PaymentMethodID);
            }
            else
            {
                return null;
            }

        }

        public static bool Delete(int TransactionID)
        {
            return clsRentalTransactionsData.DeleteTransaction(TransactionID);
        }

        public bool Save()
        {
           

            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTransaction())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTransaction();

            }

            return false;
        }
    }
}
