using RVS_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_Business_Layer
{
    public class clsEngineBlockType
    {


        public int EngineBlockTypeID { get; set; }
        public string BlockName { get; set; }

        public static DataTable GetAllEngineBlockTypes()
        {
            return clsEngineBlockTypeData.GetAllEngineBlockTypes();
        }

        private clsEngineBlockType(int EngineBlockTypeID, string BlockName)
        {
            this.EngineBlockTypeID = EngineBlockTypeID;
            this.BlockName = BlockName;
        }

        public static clsEngineBlockType GetByID(int EngineBlockTypeID)
        {
            string BlockName = string.Empty;
            bool isFound = clsEngineBlockTypeData.GetBlockTypeInfoByID(EngineBlockTypeID, ref BlockName);
            if (isFound)
            {
                return new clsEngineBlockType(EngineBlockTypeID, BlockName);
            }
            else
            {
                return null;

            }
        }

        public static clsEngineBlockType GetByName(string BlockName)
        {
            int EngineBlockTypeID = -1;
            bool isFound = clsEngineBlockTypeData.GetBlockTypeInfoByName(BlockName, ref EngineBlockTypeID);
            if (isFound)
            {
                return new clsEngineBlockType(EngineBlockTypeID, BlockName);
            }
            else
            {
                return null;

            }
        }




    }
}
