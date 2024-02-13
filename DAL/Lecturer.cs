using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace DAL
{
    public class Lecturer
    {
        public int SolutionID { get; set; }
        public string SolutionDescription { get; set; }
        public int LecturerID { get; set; }
        public Lecturer()
        {

        }
        public Lecturer(int solutionID,string solDescription, int lecturerID)
        {
            
            this.SolutionDescription = solDescription;
            this.LecturerID = lecturerID;
            this.SolutionID = solutionID;
        }
    }
    
}
