using RVS_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_Business_Layer
{
    public class clsRentalBooking
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode _Mode = enMode.AddNew;

        public int BookingID { get; set; }
        public int CustomerID { get; set; }
        public int VehicleID { get; set; }
        public DateTime RentalStartDate { get; set; }

        public DateTime RentalEndDate { get; set; }
        public string PickupLocation { get; set; }
        public string DropoffLocation { get; set; }
        public int InitialRentalDays { get; set; }

        public float RentalPricePerDay { get; set; }
        public float InitialTotalDueAmount { get; set; }
        public int InitialCheckID { get; set; }
        public int CreatedByUserID { get; set; }

        public clsCustomer CustomerInfo {  get; set; }  
        public clsVehicle VehicleInfo { get; set; } 
        public clsUser UserInfo { get; set; }
        public clsVehicleCheck InitialCheckInfo { get; set; }

        public clsRentalBooking()
        {
            this.BookingID = -1;
            this.CustomerID = -1;
            this.VehicleID = -1;
            this.RentalStartDate = DateTime.Now;
            this.RentalEndDate= DateTime.Now;
            this.PickupLocation = "";
            this.DropoffLocation = "";
            this.InitialRentalDays= 0;
            this.RentalPricePerDay = 0;
            this.InitialTotalDueAmount= 0;
            this.InitialCheckID = -1;
            this.CreatedByUserID = -1;

            this.VehicleInfo = new clsVehicle();
            this.CustomerInfo=new clsCustomer();
            this.UserInfo= new clsUser();
            this.InitialCheckInfo = new clsVehicleCheck();

            _Mode = enMode.AddNew;

        }


        private clsRentalBooking( int bookingID, int customerID, int vehicleID, DateTime rentalStartDate,
            DateTime rentalEndDate, string pickupLocation, string dropoffLocation, int initialRentalDays,
            float rentalPricePerDay, float initialTotalDueAmount, int initialCheckID, int createdByUserID)
        {
            this._Mode = enMode.Update;

            this.BookingID = bookingID;
            this.CustomerID = customerID;
            this.VehicleID = vehicleID;
            this.RentalStartDate = rentalStartDate;

            this.RentalEndDate = rentalEndDate;
            this.PickupLocation = pickupLocation;
            this.DropoffLocation = dropoffLocation;
            this.InitialRentalDays = initialRentalDays;

            this.RentalPricePerDay = rentalPricePerDay;
            this.InitialTotalDueAmount = initialTotalDueAmount;
            this.InitialCheckID = initialCheckID;
            this.CreatedByUserID = createdByUserID;

            this.CustomerInfo = clsCustomer.FindByCustomerID(customerID);
            this.VehicleInfo = clsVehicle.Find(vehicleID);
            this.UserInfo = clsUser.FindByUserID(createdByUserID);
            this.InitialCheckInfo = clsVehicleCheck.Find(initialCheckID);
        }


        public static DataTable GetAllRentalBooks()
        {
            return clsRentalBookData.GetAllRentalBooks();
        }

        private bool _AddNewRentalBooking()
        {
            this.BookingID=clsRentalBookData.AddNewRentalBook(this.CustomerID, this.VehicleID, this.RentalStartDate,
                this.RentalEndDate, this.PickupLocation, this.DropoffLocation,
                 this.RentalPricePerDay,this.InitialCheckID, this.CreatedByUserID);
            return (this.BookingID != -1);
        }

        private bool _UpdateRentalBooking()
        {
                 return clsRentalBookData.UpdateRentalBook(this.BookingID, this.CustomerID, this.VehicleID, this.RentalStartDate,
         this.RentalEndDate, this.PickupLocation, this.DropoffLocation,
          this.RentalPricePerDay, this.InitialCheckID, this.CreatedByUserID);
        }

        public bool Save()
        {
            if (!this.CustomerInfo.Save())
            {
                return false;
            }
            this.CustomerID = this.CustomerInfo.CustomerID;


            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewRentalBooking())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateRentalBooking();

            }

            return false;
        }

        public static clsRentalBooking Find(int BookingID)
        {
             int CustomerID=-1; int VehicleID=-1;
                 DateTime RentalStartDate=DateTime.Now;
            DateTime RentalEndDate = DateTime.Now; int InitialRentalDays=-1; 
                string PickupLocation=""; string DropoffLocation="";
            float RentalPricePerDay=0; float InitialTotalDueAmount=0;
                int InitialCheckID=-1; int CreatedByUserID=-1;

            if(clsRentalBookData.GetRentalBookInfoByID(BookingID,ref CustomerID,ref VehicleID,
                ref RentalStartDate, ref RentalEndDate, ref InitialRentalDays, ref PickupLocation,
                ref DropoffLocation, ref RentalPricePerDay, ref InitialTotalDueAmount,
                ref InitialCheckID, ref CreatedByUserID))
            {
                return new clsRentalBooking(BookingID, CustomerID, VehicleID, RentalStartDate,
             RentalEndDate, PickupLocation, DropoffLocation, InitialRentalDays,
             RentalPricePerDay, InitialTotalDueAmount, InitialCheckID, CreatedByUserID);
            }
            else
            {
                return null;
            }    


        }

        public bool Delete()
        {
            return clsRentalBookData.DeleteRentalBooking(this.BookingID);
        }

        public static bool Delete(int BookingID)
        {
            return clsRentalBookData.DeleteRentalBooking(BookingID);
        }

        public static bool IsBookingExists(int BookingID)
        {
            return clsRentalBookData.IsBookingExists(BookingID);
        }

        public static bool IsBookingReturned(int BookingID)
        {
            return clsRentalBookData.IsBookingReturned(BookingID);
        }
    }


}
