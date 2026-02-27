using RVS_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_Business_Layer
{
    public class clsBodies
    {

        public int BodyID { get; set; }
        public string BodyName { get; set; }

        public static DataTable GetAllBodies()
        {
            return clsBodiesData.GetAllBodies();
        }

        private clsBodies(int bodyID, string bodyName)
        {
            this.BodyID = bodyID;
            this.BodyName = bodyName;
        }

        public static clsBodies GetByID(int BodyID)
        {
            string bodyName = string.Empty;
            bool isFound = clsBodiesData.GetBodyInfoByID(BodyID, ref bodyName);
            if (isFound)
            {
                return new clsBodies(BodyID, bodyName);
            }
            else
            {
                return null;

            }
        }

        public static clsBodies GetByName(string BodyName)
        {
            int bodyID = -1;
            bool isFound = clsBodiesData.GetBodyInfoByName(BodyName, ref bodyID);
            if (isFound)
            {
                return new clsBodies(bodyID, BodyName);
            }
            else
            {
                return null;

            }
        }
    }
}
