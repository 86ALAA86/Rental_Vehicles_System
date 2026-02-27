using RVS_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RVS_Business_Layer
{
    public class clsVehicleReturns
    {
        enum enMode { AddNew,Update}

        enMode _Mode = enMode.AddNew;

        public int ReturnID{ get; set; }
        public DateTime ActualReturnDate{ get; set; } 
        public byte ActualRentalDays{ get; set; }
        public int Mileage{ get; set; } 
        public int ConsumedMileage{ get; set; }
        public string ReturnNotes{ get; set; }
        public float AdditionalCharges{ get; set; }
        public float ActualTotalDueAmount{ get; set; }
        public int CreatedByUserID{ get; set; }
        public clsUser UserInfo { get; set; }
        public int ReturnCheckID { get; set; }
        public clsVehicleCheck CheckInfo { get; set; }
        public int BookingID { get; set; }
        public clsRentalBooking BookingInfo { get; set; }

        public clsVehicleReturns()
        {
            this.ReturnID = -1;
            this.ActualReturnDate = DateTime.Now ;
            this.ActualRentalDays = 0;
            this.Mileage=0 ;
            this.ConsumedMileage = 0;
            this.ReturnNotes = "";
            this.AdditionalCharges = 0;
            this.ActualTotalDueAmount = 0;
            this.CreatedByUserID = -1;
            this.ReturnCheckID = -1;
            this.BookingID = -1;
            this._Mode = enMode.AddNew;

        }

        private clsVehicleReturns(int ReturnID, DateTime ActualReturnDate, byte ActualRentalDays,
            int Mileage, int ConsumedMileage, string ReturnNotes, float AdditionalCharges,
            float ActualTotalDueAmount, int CreatedByUserID, int ReturnCheckID, int BookingID)
        {
            this.ReturnID = ReturnID;
            this.ActualReturnDate = ActualReturnDate;
            this.ActualRentalDays = ActualRentalDays;
            this.Mileage = Mileage;
            this.ConsumedMileage = ConsumedMileage;
            this.ReturnNotes =  ReturnNotes;
            this.AdditionalCharges = AdditionalCharges;
            this.ActualTotalDueAmount = ActualTotalDueAmount;
            this.CreatedByUserID = CreatedByUserID;
            this.ReturnCheckID = ReturnCheckID;
            this.BookingID = BookingID;
            this._Mode = enMode.Update;

            this.BookingInfo = clsRentalBooking.Find(this.BookingID);
            this.CheckInfo=clsVehicleCheck.Find(this.ReturnCheckID);
            this.UserInfo = clsUser.FindByUserID(this.CreatedByUserID);
        }

        public static DataTable GetAllReturnedVehicles()
        {
            return clsVehicleReturnsData.GetAllReturnedVehicles();
        }

        private bool _AddNewReturnedVehicle()
        {
            this.ReturnID= clsVehicleReturnsData.AddNewVehicleReturn(this.ActualReturnDate, this.ActualRentalDays,
                this.Mileage, this.ConsumedMileage, this.ReturnNotes, this.AdditionalCharges, this.ActualTotalDueAmount,
                this.CreatedByUserID, this.ReturnCheckID,this.BookingID);
            return (this.ReturnID != -1);
        }

        private bool _UpdateReturnedVehicle()
        {
            return clsVehicleReturnsData.UpdateVehicleReturn(this.ReturnID,this.ActualReturnDate, this.ActualRentalDays,
                this.Mileage, this.ConsumedMileage, this.ReturnNotes, this.AdditionalCharges, this.ActualTotalDueAmount,
                this.CreatedByUserID, this.ReturnCheckID, this.BookingID);
           
        }

        public static clsVehicleReturns Find(int ReturnID)
        {
            DateTime ActualReturnDate = DateTime.Now; byte ActualRentalDays = 1;
            int Mileage = 0; int ConsumedMileage = 0; string ReturnNotes = ""; float AdditionalCharges = 0;
            float ActualTotalDueAmount = 0; int CreatedByUserID=-1; int ReturnCheckID = -1; int BookingID = -1;

            if(clsVehicleReturnsData.GetVehicleReturnInfoByID(ReturnID,ref ActualReturnDate,ref ActualRentalDays,
                ref Mileage,ref ConsumedMileage,ref ReturnNotes,ref AdditionalCharges,ref ActualTotalDueAmount,
                ref CreatedByUserID,ref ReturnCheckID,ref BookingID))
            {
                return new clsVehicleReturns(ReturnID, ActualReturnDate, ActualRentalDays, Mileage, ConsumedMileage,
                    ReturnNotes, AdditionalCharges, ActualTotalDueAmount, CreatedByUserID, ReturnCheckID, BookingID);
            }
            else
            {
                return null;
            }

        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewReturnedVehicle())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateReturnedVehicle();
                default:
                    return false;

            }

        }

        public static  bool Delete(int ReturnID)
        {
            return clsVehicleReturnsData.DeleteVehicleReturn(ReturnID);
        }


        public static bool IsReturnFinished(int ReturnID)
        {
            return clsVehicleReturnsData.IsReturnFinished(ReturnID);
        }
    }
}
