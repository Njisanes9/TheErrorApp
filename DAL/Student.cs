using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Student
    {
        public string Username { get; set; }
        public string Surname { get; set; }

        public int StudentID { get; set; }

        public string FullName
        {


            get { return Username + " " + Surname; }
        }


    }
}
