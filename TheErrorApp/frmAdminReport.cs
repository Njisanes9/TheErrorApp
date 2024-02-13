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
using BLL;
using DAL;

namespace TheErrorApp
{
    public partial class frmAdminReport : Form
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
        public frmAdminReport()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        BusinessLogicLayer bll = new BusinessLogicLayer();
        private void frmAdminReport_Load(object sender, EventArgs e)
        {
            dgvAdminReps.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cmbAdmin.DataSource = bll.SearchUser();
            cmbAdmin.DisplayMember = "Fullname";
            cmbAdmin.ValueMember = "UserID";

            cmbLecturer.DataSource = bll.GetLecturer();
            cmbLecturer.DisplayMember = "FullName";
            cmbLecturer.ValueMember = "UserID";

            cmbStudent.DataSource = bll.GetStudent();
            cmbStudent.DisplayMember = "FullName";
            cmbStudent.ValueMember = "UserID";

            cmbYear.DataSource = bll.GetYear();
            cmbYear.DisplayMember = "YearDescription";
            cmbYear.ValueMember = "YearID";

           


        }

        private void cmbAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            int userID;
            Int32.TryParse(cmbAdmin.SelectedValue.ToString(), out userID);
            dgvAdminReps.DataSource = bll.GetByUserID(userID);
        }

        private void cmbLecturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int userID;
            Int32.TryParse(cmbLecturer.SelectedValue.ToString(), out userID);
            dgvAdminReps.DataSource = bll.GetByLectureID(userID);
        }

        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int userID;
            Int32.TryParse(cmbStudent.SelectedValue.ToString(), out userID);
            dgvAdminReps.DataSource = bll.GetStudentDetails(userID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvAdminReps.DataSource = bll.GetUser();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            frmAdminDash admin = new frmAdminDash();
            admin.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            int yearID;
            Int32.TryParse(cmbYear.SelectedValue.ToString(), out yearID);
            dgvAdminReps.DataSource = bll.GetStudentByYear(yearID);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        
    }
}
