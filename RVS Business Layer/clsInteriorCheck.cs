using RVS_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_Business_Layer
{
    public class clsInteriorCheck

    {
        enum enMode { Add = 0, Edit = 1 }


        public int InteriorCheckID { get; set; }

        public bool SeatsOk { get; set; }
        public bool DashboardOk { get; set; }
        public bool OdorOk { get; set; }
        public string InteriorNotes { get; set; }

        private enMode _Mode = enMode.Add;


        public clsInteriorCheck()
        {
           this.InteriorCheckID = -1;
            this.SeatsOk = false;
            this.DashboardOk = false;
            this.OdorOk = false;
            this.InteriorNotes = string.Empty;
            _Mode = enMode.Add;
        }

      private clsInteriorCheck(int interiorCheckID, bool seatsOk, bool dashboardOk, bool odorOk, string interiorNotes)
        {
           this.InteriorCheckID = interiorCheckID;
           this.SeatsOk = seatsOk;
           this.DashboardOk = dashboardOk;
           this.OdorOk = odorOk;
           this.InteriorNotes = interiorNotes;
           this._Mode = enMode.Edit;
        }

        public static clsInteriorCheck Find(int InteiorCheckID)
        {
            bool seatsOk = false;
            bool dashboardOk = false;
            bool odorOk = false;
            string interiorNotes = string.Empty;
            bool isFound = clsInteriorChecksData.GetInteriorInfoByID(
                InteiorCheckID,
                ref seatsOk,
                ref dashboardOk,
                ref odorOk,
                ref interiorNotes);
            if (isFound)
            {
                return new clsInteriorCheck(
                    InteiorCheckID,
                    seatsOk,
                    dashboardOk,
                    odorOk,
                    interiorNotes
                    );
            }
            else
            {
                return null;
            }
        }

     
        private bool _AddNewInteriorCheck()
        {
            this.InteriorCheckID = clsInteriorChecksData.AddNewInteriorCheck(
                this.SeatsOk, this.DashboardOk, this.OdorOk, this.InteriorNotes);

            return (this.InteriorCheckID != -1);
        }

       private bool _UpdateInteriorCheck()
       {
           return clsInteriorChecksData.UpdateInteriorCheck(this.InteriorCheckID, this.SeatsOk, this.DashboardOk,
               this.OdorOk, this.InteriorNotes);
       }

        public bool Delete()
        {
            return clsInteriorChecksData.Delete(this.InteriorCheckID);
        }

        public static bool Delete(int InteriorCheckID)
        {
            return clsInteriorChecksData.Delete(InteriorCheckID);
        }

        public bool Save()
        {
            bool isSuccess = false;

            if (_Mode == enMode.Add)
            {
                isSuccess = _AddNewInteriorCheck();
                if (isSuccess)
                {
                    _Mode = enMode.Edit;
                }
            }
            else if (_Mode == enMode.Edit)
            {
                isSuccess = _UpdateInteriorCheck();
            }

            return isSuccess;
        }

    }
}
