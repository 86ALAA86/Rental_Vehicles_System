using Guna.UI2.WinForms;
using Rental_Vehicles_System.Customers;
using Rental_Vehicles_System.Global;
using Rental_Vehicles_System.People;
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

namespace Rental_Vehicles_System.Rental_Booking
{
    public partial class frmAddEditRentalBooking : Form
    {

        enum enMode { AddNew,Update}

        public frmAddEditRentalBooking()
        {
            InitializeComponent();
            _RentalBookingID = -1;
            _Mode = enMode.AddNew;
        }

        public frmAddEditRentalBooking(int RentalID)
        {
            InitializeComponent();
            _RentalBookingID = RentalID;
            _Mode = enMode.Update;
        }

        private enMode _Mode =enMode.AddNew;

        private int _RentalBookingID;

        private clsRentalBooking _Booking = new clsRentalBooking();


        private void _LoadDefaultValues()
        {
            lblFormTitle.Text = "Book A New Vehicle";
            ctrlShowVehicleInfoWithFilter1.LoadDefaultValues();
            _LoadCustomerDefaultData();
            _LoadPaymentMethodsInComboBox();

            btnNextToBooking.Enabled = false;
            btnSave.Enabled = false;
            dtpEndDate.Enabled = false;
            dtpStartDate.Enabled = false;
            txtDropoff.Enabled = false;
            txtPickUpLoc.Enabled = false;
            cbPaymentMethods.Enabled = false;

            txtDropoff.Clear();
            txtPickUpLoc.Clear();
            //dtpEndDate.Value = DateTime.Now;
            //dtpStartDate.Value = DateTime.Now;

            lblPricePerDay.Text = ctrlShowVehicleInfoWithFilter1.VehicleInfo.RentalPricePerDay.ToString();
            lblAmount.Text = "???";
            lblCustomer.Text = txtFirstName.Text + " " + txtLastName.Text;
            lblVehicle.Text = ctrlShowVehicleInfoWithFilter1.VehicleInfo.Model.ToString();
            lblBookID.Text = "???";
            lblUser.Text = clsGlobal.CurrentUser.UserName;
            
            dtpStartDate.MinDate = DateTime.Now;
            dtpEndDate.MinDate = dtpStartDate.MinDate;

            cbPaymentMethods.SelectedIndex = -1;

            _Booking = new clsRentalBooking();

        }
        private void _LoadBookingInfo()
        {
            lblFormTitle.Text = "Edit Booked Vehicle";
            _Booking= clsRentalBooking.Find(_RentalBookingID);
            if( _Booking == null )
            {
                MessageBox.Show("Rental Booking With ID :"+_RentalBookingID.ToString()+
                    " Was Not Found .","Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlShowVehicleInfoWithFilter1.LoadVehicleValues(_Booking.VehicleID);
            _LoadCustomerData(null,_Booking.CustomerInfo);

            btnNextToBooking.Enabled = true ;
            btnSave.Enabled = true;
            dtpEndDate.Enabled = true;
            dtpStartDate.Enabled = true;
            txtDropoff.Enabled = true;
            txtPickUpLoc.Enabled = true;
            cbPaymentMethods.Enabled = true;

            lblPricePerDay.Text =_Booking.RentalPricePerDay.ToString();
            lblAmount.Text = _Booking.InitialTotalDueAmount.ToString();
            lblCustomer.Text = _Booking.CustomerInfo.PersonInfo.FirstName;
            lblVehicle.Text = _Booking.VehicleInfo.Model ;
            lblBookID.Text = _Booking.BookingID.ToString();
            lblUser.Text = clsGlobal.CurrentUser.UserName;


            txtDropoff.Text = _Booking.DropoffLocation;
            txtPickUpLoc.Text = _Booking.PickupLocation;

            dtpStartDate.MinDate = _Booking.RentalStartDate.AddDays(-7);
            dtpStartDate.Value = _Booking.RentalStartDate;
            dtpEndDate.MinDate =dtpStartDate.Value ;
            dtpEndDate.Value = _Booking.RentalEndDate;

            cbPaymentMethods.SelectedIndex =
                cbPaymentMethods.FindString(clsRentalTransaction.FindByBookingID(_Booking.BookingID).PaymentMethodInfo.MethodName);

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (ctrlShowVehicleInfoWithFilter1.VehicleInfo.VehicleID != -1 &&
               ctrlShowVehicleInfoWithFilter1.VehicleInfo != null)
            {
                guna2TabControl1.SelectedIndex = 1;
                btnNextToBooking.Enabled = true;
            }
            else
            {
                MessageBox.Show("Please Chose A Vehicle First ", "Caution",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnNextToBooking_Click(object sender, EventArgs e)
        {


            if (!this.ValidateChildren())
            {
                MessageBox.Show("There is Some Messing Values, " +
               "Please Enter a Value In TextBox Near The RedMark.", "Error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            else
            {
                guna2TabControl1.SelectedIndex = 2;
                dtpEndDate.Enabled=true;
                dtpStartDate.Enabled=true;
                txtDropoff.Enabled=true;
                txtPickUpLoc.Enabled=true;
                cbPaymentMethods.Enabled = true;

                lblPricePerDay.Text = ctrlShowVehicleInfoWithFilter1.VehicleInfo.RentalPricePerDay.ToString();
                lblCustomer.Text = txtFirstName.Text+" "+txtLastName.Text;
                lblVehicle.Text = ctrlShowVehicleInfoWithFilter1.VehicleInfo.Model.ToString();
                lblUser.Text = clsGlobal.CurrentUser.UserName;

                btnSave.Enabled= true;  

            }

           

        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            // Ensure both dates are valid
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

           

            // Calculate the number of days (absolute value to avoid negatives)
            int rentDays = Math.Abs((endDate - startDate).Days);
            lblRentDays.Text = rentDays.ToString();

            // Parse price per day safely
            if (int.TryParse(lblPricePerDay.Text, out int pricePerDay))
            {
                lblAmount.Text = (rentDays * pricePerDay).ToString();
                
            }
            else
            {
                lblAmount.Text = "0"; // or show an error message
            }
        }

        private void frmAddEditRentalBooking_Load(object sender, EventArgs e)
        {
            _LoadDefaultValues();
            if (_Mode == enMode.Update)
            {
                _LoadBookingInfo();
            }
        }

        private void txtPickUpLoc_Validating(object sender, CancelEventArgs e)
        {

            ErrorProvider er = new ErrorProvider();
            Guna2TextBox txt = sender as Guna2TextBox;

            if (!txt.Enabled)
            {
                return;
            }

            if (string.IsNullOrEmpty(txt.Text))
            {
                er.SetError(txt, "Can Not Be Empty");
                e.Cancel = true;
            }
            else
            {
                er.SetError(txt, null);
                e.Cancel = false;
            }
        }

        private void dtpEndDate_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider er = new ErrorProvider();

            if (!dtpEndDate.Enabled)
            {
                return;
            }

            if(dtpEndDate.Value.Date<dtpStartDate.Value.Date)
            {
                er.SetError(dtpEndDate, "End Date Can Not Be Before Start Date");
                e.Cancel= true;
            }
            else
            {
                er.SetError(dtpEndDate, null);
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
                return;
            }

            if (!_HandlePersonImage())
            {
                return; 
            }

            _Booking.VehicleID = ctrlShowVehicleInfoWithFilter1.VehicleInfo.VehicleID;
            _Booking.RentalStartDate = dtpStartDate.Value;
            _Booking.RentalEndDate = dtpEndDate.Value;
            _Booking.DropoffLocation=txtDropoff.Text;
            _Booking.PickupLocation=txtPickUpLoc.Text;
            _Booking.RentalPricePerDay = ctrlShowVehicleInfoWithFilter1.VehicleInfo.RentalPricePerDay;
            _Booking.InitialCheckID=ctrlShowVehicleInfoWithFilter1.VehicleInfo.CurrentCheckID;
            _Booking.CreatedByUserID=clsGlobal.CurrentUser.UserID;

            _Booking.CustomerInfo.DriverLicenseNumber = txtDLN.Text;
            _Booking.CustomerInfo.CreatedByUserID= clsGlobal.CurrentUser.UserID;

            _Booking.CustomerInfo.PersonInfo.FirstName=txtFirstName.Text;
            _Booking.CustomerInfo.PersonInfo.LastName=txtLastName.Text;
            _Booking.CustomerInfo.PersonInfo.Phone=txtPhone.Text;
            _Booking.CustomerInfo.PersonInfo.DateOfBirth=dtpDateOfBirth.Value;
            _Booking.CustomerInfo.PersonInfo.Email=txtEmail.Text;
            _Booking.CustomerInfo.PersonInfo.Address=txtAddress.Text;
            _Booking.CustomerInfo.PersonInfo.NationalityID=clsCountry.Find( cbCountries.Text).ID;
            _Booking.CustomerInfo.PersonInfo.NationalNumber = txtNationalNumber.Text;
            _Booking.CustomerInfo.PersonInfo.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _Booking.CustomerInfo.PersonInfo.Gender = (rbMale.Checked) ? Convert.ToByte(1) : Convert.ToByte(0);
            _Booking.CustomerInfo.PersonInfo.ImagePath = pbPersonImage.ImageLocation;
            _Booking.CustomerInfo.CustomerID = Convert.ToInt32(lblCustomerID.Text);
            _Booking.CustomerInfo.PersonInfo.PersonID = clsCustomer.FindByCustomerID(Convert.ToInt32(lblCustomerID.Text)).PersonID;


            clsRentalTransaction Transaction = new clsRentalTransaction();

            Transaction.BookingID = _Booking.BookingID;
            Transaction.ReturnID = -1;
            Transaction.PaymentNotes = "";
            Transaction.PaidInitialTotalDueAmount = Convert.ToSingle(lblAmount.Text);
            Transaction.ActualTotalDueAmount = Transaction.PaidInitialTotalDueAmount;
            Transaction.TotalRemaining = 0;
            Transaction.TotalRefundedAmount = 0;
            Transaction.TransactionDate = DateTime.Now.Date;
            Transaction.UpdatedTransactionDate = DateTime.MinValue.Date;
            Transaction.PaymentMethodID = clsPaymentMethods.GetByName(cbPaymentMethods.Text).MethodID ;
            Transaction.CreatedByUserID = clsGlobal.CurrentUser.UserID;


            //الزبون عم ينحفظ مرة تانية لم اعمل اختيار=
            if (_Mode==enMode.AddNew&&IsSelectedCustomer)
            {
                _Booking.CustomerInfo._Mode = clsCustomer.enMode.Edit;
            }
            else
            {
                _Booking.CustomerInfo._Mode = (clsCustomer.enMode)_Booking._Mode;
            }


            if (_Booking.Save() || ctrlShowVehicleInfoWithFilter1.VehicleInfo.RentVehicle())
            {
                Transaction.BookingID=_Booking.BookingID;
              

                if (Transaction.Save())
                {
                    MessageBox.Show("Rental Booking Was Saved, Operation Done Successfully", "Done", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                }
            

            }
            else
            {
                MessageBox.Show("Rental Booking  Was Not Saved, An Error Occored", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }


            lblBookID.Text = _Booking.CustomerID.ToString();
            lblCustomerID.Text=_Booking.CustomerID.ToString();
            this.Close();
        }   

        private void btnPickCustomer_Click(object sender, EventArgs e)
        {
            frmSearchForCustomers frm = new frmSearchForCustomers();
            frm.CustomerFound += _LoadCustomerData;
            frm.ShowDialog();
        }


        ///////////////////////////
        ///

        private void _LoadCustomerDefaultData()
        {
            _LoadCountriesInComboBox();

            IsSelectedCustomer = false;
            OriginalDate = DateTime.Now.Date;
            CountryIndex = -1;
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtNationalNumber.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            cbCountries.SelectedIndex = -1;
            dtpDateOfBirth.Value = DateTime.Now.Date;

            rbFemale.Enabled = true;
            rbMale.Enabled = true ;

            txtDLN.Clear();
            txtCDLN.Clear();

            llsetPicture.Visible = true;
            llDeletePicture.Visible = false;

            lblCustomerID.Text = (-1).ToString();

            pbPersonImage.Image = Resources.Userpng;
   
                CustomerPanel.BackgroundImage =
                Resources.ChatGPT_Image_Nov_24__2025__08_20_19_PM;

        }

        private void _LoadCountriesInComboBox()
        {
            DataTable dt = clsCountry.GetAllCountries();
            foreach (DataRow dr in dt.Rows)
            {
                cbCountries.Items.Add(dr[1].ToString());
            }
        }

        private void _LoadPaymentMethodsInComboBox()
        {
            DataTable dt = clsPaymentMethods.GetAllPaymentMethods();
            foreach (DataRow dr in dt.Rows)
            {
                cbPaymentMethods.Items.Add(dr[1].ToString());
            }
        }

        private void _LoadCustomerData(object sender,clsCustomer CustomerInfo)
        {

            if (CustomerInfo == null)
            {
                _LoadCustomerDefaultData();
                IsSelectedCustomer = false;

              
                return;
            }
     
            CustomerPanel.BackgroundImage = Resources.Edit_User;
       
            txtFirstName.Text = CustomerInfo.PersonInfo.FirstName.ToString();
            txtLastName.Text = CustomerInfo.PersonInfo.LastName.ToString();
            txtEmail.Text = CustomerInfo.PersonInfo.Email.ToString();
            txtNationalNumber.Text = CustomerInfo.PersonInfo.NationalNumber.ToString();
            txtAddress.Text = CustomerInfo.PersonInfo.Address.ToString();
            txtPhone.Text = CustomerInfo.PersonInfo.Phone.ToString();

            cbCountries.SelectedIndex = cbCountries.FindString((CustomerInfo.PersonInfo.CountryInfo.CountryName));
            CountryIndex = cbCountries.SelectedIndex;
            dtpDateOfBirth.Value =OriginalDate= CustomerInfo.PersonInfo.DateOfBirth;
            if (CustomerInfo.PersonInfo.Gender == 1)
            {
                rbMale.Checked = true;
                rbFemale.Checked = false;
            }
            else
            {
                rbMale.Checked = false;
                rbFemale.Checked = true;
            }

            if (CustomerInfo.PersonInfo.ImagePath != "")
            {
                pbPersonImage.ImageLocation = CustomerInfo.PersonInfo.ImagePath;
            }
            else
            {
                pbPersonImage.Image = Resources.Userpng;
            }

            txtDLN.Text = txtCDLN.Text = CustomerInfo.DriverLicenseNumber;
            lblCustomerID.Text = CustomerInfo.CustomerID.ToString();

            IsSelectedCustomer = true;
            llDeletePicture.Visible = true;

            if (_Mode == enMode.AddNew && IsSelectedCustomer)
            {

                llDeletePicture.Visible = false;
                llsetPicture.Visible = false;

                rbFemale.Enabled = false;
                rbMale.Enabled = false;
            }


        }

        private bool _HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Booking.CustomerInfo.PersonInfo.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Booking.CustomerInfo.PersonInfo.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_Booking.CustomerInfo.PersonInfo.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Booking.CustomerInfo.PersonInfo.ImagePath);
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
            if (_Mode == enMode.Update)
            {
                return;
            }
            if (lblCustomerID.Text != "-1")
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

        private void txtCDLN_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider er = new ErrorProvider();

            if (string.IsNullOrEmpty(txtCDLN.Text))
            {
                er.SetError(txtCDLN, "Can Not Be Empty");
                e.Cancel = true;
            }
            else
            {
                er.SetError(txtCDLN, null);
                e.Cancel = false;
            }

            if (txtCDLN.Text != txtDLN.Text)
            {
                er.SetError(txtCDLN, "No Match.");
                e.Cancel = true;
            }
            else
            {
                er.SetError(txtCDLN, null);
                e.Cancel = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        bool IsSelectedCustomer = false;
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(_Mode == enMode.AddNew && IsSelectedCustomer)
            {
                e.Handled = true;
            }
        }

        int CountryIndex= -1;
        private void cbCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew && IsSelectedCustomer && CountryIndex != -1)
            {
                cbCountries.SelectedIndex = CountryIndex;

                return;
            }
           
            
        }     

        DateTime OriginalDate = DateTime.Now;
        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            if(_Mode == enMode.AddNew && IsSelectedCustomer && OriginalDate != DateTime.Now)
            {
                dtpDateOfBirth.Value = OriginalDate;

            }


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _LoadCustomerDefaultData();
        }

        private void cbPaymentMethods_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider er = new ErrorProvider();

            if (!cbPaymentMethods.Enabled)
            {
                return;
            }
            if (cbPaymentMethods.SelectedIndex == -1)
            {
                er.SetError(cbPaymentMethods, "Please Chose a Country.");
                e.Cancel = true;
            }
            else
            {
                er.SetError(cbPaymentMethods, null);
                e.Cancel = false;
            }

        }
    }
}
