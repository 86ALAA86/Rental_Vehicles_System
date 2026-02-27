using RVS_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_Business_Layer
{
    public class clsFuelType
    {



        public int FuelID { get; set; }
        public string FuelName { get; set; }

        public static DataTable GetAllFuelTypes()
        {
            return clsFuelTypeData.GetAllFuelTypes();
        }

        private clsFuelType(int FuelID, string FuelName)
        {
            this.FuelID = FuelID;
            this.FuelName = FuelName;
        }

        public static clsFuelType GetByID(int FuelID)
        {
            string FuelName = string.Empty;
            bool isFound = clsFuelTypeData.GetFuelInfoByID(FuelID, ref FuelName);
            if (isFound)
            {
                return new clsFuelType(FuelID, FuelName);
            }
            else
            {
                return null;

            }
        }

        public static clsFuelType GetByName(string FuelName)
        {
            int FuelID = -1;
            bool isFound = clsFuelTypeData.GetFuelInfoByName(FuelName, ref FuelID);
            if (isFound)
            {
                return new clsFuelType(FuelID, FuelName);
            }
            else
            {
                return null;

            }
        }




    }
}
