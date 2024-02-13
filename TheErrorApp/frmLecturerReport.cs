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
using System.Data.SqlClient;
using DAL;
using BLL;

namespace TheErrorApp
{
    public partial class frmLecturerReport : Form
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
        public frmLecturerReport()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        BusinessLogicLayer bll = new BusinessLogicLayer();
        DataAccessLayer dal = new DataAccessLayer();
        private void frmLecturerReport_Load(object sender, EventArgs e)
        {
            cmbYear.DataSource = bll.GetYear();
            cmbYear.DisplayMember = "YearDescription";
            cmbYear.ValueMember = "YearID";
            dgvLecturerReps.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            frmLecturerDash lecturer = new frmLecturerDash();
            lecturer.Show();
            this.Hide();
        }
        int UserID;
        DataTable dt = new DataTable();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt = frmLogin.dtInfo;
            UserID = int.Parse(dt.Rows[0]["UserID"].ToString());

            SolutionDate solutionDate = new SolutionDate();

            solutionDate.From = dtpFrom.Value.ToString("yyyy-MM-dd");
            solutionDate.To = dtpTo.Value.ToString("yyyy-MM-dd");
            solutionDate.UserID = UserID;



            dgvLecturerReps.DataSource = bll.GetSolutionDate(solutionDate);

        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            frmLecturerDash dash = new frmLecturerDash();
            dash.Show();
            this.Hide();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            int yearID;
            Int32.TryParse(cmbYear.SelectedValue.ToString(), out yearID);
            dgvLecturerReps.DataSource = bll.GetStudentByYear(yearID);
        }
    }
}
