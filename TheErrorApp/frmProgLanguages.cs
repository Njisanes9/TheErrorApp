using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;
using System.Runtime.InteropServices;

namespace TheErrorApp
{
    public partial class frmProgLanguages : Form
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
        public frmProgLanguages()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        BusinessLogicLayer bll = new BusinessLogicLayer();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Programming_Language progLang = new Programming_Language();
            progLang.ProgLanguageDesc = txtProgLanguage.Text;


            if (string.IsNullOrEmpty(txtProgLanguage.Text))
            {
                errorProvider1.SetError(this.txtProgLanguage, "Cannot add empty fields");

            }
            else
            {
                int x = bll.InsertProgLang(progLang);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Programming_Language progLang = new Programming_Language();
            progLang.ProgLanguageDesc = txtProgLanguage.Text;
            progLang.ProgLanguageID = int.Parse(dgvProgLanguage.SelectedRows[0].Cells["ProgLanguageID"].Value.ToString());

            if (string.IsNullOrEmpty(txtProgLanguage.Text))
            {
                errorProvider1.SetError(this.txtProgLanguage, "Cannot add empty fields");

            }
            else
            {
                int x = bll.UpdateProgLang(progLang);
                if (x > 0)
                {
                    MessageBox.Show(" Updated");
                }
                else
                {
                    MessageBox.Show(" Updated");
                }
                Refresh();
            }
            

            pnlNav.Height = btnUpdate.Height;
            pnlNav.Top = btnUpdate.Top;
            pnlNav.Left = btnUpdate.Left;
            btnUpdate.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Programming_Language progLang = new Programming_Language();
            progLang.ProgLanguageID = int.Parse(dgvProgLanguage.SelectedRows[0].Cells["ProgLanguageID"].Value.ToString());

            int x = bll.DeleteProgLang(progLang);

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
            dgvProgLanguage.DataSource = bll.GetProgLang();

            pnlNav.Height = btnView.Height;
            pnlNav.Top = btnView.Top;
            pnlNav.Left = btnView.Left;
            btnView.BackColor = Color.FromArgb(46, 51, 73);
        }

        public void Refresh()
        {
            dgvProgLanguage.DataSource = bll.GetProgLang();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmAdminDash admin = new frmAdminDash();
            admin.Show();
            this.Hide();
        }

        private void frmProgLanguages_Load(object sender, EventArgs e)
        {
            dgvProgLanguage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvProgLanguage_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dgvProgLanguage.Rows[e.RowIndex];

               txtProgLanguage.Text = row.Cells[1].Value.ToString();
                

            }
            else
            {
                MessageBox.Show("Please click View");


            }
        }

        private void dgvProgLanguage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
