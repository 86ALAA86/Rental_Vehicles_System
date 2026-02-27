using RVS_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_Business_Layer
{
    public class clsMake
    {

        public int MakeID { get; set; }
        public string MakeName { get; set; }

        public static DataTable GetAllMakes()
        {
            return clsMakeData.GetAllMakes();
        }

        private clsMake(int makeID, string makeName)
        {
            this.MakeID = makeID;
            this.MakeName = makeName;
        }

        public static clsMake GetByID(int MakeID)
        {
            string MakeName = string.Empty;
            bool isFound = clsMakeData.GetMakeInfoByID(MakeID, ref MakeName);
            if (isFound)
            {
                return new clsMake(MakeID, MakeName);
            }
            else
            {
                return null;

            }
        }

        public static clsMake GetByName(string MakeName)
        {
            int makeID = -1;
            bool isFound = clsMakeData.GetMakeInfoByName(MakeName, ref makeID);
            if (isFound)
            {
                return new clsMake(makeID, MakeName);
            }
            else
            {
                return null;

            }
        }



    }
}
