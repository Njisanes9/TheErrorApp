using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SolutionDate
    {

        public string From { get; set; }

        public string To { get; set; }

        public int UserID { get; set; }

        public SolutionDate()
        {


        }
        public SolutionDate(string from, string to,int userID)
        {

            this.From = from;
            this.To = to;
            this.UserID = userID;


        }
    }
    
}
