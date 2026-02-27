using RVS_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_Business_Layer
{
    public class clsEngine

    {

        public int EngineID { get; set; }
        public string EngineName { get; set; }

        public static DataTable GetAllEngines()
        {
            return clsEnginesData.GetAllEngines();
        }

        private clsEngine(int EngineID, string EngineName)
        {
            this.EngineID = EngineID;
            this.EngineName = EngineName;
        }

        public static clsEngine GetByID(int EngineID)
        {
            string EngineName = string.Empty;
            bool isFound = clsEnginesData.GetEngineInfoByID(EngineID, ref EngineName);
            if (isFound)
            {
                return new clsEngine(EngineID, EngineName);
            }
            else
            {
                return null;

            }
        }

        public static clsEngine GetByName(string EngineName)
        {
            int EngineID = -1;
            bool isFound = clsEnginesData.GetEngineInfoByName(EngineName, ref EngineID);
            if (isFound)
            {
                return new clsEngine(EngineID, EngineName);
            }
            else
            {
                return null;

            }
        }
    }
}
