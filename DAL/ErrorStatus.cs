using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class GetErrorStatus
    {

        public string ErrorDescription { get; set; }
       
        public int ProgLanguageID { get; set; }
        public int ModuleTopicID { get; set; }
        public string ErrorStatus { get; set; }
     

        public GetErrorStatus()
        {

        }
        public GetErrorStatus(string errorDescription, int progLanguageID, int modtopicID, string errorstat)
        {
            this.ErrorDescription = errorDescription;
            this.ProgLanguageID = progLanguageID;
            this.ModuleTopicID = modtopicID;
            this.ErrorStatus = errorstat;

        }
    }
}
