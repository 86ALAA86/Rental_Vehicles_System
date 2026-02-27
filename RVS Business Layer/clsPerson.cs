using RVS_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_Business_Layer
{


    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PersonID { set; get; }
        public string FirstName { set; get; }
    
        public string LastName { set; get; }
        public string FullName
        {
            get { return FirstName+ " " + LastName; }

        }
        public string NationalNumber { set; get; }
        public DateTime DateOfBirth { set; get; }
        public byte Gender { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int CreatedByUserID { set; get; }
        public int NationalityID { set; get; }


         public clsCountry CountryInfo;

        private string _ImagePath;

        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }

        public clsPerson()

        {
            this.PersonID = -1;
            this.FirstName = "";
            this.Gender = 1;
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityID = -1;
            this.ImagePath = "";
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsPerson(int PersonID, string FirstName, string LastName,
             string Email, string Address, string Phone, byte Gender, string NationalNumber,
             DateTime DateOfBirth, int CreatedByUserID, int NationalityID, string ImagePath)

        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;    
            this.LastName = LastName;
            this.NationalNumber = NationalNumber;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityID = NationalityID;
            this.ImagePath = ImagePath;
            this.CreatedByUserID = CreatedByUserID;
            this.CountryInfo = clsCountry.Find(NationalityID);
            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            //call DataAccess Layer 

            this.PersonID = clsPersonData.AddNewPerson( this.FirstName, this.LastName, this.
            Email, this.Address, this.Phone, this.Gender, this.NationalNumber, this.
            DateOfBirth, this.CreatedByUserID, this.NationalityID, this.ImagePath);

            return (PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return clsPersonData.UpdatePerson(this.PersonID,this.FirstName, this.LastName, this.
            Email, this.Address, this.Phone, this.Gender, this.NationalNumber, this.
            DateOfBirth, this.CreatedByUserID, this.NationalityID, this.ImagePath);
        }

        public static clsPerson Find(int PersonID)
        {

            string FirstName = "",  LastName = "", NationalNumber = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int NationalityID = -1, CreatedByUserID = -1;
            byte Gender = 0;

            bool IsFound = clsPersonData.GetPersonInfoByID(PersonID,ref FirstName,ref LastName,ref Email,ref Address,ref Phone,ref Gender,ref NationalNumber,ref
                DateOfBirth,ref CreatedByUserID,ref NationalityID,ref ImagePath);

            if (IsFound)
                //we return new object of that person with the right data
                return new clsPerson(PersonID,  FirstName,  LastName,
              Email,  Address,  Phone,  Gender,  NationalNumber,
              DateOfBirth,  CreatedByUserID,  NationalityID,  ImagePath);
            else
                return null;
        }

        public static clsPerson Find(string NationalNumber)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int NationalityID = -1, CreatedByUserID = -1,PersonID=-1;
            byte Gender = 0;

            bool IsFound = clsPersonData.GetPersonInfoByNationalNo
                                (
                                 NationalNumber,ref PersonID, ref FirstName, ref LastName,
                                 ref Email, ref Address, ref Phone, ref Gender,ref
                                 DateOfBirth, ref CreatedByUserID, ref NationalityID,
                                 ref ImagePath
                                );

            if (IsFound)

                return new clsPerson(PersonID, FirstName, LastName,
               Email, Address, Phone, Gender, NationalNumber,
               DateOfBirth, CreatedByUserID, NationalityID, ImagePath);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }

            return false;
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

        public  bool DeletePerson()
        {
            return clsPersonData.DeletePerson(this.PersonID);
        }

       

        public static bool isPersonExist(int ID)
        {
            return clsPersonData.IsPersonExist(ID);
        }

        public static bool isPersonExist(string NationlNo)
        {
            return clsPersonData.IsPersonExist(NationlNo);
        }

    }



}
