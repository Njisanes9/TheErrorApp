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
using DAL;
using BLL;
using System.Runtime.InteropServices;

namespace TheErrorApp
{
    public partial class frmStudent : Form
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
        public frmStudent()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        static string connString = "Data Source= localHost;Initial Catalog=ErrorAppDB;Integrated Security=True;";
        SqlConnection dbConn = new SqlConnection(connString);
        BusinessLogicLayer bll = new BusinessLogicLayer();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        private void button1_Click(object sender, EventArgs e)
        {
            frmProgLanguages progLang = new frmProgLanguages();
            progLang.Show();
            this.Hide();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt = frmLogin.dtInfo;
            StudentID = int.Parse(dt.Rows[0]["UserID"].ToString());

            cmbLanguage.DataSource = bll.GetProgLang();
            cmbLanguage.DisplayMember = "ProgLanguageDesc";
            cmbLanguage.ValueMember = "ProgLanguageID";

            dgvStudent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cmbModuleTopic.DataSource = bll.GetModuleTopic(StudentID);
            cmbModuleTopic.DisplayMember = "ModuleTopic";
            cmbModuleTopic.ValueMember = "ModuleTopicID";

            //cmbStudent.DataSource = bll.GetStudent();
            //cmbStudent.DisplayMember = "FullName";
            //cmbStudent.ValueMember = "UserID";
            //  lblCurrentDateTime.Text = DateTime.Now.ToLongTimeString();
            
           
            LoadErrorStatus();
        }
        public void LoadErrorStatus()
        {
            cmbErrorStatus.Items.Add("New");
            cmbErrorStatus.Items.Add("Solved");
            
            
        }
        int StudentID;
        private void btnAddError_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt = frmLogin.dtInfo;
            StudentID = int.Parse(dt.Rows[0]["UserID"].ToString());

            Error error = new Error();
           
            error.ErrorDescription = txtError.Text;
            error.StudentID = StudentID;
            error.ProgLanguageID = int.Parse(cmbLanguage.SelectedValue.ToString());
            error.ModuleTopicID = int.Parse(cmbModuleTopic.SelectedValue.ToString());
            error.ErrorStatus = cmbErrorStatus.SelectedItem.ToString();

            if (string.IsNullOrEmpty(txtError.Text))
            {
                errorProvider1.SetError(this.txtError, "Cannot add empty fields");

            }
            else
            {
                int x = bll.InsertError(error);

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
            
            
            pnlNav.Height = btnAddError.Height;
            pnlNav.Top = btnAddError.Top;
            pnlNav.Left = btnAddError.Left;
            btnAddError.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Error error = new Error();

            error.ErrorDescription = txtError.Text;
            error.ProgLanguageID = int.Parse(cmbLanguage.SelectedValue.ToString());
            error.ModuleTopicID = int.Parse(cmbModuleTopic.SelectedValue.ToString());
            error.ErrorStatus = cmbErrorStatus.SelectedItem.ToString();
            error.ErrorID = int.Parse(dgvStudent.SelectedRows[0].Cells["ErrorID"].Value.ToString());
            if (string.IsNullOrEmpty(txtError.Text))
            {
                errorProvider1.SetError(this.txtError, "Cannot add empty fields");

            }
            else
            {
                int x = bll.UpdateError(error);
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

           Error error = new Error();
            error.ErrorID = int.Parse(dgvStudent.SelectedRows[0].Cells["ErrorID"].Value.ToString());

            int x = bll.DeleteError(error);

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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmStudentDash student = new frmStudentDash();
            student.Show();
            this.Hide();

            pnlNav.Height = btnLogout.Height;
            pnlNav.Top = btnLogout.Top;
            pnlNav.Left = btnLogout.Left;
            btnLogout.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
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

            dgvStudent.DataSource = bll.GetError(StudentID);
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private void dgvStudent_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dgvStudent.Rows[e.RowIndex];

                txtError.Text = row.Cells[2].Value.ToString();
                cmbLanguage.Text = row.Cells[3].Value.ToString();
                cmbModuleTopic.Text = row.Cells[4].Value.ToString();
                cmbErrorStatus.Text = row.Cells[5].Value.ToString();


            }
            else
            {
                MessageBox.Show("Please click View");


            }


        }

        private void lblCurrentDateTime_Click(object sender, EventArgs e)
        {




        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
