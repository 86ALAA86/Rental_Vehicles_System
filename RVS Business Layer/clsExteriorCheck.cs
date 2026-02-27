using RVS_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_Business_Layer
{
    public class clsExteriorCheck
    {
        enum enMode { Add = 0, Edit = 1 }


        public int ExteriorCheckID { get; set; }

      public bool LightsOk { get; set; }
      public bool PaintOk{get;set;}
      public bool MirrorsOk{get;set;}
      public bool TiresOk{get;set;} 
      public bool WindowsOk{get;set;}
      public  string ExteriorNotes { get; set; }

      private enMode _Mode = enMode.Add;


        public clsExteriorCheck()
        {
            ExteriorCheckID = -1;
            LightsOk = false;
            PaintOk = false;
            MirrorsOk = false;
            TiresOk = false;
            WindowsOk = false;
            ExteriorNotes = string.Empty;
            _Mode=enMode.Add;
        }

        private clsExteriorCheck(int pExteriorCheckID, bool pLightsOk, bool pPaintOk, bool pMirrorsOk,
              bool pTiresOk, bool pWindowsOk, string pExteriorNotes)
        {
            ExteriorCheckID = pExteriorCheckID;
            LightsOk = pLightsOk;
            PaintOk = pPaintOk;
            MirrorsOk = pMirrorsOk;
            TiresOk = pTiresOk;
            WindowsOk = pWindowsOk;
            ExteriorNotes = pExteriorNotes;
            _Mode = enMode.Edit;
        }

        public static clsExteriorCheck Find(int ExteriorCheckID)
        {
            bool lightsOk = false;
            bool paintOk = false;
            bool mirrorsOk = false;
            bool tiresOk = false;
            bool windowsOk = false;
            string exteriorNotes = string.Empty;

            bool isFound = clsExteriorCheckData.GetExteriorInfoByID(ExteriorCheckID,
                ref lightsOk, ref paintOk, ref mirrorsOk, ref tiresOk, ref windowsOk, ref exteriorNotes);

            if (isFound)
            {
                return new clsExteriorCheck(ExteriorCheckID, lightsOk, paintOk, mirrorsOk, tiresOk, windowsOk, exteriorNotes);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewExteriorCheck()
        {
            this.ExteriorCheckID = clsExteriorCheckData.AddNewExteriorCheck(
                this.LightsOk, this.PaintOk, this.MirrorsOk,
                this.TiresOk, this.WindowsOk, this.ExteriorNotes);
            return (this.ExteriorCheckID != -1);
        }

        private bool _UpdateExteriorCheck()
        {
            return clsExteriorCheckData.UpdateExteriorCheck(
                this.ExteriorCheckID,
                this.LightsOk, this.PaintOk, this.MirrorsOk,
                this.TiresOk, this.WindowsOk, this.ExteriorNotes);
        }

        public bool Delete()
        {
            return clsExteriorCheckData.Delete(this.ExteriorCheckID);
        }

        public static bool Delete(int ExteriorCheckID)
        {
            return clsExteriorCheckData.Delete(ExteriorCheckID);
        }

        public bool SaveExteriorCheck()
        {
            bool isSuccess = false;

            if (_Mode == enMode.Add)
            {
                isSuccess = _AddNewExteriorCheck();
                if (isSuccess)
                {
                    _Mode = enMode.Edit;
                }
            }
            else if (_Mode == enMode.Edit)
            {
                isSuccess = _UpdateExteriorCheck();
            }

            return isSuccess;
        }

    }
}
