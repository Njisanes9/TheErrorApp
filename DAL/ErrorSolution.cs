using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ErrorSolution
    {
        public int ErrorSolutionID { get; set; }
        public int ErrorID { get; set; }
        public int SolutionID { get; set; }
        public string Date { get; set; }

        public ErrorSolution()
        {

        }
        public ErrorSolution(int errorSolID,int errorID,int solID,string date)
        {
            this.ErrorSolutionID = errorSolID;
            this.ErrorID = errorID;
            this.SolutionID = solID;
            this.Date = date;
        }

    }
}
