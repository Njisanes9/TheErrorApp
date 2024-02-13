using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ErrorSearch
    {
        public int ModuleID { get; set; }

        public ErrorSearch()
        {

        }
        public ErrorSearch(int moduleID)
        {
            this.ModuleID = moduleID;
        }
    }
}
