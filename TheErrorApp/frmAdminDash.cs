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
    public partial class frmAdminDash : Form
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
        public frmAdminDash()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void btnmngUsers_Click(object sender, EventArgs e)
        {
            frmUser user = new frmUser();
            user.Show();
            this.Hide();
        }

        private void btnmngModules_Click(object sender, EventArgs e)
        {
            frmModules module = new frmModules();
            module.Show();
            this.Hide();
        }

        private void btnModStud_Click(object sender, EventArgs e)
        {
            frmModuleStudent modStud = new frmModuleStudent();
            modStud.Show();
            this.Hide();
        }

        private void btnProgLang_Click(object sender, EventArgs e)
        {
            frmProgLanguages progLang = new frmProgLanguages();
            progLang.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            frmAdminReport report = new frmAdminReport();
            report.Show();
            this.Hide();
        }
        DataTable dt = frmLogin.dtInfo;
        private void frmAdminDash_Load(object sender, EventArgs e)
        {
           lblDisplayUser.Text = "(" + dt.Rows[0]["Username"].ToString() + "," + dt.Rows[0]["Surname"].ToString() + " " + "(" + dt.Rows[0]["RoleDescription"].ToString() + ")" + ")";
            timer1.Start();
            lblCurrentTime.Text = DateTime.Now.ToLongTimeString();
            lblCurrentDate.Text = DateTime.Now.ToLongDateString();
        }

        private void btnProgLang_Click_1(object sender, EventArgs e)
        {
            frmProgLanguages prog = new frmProgLanguages();
            prog.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
