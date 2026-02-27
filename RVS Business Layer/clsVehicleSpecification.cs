using RVS_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_Business_Layer
{
    public class clsVehicleSpecification
    {
        enum enMode { AddNew = 0, Update = 1 }

        public int VehicleSpecificationID { get; set; }
        public int MakeID { get; set; }
        public clsMake MakeInfo { get; set; }
        public int FuelTypeID { get; set; }
        public clsFuelType FuelInfo { get; set; }
        public int AspirationID { get; set; }
        public clsAspiration AspirationInfo { get; set; }
        public int BodyID { get; set; }
        public clsBodies BodyInfo { get; set; }
        public int CylinderTypeID { get; set; }
        public clsCylinderType CylinderInfo { get; set; }
        public int EngineBlockTypeID { get; set; }
        public clsEngineBlockType EngineBlockInfo { get; set; }
        public int EngineID { get; set; }
        public clsEngine EngineInfo { get; set; }
        public int DriveTypeID { get; set; }
        public clsDriveType DriveTypeInfo { get; set; }

        public string HexColor { get; set; }

        private enMode _Mode = enMode.AddNew;

        public clsVehicleSpecification()
        {
            this.VehicleSpecificationID = -1;
            this.MakeID = -1;
            this.FuelTypeID = -1;
            this.AspirationID = -1;
            this.BodyID = -1;
            this.CylinderTypeID = -1;
            this.EngineBlockTypeID = -1;
            this.EngineID = -1;
            this.DriveTypeID = -1;
            this.HexColor = "#FFFFFF";
            this._Mode = enMode.AddNew;
        }

        private clsVehicleSpecification(int vehicleSpecificationID, int makeID, int fuelTypeID,
            int aspirationID, int bodyID, int cylinderTypeID,
            int engineBlockTypeID, int engineID, int driveTypeID,string HexColor)
        {
           this.VehicleSpecificationID = vehicleSpecificationID;
           this.MakeID = makeID;
           this.FuelTypeID = fuelTypeID;
           this.AspirationID = aspirationID;
           this.BodyID = bodyID;
           this.CylinderTypeID = cylinderTypeID;
           this.EngineBlockTypeID = engineBlockTypeID;
           this.EngineID = engineID;
           this.DriveTypeID = driveTypeID;
            this.HexColor = HexColor;
            this._Mode = enMode.Update;

           this.MakeInfo=clsMake.GetByID(this.MakeID);
           this.FuelInfo=clsFuelType.GetByID(this.FuelTypeID);
           this.AspirationInfo=clsAspiration.GetByID(this.FuelTypeID) ;
           this.BodyInfo = clsBodies.GetByID(this.BodyID); 
           this.CylinderInfo=clsCylinderType.GetByID (this.CylinderTypeID);
           this.EngineBlockInfo=clsEngineBlockType.GetByID(this.EngineBlockTypeID);
           this.EngineInfo = clsEngine.GetByID(this.EngineID);
           this.DriveTypeInfo=clsDriveType.GetByID(this.DriveTypeID);

        }

        public static clsVehicleSpecification Find(int vehicleSpecificationID)
        {
            int makeID = -1; int fuelTypeID = -1;
            int aspirationID = -1; int bodyID = -1; int cylinderTypeID = -1;
            int EngineBlockTypeID = -1; int engineID = -1; int driveTypeID = -1;string HexColor = "";

            if (clsVehicleSpecificationData.GetSpecificationInfoByID(vehicleSpecificationID, ref makeID, ref fuelTypeID,
                ref aspirationID, ref bodyID, ref cylinderTypeID, ref EngineBlockTypeID, ref engineID, ref driveTypeID,ref HexColor))
            {
                return new clsVehicleSpecification(vehicleSpecificationID, makeID, fuelTypeID,
                                 aspirationID, bodyID, cylinderTypeID, EngineBlockTypeID, engineID, driveTypeID,HexColor);
            }
            else
            {
                return null;
            }

        }

        private bool _AddNewSpecification()
        {
            this.VehicleSpecificationID = clsVehicleSpecificationData.AddNewVehicleSpecification(MakeID, FuelTypeID,
                AspirationID, BodyID, CylinderTypeID, EngineBlockTypeID, EngineID, DriveTypeID,HexColor);

            return this.VehicleSpecificationID != -1;
        }

        private bool _UpdateSpecification()
        {
            return clsVehicleSpecificationData.UpdateVehicleSpecification(VehicleSpecificationID, MakeID, FuelTypeID,
                AspirationID, BodyID, CylinderTypeID, EngineBlockTypeID, EngineID, DriveTypeID,HexColor);
        }

        public static bool IsVehicleSpecificationsExist(int VehicleSpecificationsID)
        {
            return clsVehicleSpecificationData.IsVehicleSpecificationsExist(VehicleSpecificationsID);
        }
        public bool Delete()
        {
            return clsVehicleSpecificationData.Delete(VehicleSpecificationID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewSpecification())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    {
                        return _UpdateSpecification();
                    }
                default:
                    {
                        return false;
                    }
            }
        }
    }
}
