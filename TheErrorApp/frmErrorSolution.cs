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
    public partial class frmErrorSolution : Form
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
        public frmErrorSolution()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        BusinessLogicLayer bll = new BusinessLogicLayer();
        static string connString = "Data Source=localHostInitial Catalog=ErrorAppDB;Integrated Security=True;";
        SqlConnection dbConn = new SqlConnection(connString);
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
         
         
         
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ErrorSolution errorSolution = new ErrorSolution();
            lblSolutionDate.Text = DateTime.Now.ToString();
            errorSolution.ErrorID = int.Parse(cmbErrorDescr.SelectedValue.ToString());
            errorSolution.SolutionID = int.Parse(cmbSolutionDesc.SelectedValue.ToString());
            errorSolution.Date = lblSolutionDate.Text;

            int x = bll.InsertErrorSol(errorSolution);

            if(x > 0)
            {
                MessageBox.Show(" Solution Assigned");
            }
            else
            {
                MessageBox.Show(" Solution Assigned");
            }
            Refresh();
            pnlNav.Height = btnAdd.Height;
            pnlNav.Top = btnAdd.Top;
            pnlNav.Left = btnAdd.Left;
            btnAdd.BackColor = Color.FromArgb(46, 51, 73);
            
        }
        public void Refresh() 
        {
            dgvErrorSolution.DataSource = bll.GetErrorSol();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ErrorSolution errorSolution = new ErrorSolution();

            errorSolution.ErrorID = int.Parse(cmbErrorDescr.SelectedValue.ToString());
            errorSolution.SolutionID = int.Parse(cmbSolutionDesc.SelectedValue.ToString());
            errorSolution.Date = lblSolutionDate.Text;
            errorSolution.ErrorSolutionID = int.Parse(dgvErrorSolution.SelectedRows[0].Cells["ErrorSolutionID"].Value.ToString());

            int x = bll.UpdateErrorSol(errorSolution);

            if (x > 0)
            {
                MessageBox.Show(" Updated");
            }
            else
            {
                MessageBox.Show(" Updated");
            }
            Refresh();
            pnlNav.Height = btnUpdate.Height;
            pnlNav.Top = btnUpdate.Top;
            pnlNav.Left = btnUpdate.Left;
            btnUpdate.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ErrorSolution errorSolution = new ErrorSolution();
            errorSolution.ErrorSolutionID = int.Parse(dgvErrorSolution.SelectedRows[0].Cells["ErrorSolutionID"].Value.ToString());

            int x = bll.DeleteErrorSol(errorSolution);

            if (x > 0)
            {
                MessageBox.Show(" Deleted");
            }
            else
            {
                MessageBox.Show(" Deleted");
            }
            Refresh();
            pnlNav.Height = btnDelete.Height;
            pnlNav.Top = btnDelete.Top;
            pnlNav.Left = btnDelete.Left;
            btnDelete.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            Refresh();
            pnlNav.Height = btnView.Height;
            pnlNav.Top = btnView.Top;
            pnlNav.Left = btnView.Left;
            btnView.BackColor = Color.FromArgb(46, 51, 73);
        }
        DataTable dt = new DataTable();
        int StudentID;
        private void frmErrorSolution_Load(object sender, EventArgs e)
        {
            dt = frmLogin.dtInfo;
            StudentID = int.Parse(dt.Rows[0]["UserID"].ToString());
            cmbErrorDescr.DataSource = bll.GetLecturerError();
            cmbErrorDescr.DisplayMember = "ErrorDescription";
            cmbErrorDescr.ValueMember = "ErrorID";

            cmbSolutionDesc.DataSource = bll.GetErrorSolu();
            cmbSolutionDesc.DisplayMember = "SolutionDescription";
            cmbSolutionDesc.ValueMember = "SolutionID";

            dgvErrorSolution.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmLecturerDash lecturer = new frmLecturerDash();
            lecturer.Show();
            this.Hide();
            
            pnlNav.Height = btnBack.Height;
            pnlNav.Top = btnBack.Top;
            pnlNav.Left = btnBack.Left;
            btnBack.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvErrorSolution_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dgvErrorSolution.Rows[e.RowIndex];

               
                cmbErrorDescr.Text = row.Cells[1].Value.ToString();
                cmbSolutionDesc.Text = row.Cells[2].Value.ToString();
               
            }
            else
            {
                MessageBox.Show("Please click View");


            }


        }

        private void dgvErrorSolution_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dgvErrorSolution.Rows[e.RowIndex];

               cmbErrorDescr.Text = row.Cells[1].Value.ToString();
                cmbSolutionDesc.Text = row.Cells[2].Value.ToString();
               

            }
            else
            {
                MessageBox.Show("Please click View");


            }
        }
    }
}
