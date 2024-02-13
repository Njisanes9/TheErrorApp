using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class User
    {
        public string Username { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int RoleID { get; set; }
        public string Password { get; set; }
        public int UserID { get; set; }
        public string UserStatus { get; set; }

        public User()
        {


        }
        public User(string username, string  surname, string email, int roleID, string password, int userID,string userstat)
        {
            this.Username = username;
            this.Surname = surname;
            this.Email = email;
            this.RoleID = roleID;
            this.Password = password;
            this.UserID = userID;
            this.UserStatus = userstat;
        }
    }
}
