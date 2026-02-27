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

namespace Rental_Vehicles_System.People
{
    public partial class ctrlShowPersonInfoWithFilter : UserControl
    {
        public ctrlShowPersonInfoWithFilter()
        {
            InitializeComponent();
        }
        enum enMode { AddNew,Update}
        enMode _Mode=enMode.AddNew;

        private bool _EnableFilters = false;
        public bool EnableFilters
        {
            get { return _EnableFilters; } 
            
            set
            {
                _EnableFilters = value;


                cbFilterBy.Enabled =false;
                txtSearchValue.Enabled = false;
                btnSearch.Enabled = false;
                if(value)
                {
                    cbFilterBy.Enabled = true;
                    txtSearchValue.Enabled = true;
                    btnSearch.Enabled = true;
                }
                
            }
        }

        private clsPerson _Person;
        private int _PersonId;
        public clsPerson PersonInfo { get { return _Person; } }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = null;
            if(_Mode==enMode.AddNew)
            frm=new frmAddEditPerson();
            else
            {
                frm = new frmAddEditPerson(_PersonId);
            }
            frm.PersonAdded += _LoadPersonInfo;
            frm.ShowDialog();
        }

        private void _LoadPersonInfo(object sender,clsPerson PersonInfo)
        {
          LoadPersonInfo(PersonInfo.PersonID);
        }

        public void LoadPersonInfo(int PersonID)
        {
            _PersonId=PersonID;
            btnAdd.Text = "Update";
            _EnableFilters = false;
            ctrlShowPersonInfo1.LoadPersonInfo(PersonID);
            _Mode = enMode.Update;
            _Person = ctrlShowPersonInfo1.PersonInfo;
            txtSearchValue.Text = PersonInfo.PersonID.ToString();
        }

        public void LoadDefaultValues()
        {
            _Mode = enMode.AddNew;
            ctrlShowPersonInfo1.LoadDefaultInfo();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(cbFilterBy.SelectedIndex==0)
            {
               if( clsPerson.isPersonExist(int.Parse(txtSearchValue.Text)))
               {
                   ctrlShowPersonInfo1.LoadPersonInfo(int.Parse(txtSearchValue.Text));
                   return;
               }
               else
               {
                   MessageBox.Show("Person With ID : " + txtSearchValue.Text + " Was Not Found.",
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               
            }
            else
            {
                if (clsPerson.isPersonExist((txtSearchValue.Text)))
                {
                    ctrlShowPersonInfo1.LoadPersonInfo((txtSearchValue.Text.Trim()));
                    return;
                }
                else
                {
                    MessageBox.Show("Person With ID : " + txtSearchValue.Text + " Was Not Found.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchValue.Clear();
            txtSearchValue.Focus();
        }

        private void txtSearchValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.SelectedIndex==0)
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
