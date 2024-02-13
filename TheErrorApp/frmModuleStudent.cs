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
    public partial class frmModuleStudent : Form
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
        public frmModuleStudent()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        BusinessLogicLayer bll = new BusinessLogicLayer();
        DataAccessLayer dal = new DataAccessLayer();
        private void frmModuleStudent_Load(object sender, EventArgs e)
        {
            cmbStudent.DataSource = bll.GetStudent();
            cmbStudent.DisplayMember = "FullName";
            cmbStudent.ValueMember = "UserID";

            dgvModuleStudent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cmbModules.DataSource = bll.GetModule();
            cmbModules.DisplayMember = "ModuleDescription";
            cmbModules.ValueMember = "ModuleID";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ModuleStudent moduleStudent = new ModuleStudent();

            moduleStudent.StudentID = int.Parse(cmbStudent.SelectedValue.ToString());
            moduleStudent.ModuleID = int.Parse(cmbModules.SelectedValue.ToString());

            int x = bll.InsertModuleStudent(moduleStudent);

            if (x >0)
            {
                MessageBox.Show(" Added");
            }
            else
            {
                MessageBox.Show(" Added");
            }
            dgvModuleStudent.DataSource = bll.GetModuleStudent();

            pnlNav.Height = btnAdd.Height;
            pnlNav.Top = btnAdd.Top;
            pnlNav.Left = btnAdd.Left;
            btnAdd.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dgvModuleStudent.DataSource = bll.GetModuleStudent();

            pnlNav.Height = btnView.Height;
            pnlNav.Top = btnView.Top;
            pnlNav.Left = btnView.Left;
            btnView.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ModuleStudent moduleStudent = new ModuleStudent();

            moduleStudent.StudentID = int.Parse(cmbStudent.SelectedValue.ToString());
            moduleStudent.ModuleID = int.Parse(cmbModules.SelectedValue.ToString());
            moduleStudent.ModuleStudentID = int.Parse(dgvModuleStudent.SelectedRows[0].Cells["ModuleStudentID"].Value.ToString());
            int x = bll.UpdateModuleStudent(moduleStudent);
            if (x > 0)
            {
                MessageBox.Show(" Updated");
            }
            else
            {
                MessageBox.Show(" Updated");
            }
            dgvModuleStudent.DataSource = bll.GetModuleStudent();
           
            pnlNav.Height = btnUpdate.Height;
            pnlNav.Top = btnUpdate.Top;
            pnlNav.Left = btnUpdate.Left;
            btnUpdate.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ModuleStudent moduleStudent = new ModuleStudent();
            moduleStudent.ModuleStudentID = int.Parse(dgvModuleStudent.SelectedRows[0].Cells["ModuleStudentID"].Value.ToString());

            int x = bll.DeleteModuleStudent(moduleStudent);

            if (x > 0)
            {
                MessageBox.Show(" Deleted");
            }
            else
            {
                MessageBox.Show(" Deleted");
            }
            dgvModuleStudent.DataSource = bll.GetModuleStudent();

            pnlNav.Height = btnDelete.Height;
            pnlNav.Top = btnDelete.Top;
            pnlNav.Left = btnDelete.Left;
            btnDelete.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmAdminDash admin = new frmAdminDash();
            admin.Show();
            this.Hide();

            pnlNav.Height = btnBack.Height;
            pnlNav.Top = btnBack.Top;
            pnlNav.Left = btnBack.Left;
            btnBack.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvModuleStudent_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dgvModuleStudent.Rows[e.RowIndex];

                cmbStudent.Text = row.Cells[1].Value.ToString();
                cmbModules.Text = row.Cells[2].Value.ToString();
              

            }
            else
            {
                MessageBox.Show("Please click View");


            }
        }

        private void dent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
