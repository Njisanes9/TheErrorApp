using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using DAL;
using BLL;

namespace TheErrorApp
{
    public partial class frmResetPassword : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,
           int nTopRect,
           int nRightRect,
           int nBottomRect,
           int nWidthEllipse,
           int nHeightEllipse
       );
        public frmResetPassword()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        BusinessLogicLayer bll = new BusinessLogicLayer();
        DataAccessLayer dal = new DataAccessLayer();
        
        DataTable dt = new DataTable();
        
        private void btnChange_Click(object sender, EventArgs e)
        {
            dt = bll.GetEmail(txtEmail.Text);
            ChangePassword changePassword = new ChangePassword();

            changePassword.Email = txtEmail.Text;
            changePassword.Password = txtPassword1.Text;
            changePassword.Password = txtConfirmPassword.Text;
            if(dt.Rows.Count != 1)
            {
                MessageBox.Show("Email does not exist!");
            }
            else if(txtPassword1.Text != txtConfirmPassword.Text)
            {
              MessageBox.Show("Passwords do not match!! \nPlease enter matching passwords!");

                txtEmail.Text = "";
                txtConfirmPassword.Text = "";
                txtPassword1.Text = "";
            }
            else
            {
                int x = bll.ChangePassword(changePassword);
                MessageBox.Show("Password changed successfully!");

                frmLogin login = new frmLogin();
                login.Show();
                this.Hide();
            }
                
            
        }

        private void chkShowHide_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowHide.Checked) 
            { 
                txtPassword1.UseSystemPasswordChar = true;
                txtConfirmPassword.UseSystemPasswordChar = true;
                
            } 
            else 
            { 
                txtPassword1.UseSystemPasswordChar = false;
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }
    }
}
