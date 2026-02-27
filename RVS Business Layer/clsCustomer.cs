using RVS_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_Business_Layer
{
     public class clsCustomer
    {

       public enum enMode
        {
            AddNew=0, Edit=1
        }
        
        public int CustomerID { get; set; }
        public int PersonID { get; set; }   
        public clsPerson PersonInfo { get; set; }
        public string DriverLicenseNumber { get; set; } 
        public int CreatedByUserID { get; set; } 
        public clsUser UserInfo { get; set; }

        public enMode _Mode =enMode.AddNew;

        public clsCustomer()
        {
            this.CustomerID = -1;
            this.PersonID = -1;
            this.PersonInfo = new clsPerson();
            this.DriverLicenseNumber = string.Empty;
            this.CreatedByUserID =-1;
            this.UserInfo = new clsUser();
            _Mode = enMode.AddNew;
        }

        public clsCustomer(int customerID, int personID, string driverLicenseNumber, int createdByUserID)
        {
            this.CustomerID = customerID;
            this.PersonID = personID;
            this.PersonInfo =clsPerson.Find(personID);
            this.DriverLicenseNumber = driverLicenseNumber;
            this.CreatedByUserID = createdByUserID;
            this.UserInfo = clsUser.FindByUserID(createdByUserID);
            _Mode = enMode.Edit;
        }

        public static DataTable GetAllCustomers()
        {
            return clsCustomerData.GetAllCustomer();
        }

        public static DataTable GetAllCustomerBooks(int CustomerID)
        {
            return clsCustomerData.GetAllCustomerBooks(CustomerID);
        }

        public static bool DeleteCustomer(int customerID)
        {
            return clsCustomerData.DeleteCustomer(customerID);
        }

        public static bool IsCustomerExistByPersonID(int PersonID)
        {
            return clsCustomerData.IsCustomerExistByPersonID(PersonID);
        }

        public static bool IsCustomerExistByCustomerID(int CustomerID)
        {
            return clsCustomerData.IsCustomerExistByCustomerID(CustomerID);
        }

        public static clsCustomer FindByLicenseNumber(string LicenseNumber)
        {
            int PersonID = -1; int CreatedByUserID = -1;
            int CustomerID = -1;
            if (clsCustomerData.GetCustomerInfoByDriverLicenseNumber
                ( LicenseNumber,ref CustomerID, ref PersonID, ref CreatedByUserID))
            {
                return new clsCustomer(CustomerID, PersonID,LicenseNumber, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }
        private bool _AddNewCustomer()
        {
            this.CustomerID = clsCustomerData.AddNewCustomer(this.PersonID, this.DriverLicenseNumber, this.CreatedByUserID);
            return (this.CustomerID != -1);
        }

        private bool _UpdateCustomer()
        {
            return clsCustomerData.UpdateCustomer
                (this.CustomerID, this.PersonID, this.DriverLicenseNumber, this.CreatedByUserID);
        }

        public static clsCustomer FindByCustomerID(int CustomerID)
        {
            int PersonID = -1;int CreatedByUserID = -1;
            string DriverLicenseNumber = "";
            if(clsCustomerData.GetCustomerInfoByCustomerID
                (CustomerID,ref PersonID,ref DriverLicenseNumber,ref CreatedByUserID))
            {
                return new clsCustomer(CustomerID,PersonID,DriverLicenseNumber,CreatedByUserID);
            }    
            else
            {
                return null;
            }

        }

        public static clsCustomer FindByPersonID(int PersonID)
        {
            int CustomerID = -1; int CreatedByUserID = -1;
            string DriverLicenseNumber = "";
            if (clsCustomerData.GetCustomerInfoByPersonID
                ( PersonID,ref CustomerID, ref DriverLicenseNumber, ref CreatedByUserID))
            {
                return new clsCustomer(CustomerID, PersonID, DriverLicenseNumber, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        public bool Save()
        {
            this.PersonInfo.Mode = (clsPerson.enMode)this._Mode;
            if (!this.PersonInfo.Save())
            {
                return false;
            }
            this.PersonID = this.PersonInfo.PersonID;

            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCustomer())
                    {

                        _Mode = enMode.Edit;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Edit:

                    return _UpdateCustomer();

            }

            return false;
        }

        public static bool IsCustomerExistByDriverLicenseNumber(string DriverLicenseNumber)
        {
            return clsCustomerData.IsCustomerExistByDriverLicenseNumber(DriverLicenseNumber);
        }
    }
}
