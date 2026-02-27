using RVS_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_Business_Layer
{
    public class clsCylinderType
    {


        public int CylinerTypeID { get; set; }
        public string CylinderName { get; set; }

        public static DataTable GetAllCylinderTypes()
        {
            return clsCylinderTypeData.GetAllCylinderTypes();
        }

        private clsCylinderType(int cylinderTypeID, string cylinderName)
        {
            this.CylinerTypeID = cylinderTypeID;
            this.CylinderName = cylinderName;
        }

        public static clsCylinderType GetByID(int CylinerTypeID)
        {
            string CylinderName = string.Empty;
            bool isFound = clsCylinderTypeData.GetCylinderTypeInfoByID(CylinerTypeID, ref CylinderName);
            if (isFound)
            {
                return new clsCylinderType(CylinerTypeID, CylinderName);
            }
            else
            {
                return null;

            }
        }

        public static clsCylinderType GetByName(string CylinderName)
        {
            int cylinderTypeID = -1;
            bool isFound = clsCylinderTypeData.GetCylinderInfoByName(CylinderName, ref cylinderTypeID);
            if (isFound)
            {
                return new clsCylinderType(cylinderTypeID, CylinderName);
            }
            else
            {
                return null;

            }
        }


    }
}
