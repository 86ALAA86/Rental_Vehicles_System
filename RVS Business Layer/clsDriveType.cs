using RVS_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_Business_Layer
{
    public class clsDriveType
    {


        public int DriveTypeID { get; set; }
        public string DriveName { get; set; }

        public static DataTable GetAllDriveTypes()
        {
            return clsDriveTypeData.GetAllDriveTypes();
        }

        private clsDriveType(int DriveTypeID, string DriveName)
        {
            this.DriveTypeID = DriveTypeID;
            this.DriveName = DriveName;
        }

        public static clsDriveType GetByID(int DriveTypeID)
        {
            string DriveName = string.Empty;
            bool isFound = clsDriveTypeData.GetDriveTypeInfoByID(DriveTypeID, ref DriveName);
            if (isFound)
            {
                return new clsDriveType(DriveTypeID, DriveName);
            }
            else
            {
                return null;

            }
        }

        public static clsDriveType GetByName(string DriveName)
        {
            int DriveTypeID = -1;
            bool isFound = clsDriveTypeData.GetDriveTypeInfoByName(DriveName, ref DriveTypeID);
            if (isFound)
            {
                return new clsDriveType(DriveTypeID, DriveName);
            }
            else
            {
                return null;

            }
        }




    }
}
