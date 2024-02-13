using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ModuleError
    {
        public int ModuleErrorID { get; set; }
        public int ModuleID { get; set; }
        public int ErrorID { get; set; }
        public ModuleError()
        {

        }
        public ModuleError(int moduleErrorID,int moduleID,int errorID)
        {
            this.ModuleErrorID = moduleErrorID;
            this.ModuleID = moduleID;
            this.ErrorID = errorID;
        }
    }
}
