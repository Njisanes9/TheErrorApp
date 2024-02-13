using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DAL;
using BLL;

namespace TheErrorApp
{
    public partial class frmLogin : Form
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
        public frmLogin()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        BusinessLogicLayer bll = new BusinessLogicLayer();
        string roledesc;
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static DataTable dtInfo;
        //int userID;
        private void button1_Click(object sender, EventArgs e)
        {
            dtInfo = bll.GetLogin(txtUsername.Text,txtPassword.Text);

            if (dtInfo.Rows.Count > 0)
            {
                roledesc = dtInfo.Rows[0]["RoleDescription"].ToString().Trim();
                if(roledesc == "Administrator")
                {
                    frmAdminDash admin = new frmAdminDash();
                    admin.Show();
                    this.Hide();
                }
                else if(roledesc == "Lecturer")
                {
                    frmLecturerDash lecturer = new frmLecturerDash();
                    lecturer.Show();
                    this.Hide();
                    this.Hide();
                }
                else if(roledesc == "Student")
                {
                    frmStudentDash student = new frmStudentDash();
                    student.Show();
                    this.Hide();
                }
                
            }
            else
            {
                lblErrorMessage.Text = "Incorrect username or password";
                txtUsername.Text = "";
                txtPassword.Text = "";
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkViewPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkViewPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = true;
                var checkbox = (CheckBox)sender;
                checkbox.Text = "Hide Password";
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
                var checkbox = (CheckBox)sender;
                checkbox.Text = "Show Password";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmResetPassword reset = new frmResetPassword();
            reset.Show();
            this.Hide();
        }
    }
}
