using RVS_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_Business_Layer
{
    public class clsPaymentMethods

    {

        public int MethodID { get; set; }
        public string MethodName { get; set; }

        

        public static DataTable GetAllPaymentMethods()
        {
            return clsPaymentMethodsData.GetAllPaymentMethods();
        }

        private clsPaymentMethods(int methodID, string methodName)
        {
            this.MethodID = methodID;
            this.MethodName = methodName;
        }

        public static clsPaymentMethods GetByID(int MethodID)
        {
            string methodName = string.Empty;
            bool isFound = clsPaymentMethodsData.GetPaymentInfoByID(MethodID, ref methodName);
            if (isFound)
            {
                return new clsPaymentMethods(MethodID, methodName);
            }
            else
            {
                return null;

            }
        }

        public static clsPaymentMethods GetByName(string MethodName)
        {
            int methodID = -1;
            bool isFound = clsPaymentMethodsData.GetPaymentInfoByName(MethodName, ref methodID);
            if (isFound)
            {
                return new clsPaymentMethods(methodID, MethodName);
            }
            else
            {
                return null;

            }
        }
    }
}
