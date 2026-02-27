using RVS_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_Business_Layer
{
    public class clsEngineCheck


    {
        enum enMode { Add = 0, Edit = 1 }


        public int EngineCheckID { get; set; }

        public bool EngineStartsOk { get; set; }
        public bool EngineNoiseOk { get; set; }
        public bool OilLevelOk { get; set; }
        public bool WarningLightsOk { get; set; }

        public string EngineNotes { get; set; }

        private enMode _Mode = enMode.Add;


       public clsEngineCheck()
       {
           this.EngineNotes = "";
           this.EngineCheckID = -1;
           this.EngineStartsOk = false;
           this.EngineNoiseOk = false;
           this.OilLevelOk=false;
           this.WarningLightsOk = false;
           this._Mode= enMode.Add;
       }

        private clsEngineCheck(int EngineCheckID,bool EngineStartsOK,bool EngineNoise,bool OilLevel,bool WarningLights,string EngineNotes)
        {
            this.EngineCheckID = EngineCheckID;
            this.EngineStartsOk = EngineStartsOK;
            this.EngineNoiseOk = EngineNoise;
            this.OilLevelOk=OilLevel;
            this.WarningLightsOk = WarningLights;
            this.EngineNotes=EngineNotes;
            this._Mode = enMode.Edit;
        }

        public static clsEngineCheck Find(int EngineCheckID)
        {
            bool EngineStartsOk = false;
            bool EngineNoiseOk = false;
            bool OilLevelOk = false;
            bool WarningLightsOk = false;
            string EngineNotes="";

            bool isFound = clsEngineCheckData.GetEngineInfoByID(
                EngineCheckID,ref EngineStartsOk,ref EngineNoiseOk,ref OilLevelOk,ref WarningLightsOk,ref EngineNotes);
            if (isFound)
            {
                return new clsEngineCheck(EngineCheckID,EngineStartsOk,EngineNoiseOk,OilLevelOk,WarningLightsOk,EngineNotes);
            }
            else
            {
                return null;
            }
        }


        private bool _AddNewEngineCheck()
        {
            this.EngineCheckID = clsEngineCheckData.AddNewEngineCheck(EngineStartsOk, EngineNoiseOk,OilLevelOk,WarningLightsOk,
                EngineNotes);

            return (this.EngineCheckID != -1);
        }

        private bool _UpdateEngineCheck()
        {
            return clsEngineCheckData.UpdateEngineCheck(EngineCheckID, EngineStartsOk, EngineNoiseOk, OilLevelOk, WarningLightsOk, EngineNotes);
        }

        public bool Delete()
        {
            return clsEngineCheckData.Delete(this.EngineCheckID);
        }

        public static bool Delete(int EngineCheckID)
        {
            return clsEngineCheckData.Delete(EngineCheckID);
        }

        public bool Save()
        {
            bool isSuccess = false;

            if (_Mode == enMode.Add)
            {
                isSuccess = _AddNewEngineCheck();
                if (isSuccess)
                {
                    _Mode = enMode.Edit;
                }
            }
            else if (_Mode == enMode.Edit)
            {
                isSuccess = _UpdateEngineCheck();
            }

            return isSuccess;
        }

    }
}
