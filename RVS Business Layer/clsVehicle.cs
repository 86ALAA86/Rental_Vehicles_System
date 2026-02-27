using RVS_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_Business_Layer
{
    public class clsVehicle
    {
        enum enMode { AddNewVehicle=0, UpdateVehicle=1 }

        public int VehicleID { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public int Mileage { get; set; }
        public string PlateNumber { get; set; }
        public float RentalPricePerDay { get; set; }
        public bool IsAvailableForRent { get; set; }
        public int CreatedByUserID { get; set; }
        public int VehicleSpecificationID { get; set; }
        public clsVehicleSpecification SpecificationInfo { get; set; }
        public int CurrentCheckID { get; set; }
        public clsVehicleCheck CurrentCheckInfo { get; set; }

        private enMode _mode = enMode.AddNewVehicle;

        public clsVehicle()
        {
            this.VehicleID = -1;
            this.Model= string.Empty;
            this.Year = "";
            this.Mileage = 0;
            this.PlateNumber = string.Empty;
            this.IsAvailableForRent = true;
            this.CreatedByUserID = -1;
            this.VehicleSpecificationID = -1;
            this.CurrentCheckID = -1;
            _mode = enMode.AddNewVehicle;
        }



        private clsVehicle(int vehicleID, string model, string year, int mileage,
            string plateNumber, float rentalPricePerDay, bool isAvailableForRent,
            int createdByUserID, int vehicleSpecificationID, int currentCheckID)
        {
            this.VehicleID = vehicleID;
            this.Model = model;
            this.Year = year;
            this.Mileage = mileage;
            this.PlateNumber = plateNumber;
            this.RentalPricePerDay = rentalPricePerDay;
            this.IsAvailableForRent = isAvailableForRent;
            this.CreatedByUserID = createdByUserID;
            this.VehicleSpecificationID = vehicleSpecificationID;
            this.CurrentCheckID = currentCheckID;
            this._mode = enMode.UpdateVehicle;

            this.CurrentCheckInfo = clsVehicleCheck.Find(currentCheckID);
        }

        public static DataTable GetAllVehicles()
        {
            return clsVehiclesData.GetAllVehicles();
        }

        public static  DataTable GetAllVehicleMaintenances(int VehicleID)
        {
            return clsVehiclesData.GetAllVehicleMaintenances(VehicleID);
        }

        public static bool IsVehicleExist(int VehicleID)
        {
            return clsVehiclesData.IsVehicleExist(VehicleID);
        }
        private bool _AddNewVehicle()
        {
            this.VehicleID = clsVehiclesData.AddNewVehicle(this.Model, this.Year, this.Mileage,
                this.PlateNumber, this.RentalPricePerDay, this.IsAvailableForRent,
                this.CreatedByUserID, this.VehicleSpecificationID, this.CurrentCheckID);
            return this.VehicleID !=-1;
        }

        private bool _UpdateVehicle()
        {
            return clsVehiclesData.UpdateVehicle(this.VehicleID, this.Model, this.Year,
                this.Mileage, this.PlateNumber, this.RentalPricePerDay,
                this.IsAvailableForRent, this.CreatedByUserID,
                this.VehicleSpecificationID, this.CurrentCheckID);
        }

        public bool RentVehicle()
        {
            return clsVehiclesData.RentVehicle(this.VehicleID);
        }

        public bool Save()
        {
     

            switch (_mode)
            {
                case enMode.AddNewVehicle:
                    if (_AddNewVehicle())
                    {
                        _mode = enMode.UpdateVehicle;
                        return true;
                    }
                    return false;
                case enMode.UpdateVehicle:
                    return _UpdateVehicle();
            }

            return false;
        }

        public static bool Delete(int VehicleID)
        {
            return clsVehiclesData.DeleteVehicle(VehicleID);
        }

        public static clsVehicle Find(int vehicleID)
        {
            string model = ""; string year=""; int mileage=0;
            string plateNumber=""; float rentalPricePerDay=0; bool isAvailableForRent=true;
            int createdByUserID=-1; int vehicleSpecificationID=-1; int currentCheckID = -1;

            if(clsVehiclesData.GetVehicleInfoByID(vehicleID, ref model, ref year,
                ref mileage, ref plateNumber, ref rentalPricePerDay,
                ref isAvailableForRent, ref createdByUserID,
                ref vehicleSpecificationID, ref currentCheckID))
            {
                return new clsVehicle(vehicleID, model, year, mileage,
                    plateNumber, rentalPricePerDay, isAvailableForRent,
                    createdByUserID, vehicleSpecificationID, currentCheckID);
            }
            else
            {
                return null;
            }

        }





    }
}
