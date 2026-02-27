using RVS_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_Business_Layer
{
    public class clsVehicleCheck
    {

        enum enMode { Add=0, Edit=1 }

        public int VehicleCheckID { get; set; }
        public int ExteriorCheckID { get; set; }
        public clsExteriorCheck ExteriorCheckInfo { get; set; }
        public int InteriorCheckID { get; set; }
        public clsInteriorCheck InteriorCheckInfo { get; set; }
        public int EngineCheckID { get; set; }
        public clsEngineCheck EngineCheckInfo { get; set; }

        public float FuelLevel { get; set; }
        public bool DamagedFound { get; set; }
        public string GeneralNotes { get; set; }
        public DateTime CheckDate { get; set; }
        public int CreatedByUserID { get; set; }

        private enMode _Mode = enMode.Add;

        public clsVehicleCheck()
        {
           this. VehicleCheckID = -1;
           this. ExteriorCheckID = -1;
           this. InteriorCheckID = -1;
           this. EngineCheckID = -1;
           this. FuelLevel = -1;
           this. DamagedFound = false;
           this. GeneralNotes = "";
           this. CheckDate = DateTime.Now;
           this. CreatedByUserID = -1;
           this. _Mode=enMode.Add;
        }




        private clsVehicleCheck(int VehicleCheckID, int ExteriorCheckID, int InteriorCheckID,
            int EngineCheckID, float FuelLevel, bool DamagedFound, string GeneralNotes,
            DateTime CheckDate, int CreatedByUserID)
        {
            this.VehicleCheckID = VehicleCheckID;
            this.ExteriorCheckID = ExteriorCheckID;
            this.InteriorCheckID = InteriorCheckID;
            this.EngineCheckID = EngineCheckID;
            this.FuelLevel = FuelLevel;
            this.DamagedFound = DamagedFound;
            this.GeneralNotes = GeneralNotes;
            this.CheckDate = CheckDate;
            this.CreatedByUserID = CreatedByUserID;

            this.ExteriorCheckInfo = clsExteriorCheck.Find(ExteriorCheckID);
            this.InteriorCheckInfo = clsInteriorCheck.Find(InteriorCheckID);
            this.EngineCheckInfo = clsEngineCheck.Find(EngineCheckID);
            this._Mode = enMode.Edit;
        }

        public static bool IsVehicleCheckExist(int VehicleCheckID)
        {
            return clsVehicleCheckData.IsVehicleCheckExist(VehicleCheckID);
        }
        public static clsVehicleCheck Find(int VehicleCheckID)
        {
            int ExteriorCheckID=-1; int InteriorCheckID=-1;
            int EngineCheckID=-1; float FuelLevel=0; bool DamagedFound=false; string GeneralNotes="";
            DateTime CheckDate=DateTime.Now; int CreatedByUserID = -1;

            if(clsVehicleCheckData.GetVehicleCheckInfoByID(VehicleCheckID, ref ExteriorCheckID, ref InteriorCheckID,
                ref EngineCheckID, ref FuelLevel, ref DamagedFound, ref GeneralNotes,
                ref CheckDate, ref CreatedByUserID))
            {
                return new clsVehicleCheck(VehicleCheckID, ExteriorCheckID, InteriorCheckID,
                    EngineCheckID, FuelLevel, DamagedFound, GeneralNotes,
                    CheckDate, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewVehicleCheck()
        {
            this.VehicleCheckID = clsVehicleCheckData.AddNewVehicleCheck(
                this.ExteriorCheckID,
                this.InteriorCheckID,
                this.EngineCheckID,
                this.FuelLevel,
                this.DamagedFound,
                this.GeneralNotes,
                this.CheckDate,
                this.CreatedByUserID);
            return this.VehicleCheckID != -1;
        }

        private bool _UpdateVehicleCheck()
        {
            return clsVehicleCheckData.UpdateVehicleCheck(
                this.VehicleCheckID,
                this.ExteriorCheckID,
                this.InteriorCheckID,
                this.EngineCheckID,
                this.FuelLevel,
                this.DamagedFound,
                this.GeneralNotes,
                this.CheckDate,
                this.CreatedByUserID);
        }

        public bool Delete()
        {
           return clsVehicleCheck.Delete(this.VehicleCheckID, this.EngineCheckID, this.ExteriorCheckID,
                 this.InteriorCheckID);
        }

        public static bool Delete(int VehicleCheckID, int EngineCheckID
            , int ExteriorCheckID, int InteriorCheckID)
        {
            return clsVehicleCheckData.Delete(VehicleCheckID, EngineCheckID, ExteriorCheckID,
               InteriorCheckID);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (_AddNewVehicleCheck())
                    {
                        _Mode = enMode.Edit;
                        return true;
                    }
                    return false;
                case enMode.Edit:
                    return _UpdateVehicleCheck();
                default:
                    return false;

            }

        }

    }
}
