using Rental_Vehicles_System.Properties;
using RVS_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_Vehicles_System.Users
{
    public partial class ctrlShowPersonInfo : UserControl
    {
        public ctrlShowPersonInfo()
        {
            InitializeComponent();
        }

        private clsPerson _Person =new clsPerson();
        public clsPerson PersonInfo { get { return _Person; } }
        public void LoadPersonInfo(int personId)
        {
            _Person = clsPerson.Find(personId);
            if(PersonInfo == null)
            {
                MessageBox.Show("Person Was Not Found ,Try Again .","Error",MessageBoxButtons.OK
                    ,MessageBoxIcon.Error);
                return;
            }
            lblPersonID.Text = personId.ToString();
            lblAddress.Text = PersonInfo.Address;
            lblDateOfBirth.Text = PersonInfo.DateOfBirth.ToShortDateString();
            lblEamil.Text=PersonInfo.Email;
            lblFirstName.Text = PersonInfo.FirstName;
            lblLastName.Text = PersonInfo.LastName;
            lblNationalNo.Text=PersonInfo.NationalNumber;
            lblGender.Text = (PersonInfo.Gender == 1) ? "Male" : "Female";
            lblPhone.Text = PersonInfo.Phone;
            lblNationlity.Text = PersonInfo.CountryInfo.CountryName;
            
            if(PersonInfo.ImagePath != "" )
            {
                pbPersonImage.ImageLocation=PersonInfo.ImagePath;
            }
            else
            {
                pbPersonImage.Image = Resources.Userpng;
            }


        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            if (PersonInfo == null)
            {
                MessageBox.Show("Person Was Not Found ,Try Again .", "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return;
            }
            lblPersonID.Text = PersonInfo.PersonID.ToString();
            lblAddress.Text = PersonInfo.Address;
            lblDateOfBirth.Text = PersonInfo.DateOfBirth.ToShortDateString();
            lblEamil.Text = PersonInfo.Email;
            lblFirstName.Text = PersonInfo.FirstName;
            lblLastName.Text = PersonInfo.LastName;
            lblNationalNo.Text = PersonInfo.NationalNumber;
            lblGender.Text = (PersonInfo.Gender == 1) ? "Male" : "Female";
            lblPhone.Text = PersonInfo.Phone;
            lblNationlity.Text = PersonInfo.CountryInfo.CountryName;

            if (PersonInfo.ImagePath != "")
            {
                pbPersonImage.ImageLocation = PersonInfo.ImagePath;
            }
            else
            {
                pbPersonImage.Image = Resources.Userpng;
            }


        }

        public void LoadDefaultInfo()
        {

            lblPersonID.Text = "????";
            lblAddress.Text = "????";
            lblDateOfBirth.Text = "????";
            lblEamil.Text = "????";
            lblFirstName.Text = "????";
            lblLastName.Text = "????";
            lblNationalNo.Text = "????";
            lblGender.Text = "????";
            lblPhone.Text = "????";
            lblNationlity.Text =  "????";


            pbPersonImage.Image = Resources.Userpng;



        }

    }
}
