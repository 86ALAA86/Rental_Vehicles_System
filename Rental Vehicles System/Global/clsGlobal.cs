using RVS_Business_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Vehicles_System.Global
{
    public class clsGlobal
    {
        public static clsUser CurrentUser=clsUser.FindByUserID(1);



    }
}
