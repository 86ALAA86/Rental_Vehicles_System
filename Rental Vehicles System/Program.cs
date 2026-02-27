using Rental_Vehicles_System.Checks;
using Rental_Vehicles_System.Customers;
using Rental_Vehicles_System.Log_IN;
using Rental_Vehicles_System.Maintenance;
using Rental_Vehicles_System.People;
using Rental_Vehicles_System.Rental_Booking;
using Rental_Vehicles_System.Returns;
using Rental_Vehicles_System.Specifications;
using Rental_Vehicles_System.Transactions;
using Rental_Vehicles_System.Users;
using Rental_Vehicles_System.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_Vehicles_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
         {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            frmLogINSceen LoginForm = new frmLogINSceen();
            Application.Run(LoginForm);

            Form1 main = new Form1();
            if (LoginForm.DialogResult == DialogResult.OK)
            {

                //When you want to start with Login Just in 'Run()' put main
                Application.Run(main);

            }

           // Application.Run(new frmChangeUserPasword(2));
        }
    }
}
