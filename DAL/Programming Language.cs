using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Programming_Language
    {
        public int ProgLanguageID { get; set; } 
        public string ProgLanguageDesc { get; set; }

        public Programming_Language()
        {

        }
        public Programming_Language(int progID,string progDesc)
        {
            this.ProgLanguageID = progID;
            this.ProgLanguageDesc = progDesc;
        }
    }
}
