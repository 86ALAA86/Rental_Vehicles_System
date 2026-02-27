using Guna.UI2.WinForms;
using Rental_Vehicles_System.Customers;
using Rental_Vehicles_System.Global;
using Rental_Vehicles_System.Maintenance;
using Rental_Vehicles_System.Rental_Booking;
using Rental_Vehicles_System.Returns;
using Rental_Vehicles_System.Transactions;
using Rental_Vehicles_System.Users;
using Rental_Vehicles_System.Vehicles;
using RVS_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_Vehicles_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private DataTable _dtUsers;

        private DataTable _dtVehicles;

        private DataTable _dtCustomers;

        private DataTable _dtRentalBooks;

        private DataTable _dtReturnVehicles;

        private DataTable _dtRentalTransactions;

        private DataTable _dtMaintenace;

        //

        private void cms_Opening(object sender, CancelEventArgs e)
        {
            var cms = sender as ContextMenuStrip;
            var CallingControl = cms?.SourceControl;

            if (!(CallingControl is  Guna2DataGridView dgv))
            {
                return;
            }
            cms.Items.Clear();

            string tag = CallingControl.Tag?.ToString();

            switch (tag)
            {
                case "Customers":
                    cms.Items.Add("Update Info", null,(Sender, E) => {
                        frmAddEditCustomer frm = new frmAddEditCustomer((int)dgvCustomers.CurrentRow.Cells[0].Value);
                        frm.ShowDialog();
                    });
                    cms.Items.Add("Show Info", null, (Sender, E) => {
                        frmShowCustomerInfo frm = new frmShowCustomerInfo((int)dgvCustomers.CurrentRow.Cells[0].Value);
                        frm.ShowDialog();
                    });
                    cms.Items.Add("Delete", null, (Sender, E) => {

                     int CustomerID = (int)dgvCustomers.CurrentRow.Cells[0].Value;

                        if (MessageBox.Show("Are You Sure You Want To Delete This Customer With ID : "
                            +CustomerID.ToString() +" ?",
                            "Deleting",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
                        {
                            if (!clsCustomer.DeleteCustomer(CustomerID))
                            { 
                                MessageBox.Show("Customer Was Not Deleted Because He Is Linked To Other Data",
                                    "Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            
                            }
                            else
                            {
                                MessageBox.Show("Customer Was Deleted Successfully",
                                    "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                   
                    });
                    break;

                case "Vehicles":
                    cms.Items.Add("Update Info", null, (Sender, E) => {
                        frmAddEditVehicles frm = new frmAddEditVehicles((int)dgvVehicles.CurrentRow.Cells[0].Value);
                        frm.ShowDialog();
                    });
                    cms.Items.Add("Show Info", null, (Sender, E) => {
                        frmShowVehicleInfo frm = new frmShowVehicleInfo((int)dgvVehicles.CurrentRow.Cells[0].Value);
                        frm.ShowDialog();
                    });
                    cms.Items.Add("Delete", null, (Sender, E) => {

                        int VehicleID = (int)dgvVehicles.CurrentRow.Cells[0].Value;

                        if (MessageBox.Show("Are You Sure You Want To Delete This Vehicle With ID : "
                            + VehicleID.ToString() + " ?",
                            "Deleting", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            if (!clsVehicle.Delete(VehicleID))
                            {
                                MessageBox.Show("Vehicle Was Not Deleted Because He Is Linked To Other Data",
                                    "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            else
                            {
                                MessageBox.Show("Vehicle Was Deleted Successfully",
                                    "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }

                    });
                    cms.Items.Add("Maintenance", null, (Sender, E) => {
                        frmAddEditMaintenance frm = new frmAddEditMaintenance((int)dgvVehicles.CurrentRow.Cells[0].Value);
                        frm.ShowDialog();
                    });
                   



                    break;

                case "Users":
                    cms.Items.Add("Update Info", null, (Sender, E) => {
                        frmAddEditUser frm = new frmAddEditUser((int)dgvUsers.CurrentRow.Cells[0].Value);
                        frm.ShowDialog();
                    });
                    cms.Items.Add("Show Info", null, (Sender, E) => {
                       frmShowUserInfo frm = new frmShowUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
                        frm.ShowDialog();
                    });
                    cms.Items.Add("Delete", null, (Sender, E) => {

                        int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

                        if (MessageBox.Show("Are You Sure You Want To Delete This User With ID : "
                            + UserID.ToString() + " ?",
                            "Deleting", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            if (!clsUser.DeleteUser(UserID))
                            {
                                MessageBox.Show("User Was Not Deleted Because He Is Linked To Other Data",
                                    "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            else
                            {
                                MessageBox.Show("User Was Deleted Successfully",
                                    "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }

                    });
                    cms.Items.Add("Change Password", null, (Sender, E) => {
                        frmChangeUserPasword frm = new frmChangeUserPasword((int)dgvUsers.CurrentRow.Cells[0].Value);
                        frm.ShowDialog();
                    });

                    break;

                case "Booking":
                    cms.Items.Add("Update Info", null, (Sender, E) => {
                        frmAddEditRentalBooking frm = new frmAddEditRentalBooking((int)dgvRentals.CurrentRow.Cells[0].Value);
                        frm.ShowDialog();
                    });
                    cms.Items.Add("Show Info", null, (Sender, E) => {
                        frmShowBookInfo frm = new frmShowBookInfo((int)dgvRentals.CurrentRow.Cells[0].Value);
                        frm.ShowDialog();
                    });
                    cms.Items.Add("Delete", null, (Sender, E) => {

                        int BookingID = (int)dgvRentals.CurrentRow.Cells[0].Value;

                        if (MessageBox.Show("Are You Sure You Want To Delete This Booking With ID : "
                            + BookingID.ToString() + " ?",
                            "Deleting", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            if (!clsRentalBooking.Delete(BookingID))
                            {
                                MessageBox.Show("Booking Was Not Deleted Because He Is Linked To Other Data",
                                    "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            else
                            {
                                MessageBox.Show("Booking Was Deleted Successfully",
                                    "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }

                    });
                    cms.Items.Add("Return", null, (Sender, E) => {
                        frmReturnVehicle frm = new frmReturnVehicle((int)dgvRentals.CurrentRow.Cells[0].Value);
                        frm.ShowDialog();
                    });

                    if (clsRentalBooking.IsBookingReturned((int)dgvRentals.CurrentRow.Cells[0].Value))
                        CMS.Items[3].Enabled = false;
                    else
                        CMS.Items[3].Enabled = true;


                    break;

                case "Retruns":
                    cms.Items.Add("Update Info", null, (Sender, E) => {
                        frmReturnVehicle frm = new frmReturnVehicle((int)dgvReturnVehicles.CurrentRow.Cells[0].Value,false);
                        frm.ShowDialog();
                    });
                    cms.Items.Add("Show Info", null, (Sender, E) => {
                        frmShowReturnInfo frm = new frmShowReturnInfo((int)dgvReturnVehicles.CurrentRow.Cells[0].Value);
                        frm.ShowDialog();
                    });
                    cms.Items.Add("Delete", null, (Sender, E) => {

                        int ReturnID = (int)dgvReturnVehicles.CurrentRow.Cells[0].Value;

                        if (MessageBox.Show("Are You Sure You Want To Delete This Return With ID : "
                            + ReturnID.ToString() + " ?",
                            "Deleting", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            if (!clsVehicleReturns.Delete(ReturnID))
                            {
                                MessageBox.Show("Return Was Not Deleted Because He Is Linked To Other Data",
                                    "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            else
                            {
                                MessageBox.Show("Return Was Deleted Successfully",
                                    "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }

                    });
                    break;

                    
                case "Transactions":
                    cms.Items.Add("Show Info", null, (Sender, E) => {
                        frmShowTransactionInfo frm = new frmShowTransactionInfo((int)dgvTransactions.CurrentRow.Cells[0].Value);
                        frm.ShowDialog();
                    });
                    cms.Items.Add("Refund", null, (Sender, E) => {

                        int TransactionID = (int)dgvTransactions.CurrentRow.Cells[0].Value;

                        if (MessageBox.Show("Are You Sure You Want To Refund This Transaction With ID : "
                            + TransactionID.ToString() + " ?",
                            "Refunding", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            if (clsRentalTransaction.PayRefurnds(TransactionID))
                            {
                                MessageBox.Show("Transaction Was Refunded Successfully.",
                                    "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else
                            {
                                MessageBox.Show("Transaction Was Not Refunded, An Error Occord",
                                    "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }

                    });

                    if (clsRentalTransaction.IsRefunded((int)dgvTransactions.CurrentRow.Cells[0].Value))
                    CMS.Items[1].Enabled = false;
                    else
                    CMS.Items[1].Enabled = true;
                

                    break;

                case "Maintenance":
                    cms.Items.Add("Update Info", null, (Sender, E) => {
                       frmAddEditMaintenance frm = new frmAddEditMaintenance((int)dgvMaintenance.CurrentRow.Cells[0].Value, false);
                        frm.ShowDialog();
                    });
                    cms.Items.Add("Show Info", null, (Sender, E) => {
                       frmShowMaintenanceInfo frm = new frmShowMaintenanceInfo((int)dgvMaintenance.CurrentRow.Cells[0].Value);
                        frm.ShowDialog();
                    });


                    break;

                default:
                   
                    break;
                    

                    // Add more cases for your other 5 grids
            }
        }

   

        private void _LoadAllTables()
        {
            //Vehicles
            DataTable _dtAllVehicles = clsVehicle.GetAllVehicles();
            _dtVehicles = _dtAllVehicles.DefaultView.ToTable(false, "VehicleID", "Maker", "Model", "Year", "Mileage",
                 "PlateNumber", "RentalPricePerDay", "IsAvailableForRent");
            lblVehiclesCount.Text = _dtVehicles.Rows.Count.ToString();

            //Users
            _dtUsers = clsUser.GetAllUsers();
            lblUsersCount.Text = _dtUsers.Rows.Count.ToString();

            //Customers
            _dtCustomers = clsCustomer.GetAllCustomers();
            lblCustomersCount.Text = _dtCustomers.Rows.Count.ToString();

            //Booking

            _dtRentalBooks = clsRentalBooking.GetAllRentalBooks();
            lblRentalsCount.Text = _dtRentalBooks.Rows.Count.ToString();

            //Returns
            _dtReturnVehicles = clsVehicleReturns.GetAllReturnedVehicles();
            lblRentalsCount.Text = _dtReturnVehicles.Rows.Count.ToString();

            //Transactions
            DataTable _dtAll = clsRentalTransaction.GetAllRentalTransaction();
            if (_dtAll.Rows.Count != 0)
            {
                _dtRentalTransactions = _dtAll.DefaultView.ToTable(false, "TransactionID", "BookingID", "ReturnID",
               "PaidInitialTotalDueAmount", "ActualTotalDueAmount", "TotalRemaining", "TotalRefundedAmount",
               "TransactionDate", "UpdatedTransactionDate");
                lblTransactionsCount.Text = _dtRentalTransactions.Rows.Count.ToString();
            }

            //Maintenance
            _dtMaintenace = clsMaintenance.GetAllMaintenances();
            lblMaintenanceCount.Text = _dtMaintenace.Rows.Count.ToString();

        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (tabMain.SelectedIndex)
            {

                case 0:


                    break;

                case 1:
                    _LoadCustomers(dgvCustomers,_dtCustomers);

                    break;

                case 2:
                    _LoadVehiles();

                    break;

                case 3:
                    _LoadUsers();

                    break;

                case 4:
                    _LoadRentalBooking(dgvRentals,_dtRentalBooks);

                    break;

                case 5:
                    _LoadReturnVehicles();

                    break;

                case 6:
                    _LoadRentalTransactions();

                    break;

                case 7:
                    _LoadVehicleMaintenance();
                    break;


            }

        }

        //Vehicles 
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Clear();
            _dtVehicles.DefaultView.RowFilter = "";

            switch (cbFilterBy.Text)
            {
                case "None":
                    txtFilterValue.Visible = false;
                    cbAvailable.Visible = false;
                    break;
                case "Is Available For Rent":
                    txtFilterValue.Visible = false;
                    cbAvailable.Visible = true;
                    break;

                default:
                    txtFilterValue.Visible = true;
                    cbAvailable.Visible = false;
                    txtFilterValue.Focus();
                    break;
            }
        }

        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            frmAddEditVehicles frm = new frmAddEditVehicles(-1);
            frm.ShowDialog();
            _LoadVehiles();
        }

        private void _LoadVehiles()
        {
            if (_dtVehicles.Rows.Count <=0)
            {
                return;
            }

            dgvVehicles.DataSource = _dtVehicles;
            lblVehiclesCount.Text = dgvVehicles.Rows.Count.ToString();

            if (dgvVehicles.Rows.Count > 0)
            {

                dgvVehicles.Columns[0].HeaderText = "Vehicle ID";
                dgvVehicles.Columns[0].Width = 90;

                dgvVehicles.Columns[1].HeaderText = "Brand";


                dgvVehicles.Columns[2].HeaderText = "Model";

                dgvVehicles.Columns[3].HeaderText = "Year";
                dgvVehicles.Columns[3].Width = 100;


                dgvVehicles.Columns[4].HeaderText = "Mileage";

                dgvVehicles.Columns[5].HeaderText = "Plate Number";

                dgvVehicles.Columns[6].HeaderText = "Price Rent Per Day";
                dgvVehicles.Columns[6].Width = 190;

                dgvVehicles.Columns[7].HeaderText = "Is Available";


            }


        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)

        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Vehicle ID":
                    FilterColumn = "VehicleID";
                    break;
                case "Plate Number":
                    FilterColumn = "PlateNumber";
                    break;
                case "Rental Price Per Day":
                    FilterColumn = "RentalPricePerDay";
                    break;
                case "Brand":
                    FilterColumn = "Maker";
                    break;

                case "Is Available":
                    FilterColumn = "IsAvailableForRent";
                    break;

                default:
                    FilterColumn = cbFilterBy.Text;
                    break;

            }

            //Reset t"Is Available";he filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtVehicles.DefaultView.RowFilter = "";
                lblVehiclesCount.Text = dgvVehicles.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "Model" && FilterColumn != "Maker" && FilterColumn != "PlateNumber" && FilterColumn != "IsAvailableForRent")
                //in this case we deal with numbers not string.
                _dtVehicles.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtVehicles.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblVehiclesCount.Text = dgvVehicles.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text != "Model" && cbFilterBy.Text != "Brand" && cbFilterBy.Text != "Plate Number" && cbFilterBy.Text != "Is Available For Rent")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsAvailableForRent";
            string FilterValue = cbAvailable.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "All")
                _dtVehicles.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtVehicles.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblVehiclesCount.Text = _dtVehicles.Rows.Count.ToString();

        }

        private void dgvVehicles_DoubleClick(object sender, EventArgs e)
        {
            frmShowVehicleInfo frm = new frmShowVehicleInfo((int)dgvVehicles.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblUserName.Text = clsGlobal.CurrentUser.UserName;
            _LoadAllTables();
        }

        //Users :

        private void cbUsersFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            cbUsersActivety.SelectedIndex = 0;
            txtUsersFilterValue.Text = "";

            switch (cbUsersFilterBy.SelectedIndex)
            {
                case 0:
                    txtUsersFilterValue.Visible = false;
                    cbUsersActivety.Visible = false;
                    break;
                case 3:
                    txtUsersFilterValue.Visible = false;
                    cbUsersActivety.Visible = true;
                    break;
                default:
                    txtUsersFilterValue.Visible = true;
                    cbUsersActivety.Visible = false;
                    txtUsersFilterValue.Focus();
                    break;

            }

        }

        private void _LoadUsers()
        {
            if (_dtUsers.Rows.Count <=0)
            {
                return;
            }
            dgvUsers.DataSource = _dtUsers;
            lblUsersCount.Text = dgvUsers.Rows.Count.ToString();

            if (dgvUsers.Rows.Count > 0)
            {

                dgvUsers.Columns[0].HeaderText = "User ID";

                dgvUsers.Columns[1].HeaderText = "Person ID";

                dgvUsers.Columns[2].HeaderText = "Full Name";

                dgvUsers.Columns[3].HeaderText = "User Name";

                dgvUsers.Columns[4].HeaderText = "Is Active";

            }


        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();
            frm.ShowDialog();
            _LoadUsers();
        }

        private void txtUsersFitlerValue_TextChanged(object sender, EventArgs e)


        {
            string FilterColumn = cbUsersFilterBy.Text;
            //Map Selected Filter to real Column name 

            if (cbUsersFilterBy.Text == "Is Active")
            {
                FilterColumn = "IsActive";
            }


            //Reset t"Is Available";he filters in case nothing selected or filter value conains nothing.
            if (txtUsersFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblVehiclesCount.Text = dgvVehicles.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "UserName" && FilterColumn != "IsActive")
                //in this case we deal with numbers not string.
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtUsersFilterValue.Text.Trim());
            else
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtUsersFilterValue.Text.Trim());

            lblVehiclesCount.Text = dgvVehicles.Rows.Count.ToString();
        }

        private void txtUsersFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbUsersFilterBy.SelectedIndex == 1)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbUsersActivety_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbUsersActivety.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "All")
                _dtUsers.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblUsersCount.Text = _dtUsers.Rows.Count.ToString();

        }


        private void dgvUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmShowUserInfo frm = new frmShowUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }


        //Cutomers
        private void cbCustomersFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            txtCustomersFilterValue.Text = "";

            switch (cbCustomersFilterBy.SelectedIndex)
            {
                case 0:
                    txtCustomersFilterValue.Visible = false;
                    break;
                
                default:
                    txtCustomersFilterValue.Visible = true;
                    txtCustomersFilterValue.Focus();
                    break;
            }
        }

        private void txtCustomersFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbCustomersFilterBy.SelectedIndex == 1)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtCustomersFilterValue_TextChanged(object sender, EventArgs e)
        {

             string FilterColumn = cbCustomersFilterBy.Text;
             //Map Selected Filter to real Column name 

           if(cbCustomersFilterBy.SelectedIndex==2)
           {
               FilterColumn = "FullName";
           }

            if (cbCustomersFilterBy.SelectedIndex == 3)
            {
                FilterColumn = "DriverLicenseNumber";
            }

            //Reset t"Is Available";he filters in case nothing selected or filter value conains nothing.
            if (txtCustomersFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtCustomers.DefaultView.RowFilter = "";
                lblCustomersCount.Text = dgvCustomers.Rows.Count.ToString();
                return;
            }


             if (FilterColumn == "CustomerID")
                 //in this case we deal with numbers not string.
                 _dtCustomers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtCustomersFilterValue.Text.Trim());
             else
                 _dtCustomers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtCustomersFilterValue.Text.Trim());

             lblCustomersCount.Text = dgvCustomers.Rows.Count.ToString();
          
        }

        internal void _LoadCustomers(DataGridView dgv,DataTable DT)
        {
           

            //if (_dtCustomers.Rows.Count <=0)
            //{
            //    return;
            //}
            //dgvCustomers.DataSource = _dtCustomers;
            //lblCustomersCount.Text = dgvCustomers.Rows.Count.ToString();

            //if (dgvCustomers.Rows.Count > 0)
            //{

            //    dgvCustomers.Columns[0].HeaderText = "Customer ID";

            //    dgvCustomers.Columns[1].HeaderText = "National No";

            //    dgvCustomers.Columns[2].HeaderText = "Full Name";

            //    dgvCustomers.Columns[3].HeaderText = "Email";

            //    dgvCustomers.Columns[4].HeaderText = "Address";

            //    dgvCustomers.Columns[5].HeaderText = "Phone";

            //    dgvCustomers.Columns[6].HeaderText = "Driver License Number";

            //}

            if (DT.Rows.Count <= 0)
            {
                return;
            }
            dgv.DataSource = DT;
            lblCustomersCount.Text = dgv.Rows.Count.ToString();

            if (dgv.Rows.Count > 0)
            {

                dgv.Columns[0].HeaderText = "Customer ID";

                dgv.Columns[1].HeaderText = "National No";

                dgv.Columns[2].HeaderText = "Full Name";

                dgv.Columns[3].HeaderText = "Email";

                dgv.Columns[4].HeaderText = "Address";

                dgv.Columns[5].HeaderText = "Phone";

                dgv.Columns[6].HeaderText = "Driver License Number";

            }


        }

        private void dgvCustomers_DoubleClick(object sender, EventArgs e)
        {
            frmShowCustomerInfo frm = new frmShowCustomerInfo((int)dgvCustomers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

       

        //Rental  Booking 

        internal static void _LoadRentalBooking(DataGridView dgv, DataTable DT)
        {
            if (DT.Rows.Count <=0)
            {
                return;
            }
            dgv.DataSource = DT;
          // lblRentalsCount.Text = dgv.Rows.Count.ToString();

            if (dgv.Rows.Count > 0)
            {

                dgv.Columns[0].HeaderText = "BookID";

                dgv.Columns[1].HeaderText = "Customer\nID";

                dgv.Columns[2].HeaderText = "Full\nName";

                dgv.Columns[3].HeaderText = "Vehicle\n  ID";

                dgv.Columns[4].HeaderText = "Vehicle\n Name";

                dgv.Columns[5].HeaderText = "Start\n Date";

                dgv.Columns[6].HeaderText = "End\n Date";

                dgv.Columns[7].HeaderText = "Pickup\n Location";

                dgv.Columns[8].HeaderText = "Dropoff\n Location";

                dgv.Columns[9].HeaderText = "Duration";

                dgv.Columns[10].HeaderText = "Rental Price\nPer Day";

                dgv.Columns[11].HeaderText = "Initial Amount";

            }

        }

        private void cbRentsFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbRentsFilterBy.SelectedIndex)
            {
                case 0:
                    txtRentFilterValue.Visible= false;
                    break;
                default:
                    txtRentFilterValue.Visible= true;
                    txtRentFilterValue.Clear();
                    txtRentFilterValue.Focus();
                    break;
       
            }

        }

        private void txtRentFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cbRentsFilterBy.Text == "BookingID"|| cbRentsFilterBy.Text == "CustomerID"
                || cbRentsFilterBy.Text == "VehicleID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtRentFilterValue_TextChanged(object sender, EventArgs e)

        {

            string FilterColumn = cbRentsFilterBy.Text;
            //Map Selected Filter to real Column name 

           

            //Reset t"Is Available";he filters in case nothing selected or filter value conains nothing.
            if (txtRentFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtRentalBooks.DefaultView.RowFilter = "";
                lblRentalsCount.Text = dgvRentals.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "CustomerID"|| FilterColumn == "VehicleID"|| FilterColumn == "BookingID")
                //in this case we deal with numbers not string.
                _dtRentalBooks.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtRentFilterValue.Text.Trim());
            else
                _dtRentalBooks.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtRentFilterValue.Text.Trim());

            lblRentalsCount.Text = dgvRentals.Rows.Count.ToString();

        }

        private void dgvRentals_DoubleClick(object sender, EventArgs e)
        {
            frmShowBookInfo frm = new frmShowBookInfo((int)dgvRentals.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void btnRentVehicle_Click(object sender, EventArgs e)
        {
            frmAddEditRentalBooking frm = new frmAddEditRentalBooking();
            frm.ShowDialog();
            _LoadRentalBooking(dgvRentals,_dtRentalBooks);
        }


        // Return Vehicles

        private void _LoadReturnVehicles()
        {
            if (_dtReturnVehicles.Rows.Count <=0)
            {
                return;
            }
            dgvReturnVehicles.DataSource = _dtReturnVehicles;
            lblReturnsCount.Text = dgvReturnVehicles.Rows.Count.ToString();

            if (dgvReturnVehicles.Rows.Count > 0)
            {

                dgvReturnVehicles.Columns[0].HeaderText = "Return ID";

                dgvReturnVehicles.Columns[1].HeaderText = "Model";

                dgvReturnVehicles.Columns[2].HeaderText = "Plate Number";

                dgvReturnVehicles.Columns[3].HeaderText = "National Number";

                dgvReturnVehicles.Columns[4].HeaderText = "Driver Licnese Number";

                dgvReturnVehicles.Columns[5].HeaderText = "Rent Start Date";

                dgvReturnVehicles.Columns[6].HeaderText = "Rent End Date";

                dgvReturnVehicles.Columns[7].HeaderText = "Consumed Mileage";

                dgvReturnVehicles.Columns[8].HeaderText = "Additional Charges";

               
            }

        }

        private void cbReturnsFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbReturnsFilterBy.SelectedIndex == 0)
            {
                txtReturnsFilterValue.Visible = false;
            }
            else
            {
                txtReturnsFilterValue.Visible = true;
            }
            txtReturnsFilterValue.Focus();
            txtReturnsFilterValue.Clear();

        }

        private void txtReturnsFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = cbReturnsFilterBy.Text;
            //Map Selected Filter to real Column name 

            switch (cbReturnsFilterBy.SelectedIndex)
            {
                
                case 0:

                    FilterColumn = "";
                    break;
                case 1:
                FilterColumn = "ReturnID";

                    break;
                case 2:
                FilterColumn = "Model";


                break;
                case 3:
                FilterColumn = "PlateNumber";


                break;
                case 4:
                FilterColumn = "NationalNumber";


                break;

            }

            //Reset t"Is Available";he filters in case nothing selected or filter value conains nothing.

            //Reset t"Is Available";he filters in case nothing selected or filter value conains nothing.
            if (txtReturnsFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtReturnVehicles.DefaultView.RowFilter = "";
                lblReturnsCount.Text = dgvReturnVehicles.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "ReturnID")
                //in this case we deal with numbers not string.
                _dtReturnVehicles.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtReturnsFilterValue.Text.Trim());
            else
                _dtReturnVehicles.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtReturnsFilterValue.Text.Trim());

            lblReturnsCount.Text = dgvReturnVehicles.Rows.Count.ToString();

        }

        private void txtReturnsFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbReturnsFilterBy.SelectedIndex==1)
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void dgvReturnVehicles_DoubleClick(object sender, EventArgs e)
        {
            frmShowReturnInfo frm = new
                frmShowReturnInfo((int)dgvReturnVehicles.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadReturnVehicles();
        }

        int BookID = -1;
        void _HandelBookingInputID(object sender, int BookingID)
        {
            BookID = BookingID;
        }

        private void btnReturnVehicle_Click(object sender, EventArgs e)
        {
             BookID = -1;
            frmInputBookingID frm=new frmInputBookingID();
            frm.OnInputBookingIDChanged += _HandelBookingInputID;
            frm.ShowDialog();

           

            if (BookID != -1)
            {
                frmReturnVehicle frm1 = new frmReturnVehicle(BookID);
                frm1.ShowDialog();
            }

          
        }


        // Transactions

        private void _LoadRentalTransactions()
        {
            if (_dtRentalTransactions.Rows.Count <=0)
            {
                return;
            }
            dgvTransactions.DataSource = _dtRentalTransactions;
            lblTransactionsCount.Text = dgvTransactions.Rows.Count.ToString();

            if (dgvTransactions.Rows.Count > 0)
            {

                dgvTransactions.Columns[0].HeaderText = "Transaction ID";

                dgvTransactions.Columns[1].HeaderText = "BookingID";

                dgvTransactions.Columns[2].HeaderText = "Return ID";

                dgvTransactions.Columns[3].HeaderText = "Paid\nInitial\nTotal\nDue Amount";

                dgvTransactions.Columns[4].HeaderText = "Actual\nTotal\nDue Amount";

                dgvTransactions.Columns[5].HeaderText = "Total Remaining";

                dgvTransactions.Columns[6].HeaderText = "Total\nRefunded\nAmount";

                dgvTransactions.Columns[7].HeaderText = "Transaction\nDate";

                dgvTransactions.Columns[8].HeaderText = "Updated\nTransaction\nDate";

            }

        }

        private void cbTransactionsFilterBy_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (cbTransactionsFilterBy.SelectedIndex == 0)
            {
                txtTransactionsFilterValue.Visible = false;
            }
            else
            {
                txtTransactionsFilterValue.Visible = true;
            }
            txtTransactionsFilterValue.Focus();
            txtTransactionsFilterValue.Clear();

        }  

        private void txtTransactionsFilterValue_TextChanged(object sender, EventArgs e)

        {

            string FilterColumn = cbTransactionsFilterBy.Text;
            //Map Selected Filter to real Column name 

            switch (cbTransactionsFilterBy.SelectedIndex)
            {

                case 0:

                    FilterColumn = "None";
                    break;
                case 1:
                    FilterColumn = "TransactionID";

                    break;
                case 2:
                    FilterColumn = "BookingID";


                    break;
                case 3:
                    FilterColumn = "ReturnID";


                    break;
             

            }

            //Reset t"Is Available";he filters in case nothing selected or filter value conains nothing.

            //Reset t"Is Available";he filters in case nothing selected or filter value conains nothing.
            if (txtTransactionsFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtRentalTransactions.DefaultView.RowFilter = "";
                lblTransactionsCount.Text = dgvTransactions.Rows.Count.ToString();
                return;
            }

           
                //in this case we deal with numbers not string.
                _dtRentalTransactions.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtTransactionsFilterValue.Text.Trim());
          
            lblTransactionsCount.Text = dgvTransactions.Rows.Count.ToString();

        }

        private void txtTransactionsFilterValue_KeyPress(object sender, KeyPressEventArgs e)

        {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        //Maintenance 

        private void _LoadVehicleMaintenance()
        {

            if (_dtMaintenace.Rows.Count <= 0)
            {
                return;
            }
            dgvMaintenance.DataSource = _dtMaintenace;
            lblMaintenanceCount.Text = dgvMaintenance.Rows.Count.ToString();

            if (dgvMaintenance.Rows.Count > 0)
            {

                dgvMaintenance.Columns[0].HeaderText = "Maintenance ID";

                dgvMaintenance.Columns[1].HeaderText = "Vehicle ID";

                dgvMaintenance.Columns[2].HeaderText = "Description";

                dgvMaintenance.Columns[3].HeaderText = "Maintenance\nDate";

                dgvMaintenance.Columns[4].HeaderText = "Cost";

                dgvMaintenance.Columns[5].HeaderText = "Check ID";

                dgvMaintenance.Columns[6].HeaderText = "User";

              

            }

        }
        private void cbMaintenanceFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaintenanceFilterBy.SelectedIndex == 0)
            {
                txtMaintenanceFilterValue.Visible = false;
            }
            else
            {
                txtMaintenanceFilterValue.Visible = true;
            }
            txtMaintenanceFilterValue.Focus();
            txtMaintenanceFilterValue.Clear();

        }

        private void txtMaintenanceFilterValue_TextChanged(object sender, EventArgs e)


        {

            string FilterColumn = cbMaintenanceFilterBy.Text;
            //Map Selected Filter to real Column name 

            switch (cbMaintenanceFilterBy.SelectedIndex)
            {

                case 0:

                    FilterColumn = "None";
                    break;
                case 1:
                    FilterColumn = "MaintenanceID";

                    break;
                case 2:
                    FilterColumn = "VehicleID";


                    break;
               
            }

            //Reset t"Is Available";he filters in case nothing selected or filter value conains nothing.

            //Reset t"Is Available";he filters in case nothing selected or filter value conains nothing.
            if (txtMaintenanceFilterValue.Text.Trim() == "" || FilterColumn == "None"||_dtMaintenace.Rows.Count==0)
            {
                _dtMaintenace.DefaultView.RowFilter = "";
                lblMaintenanceCount.Text = dgvMaintenance.Rows.Count.ToString();
                return;
            }


            //in this case we deal with numbers not string.
            _dtMaintenace.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtMaintenanceFilterValue.Text.Trim());

            lblMaintenanceCount.Text = dgvMaintenance.Rows.Count.ToString();

        }

        private void txtMaintenanceFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

       
    }
}
