using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Modules
    {
        public string ModuleDescription { get; set; }
        public int YearID { get; set; }
        public int ModuleID { get; set; }
        public Modules()
        {

        }
        public Modules(string moduleDescription, int yearID,int moduleID)
        {
            this.ModuleDescription = moduleDescription;
            this.YearID = yearID;
            this.ModuleID = moduleID;
        }
    }
}
