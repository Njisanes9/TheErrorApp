using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserStatus
    {

        public int UserID { get; set; }
        public string Userstatus { get; set; }


        public UserStatus()
        {


        }

        public UserStatus(int userID)
        {

            this.UserID = userID;
           this.Userstatus = Userstatus;

        }

    }
}
