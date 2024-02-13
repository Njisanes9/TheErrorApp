using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BLL;
using DAL;
using System.Data.SqlClient;
using System.Runtime.InteropServices;


namespace TheErrorApp
{
    public partial class frmUser : Form
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
        public frmUser()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        BusinessLogicLayer bll = new BusinessLogicLayer();
        DataTable dt = new DataTable();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            User user = new User();
            string email;
            dt = bll.GetEmail(txtEmail.Text);
            //email = dt.Rows[0]["Email"].ToString();

            user.Username = txtUsername.Text;
            user.Surname = txtSurname.Text;
            user.Email = txtEmail.Text;
            user.Password = txtPassword.Text;
            user.RoleID = int.Parse(cmbRole.SelectedValue.ToString());
            user.UserStatus = cmbUserStatus.SelectedItem.ToString();
            if (string.IsNullOrEmpty(txtUsername.Text)|| string.IsNullOrEmpty(txtSurname.Text))
            {
                errorProvider1.SetError(txtUsername, "Please enter valid username");
                errorProvider1.SetError(txtUsername, "Please enter valid surname");
            }
            else if(dt.Rows.Count >= 1)
            {
                MessageBox.Show("Email already exists!");
            }
            else
            {
                int x = bll.InsertUsers(user);
                if (x > 0)
                {
                    MessageBox.Show(" Added");
                }
                else
                {
                    MessageBox.Show(" Added");
                }

                dgvAdmin.DataSource = bll.GetUser();
                Clear();
            }

            pnlNav.Height = btnAdd.Height;
            pnlNav.Top = btnAdd.Top;
            pnlNav.Left = btnAdd.Left;
            btnAdd.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            cmbRole.DataSource = bll.GetRole();
            cmbRole.ValueMember = "RoleID";
            cmbRole.DisplayMember = "RoleDescription";
            LoadStatus();


            dgvAdmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnViewUsers_Click(object sender, EventArgs e)
        {
            Clear();
            GetActiveUser();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
          
            User user = new User();

          
                user.Username = txtUsername.Text;
                user.Surname = txtSurname.Text;
                user.Email = txtEmail.Text;
                user.Password = txtPassword.Text;
                user.RoleID = int.Parse(cmbRole.SelectedValue.ToString());
                user.UserStatus = cmbUserStatus.SelectedItem.ToString();
                user.UserID = int.Parse(dgvAdmin.SelectedRows[0].Cells["UserID"].Value.ToString());

            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Do not leave filed");
                errorProvider1.SetError(txtSurname, "Do not leave filed");
            }
            else
            {
                int x = bll.UpdateUser(user);

                if (x > 0)
                {
                    MessageBox.Show(" Action completed successfully!");

                }
                else
                {
                    MessageBox.Show(" Action completed successfully!");
                }
                Clear();
                GetActiveUser();
            }

                pnlNav.Height = btnUpdate.Height;
                pnlNav.Top = btnUpdate.Top;
                pnlNav.Left = btnUpdate.Left;
                btnUpdate.BackColor = Color.FromArgb(46, 51, 73);

        }
        public void LoadStatus()
        {
            cmbUserStatus.Items.Add("Active");
            cmbUserStatus.Items.Add("In-Active");
        }

      

        private void btnAddModules_Click(object sender, EventArgs e)
        {
            frmModules module = new frmModules();
            module.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmAdminDash admin = new frmAdminDash();
            admin.Show();
            this.Hide();

            pnlNav.Height = btnLogout.Height;
            pnlNav.Top = btnLogout.Top;
            pnlNav.Left = btnLogout.Left;
            btnLogout.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void manageProgrammingLanguagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProgLanguages progLanguage = new frmProgLanguages();
            progLanguage.Show();
            this.Hide();
        }

        private void registerModulesToStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModuleStudent modStudent = new frmModuleStudent();
            modStudent.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Clear()
        {

            txtEmail.Text = " ";
            txtPassword.Text = " ";
            txtSurname.Text = " ";
            txtUsername.Text = " ";
           

            cmbRole.DataSource = bll.GetRole();
            cmbRole.ValueMember = "RoleID";
            cmbRole.DisplayMember = "RoleDescription";
           


        }

        private void dgvAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void dgvAdmin_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dgvAdmin.Rows[e.RowIndex];

                txtUsername.Text = row.Cells[1].Value.ToString();
                txtSurname.Text = row.Cells[2].Value.ToString();
                txtEmail.Text = row.Cells[3].Value.ToString();
                txtPassword.Text = row.Cells[4].Value.ToString();
                cmbRole.Text = row.Cells[5].Value.ToString();
                cmbUserStatus.Text = row.Cells[6].Value.ToString();

            }
            else
            {
                MessageBox.Show("Please click View");


            }
        }
        public void GetActiveUser()
        {


            dgvAdmin.DataSource = bll.GetUser();


        }

        private void btnInActive_Click(object sender, EventArgs e)
        {
            Clear();
            dgvAdmin.DataSource = bll.GetInActive();
        }

        private void cmbUserStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string partten = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txtEmail.Text, partten))
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(this.txtEmail, "Please enter a valid email!");
                return;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
