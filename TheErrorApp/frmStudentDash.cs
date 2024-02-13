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


namespace TheErrorApp
{
    public partial class frmStudentDash : Form
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
        public frmStudentDash()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        DataTable dt = frmLogin.dtInfo;
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnmngErrors_Click(object sender, EventArgs e)
        {
            frmStudent student = new frmStudent();
            student.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            frmSearchErrors errors = new frmSearchErrors();
            errors.Show();
            this.Hide();
        }

        private void frmStudentDash_Load(object sender, EventArgs e)
        {
            lblUserDetails.Text = "(" + dt.Rows[0]["Username"].ToString() + "," + dt.Rows[0]["Surname"].ToString()+" " + "(" + dt.Rows[0]["RoleDescription"].ToString() + ")" + ")";

            timer1.Start();
            lblCurrentTime.Text = DateTime.Now.ToLongTimeString();
            lblCurrentDate.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
