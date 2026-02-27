using Guna.UI2.WinForms;
using Rental_Vehicles_System.Global;
using Rental_Vehicles_System.Properties;
using RVS_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_Vehicles_System.People
{
    public partial class frmAddEditPerson : Form
    {

        public EventHandler<clsPerson> PersonAdded;

        protected virtual void OnPersonAdded(clsPerson PersonInfo)
        {
            PersonAdded?.Invoke(this, PersonInfo);
        }



        enum enMode { AddNew = 0, Edit = 1 }
        public frmAddEditPerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Mode = enMode.Edit;
        }


        private int _PersonID;
        private clsPerson _Person;
        private enMode _Mode = enMode.AddNew;


        private void _LoadDefaultData()
        {
            _LoadCountriesInComboBox();

            _Person = new clsPerson();

           
            pbPersonImage.Image = Resources.Userpng;


            guna2Panel1.BackgroundImage =
                guna2Panel1.BackgroundImage =
                Resources.ChatGPT_Image_Nov_24__2025__08_20_19_PM;

            lblFormTitle.Text = lblFormTitle.Text = "Add New Person";

        }

        private void _LoadCountriesInComboBox()
        {
            DataTable dt = clsCountry.GetAllCountries();
            foreach (DataRow dr in dt.Rows)
            {
                cbCountries.Items.Add(dr[1].ToString());
            }
        }

        private void _LoadUserData()
        {
            _Person = clsPerson.Find(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("Person With ID = " + _PersonID.ToString() + " Was Not Found",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           

            guna2Panel1.BackgroundImage =
                guna2Panel1.BackgroundImage =
                Resources.Edit_User;

            lblFormTitle.Text = lblFormTitle.Text = "Edit User";

            btnSave.Enabled = true;

            txtFirstName.Text = _Person.FirstName.ToString();
            txtLastName.Text = _Person.LastName.ToString();
            txtEmail.Text = _Person.Email.ToString();
            txtNationalNumber.Text = _Person.NationalNumber.ToString();
            txtAddress.Text = _Person.Address.ToString();
            txtPhone.Text = _Person.Phone.ToString();
            cbCountries.SelectedIndex = cbCountries.FindString((_Person.CountryInfo.CountryName));
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            if (_Person.Gender == 1)
            {
                rbMale.Checked = true;
                rbFemale.Checked = false;
            }
            else
            {
                rbMale.Checked = false;
                rbFemale.Checked = true;
            }

            if (_Person.ImagePath != "")
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }
            else
            {
                pbPersonImage.Image = Resources.Userpng;


            }

           

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _LoadDefaultData();
            if (_Mode == enMode.Edit)
                _LoadUserData();

        }

        private bool _HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (pbPersonImage.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }

        private void llsetPicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.ImageLocation = (selectedFilePath);
                llDeletePicture.Visible = true;
                // ...
            }

        }

        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            Guna2TextBox tb = sender as Guna2TextBox;

            if (!tb.Enabled)
            {
                return;
            }

            ErrorProvider er = new ErrorProvider();

            if (string.IsNullOrEmpty(tb.Text))
            {
                er.SetError(tb, "This Field Can Not Be Empty");
                e.Cancel = true;
            }
            else
            {
                er.SetError(tb, "");
                e.Cancel = false;
            }

        }

        private void cbCountries_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider er = new ErrorProvider();
            if (cbCountries.SelectedIndex == -1)
            {
                er.SetError(cbCountries, "Please Chose a Country.");
                e.Cancel = true;
            }
            else
            {
                er.SetError(cbCountries, null);
                e.Cancel = false;
            }

        }

        private void llDeletePicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = "";
            pbPersonImage.Image = Resources.Userpng;
            llDeletePicture.Visible = false;

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider er = new ErrorProvider();
            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                er.SetError(txtEmail, "Email is Not in Right Format.");
                e.Cancel = true;
            }
            else
            {
                er.SetError(txtEmail, null);
                e.Cancel = false;
            }
        }

        private void txtNationalNumber_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider er = new ErrorProvider();
            if (_Mode == enMode.Edit)
            {
                return;
            }
            if (clsPerson.isPersonExist(txtNationalNumber.Text))
            {
                er.SetError(txtNationalNumber, "There Is A Person With This National Number, Try Another One.");
                e.Cancel = true;
            }
            else
            {
                er.SetError(txtNationalNumber, null);
                e.Cancel = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("There is Some Messing Values, " +
               "Please Enter a Value In TextBox Near The RedMark.", "Error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                this.Close();


            }

            if (!_HandlePersonImage())
            {
                MessageBox.Show("Person Was Not Saved, An Error Occored", "Error", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
                this.Close();


            }

            _Person.FirstName = txtFirstName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.Address = txtAddress.Text;
            _Person.Phone = txtPhone.Text;
            _Person.Email = txtEmail.Text;
            _Person.NationalNumber = txtNationalNumber.Text;
            _Person.Gender = (rbMale.Checked) ? Convert.ToByte(1) : Convert.ToByte(0);
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.NationalityID = clsCountry.Find(cbCountries.Text).ID;
            _Person.ImagePath = (pbPersonImage.Image == Resources.Userpng) ? "" : pbPersonImage.ImageLocation;
            _Person.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (!_Person.Save())
            {
                MessageBox.Show("Person Was Not Saved, An Error Occored", "Error", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
                this.Close();


            }
            MessageBox.Show("Person Was Saved, Operation Done Successfully", "Done", MessageBoxButtons.OK,
             MessageBoxIcon.Information);
            OnPersonAdded(_Person);
            this.Close();

        }


    }
}
