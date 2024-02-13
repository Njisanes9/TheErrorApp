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
    public partial class frmModules : Form
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
        public frmModules()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        BusinessLogicLayer bll = new BusinessLogicLayer();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Modules module = new Modules();

            module.ModuleDescription = txtInsertModule.Text;
            module.YearID = int.Parse(cmbYear.SelectedValue.ToString());
            if (string.IsNullOrEmpty(txtInsertModule.Text))
            {
                errorProvider1.SetError(this.txtInsertModule, "Cannot add empty fields");

            }
            else
            {
                int x = bll.InsertModule(module);
                if (x > 0)
                {
                    MessageBox.Show(" Added");
                }
                else
                {
                    MessageBox.Show(" Added");
                }
                Refresh();
            }
            

            pnlNav.Height = btnAdd.Height;
            pnlNav.Top = btnAdd.Top;
            pnlNav.Left = btnAdd.Left;
            btnAdd.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void frmModules_Load(object sender, EventArgs e)
        {
            cmbYear.DataSource = bll.GetYear();
            cmbYear.ValueMember = "YearID";
            cmbYear.DisplayMember = "YearDescription";

            dgvModule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Modules module = new Modules();

            module.ModuleDescription = txtInsertModule.Text;
            module.ModuleID = int.Parse(dgvModule.SelectedRows[0].Cells["ModuleID"].Value.ToString());

            int x = bll.UpdateModule(module);
            if (x > 0)
            {
                MessageBox.Show(" Module Updated");
            }
            else
            {
                MessageBox.Show(" Module Updated");
            }
            Refresh();

            pnlNav.Height = btnUpdate.Height;
            pnlNav.Top = btnUpdate.Top;
            pnlNav.Left = btnUpdate.Left;
            btnUpdate.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dgvModule.DataSource = bll.GetModule();

            pnlNav.Height = btnView.Height;
            pnlNav.Top = btnView.Top;
            pnlNav.Left = btnView.Left;
            btnView.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Modules module = new Modules();
            module.ModuleID = int.Parse(dgvModule.SelectedRows[0].Cells["ModuleID"].Value.ToString());

            int x = bll.DeleteModule(module);

            if (x > 0)
            {
                MessageBox.Show(" Deleted");
            }
            else
            {
                MessageBox.Show(" Deleted");
            }
            Refresh();

            pnlNav.Height = button6.Height;
            pnlNav.Top = button6.Top;
            pnlNav.Left = button6.Left;
            button6.BackColor = Color.FromArgb(46, 51, 73);
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
        public override void Refresh()
        {
            dgvModule.DataSource = bll.GetModule();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvModule_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dgvModule.Rows[e.RowIndex];

               txtInsertModule.Text = row.Cells[1].Value.ToString();
               cmbYear.Text = row.Cells[2].Value.ToString();


            }
            else
            {
                MessageBox.Show("Please click View");


            }
        }

        private void dgvModule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
