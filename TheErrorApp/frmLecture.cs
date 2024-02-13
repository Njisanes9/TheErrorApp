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
    public partial class frmLecture : Form
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
        public frmLecture()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        DataTable dt = new DataTable();
        BusinessLogicLayer bll = new BusinessLogicLayer();
        private void frmLecture_Load(object sender, EventArgs e)
        {
            

            dgvSolution.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
        }
        int LecturerID;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Lecturer lecture = new Lecturer();
            dt = new DataTable();
            dt = frmLogin.dtInfo;
            LecturerID = int.Parse(dt.Rows[0]["UserID"].ToString());

            lecture.SolutionDescription = txtSolution.Text;
            lecture.LecturerID = LecturerID;

            if (string.IsNullOrEmpty(txtSolution.Text))
            {
                errorProvider1.SetError(this.txtSolution, "Cannot add empty fields");

            }
            else
            {
                int x = bll.InsertSolution(lecture);

                if (x > 0)
                {
                    MessageBox.Show(" Added");
                }
                else
                {
                    MessageBox.Show(" Added");
                }
                GetSolution();
            }
            
            pnlNav.Height = btnAdd.Height;
            pnlNav.Top = btnAdd.Top;
            pnlNav.Left = btnAdd.Left;
            btnAdd.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Lecturer lecture = new Lecturer();
            
            lecture.SolutionDescription = txtSolution.Text;
            lecture.SolutionID = int.Parse(dgvSolution.SelectedRows[0].Cells["SolutionID"].Value.ToString());

            int x = bll.UpdateSolution(lecture);

            if (x > 0)
            {
                MessageBox.Show(" Solution Updated");
            }
            else
            {
                MessageBox.Show(" Solution Updated");
            }
            GetSolution();
            pnlNav.Height = btnUpdate.Height;
            pnlNav.Top = btnUpdate.Top;
            pnlNav.Left = btnUpdate.Left;
            btnUpdate.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Lecturer lecturer = new Lecturer();
            lecturer.SolutionID = int.Parse(dgvSolution.SelectedRows[0].Cells["SolutionID"].Value.ToString());

            int x = bll.DeleteSolution(lecturer);

            if (x > 0)
            {
                MessageBox.Show(" Deleted");
            }
            else
            {
                MessageBox.Show(" Deleted");
            }
            GetSolution();
            pnlNav.Height = btnDelete.Height;
            pnlNav.Top = btnDelete.Top;
            pnlNav.Left = btnDelete.Left;
            btnDelete.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            Refresh();
            pnlNav.Height = btnView.Height;
            pnlNav.Top = btnView.Top;
            pnlNav.Left = btnView.Left;
            btnView.BackColor = Color.FromArgb(46, 51, 73);
            
        }

        public void Refresh()
        {
            dgvSolution.DataSource = bll.GetSolution();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLecturerDash lecturer = new frmLecturerDash();
            lecturer.Show();
            this.Hide();

            pnlNav.Height = btnLogout.Height;
            pnlNav.Top = btnLogout.Top;
            pnlNav.Left = btnLogout.Left;
            btnLogout.BackColor = Color.FromArgb(46, 51, 73);
        }
        private void btnX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            frmErrorSolution errorSolution = new frmErrorSolution();
            errorSolution.Show();
            this.Hide();

            pnlNav.Height = btnAssign.Height;
            pnlNav.Top = btnAssign.Top;
            pnlNav.Left = btnAssign.Left;
            btnAssign.BackColor = Color.FromArgb(46, 51, 73);
        }
        public void GetSolution()
        {
            dgvSolution.DataSource = bll.GetLecturerSolution();        }
        private void btnViewSol_Click(object sender, EventArgs e)
        {
            GetSolution();
        }

        private void dgvSolution_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dgvSolution.Rows[e.RowIndex];

                txtSolution.Text = row.Cells[2].Value.ToString();


            }
            else
            {
                MessageBox.Show("Please click View");


            }
        }
    }
}
