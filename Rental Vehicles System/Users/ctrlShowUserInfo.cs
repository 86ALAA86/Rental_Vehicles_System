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
    public partial class ctrlShowUserInfo : UserControl
    {
        public ctrlShowUserInfo()
        {
            InitializeComponent();
        }

        public clsUser UserInfo { get; set; }

        public void LoadUserInfo(int UserID)
        {
            UserInfo= clsUser.FindByUserID(UserID);
            if(UserInfo == null)
            {
                MessageBox.Show("User Was Not Found, Try Again Later.","Error",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            lblUserID.Text=UserID.ToString();
            lblUserName.Text = UserInfo.UserName;
            lblActive.Text = (UserInfo.IsActive) ? "Yes" : "No";
            ctrlShowPersonInfo1.LoadPersonInfo(UserInfo.PersonID);
        }


    }
}
