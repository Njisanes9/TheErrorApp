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
using System.Data.SqlClient;
using System.Runtime.InteropServices;


namespace TheErrorApp
{
    public partial class frmModuleTopic : Form
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
        public frmModuleTopic()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        static string connString = "Data Source=localHostInitial Catalog=ErrorAppDB;Integrated Security=True;";
        SqlConnection dbConn = new SqlConnection(connString);

        BusinessLogicLayer bll = new BusinessLogicLayer();
        DataAccessLayer dll = new DataAccessLayer();

        private void frmModuleTopic_Load(object sender, EventArgs e)
        {
            cmbModules.DataSource = bll.GetModule();
            cmbModules.DisplayMember = "ModuleDescription";
            cmbModules.ValueMember = "ModuleID";

            dgvModuleTopic.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cmbTopics.DataSource = bll.GetTopics();
            cmbTopics.DisplayMember = "TopicDescription";
            cmbTopics.ValueMember = "TopicID";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ModuleTopic moduleTopic = new ModuleTopic();
            moduleTopic.ModuleID = int.Parse(cmbModules.SelectedValue.ToString());
            moduleTopic.TopicID = int.Parse(cmbTopics.SelectedValue.ToString());

            int x = bll.InsertModuleTopic(moduleTopic);
            if(x > 0)
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

        /*
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            ModuleTopic moduleTopic = new ModuleTopic();
            moduleTopic.ModuleID = int.Parse(cmbModules.SelectedValue.ToString());
            moduleTopic.TopicID = int.Parse(cmbTopics.SelectedValue.ToString());

            int x = bll.UpdateModuleTopic(moduleTopic);
            if (x > 0)
            {
                MessageBox.Show(x + " Updated");
            }
            else
            {
                MessageBox.Show(x + " Updated");
            }

        
        }
        */
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ModuleTopic moduleTopic = new ModuleTopic();
            moduleTopic.ModuleTopicID = int.Parse(dgvModuleTopic.SelectedRows[0].Cells["ModuleTopicID"].Value.ToString());

            int x = bll.DeleteModuleTopic(moduleTopic);

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
        DataTable dt = new DataTable();
        int StudentID;
        public void Refresh()
        {
            dgvModuleTopic.DataSource = bll.GetLecturerModuleTopic();
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt = frmLogin.dtInfo;
            StudentID = int.Parse(dt.Rows[0]["UserID"].ToString());
            Refresh();

            pnlNav.Height = btnView.Height;
            pnlNav.Top = btnView.Top;
            pnlNav.Left = btnView.Left;
            btnView.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {


            ModuleTopic moduleTopic = new ModuleTopic();
            moduleTopic.ModuleID = int.Parse(cmbModules.SelectedValue.ToString());
            moduleTopic.TopicID = int.Parse(cmbTopics.SelectedValue.ToString());
            moduleTopic.ModuleTopicID = int.Parse(dgvModuleTopic.SelectedRows[0].Cells["ModuleTopicID"].Value.ToString());
                
            int x = bll.UpdateModuleTopic(moduleTopic);
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

        private void btnX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvModuleTopic_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvModuleTopic_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
