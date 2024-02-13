using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ModuleStudent
    {
        public int ModuleStudentID { get; set; }
        public int StudentID { get; set; }
        public int ModuleID { get; set; }
        public ModuleStudent()
        {

        }
        public ModuleStudent(int moduleStudent,int studentID,int moduleID)
        {
            this.ModuleStudentID = moduleStudent;
            this.StudentID = studentID;
            this.ModuleID = moduleID;
        }
    }
}
