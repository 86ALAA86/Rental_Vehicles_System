using RVS_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_Business_Layer
{
    public class clsAspiration
    {

        public int AspirationID { get; set; }
        public string AspirationName { get; set; }

        public static DataTable GetAllAspirations()
        {
            return clsAspirationData.GetAllAspirations();
        }

        private clsAspiration(int aspirationID, string aspirationName)
        {
            this.AspirationID = aspirationID;
            this.AspirationName = aspirationName;
        }

        public static clsAspiration GetByID(int AspirationID)
        {
            string AspirationName = string.Empty;
            bool isFound = clsAspirationData.GetAspirationsInfoByID(AspirationID, ref AspirationName);
            if (isFound)
            {
                return new clsAspiration(AspirationID, AspirationName);
            }
            else
            {
                return null;

            }
        }

        public static clsAspiration GetByName(string AspirationName)
        {
            int aspirationID = -1;
            bool isFound = clsAspirationData.GetAspirationsInfoByName(AspirationName, ref aspirationID);
            if (isFound)
            {
                return new clsAspiration(aspirationID, AspirationName);
            }
            else
            {
                return null;

            }
        }


    }
}
