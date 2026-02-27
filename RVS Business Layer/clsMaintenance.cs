using RVS_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_Business_Layer
{
    public class clsMaintenance
    {

        enum enMode { AddNew,Update}
        enMode _Mode=enMode.AddNew;

        public int MaintenanceID { get; set;}
        public int VehicleID { get; set;}
        public string Description { get; set;}
        public DateTime MaintenanceDate{get;set;}
        public float Cost{get;set;}
        public int MaintenanceCheckID{get;set;}
        public int CreatedByUserID{get;set;}

        public clsVehicle VehicleInfo {get;set;}
        public clsVehicleCheck CheckInfo {get;set;}
        public clsUser UserInfo {get;set;}



        public clsMaintenance()
        {
            this.MaintenanceID = -1;
            this.VehicleID = -1;
            this.Description = "";
            this.MaintenanceDate = DateTime.Now;
            this.Cost = 0;
            this.MaintenanceCheckID = -1;
            this.CreatedByUserID = -1;
            this._Mode = enMode.AddNew;

            this.VehicleInfo = new clsVehicle();
            this.CheckInfo=new clsVehicleCheck();
            this.UserInfo = new clsUser();
        }

        private clsMaintenance( int maintenanceID, int vehicleID, string description,
            DateTime maintenanceDate, float cost, int maintenanceCheckID, int createdByUserID)
        {
            this._Mode = enMode.Update;
            this.MaintenanceID = maintenanceID;
            this.VehicleID = vehicleID;
            this.Description = description;
            this.MaintenanceDate = maintenanceDate;
            this.Cost = cost;
            this.MaintenanceCheckID = maintenanceCheckID;
            this.CreatedByUserID = createdByUserID;

            this.VehicleInfo=clsVehicle.Find(vehicleID);
            this.CheckInfo = clsVehicleCheck.Find(maintenanceCheckID);
            this.UserInfo = clsUser.FindByUserID(createdByUserID);
        }


        public static DataTable GetAllMaintenances()
        {
            return clsMaintenanceData.GetAllMaintenances();
        }

        public static clsMaintenance Find(int MaintenanceID)
        {
            int vehicleID=-1 ; string description="" ;
            DateTime maintenanceDate= DateTime.Now; float cost=0 ;
            int maintenanceCheckID=-1 ; int createdByUserID=-1;

            if(clsMaintenanceData.GetMaintenanceInfoByMaintenanceID(MaintenanceID,ref  vehicleID,ref description,
                ref maintenanceDate, ref cost, ref maintenanceCheckID, ref createdByUserID) )
            {
                return new clsMaintenance(MaintenanceID,vehicleID,description, maintenanceDate, cost, maintenanceCheckID,
                    createdByUserID);
            }
            else
            {
                return null; 
            }

        }

        private bool _AddNew()
        {
            this.MaintenanceID=clsMaintenanceData.AddNewMaintenance(this.VehicleID,this.Description,this.MaintenanceDate,
                this.Cost,this.MaintenanceCheckID,this.CreatedByUserID);
            return (this.MaintenanceID!=-1);
        }

        private bool _Update()
        {
            return clsMaintenanceData.UpdateMaintenace(this.MaintenanceID, this.VehicleID, this.Description, this.MaintenanceDate,
                this.Cost, this.MaintenanceCheckID, this.CreatedByUserID);
        }

        public bool Save()
        {

            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _Update();

            }

            return false;
        }

        public static bool DeleteMaintenance(int MaintenanceID)
        {
            return clsMaintenanceData.DeleteMaintenance(MaintenanceID);
        }

    }
}
