using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Error
    {
        public string ErrorDescription { get; set; }
        public int ErrorID { get; set; }
        public int StudentID { get; set; }
        public int ProgLanguageID { get; set; }
        public int ModuleTopicID { get; set; }
        public string ErrorStatus { get; set; }
        public int UserID { get; set; }
        
        public Error()
        {

        }
        public Error(int errorID,string errorDesc,int studentID,int progLanguageID,int modtopicID,string errorstat,int userID)
        {
            this.ErrorDescription = errorDesc;
            this.ErrorID = errorID;
            this.StudentID = studentID;
            this.ProgLanguageID = progLanguageID;
            this.ModuleTopicID = modtopicID;
            this.ErrorStatus = errorstat;
            this.UserID = userID;
        }
    }
}
