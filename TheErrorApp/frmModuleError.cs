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
    public partial class frmModuleError : Form
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
        public frmModuleError()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        BusinessLogicLayer bll = new BusinessLogicLayer();
        DataAccessLayer dal = new DataAccessLayer();
        DataTable dt = new DataTable();
        int StudentID;
        private void frmModuleError_Load(object sender, EventArgs e)
        {
            dt = frmLogin.dtInfo;
            StudentID = int.Parse(dt.Rows[0]["UserID"].ToString());
            cmbErrorDesc.DataSource = bll.GetError(StudentID);
            cmbErrorDesc.DisplayMember = "ErrorDescription";
            cmbErrorDesc.ValueMember = "ErrorID";

            dgvModuleError.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cmbModuleDescr.DataSource = bll.GetModule();
            cmbModuleDescr.DisplayMember = "ModuleDescription";
            cmbModuleDescr.ValueMember = "ModuleID";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ModuleError moduleError = new ModuleError();
            moduleError.ModuleID = int.Parse(cmbModuleDescr.SelectedValue.ToString());
            moduleError.ErrorID = int.Parse(cmbErrorDesc.SelectedValue.ToString());

            int x = bll.InsertModuleError(moduleError);
            if (x > 0)
            {
                MessageBox.Show(" Added");
            }
            else
            {
                MessageBox.Show(" Added");
            }
            Refresh();
            pnlNav.Height = btnAdd.Height;
            pnlNav.Top = btnAdd.Top;
            pnlNav.Left = btnAdd.Left;
            btnAdd.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ModuleError moduleError = new ModuleError();
            moduleError.ModuleID = int.Parse(cmbModuleDescr.SelectedValue.ToString());
            moduleError.ErrorID = int.Parse(cmbErrorDesc.SelectedValue.ToString());

            int x = bll.UpdateModuleError(moduleError);
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
            ModuleError moduleError = new ModuleError();

            moduleError.ModuleErrorID = int.Parse(dgvModuleError.SelectedRows[0].Cells["ModuleErrorID"].Value.ToString());

            int x = bll.DeleteModuleError(moduleError);

            if(x > 0)
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
        public void Refresh()
        {
            dgvModuleError.DataSource = bll.GetModuleError();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            frmStudentDash frmStudent = new frmStudentDash();
            frmStudent.Show();
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

        private void dgvModuleError_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dgvModuleError.Rows[e.RowIndex];

                cmbModuleDescr.Text = row.Cells[1].Value.ToString();
                cmbErrorDesc.Text = row.Cells[2].Value.ToString();
              

            }
            else
            {
                MessageBox.Show("Please click View");


            }
        }
    }
}
