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
    public partial class frmLecturerDash : Form
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
        public frmLecturerDash()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void btnAssModTopic_Click(object sender, EventArgs e)
        {
            frmModuleTopic modtopic = new frmModuleTopic();
            modtopic.Show();
            this.Hide();
        }

        private void btnmngSol_Click(object sender, EventArgs e)
        {
            frmLecture sol = new frmLecture();
            sol.Show();
            this.Hide();
        }

        private void btnAssSol_Click(object sender, EventArgs e)
        {
            frmErrorSolution errSol = new frmErrorSolution();
            errSol.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnmngTopics_Click(object sender, EventArgs e)
        {
            frmTopic topic = new frmTopic();
            topic.Show();
            this.Hide();
        }
        DataTable dt = frmLogin.dtInfo;
        private void frmLecturerDash_Load(object sender, EventArgs e)
        {
            lblDisplayUser.Text = "(" + dt.Rows[0]["Username"].ToString() + "," + dt.Rows[0]["Surname"].ToString() + " " + "(" + dt.Rows[0]["RoleDescription"].ToString() + ")" + ")";
            timer1.Start();
            lblCurrentTime.Text = DateTime.Now.ToLongTimeString();
            lblCurrentDate.Text = DateTime.Now.ToLongDateString();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            frmLecturerReport frmLecturerReport = new frmLecturerReport();
            frmLecturerReport.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
